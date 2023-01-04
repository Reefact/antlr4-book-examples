#### 9.3.1. Récupération en Recherchant les Jetons Suivants

Lorsque l'analyseur est confronté à une entrée vraiment abîmée, la règle actuelle ne peut pas continuer, donc l'analyseur récupère en avalant des tokens jusqu'à ce qu'il pense avoir resynchronisé et retourne à la règle appelante. On peut appeler cela la stratégie "sync-and-return". Certains l'appellent "mode panique", mais elle fonctionne remarquablement bien. L'analyseur sait qu'il ne peut pas faire correspondre l'entrée actuelle avec la règle actuelle. Il ne peut jeter des jetons que jusqu'à ce que le [lookahead](https://fr.javascript.info/regexp-lookahead-lookbehind) soit cohérent avec quelque chose qui devrait correspondre après la sortie de l'analyseur de la règle. Par exemple, s'il y a une erreur de syntaxe dans une instruction d'affectation, il est très logique de rejeter les jetons jusqu'à ce que l'analyseur voit un point-virgule ou un autre terminateur d'instruction. Drastique, mais efficace. Comme nous le verrons, ANTLR essaie de récupérer dans la règle avant de se rabattre sur cette stratégie de base.

Chaque méthode de règle générée par ANTLR est enveloppée dans un try-catch qui répond aux erreurs de syntaxe en signalant l'erreur et en essayant de récupérer avant de retourner.

```csharp
try {
    ...
} catch(RecognitionException re) {
    ErrorHandler.ReportError(this, re);
    ErrorHandler.Recover(this, re);
}
```

Nous examinerons la stratégie de gestion des erreurs plus en détail au chapitre [9.5. Modifier la stratégie de gestion des erreurs d'ANTLR](../../5/ReadMe.md), mais, pour l'instant, nous pouvons résumer la méthode `ErrorHandler.Recover()` comme consommant des jetons jusqu'à ce qu'il en trouve un dans l'_ensemble de resynchronisation_.
L'ensemble de resynchronisation est l'union des _ensembles de suivi_ des références de règles pour toutes les règles de la pile d'invocation. L'ensemble de suivi d'une référence de règle est l'ensemble des jetons qui peuvent correspondre immédiatement après cette référence et sans quitter la règle actuelle. Ainsi, par exemple, étant donné l'alternative `assign` ';', l'ensemble suivant pour la référence de règle `assign` est {';'}.

Il est utile de passer par un exemple pour verrouiller ce que contiennent les ensembles de resynchronisation. Considérons la grammaire suivante, et imaginons qu'à chaque invocation de règle, l'analyseur syntaxique suive l'ensemble suivant pour chaque invocation de règle:

https://github.com/Reefact/antlr4-book-examples/blob/12664a0d317a3cebb9667926e4c8c85f06ac7eb7/Reefact.BookExamples.Antlr4/Chapter_09/3/1/.antlr/F.g4?plain=1#L1-L13

```bat
antlr4 F.g4 -Dlanguage=CSharp
```

Considérons l'arbre d'analyse à gauche pour l'entrée \[1^2\] dans le diagramme suivant :

| Good syntax: \[1^2\] | Bad syntax: \[\] |
| ----------- | ---------- |
| <img src=".resources/good_syntax.svg" alt="Good Syntax Tree" width="300px"/> | <img src=".resources/bad_syntax.svg" alt="Bad Syntax Tree" width="300px"/> |

En faisant correspondre le token 1 à la règle `atom`, la pile d'appels est \[`group`, `expr`, `atom`\] (`group` a appelé `expr`, qui a appelé `atom`). En regardant la pile d'appels, nous connaissons précisément l'ensemble des tokens qui peuvent suivre chaque règle que l'analyseur a appelée pour nous amener à la position actuelle. Les ensembles qui suivent ne prennent en compte que les tokens de la règle actuelle, de sorte qu'au moment de l'exécution, nous pouvons combiner uniquement les ensembles associés à la pile d'appels actuelle. En d'autres termes, nous ne pouvons pas atteindre la règle `expr` à partir des deux alternatives de groupe en même temps.


En combinant les ensembles suivants tirés des commentaires de la grammaire F, nous obtenons un ensemble de resynchronisation de {'^', '\]'}. Pour voir pourquoi c'est l'ensemble que nous voulons, observons ce qui se passe lorsque l'analyseur rencontre une entrée erronée \[\]. Nous obtenons l'arbre d'analyse syntaxique montré à droite dans le diagramme côte à côte précédent. Dans `atom`, l'analyseur découvre que le token actuel, \], n'est pas compatible avec l'une ou l'autre des alternatives de `atom`. Pour resynchroniser, l'analyseur consomme des jetons jusqu'à ce qu'il trouve un jeton de l'ensemble de resynchronisation. Dans ce cas, le jeton courant ] commence comme un membre de l'ensemble de resynchronisation, donc l'analyseur syntaxique ne consomme pas réellement de jetons pour resynchroniser dans `atom`.

Après avoir terminé le processus de récupération dans la règle `atom`, l'analyseur syntaxique retourne à la règle `expr` mais découvre immédiatement qu'il n'a pas le token ^. Le processus se répète, et l'analyseur consomme des jetons jusqu'à ce qu'il trouve quelque chose dans l'ensemble de resynchronisation de la règle `expr`. L'ensemble de resynchronisation pour `expr` est l'ensemble suivant pour la référence `expr` dans la première alternative de `group` : { ']' }. Encore une fois, l'analyseur syntaxique ne consomme rien et quitte `expr`, retournant à la première alternative de la règle `group`. Maintenant, l'analyseur syntaxique trouve exactement ce qu'il cherche à la suite de la référence à `expr`. Il correspond avec succès au ']' dans le groupe, et l'analyseur syntaxique est maintenant correctement resynchronisé.

Pendant la récupération, les analyseurs ANTLR évitent d'émettre des messages d'erreur en cascade (une idée empruntée à Grosch). C'est-à-dire que les analyseurs syntaxiques émettent un seul message d'erreur pour chaque erreur de syntaxe jusqu'à ce qu'ils réussissent à récupérer de cette erreur. Grâce à l'utilisation d'une simple variable booléenne, définie en cas d'erreur de syntaxe, l'analyseur syntaxique évite d'émettre d'autres erreurs jusqu'à ce qu'il réussisse à faire correspondre un token et à réinitialiser la variable. (Voir le champ `errorRecoveryMode` dans la classe `DefaultErrorStrategy`).

| FOLLOW Sets vs. Following Sets |
| --- |
| Ceux qui sont familiers avec la théorie du langage se demanderont si l'ensemble de resynchronisation pour la règle `atom` est simplement _FOLLOW(`atom`)_, l'ensemble de tous les tokens viables qui peuvent suivre les références à `atom` dans un certain contexte. Ce n'est malheureusement pas si simple, et les ensembles de resynchronisation doivent être calculés dynamiquement pour obtenir l'ensemble des tokens qui peuvent suivre la règle dans un contexte particulier plutôt que dans tous les contextes. _FOLLOW(`expr`)_ c'est { ')', ']' }, qui inclut tous les tokens qui peuvent suivre les références à `expr` dans les deux contextes (alternatives 1 et 2 de `group`). Cependant, il est clair qu'au moment de l'exécution, l'analyseur syntaxique ne peut appeler `expr` qu'à partir d'un seul emplacement à la fois. Notez que _FOLLOW(`atom`)_ est '^', et si l'analyseur syntaxique se resynchronise sur ce token au lieu de l'ensemble de resynchronisation { '^', ']' }, il consommerait jusqu'à la fin du fichier car il n'y a pas de '^' sur le flux d'entrée. |

Dans de nombreux cas, ANTLR peut récupérer plus intelligemment que de consommer jusqu'à l'ensemble de resynchronisation et de revenir de la règle actuelle. Il est payant d'essayer de "réparer" l'entrée et de continuer dans la même règle. Au cours des prochaines sections, nous examinerons comment l'analyseur syntaxique récupère les tokens mal assortis et les erreurs dans les sous-règles.

[Chapitre suivant: 9.3.2. Récupération à partir de jetons non concordants](../2)
