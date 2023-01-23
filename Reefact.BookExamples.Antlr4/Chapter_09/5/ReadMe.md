### 9.5 Modification de la Stratégie de Gestion des Erreurs d'ANTLR

Le mécanisme de gestion des erreurs par défaut fonctionne très bien, mais il existe quelques situations atypiques dans lesquelles nous pouvons souhaiter le modifier. Tout d'abord, nous pourrions vouloir désactiver une partie de la gestion des erreurs en ligne en raison de sa surcharge d'exécution. Deuxièmement, nous pourrions vouloir abandonner l'analyseur syntaxique à la première erreur de syntaxe. Par exemple, lors de l'analyse d'une ligne de commande pour un shell comme bash, il est inutile d'essayer de récupérer les erreurs. Nous ne pouvons pas risquer d'exécuter cette commande de toute façon, donc l'analyseur syntaxique peut s'arrêter au premier signe de problème.

Pour explorer la stratégie de gestion des erreurs, examinez l'interface `ANTLRErrorStrategy` et sa mise en oeuvre concrète, la classe `DefaultErrorStrategy`. Cette classe contient tout ce qui est associé au comportement de traitement des erreurs par défaut. Les analyseurs ANTLR signalent cet objet pour signaler les erreurs et récupérer. Par exemple, voici le bloc `catch` à l'intérieur de chaque fonction de règle générée par ANTLR :

```csharp
_errHandler.ReportError(this, re) ;
_errHandler.Recover(this, re) ;
```

`_errHandler` est une variable contenant une référence à une instance de `DefaultErrorStrategy`. Les méthodes `reportError()` et `recover()` incarnent la fonctionnalité de signalement d'erreur et de retour de synchronisation. `reportError()` délègue le signalement d'erreur à l'une des trois méthodes, en fonction du type d'exception levée.

Pour en revenir à notre première situation atypique, diminuons la charge d'exécution que la gestion des erreurs impose à l'analyseur syntaxique. Regardez ce code que ANTLR génère pour la sous-règle `membre+` dans la grammaire `Simple` :

https://github.com/Reefact/antlr4-book-examples/blob/bebfcab8f5ac42dbd61c43a78ad522e740b226a9/Reefact.BookExamples.Antlr4/Chapter_09/1/.antlr/SimpleParser.cs#L190-L202

Pour les applications où l'on peut supposer sans risque que l'entrée est syntaxiquement correcte, comme les protocoles réseau, nous pourrions tout aussi bien éviter les coûts génériques de détection et de récupération des erreurs dans les sous-règles. Pour ce faire, nous pouvons sous-classer `DefaultErrorStrategy` et remplacer `sync()` par une méthode vide. Le compilateur Java devrait alors mettre en ligne et éliminer les appels `_errHandler.sync(this)`. Nous verrons comment notifier l'analyseur syntaxique d'utiliser une stratégie d'erreur différente dans l'exemple suivant.

L'autre situation atypique est l'abandon de l'analyseur syntaxique à la première erreur de syntaxe. Pour que cela fonctionne, nous devons surcharger trois méthodes de récupération de clés, comme le montre le code suivant :

https://github.com/Reefact/antlr4-book-examples/blob/154d5614032bdfd830d6cb843fecc0bf839eadc0/Reefact.BookExamples.Antlr4/Chapter_09/5/BailErrorStrategy.cs#L9-L34

_Remarque: Pour notre exemple nous allons utiliser cette version du `BailErrorStrategy` mais cette classe est déjà implémentée par la librairie core d'ANTLR dans le namespace `Antlr4.Runtime`._

Pour un banc d'essai, nous pouvons réutiliser notre code standard. En plus de la création et du lancement du parseur, nous devons créer une nouvelle instance de `BailErrorStrategy` et indiquer à l'analyseur syntaxique de l'utiliser à la place de la stratégie par défaut.

https://github.com/Reefact/antlr4-book-examples/blob/a4be1335acc6508241164a44d1bf9f7296eefe77/Reefact.BookExamples.Antlr4/Chapter_09/5/GRun.cs#L20

Pendant que nous y sommes, nous devrions également nous en sortir à la première erreur lexicale. Pour ce faire, nous devons surcharger la méthode `recover()` dans le Lexer.

https://github.com/Reefact/antlr4-book-examples/blob/a4be1335acc6508241164a44d1bf9f7296eefe77/Reefact.BookExamples.Antlr4/Chapter_09/5/BailSimpleLexer.cs#L22-L24

Essayons d'abord une erreur lexicale en insérant un caractère farfelu `#` au début de l'entrée. Le lexer lève une exception qui fait exploser le flux de contrôle jusqu'au programme principal.

https://github.com/Reefact/antlr4-book-examples/blob/4f63052d85e5d93479856ea421177ddd35765987/Reefact.BookExamples.Antlr4/Chapter_09/5/Examples.cs#L18-L27

L'analyseur syntaxique s'arrête également à la première erreur de syntaxe (un nom de classe manquant, dans ce cas).

https://github.com/Reefact/antlr4-book-examples/blob/0dfe6691fb7d15caeebaaf33baf4d24e2deccf79/Reefact.BookExamples.Antlr4/Chapter_09/5/Examples.cs#L30-L37

Pour démontrer la flexibilité de l'interface `ANTLRErrorStrategy`, terminons en modifiant la façon dont l'analyseur syntaxique signale les erreurs. Pour modifier le message standard, "aucune alternative viable à l'entrée X", nous pouvons surcharger `reportNoViableAlternative()` et changer le message en quelque chose de différent.

https://github.com/Reefact/antlr4-book-examples/blob/33d7324d6b8a51d6907764c4fd84f20bb2629318/Reefact.BookExamples.Antlr4/Chapter_09/5/MyErrorStrategy.cs#L9-L20
https://github.com/Reefact/antlr4-book-examples/blob/33d7324d6b8a51d6907764c4fd84f20bb2629318/Reefact.BookExamples.Antlr4/Chapter_09/5/Examples.cs#L42-L52
https://github.com/Reefact/antlr4-book-examples/blob/33d7324d6b8a51d6907764c4fd84f20bb2629318/Reefact.BookExamples.Antlr4/Chapter_09/5/Examples.custom_error_message.approved.txt#L1-L2

Rappelez-vous, cependant, que si tout ce que nous voulons faire est de changer où sont redirigé les messages d'erreur, nous pouvons spécifier un `ANTLRErrorListener` comme nous l'avons fait au chapitre [9.2. Modifier et Rediriger les Messages d'Erreur ANTLR](../2). Pour apprendre comment remplacer complètement la façon dont ANTLR génère le code pour attraper les exceptions, voir [15.3.6. Catching Exceptions](../../15.3.6).

Nous avons couvert toutes les éléments importants de gestion de rapport d'erreur et de récupération dans ANTLR. Grâce aux interfaces `ANTLRErrorListener` et `ANTLRErrorStategy`, nous avons une grande flexibilité sur l'endroit où les messages d'erreur sont redirigés, ce que sont ces messages, et comment l'analyseur syntaxique récupère les erreurs.

Dans le prochain chapitre, nous allons apprendre à intégrer des extraits de code appelés `actions` directement dans la grammaire.

⏭ Chapitre suivant: [10. Attributs et Actions](../../Chapter_10)
