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

À titre d'exemple, créons un listener d'erreurs qui imprime la ligne avec le token incriminé souligné, comme dans l'exemple d'exécution suivant :

https://github.com/Reefact/antlr4-book-examples/blob/f34dea9f11ae05bf516f6f03f6c1791c7b60bbe5/Reefact.BookExamples.Antlr4/Chapter_09/2/Examples.cs#L31-L40
https://github.com/Reefact/antlr4-book-examples/blob/f34dea9f11ae05bf516f6f03f6c1791c7b60bbe5/Reefact.BookExamples.Antlr4/Chapter_09/2/Examples.underline_listener.approved.txt#L1-L7

Pour faciliter les choses, nous ne tiendrons pas compte des tabulations--CharPositionInLine n'est pas le numéro de colonne, car la taille des tabulations n'est pas universellement définie. Voici une implémentation d'un listener d'erreur qui souligne les emplacements d'erreur dans l'entrée comme nous venons de le voir :

https://github.com/Reefact/antlr4-book-examples/blob/f34dea9f11ae05bf516f6f03f6c1791c7b60bbe5/Reefact.BookExamples.Antlr4/Chapter_09/2/UnderlineListener.cs#L11-L45

Il y a une dernière chose à savoir sur les listeners d'erreurs. Lorsque le parser détecte une séquence d'entrée ambiguë, il en informe le listener d'erreurs. Le listener d'erreur par défaut, `ConsoleErrorListener`, n'affiche cependant rien dans la console. Comme nous l'avons vu dans le chapitre [2.3. On ne Peut Pas Mettre Trop d'Eau Dans un Réacteur Nucléaire](../../Chapter_02/3), une entrée ambiguë indique probablement une erreur dans notre grammaire ; l'analyseur syntaxique ne devrait pas en informer nos utilisateurs. Revenons à la grammaire ambiguë de cette section qui peut correspondre à l'entrée `f();` de deux manières différentes.

https://github.com/Reefact/antlr4-book-examples/blob/844b13c657df92d62b6bc54ae7ceb8082588319c/Reefact.BookExamples.Antlr4/Chapter_09/2/.antlr/Ambig.g4#L1-L13
```bat
antlr4 Ambig.g4 -Dlanguage=CSharp
```
https://github.com/Reefact/antlr4-book-examples/blob/844b13c657df92d62b6bc54ae7ceb8082588319c/Reefact.BookExamples.Antlr4/Chapter_09/2/AmbiguousGRun.cs#L14-L55

Si nous testons la grammaire, nous ne voyons pas d'avertissement pour l'entrée ambiguë.

https://github.com/Reefact/antlr4-book-examples/blob/844b13c657df92d62b6bc54ae7ceb8082588319c/Reefact.BookExamples.Antlr4/Chapter_09/2/Examples.cs#L42-L51

Pour savoir que le parser détecte une ambiguïté, vous devez indiquer au parser d'utiliser une instance de `DiagnosticErrorListener` en utilisant `AddErrorListener()`. Vous devez également informer l'analyseur syntaxique que vous êtes intéressé par tous les avertissements d'ambiguïté, et pas seulement par ceux qu'il peut détecter rapidement. Dans un souci d'efficacité, le mécanisme de décision d'ANTLR ne recherche pas toujours toutes les informations d'ambiguïté. 

https://github.com/Reefact/antlr4-book-examples/blob/c323948a443193aab5fb47c26128b3481e8352af/Reefact.BookExamples.Antlr4/Chapter_09/2/Examples.cs#L53-L72
https://github.com/Reefact/antlr4-book-examples/blob/c323948a443193aab5fb47c26128b3481e8352af/Reefact.BookExamples.Antlr4/Chapter_09/2/Examples.ambiguity_detected.approved.txt#L1-L4

La sortie montre que l'analyseur syntaxique appelle également `ReportAttemptingFullContext()`. ANTLR appelle cette méthode lorsque l'analyse syntaxique `SLL(*)` échoue et que l'analyseur syntaxique engage le mécanisme plus puissant de full `ALL(*)`. Voir chapitre [13.7. Maximiser la Vitesse de l'Analyseur Syntaxique](../../Chapter_13/7).

C'est une bonne idée d'utiliser l'écouteur d'erreurs de diagnostic pendant le développement car l'outil ANTLR ne peut pas vous avertir des constructions grammaticales ambiguës de manière statique (lors de la génération des parsers). Seul le parseur peut détecter les ambiguïtés dans ANTLR v4. C'est la différence entre le typage statique en Java, disons, et le typage dynamique en Python.

// to be continued...
