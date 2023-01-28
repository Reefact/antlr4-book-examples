#### 10.1.1. Utiliser des Actions en Dehors des Règles de Grammaire

En dehors des règles de grammaire, il y a deux types de choses que nous voulons injecter dans les parsers et les lexers générés : les déclarations de `using`/`namespace` et les membres de classe comme les champs et les méthodes.

Voici un modèle idéalisé de génération de code qui illustre l'endroit où nous voulons injecter des extraits de code pour, par exemple, l'analyseur syntaxique :

```
<header>
public class <grammarName>Parser: Parser {
  <members>
  ...
}
```

Pour spécifier une action d'en-tête, nous utilisons `@header {...}` dans notre grammaire. Pour injecter des champs ou des méthodes dans le code généré, nous utilisons `@members {...}`. Dans une grammaire combinée parser/lexer, ces actions nommées s'appliquent à la fois au parser et au lexer. (L'option ANTLR `-package` nous permet de définir le paquetage sans action d'en-tête). Pour restreindre une action au parser ou au lexer généré, nous utilisons `@parser::name` ou `@lexer::name`.

Voyons à quoi cela ressemble pour notre calculatrice. La grammaire d'expression commence par une déclaration de grammaire comme précédemment, mais nous allons maintenant déclarer que le code généré se trouve dans un namespace spécifique. Nous devrons également importer certaines classes utilitaires du SDK .Net.

https://github.com/Reefact/antlr4-book-examples/blob/a1d19b92ce1b759e3a2beef1f99b472746ddb9dc/Reefact.BookExamples.Antlr4/Chapter_10/1/1/.antlr/ActionExpr.g4#L3-L5

_Note: Contrairement au livre, qui présente les exemples en Java, il n'est pas nécessaire ici d'ajouter un `using` - en référence au `import java.util.*;` dans le livre) - car [le générateur de parser et lexer de ANTLR en C#](https://github.com/antlr/antlr4/blob/49b69bb31aa34654676a864b229a369680122470/tool/resources/org/antlr/v4/tool/templates/codegen/CSharp/CSharp.stg#L34-L53) inclus les namespace `System`, `System.IO`, `System.Text`, `System.Diagnostics` et `System.Collections.Generic`. Si nous avions besoin d'inclure un namespace, il suffirait d'ajouter le `using` nécessaire dans le header._

La classe `EvalVisitor` de la calculatrice précédente avait un champ de mémoire qui stockait les paires nom-valeur pour implémenter les affectations et les références de variables. Nous allons mettre cela dans l'action de nos membres. Pour réduire l'encombrement de la grammaire, définissons également une méthode pratique appelée `eval()` qui effectue une opération sur deux opérandes. Voici à quoi ressemble l'action `members` complète :

https://github.com/Reefact/antlr4-book-examples/blob/a1d19b92ce1b759e3a2beef1f99b472746ddb9dc/Reefact.BookExamples.Antlr4/Chapter_10/1/1/.antlr/ActionExpr.g4#L7-L20

Avec cette infrastructure en place, voyons comment utiliser ces membres de la classe de l'analyseur syntaxique dans les actions parmi les éléments de la règle.

⏭ Chapitre suivant: [10.1.2. Intégrer des Actions dans les Règles](../2)
