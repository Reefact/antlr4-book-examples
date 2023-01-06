### 3.3. Intégration d'un analyseur généré dans un programme en C#

Une fois que nous avons un bon départ sur une grammaire, nous pouvons intégrer le code généré par ANTLR dans une application plus large. Dans cette section, nous allons examiner comment le GRun qui invoque notre analyseur fonctionne et imprime l'arbre d'analyse comme l'option `-tree` de TestRig.

__TODO: indiquer que nous redéveloppons nous-même ici une méthode ToListStyleTree simplifiée par rapport au GRunBase__

https://github.com/Reefact/antlr4-book-examples/blob/e04dbec8e6c30357ee9f0ac28aad1916d3753d40/Reefact.BookExamples.Antlr4/Chapter_03/3/GRun.cs#L10-L51

Le programme utilise un certain nombre de classes comme `CommonTokenStream` et `ParseTree` de la bibliothèque d'exécution d'ANTLR dont nous apprendrons davantage à partir du chapitre [4.1. Matching an Arithmetic Expression Language](../../Chapter_04/1).

Le code de test suivant montre le résultat de l'appel à notre GRun:

https://github.com/Reefact/antlr4-book-examples/blob/e04dbec8e6c30357ee9f0ac28aad1916d3753d40/Reefact.BookExamples.Antlr4/Chapter_03/3/Examples.cs#L19-L28

Les analyseurs ANTLR signalent et corrigent aussi automatiquement les erreurs de syntaxe. Par exemple, voici ce qui se passe si nous entrons un initialisateur auquel il manque l'accolade finale :

https://github.com/Reefact/antlr4-book-examples/blob/e04dbec8e6c30357ee9f0ac28aad1916d3753d40/Reefact.BookExamples.Antlr4/Chapter_03/3/Examples.cs#L30-L39
https://github.com/Reefact/antlr4-book-examples/blob/d866cfec1f2d0806d8a50064b01255ad3fc193ed/Reefact.BookExamples.Antlr4/Chapter_03/3/Examples.to_lisp_style_tree_with_missing_brace.approved.txt#L1-L2

__TODO: indiquer que nous utilisons ci-dessus le GRunBase__

À ce stade, nous avons vu comment exécuter ANTLR sur une grammaire et intégrer le parser généré dans une application .Net triviale. Une application qui se contente de vérifier la syntaxe n'est pas très impressionnante, alors finissons par construire un traducteur qui convertit les initialisateurs de tableaux de `short` en objets `string`.

⏭ Chapitre suivant: [3.4. Création d'une application linguistique](../4)
