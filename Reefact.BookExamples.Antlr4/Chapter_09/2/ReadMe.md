### 9.2. Modifier et Rediriger les Messages d'Erreur ANTLR

Par défaut, ANTLR envoie toutes les erreurs à l'erreur standard, mais nous pouvons changer la destination et le contenu en fournissant une implémentation de l'interface ANTLRErrorListener. L'interface possède une méthode `syntaxError()` qui s'applique à la fois aux lexers et aux parsers. La méthode `syntaxError()` reçoit toutes sortes d'informations sur l'emplacement de l'erreur ainsi que le message d'erreur. Elle reçoit également une référence à l'analyseur syntaxique, de sorte que nous pouvons l'interroger sur l'état de la reconnaissance.

Par exemple, voici un listener d'erreurs qui affiche la pile d'invocation de la règle, suivie du message d'erreur habituel et des informations sur le jeton incriminé :

https://github.com/Reefact/antlr4-book-examples/blob/d1cf073ad26ad1f1bd8d6ef1bcb9c7fe7adbe859/Reefact.BookExamples.Antlr4/Chapter_09/2/VerboseListener.cs#L11-L34

Avec cette définition, notre application peut facilement ajouter un listener d'erreurs à l'analyseur syntaxique avant d'invoquer la règle de démarrage.

https://github.com/Reefact/antlr4-book-examples/blob/6cff66b101232b6252c0aa327b826e41a53cd01d/Reefact.BookExamples.Antlr4/.core/GRunBase.cs#L39-L42

Juste avant d'ajouter notre listener d'erreurs, nous devons supprimer le listener d'erreurs standard de la console afin d'éviter de répéter les messages d'erreurs.

https://github.com/Reefact/antlr4-book-examples/blob/d1cf073ad26ad1f1bd8d6ef1bcb9c7fe7adbe859/Reefact.BookExamples.Antlr4/Chapter_09/2/SimpleGRun.cs#L12-L47

Voyons maintenant à quoi ressemblent les messages d'erreur pour une définition de classe contenant un nom de classe supplémentaire et un nom de champ manquant.

https://github.com/Reefact/antlr4-book-examples/blob/fa74ac779d96255099ffd8385699a884429974ea/Reefact.BookExamples.Antlr4/Chapter_09/2/Examples.cs#L20-L29
https://github.com/Reefact/antlr4-book-examples/blob/fa74ac779d96255099ffd8385699a884429974ea/Reefact.BookExamples.Antlr4/Chapter_09/2/Examples.verbose_listener.approved.txt#L1-L5

La pile `[prog, classDef]` indique que l'analyseur syntaxique se trouve dans la règle `classDef`, qui a été appelée par `prog`. Remarquez que les informations sur les jetons contiennent la position des caractères dans le flux d'entrée. Ceci est utile pour mettre en évidence les erreurs dans l'entrée comme le font les environnements de développement. Par exemple, le jeton `[@2,8:8='T',<9>,1:8]` indique qu'il s'agit du troisième jeton du flux de jetons (index 2 à partir de 0), qu'il est compris entre les caractères 8 et 8, qu'il a le type de jeton 9, qu'il se trouve sur la ligne 1 et qu'il est à la position de caractère 8 (en comptant à partir de 0 et en traitant les tabulations comme un seul caractère).

// TODO: to be continued...


_Remarks:_

_C# lexer and parser classes are generated with the following command line:_

```bat
antlr4 Ambig.g4 -Dlanguage=CSharp
```
