#### 10.1.3. Construire une Calculatrice Interactive

```bat
antlr4 ActioExpr.g4 -no-listener -Dlanguage=CSharp
```

Afin de tester notre grammaire nous utiliserons les exemples suivants:

https://github.com/Reefact/antlr4-book-examples/blob/d5851beb38f8f1cee4fef4f703c09e4ccfebd82f/Reefact.BookExamples.Antlr4/Chapter_10/1/3/Examples.cs#L18-L74

Comme vous pouvez le voir nous nous passons de l'habituel `GRUN` et allons créer notre calculateur `Calc` personnalisé qui prend en paramètre une chaîne de caractères.

https://github.com/Reefact/antlr4-book-examples/blob/a34ee7644aee642061c748062c58eb7938b72f98/Reefact.BookExamples.Antlr4/Chapter_10/1/3/Calc.cs#L15-L20

Pour maintenir les valeurs des champs de mémoire entre les expressions, nous avons besoin d'un seul analyseur partagé pour toutes les lignes d'entrée.

https://github.com/Reefact/antlr4-book-examples/blob/a34ee7644aee642061c748062c58eb7938b72f98/Reefact.BookExamples.Antlr4/Chapter_10/1/3/Calc.cs#L21-L22

Lorsque nous lisons une ligne, nous créons un nouveau flux de tokens et le transmettons au parser partagé.

https://github.com/Reefact/antlr4-book-examples/blob/a34ee7644aee642061c748062c58eb7938b72f98/Reefact.BookExamples.Antlr4/Chapter_10/1/3/Calc.cs#L23-L34

Nous savons maintenant comment construire un outil interactif et nous avons une assez bonne idée de la manière de placer et d'utiliser les actions intégrées. Notre calculatrice a utilisé une action `header` pour spécifier un namespace et une action `members` pour définir deux membres de la classe de l'analyseur syntaxique. Nous avons utilisé des actions dans les règles pour calculer et renvoyer les valeurs des sous-expressions en tant que fonction des attributs des tokens et des règles. Dans la prochaine section, nous verrons d'autres attributs et identifierons d'autres emplacements d'actions.

⏭ Chapitre suivant: [10.2. Accès aux Attributs de Règles et de Tokens](../2)
