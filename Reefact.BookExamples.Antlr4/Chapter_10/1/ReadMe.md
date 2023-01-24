### 10.1. Construire une Calculatrice avec des Actions Grammaticales

Reprenons la grammaire d'expression du chapitre [4.2. Construire une Calculatrice à l'Aide d'un Visiteur](../../Chapter_04/2) pour en savoir plus sur les actions. Dans ce chapitre, nous avons construit une calculatrice à l'aide d'un visiteur d'arbre syntaxique qui évalue des expressions telles que celles -ci :

```lisp
x = 1
x + 2 * 3
```

Notre objectif ici est de reproduire cette même fonctionnalité, mais sans utiliser de visiteur et sans même construire un arbre d'analyse. De plus, nous utiliserons une petite astuce pour rendre l'opération interactive, c'est-à-dire que nous obtiendrons des résultats lorsque nous appuierons sur _Return_, et non à la fin de l'entrée. Nos exemples jusqu'à présent ont absorbé la totalité de l'entrée et ont ensuite traité les arbres d'analyse résultants.

Dans ce chapitre, nous allons apprendre à placer les analyseurs syntaxiques générés par dans des packages, à définir les champs et les méthodes des analyseurs syntaxiques, à insérer des actions dans les alternatives de règles, à étiqueter les éléments de grammaire à utiliser dans les actions et à définir les valeurs de retour des règles.

// to be continued...
