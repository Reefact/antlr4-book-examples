#### 10.1.2. Intégrer des Actions dans les Règles

Dans cette section, nous allons apprendre comment intégrer des actions dans la grammaire afin de générer une sortie, mettre à jour les structures de données et définir les valeurs de retour des règles. Nous verrons également comment ANTLR intègre les paramètres des règles, les valeurs de retour et d'autres attributs d'une invocation de règle dans des instances de sous-classes de `ParserRuleContext`.

##### L'essentiel

La règle `stat` reconnaît les expressions, les affectations de variables et les lignes vides. Comme nous ne faisons rien sur une ligne blanche, `stat` n'a besoin que de deux actions.

https://github.com/Reefact/antlr4-book-examples/blob/a1d19b92ce1b759e3a2beef1f99b472746ddb9dc/Reefact.BookExamples.Antlr4/Chapter_10/1/1/.antlr/ActionExpr.g4#L24-L27

Les actions s'exécutent après l'élément grammatical précédent et avant le suivant. Dans ce cas, les actions apparaissent à la fin des alternatives, donc elles s'exécutent après que l'analyseur syntaxique ait fait correspondre la déclaration entière. Lorsque `stat` voit une expression suivie de `NEWLINE`, il doit imprimer la valeur de l'expression. Lorsque `stat` voit une affectation de variable, il doit stocker la paire nom-valeur dans la mémoire de champ.

Les seules syntaxes peu familières dans ces actions sont `$expr.v` et `$ID.text`. En général, `$x.y` fait référence à l'attribut y de l'élément `x`, où `x` est soit une référence à un jeton, soit une référence à une règle. Ici, `$expr.v` se réfère à la valeur de retour de l'appel de la règle `e`. (Nous verrons pourquoi il est appelé `v` dans une seconde) `$ID.text` se réfère au texte correspondant à la référence `ID`.

Si ANTLR ne reconnaît pas la composante `y`, il ne la traduit pas. Dans ce cas, le texte est un attribut connu d'un token, et ANTLR le traduit par `getText()`. Nous pourrions également utiliser `$ID.getText()` pour obtenir la même chose. Pour une liste complète des attributs des règles et des jetons, voir le chapitre [15.4. Actions et Attributs].

Passons maintenant à la règle `expr`, et voyons à quoi elle ressemble avec des actions intégrées. L'idée de base est d'imiter la fonctionnalité `EvalVisitor` en insérant des extraits de code directement dans la grammaire sous forme d'actions.

https://github.com/Reefact/antlr4-book-examples/blob/a1d19b92ce1b759e3a2beef1f99b472746ddb9dc/Reefact.BookExamples.Antlr4/Chapter_10/1/1/.antlr/ActionExpr.g4#L29-L38

Un certain nombre de choses intéressantes se passent dans cet exemple. La première chose que nous voyons est la spécification de la valeur de retour pour un entier, `v`. C'est pourquoi les actions de `stat` se réfèrent à `$expr.v`. Les valeurs de retour ANTLR diffèrent des valeurs de retour C# en ce sens que nous pouvons les nommer et que nous pouvons en avoir plusieurs.

Ensuite, nous voyons des étiquettes sur les références de règles et sur les sous-règles d'opérateur telles que `op=('*'|'/')`. Les étiquettes font référence aux objets `Token` ou `ParserRuleContext` dérivés de la correspondance d'un token ou de l'invocation d'une règle.

Avant de passer au contenu de l'action, il est utile de regarder où ANTLR stocke des choses comme les valeurs de retour et les étiquettes. Cela facilitera le suivi du code généré par ANTLR lors du débogage au niveau de la source.

##### Un seul objet de contexte de règle pour les lier tous

Dans le chapitre [2.4. Construire des Applications Linguistiques à l'Aide d'Arbres d'Analyse], nous avons appris que ANTLR implémente les noeuds d'arbres d'analyse avec des objets de contexte de règle. Chaque invocation de règle crée et renvoie un objet de contexte de règle, qui contient toutes les informations importantes sur la reconnaissance d'une règle à un emplacement spécifique dans le flux d'entrée. Par exemple, la règle `expr` crée et renvoie des objets `ExprContext`.

```CSharp
public ExprContext expr(...) { ... }
```

Naturellement, un objet de contexte de règle est un endroit très pratique pour placer des entités spécifiques aux règles. La première partie de l'`ExprContext` ressemble à ceci :

```CSharp
public partial class ExprContext : ParserRuleContext {
		public int v; // rule e return value from "returns [int v]"
		public ExprContext a; // label a on (recursive) rule reference to e
		public IToken _INT; // reference to INT matched by 3rd alternative
		public IToken _ID; // reference to ID matched by 4th alternative
		public ExprContext _expr; // reference to context object from e invocation
		public IToken op; // label on operator sub rules like ('*'|'/')
		public ExprContext b; // label b on (recursive) rule reference to e
...
}
 ```

Les étiquettes deviennent toujours des champs dans l'objet contexte de la règle, mais ANTLR ne génère pas toujours des champs pour les éléments alternatifs tels que `ID`, `INT` et `expr`. ANTLR génère des champs pour eux seulement s'ils sont référencés par des actions dans la grammaire (comme le font les actions de `expr`). ANTLR essaie de réduire le nombre de champs d'objets de contexte.

Maintenant que nous avons toutes les pièces en place, analysons le contenu des actions parmi les alternatives de la règle `expr`.

##### Calcul des valeurs de retour

Toutes les actions de `expr` finissent la valeur de retour avec l'affectation `$v = ... ;`. Cela définit la valeur de retour mais n'effectue pas de retour de la fonction de règle. (N'utilisez pas d'instruction de retour dans vos actions car cela rendra l'analyseur syntaxique fou). Voici l'action utilisée par les deux premières alternatives :

```csharp
$v = eval($a.v, $op.type, $b.v);
```

Cette action calcule la valeur de la sous-expression et définit la valeur de retour de `expr`. Les arguments de `eval()` sont les valeurs de retour des deux références à `expr`, `$a.v` et `$b.v`, et le type de jeton de l'opérateur correspondant à l'alternative, `$op.type`. `$op.type` sera toujours le type de jeton de l'un des opérateurs arithmétiques. Remarquez que nous pouvons réutiliser les étiquettes (tant qu'elles font référence au même type de chose). La seconde alternative réutilise les étiquettes `a`, `b`, et `op`.

L'action de la troisième alternative utilise `$INT.int` pour accéder à la valeur entière du texte correspondant au jeton `INT`. Il s'agit simplement d'un raccourci pour `int.Parse($INT.text)`. L'action intégrée est beaucoup plus simple que la méthode équivalente du visitor `VisitInt()` (mais au prix de l'enchevêtrement du code spécifique à l'application avec la grammaire).

https://github.com/Reefact/antlr4-book-examples/blob/ebebe7702a5ca2a49a5fe37cddf65643721ddac3/Reefact.BookExamples.Antlr4/Chapter_04/2/EvalVisitor.cs#L35-L40

La quatrième alternative reconnaît une référence de variable et définit la valeur de retour de `expr` à la valeur stockée en mémoire, si nous avons stocké une valeur pour ce nom. Cette action utilise l'opérateur C# `?:`, mais nous aurions pu tout aussi bien utiliser une instruction C# if-then-else. Nous pouvons mettre n'importe quoi dans une action qui fonctionnerait comme le corps d'une méthode C#.

Enfin, l'action `$v = $e.v ;` dans la dernière alternative fixe la valeur de retour au résultat de l'expression correspondante entre parenthèses. Nous ne faisons que passer la valeur de retour. La valeur de `(3)` est 3.

C'est tout pour la grammaire et le code d'action. Maintenant, voyons comment construire un pilote interactif pour notre calculatrice.

⏭ Chapitre suivant: [10.1.3. Construire une Calculatrice Interactive](../3)
