### 3.3. Intégration d'un analyseur généré dans un programme en C#

Une fois que nous avons un bon départ sur une grammaire, nous pouvons intégrer le code généré par ANTLR dans une application plus large. Dans cette section, nous allons examiner comment le GRun qui invoque notre analyseur fonctionne et imprime l'arbre d'analyse comme l'option `-tree` de TestRig.

https://github.com/Reefact/antlr4-book-examples/blob/8bc2724d11e63488b3b8fe51485f57d8b0d8258c/Reefact.BookExamples.Antlr4/Chapter_03/2/GRun.cs#L14-L22
https://github.com/Reefact/antlr4-book-examples/blob/8bc2724d11e63488b3b8fe51485f57d8b0d8258c/Reefact.BookExamples.Antlr4/.core/GRunBase.cs#L45
https://github.com/Reefact/antlr4-book-examples/blob/8bc2724d11e63488b3b8fe51485f57d8b0d8258c/Reefact.BookExamples.Antlr4/.core/GRunBase.cs#L59

Le programme utilise un certain nombre de classes comme `CommonTokenStream` et `ParseTree` de la bibliothèque d'exécution d'ANTLR dont nous apprendrons davantage à partir du chapitre [4.1. Matching an Arithmetic Expression Language](../../Chapter_04/1).
