### 3.3. Intégration d'un analyseur généré dans un programme en C#

Une fois que nous avons un bon départ sur une grammaire, nous pouvons intégrer le code généré par ANTLR dans une application plus large. Dans cette section, nous allons examiner comment le GRun qui invoque notre analyseur fonctionne et imprime l'arbre d'analyse comme l'option `-tree` de TestRig.

xxxxxx

Le programme utilise un certain nombre de classes comme `CommonTokenStream` et `ParseTree` de la bibliothèque d'exécution d'ANTLR dont nous apprendrons davantage à partir du chapitre [4.1. Matching an Arithmetic Expression Language](../../Chapter_04/1).
