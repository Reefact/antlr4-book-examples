#### 9.3.5. Récupération d'Erreur "Fail-Safe"

Les analyseurs ANTLR ont une sécurité intégrée pour garantir la fin de la récupération des erreurs. Si nous atteignons le même emplacement de parser et avons la même position d'entrée, le parser force une consommation de jeton avant de tenter la récupération. Revenons à la grammaire simple `Simple` du début de ce chapitre et examinons un exemple d'entrée qui déclenche le dispositif de sécurité. Si nous ajoutons un token `int` supplémentaire dans une définition de champ, l'analyseur syntaxique détecte une erreur et tente de la récupérer. Comme nous le verrons dans le prochain test, l'analyseur syntaxique appelle `recover()` et essaie de relancer l'analyse plusieurs fois avant de se resynchroniser correctement (Figure 9, _Resynchronisation de l'analyseur syntaxique_).

L'arbre d'analyse syntaxique de droite dans le diagramme de la Figure 10, _Arbres d'analyse syntaxique pour la bonne et la mauvaise syntaxe_, montre qu'il y a trois invocations de `member` de `classDef`.

https://github.com/Reefact/antlr4-book-examples/blob/a85936a9001fcac11b3e81239125568c1a489ae2/Reefact.BookExamples.Antlr4/Chapter_09/3/5/.resources/extra_int.simple#L1-L3
https://github.com/Reefact/antlr4-book-examples/blob/a85936a9001fcac11b3e81239125568c1a489ae2/Reefact.BookExamples.Antlr4/Chapter_09/3/5/Examples.cs#L19-L28
https://github.com/Reefact/antlr4-book-examples/blob/a85936a9001fcac11b3e81239125568c1a489ae2/Reefact.BookExamples.Antlr4/Chapter_09/3/5/Examples.extra_int_output.approved.txt#L1-L3

// to be continued
