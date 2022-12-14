#### 9.3.2. Récupération à Partir de Jetons Non Concordants

L'une des opérations les plus courantes lors de l'analyse syntaxique est "match token". Pour chaque référence de token, `T`, dans la grammaire, l'analyseur syntaxique invoque `match(T)`. Si le token actuel n'est pas `T`, `match()` notifie les listeners d'erreur et tente de se resynchroniser. Pour se resynchroniser, il a trois choix. Il peut soit supprimer un jeton, soit il peut en faire apparaître un, soit il peut lancer une exception pour engager le mécanisme de synchronisation et de retour de base.

La suppression du jeton actuel est le moyen le plus simple de resynchroniser, si cela a un sens. Revoyons la règle `classDef` de notre langage de définition de classe dans la grammaire `Simple`.

https://github.com/Reefact/antlr4-book-examples/blob/50f1e91c0c7061d62119799b4e2e867f3e4f0999/Reefact.BookExamples.Antlr4/Chapter_09/1/.antlr/Simple.g4#L10-L12

Étant donné la classe d'entrée `9 T { int i ; }`, l'analyseur syntaxique supprimera 9 et continuera dans la règle pour correspondre au corps de la classe. L'image suivante illustre l'état de l'entrée après que l'analyseur syntaxique ait consommé la classe :

```mermaid
graph LR
    A[class] -->|lookahead 1|B[9]:::lookahead
    B --> |lookahead 2|C[T]:::lookahead

classDef default stroke:#000,fill:#aaa
classDef lookahead fill:#eee,stroke:#000
```

Les étiquettes `LA(1)` et `LA(2)` marquent le premier token de lookahead (le token actuel) et le second token de lookahead. Le `match(ID)` s'attend à ce que `LA(1)` soit un `ID`, mais ce n'est pas le cas. Cependant, le jeton suivant, `LA(2)`, est en fait un `ID`. Pour récupérer, il suffit de supprimer le jeton actuel (en tant que bruit), de consommer l'`ID` que nous attendions, et de quitter `match()`.

Le code suivant nous montre comment cette entrée est considérée par le parser:

https://github.com/Reefact/antlr4-book-examples/blob/eebe6d24e42572c7c85786beee0ad3ca4234fe24/Reefact.BookExamples.Antlr4/Chapter_09/3/2/Examples.cs#L19-L39
https://github.com/Reefact/antlr4-book-examples/blob/eebe6d24e42572c7c85786beee0ad3ca4234fe24/Reefact.BookExamples.Antlr4/Chapter_09/3/2/Examples.extraneous_input_9_lisp_style_tree.approved.txt#L1-L2
```mermaid
graph TD
	1["prog"] --> 2["classDef"]
	2 --> 3["class"]
	2 --> 4["9"]:::error
	2 --> 5["T"]
	2 --> 6["{"]
	2 --> 7["member"]
	7 --> 8["int"]
	7 --> 9["i"]
	7 --> 10[";"]
	2 --> 11["}"]

classDef default fill:#fff,stroke:#000,stroke-width:0.25px;
classDef error color:#fff,fill:#FF0000,stroke:#000,stroke-width:0.25px;
```

Si le parser ne peut pas se resynchroniser en supprimant un jeton, il tente d'insérer un jeton à la place. Disons que nous avons oublié l'`ID` pour que `classDef` voie l'entrée `class { int i ; 3`. Après avoir fait correspondre la classe, l'état de l'entrée ressemble à ceci :

```mermaid
graph LR
    A[class] -->|lookahead 1|B["#123;"]:::lookahead

classDef default stroke:#000,fill:#aaa
classDef lookahead fill:#eee,stroke:#000
```

Le parseur invoque `match(ID)` mais au lieu d'un identifiant, il trouve `1`. Dans cette situation, le parseur sait que le `{` est ce dont il aura besoin ensuite puisque c'est ce qui suit la référence `ID` dans `classDef`. Pour resynchroniser, le `match()` peut prétendre voir l'identifiant et revenir, permettant ainsi à l'appel `match('{')` suivant de réussir.

Cela fonctionne très bien si nous ignorons les actions intégrées, comme l'instruction `print` qui fait référence à l'identificateur de nom de classe. L'instruction `print` fait référence au jeton manquant via `$ID.text` et provoquera une exception si le jeton est nul. Plutôt que de simplement prétendre que le jeton existe, le gestionnaire d'erreur en crée un : voir `getMissingSymbol()` dans `DefaultErrorStrategy`. Le symbole conjuré a le type de symbole attendu par le parser et prend les informations de position de ligne et de caractère du symbole d'entrée actuel, `LA(1)`. Ce jeton conjuré empêche également les exceptions dans les listeners et les visiteurs qui font référence au jeton manquant.

La façon la plus simple de voir ce qui se passe est de regarder l'arbre syntaxique, qui montre comment le parser reconnaît tous les tokens. En cas d'erreur, l'arbre syntaxique met en évidence en rouge les tokens que le parser supprime ou fait apparaître lors de la resynchronisation. Pour la classe d'entrée `{ int i ; }` et la grammaire `Simple`, nous obtenons l'arbre syntaxique suivant :

https://github.com/Reefact/antlr4-book-examples/blob/420291564d29b566ee5029243a887b4209f4dbed/Reefact.BookExamples.Antlr4/Chapter_09/3/2/Examples.cs#L52-L61
```mermaid
graph TD
	1["prog"] --> 2["classDef"]
	2 --> 3["class"]
	2 --> 4["#0060;missing ID#0062;"]:::error
	2 --> 5["{"]
	2 --> 6["member"]
	6 --> 7["int"]
	6 --> 8["i"]
	6 --> 9[";"]
	2 --> 10["}"]

classDef default fill:#fff,stroke:#000,stroke-width:0.25px;
classDef error color:#fff,fill:#FF0000,stroke:#000,stroke-width:0.25px;
```

L'analyseur syntaxique exécute également les actions d'impression intégrées sans lever d'exception puisque la récupération d'erreur fait apparaître un objet `Token` valide pour `$ID`.

https://github.com/Reefact/antlr4-book-examples/blob/420291564d29b566ee5029243a887b4209f4dbed/Reefact.BookExamples.Antlr4/Chapter_09/3/2/Examples.cs#L41-L50
https://github.com/Reefact/antlr4-book-examples/blob/eac5a04249841438830890cfe32cff86c29df786/Reefact.BookExamples.Antlr4/Chapter_09/3/2/Examples.missing_ID_output.approved.txt#L1-L3

Naturellement, un identifiant avec le texte `<missing ID>` n'est pas vraiment utile pour le but que nous essayons d'accomplir, mais au moins la récupération d'erreur n'induit pas un tas d'exceptions de pointeur nul.

Maintenant que nous savons comment ANTLR fait la récupération _intra-règle_ pour les références simples de tokens, explorons comment il récupère les erreurs avant et pendant la reconnaissance des sous-règles.

⏭ Chapitre suivant: [9.3.3. Récupération d'Erreurs Dans les Sous-Règles](../3)
