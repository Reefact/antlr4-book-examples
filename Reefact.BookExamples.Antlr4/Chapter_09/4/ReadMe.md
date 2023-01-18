### 9.4. Alternatives aux erreurs

Certaines erreurs de syntaxe sont si courantes qu'il vaut la peine de les traiter spécialement. Par exemple, les programmeurs ont souvent le mauvais nombre de parenthèses à la fin d'un appel de fonction avec des arguments imbriqués. Pour traiter spécialement ces cas, il suffit d'ajouter des alternatives pour correspondre à la syntaxe erronée mais courante. La grammaire suivante reconnaît les appels de fonction avec un seul argument, éventuellement avec des parenthèses imbriquées dans l'argument. La règle `fcall` a deux alternatives dites d'erreur.

https://github.com/Reefact/antlr4-book-examples/blob/5daa690a893ffa62f485cca6e912ef6a38962f0b/Reefact.BookExamples.Antlr4/Chapter_09/4/.antlr/Call.g4#L1-L13

Bien que ces alternatives d'erreur puissent rendre le travail d'un parser généré par ANTLR un peu plus difficile pour choisir entre les alternatives, elles ne confondent en aucun cas l'analyseur. Comme toute autre alternative, l'analyseur syntaxique les fait correspondre si elles sont cohérentes avec l'entrée actuelle. Par exemple, essayons quelques séquences d'entrée qui correspondent aux alternatives d'erreur, en commençant par un appel de fonction valide.

```bat
antlr4 Call.g4 -Dlanguage=CSharp -no-listener
```
https://github.com/Reefact/antlr4-book-examples/blob/5daa690a893ffa62f485cca6e912ef6a38962f0b/Reefact.BookExamples.Antlr4/Chapter_09/4/Examples.cs#L19-L28

Continuons avec un exemple dans lequel une parenthèse fermante est manquante:

https://github.com/Reefact/antlr4-book-examples/blob/5daa690a893ffa62f485cca6e912ef6a38962f0b/Reefact.BookExamples.Antlr4/Chapter_09/4/Examples.cs#L30-L39
https://github.com/Reefact/antlr4-book-examples/blob/5daa690a893ffa62f485cca6e912ef6a38962f0b/Reefact.BookExamples.Antlr4/Chapter_09/4/Examples.missing_closure.approved.txt#L1-L2

Et enfin, terminons par un exemple dans lequel un parenthèse fermante est surnuméraire:

https://github.com/Reefact/antlr4-book-examples/blob/5daa690a893ffa62f485cca6e912ef6a38962f0b/Reefact.BookExamples.Antlr4/Chapter_09/4/Examples.cs#L41-L50
https://github.com/Reefact/antlr4-book-examples/blob/5daa690a893ffa62f485cca6e912ef6a38962f0b/Reefact.BookExamples.Antlr4/Chapter_09/4/Examples.too_much_parentheses.approved.txt#L1-L2

À ce stade, nous avons appris beaucoup de choses sur les messages d'erreur que les parsers ANTLR peuvent générer et aussi sur la façon dont les parseurs récupèrent les erreurs dans de nombreuses situations différentes. Nous avons également vu comment personnaliser les messages d'erreur et les rediriger vers différents récepteurs d'erreurs. Toute cette fonctionnalité est contrôlée et encapsulée dans un objet qui spécifie la stratégie de gestion des erreurs d'ANTLR. Dans la section suivante, nous examinerons cette stratégie en détail pour en savoir plus sur la personnalisation de la façon dont les analyseurs syntaxiques répondent aux erreurs.

⏭ Chapitre suivant: [9.5. Modification de la stratégie de gestion des erreurs d'ANTLR](../../5)
