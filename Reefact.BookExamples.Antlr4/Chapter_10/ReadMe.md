## 10. Attributs et Actions

Jusqu'à présent, nous avons isolé notre code spécifique à l'application aux tree-walker d'analyse, ce qui signifie que notre code a toujours été exécuté une fois l'analyse terminée. Comme nous le verrons dans les prochains chapitres, certaines applications linguistiques nécessitent l'exécution de code spécifique à l'application pendant l'analyse. Pour ce faire, nous devons être en mesure d'injecter des extraits de code, appelés _actions_, directement dans le code généré par ANTLR. Notre premier objectif est donc d'apprendre à intégrer des actions dans les parsers et les lexers et de déterminer ce que nous pouvons mettre dans ces actions.

Gardez à l'esprit qu'en général, il est préférable d'éviter de mêler grammaires et code spécifique à une application. Les grammaires sans actions sont plus faciles à lire, ne sont pas liées à un langage cible particulier et ne sont pas liées à une application spécifique. Néanmoins, les actions intégrées peuvent être utiles pour trois raisons.

- Simplicité : Il est parfois plus facile de se contenter de quelques actions et d'éviter de créer une arborescence de tree-listeners ou de visiteurs.
- Efficacité : Dans les applications critiques en termes de ressources, il se peut que nous ne voulions pas gaspiller le temps ou la mémoire nécessaires à la construction d'un arbre d'analyse.
- Analyse prédictive : Dans de rares cas, nous ne pouvons pas analyser correctement sans nous référer aux données collectées précédemment dans le flux d'entrée. Certaines grammaires doivent construire une table de symboles, puis reconnaître différemment les entrées futures, selon qu'un identifiant est, par exemple, un type ou une méthode. Nous étudierons ce point au chapitre [11. Modifier l'Analyse avec des Prédicats Sémantiques](../Chapter_11).

Les actions sont des morceaux de code arbitraires écrits dans la langue cible - la langue dans laquelle ANTLR génère le code (`-Dlanguage=#targetLanguage`) - et entourés de `{...}`. Nous pouvons faire ce que nous voulons dans ces actions tant qu'elles sont des déclarations valides en langue cible. Typiquement, les actions opèrent sur les attributs des tokens et des références de règles. Par exemple, nous pouvons demander le texte d'un token ou le texte correspondant à une règle entière.

En utilisant les données dérivées des références aux jetons et aux règles, nous pouvons imprimer des choses et effectuer des calculs arbitraires. Les règles autorisent également les paramètres et les valeurs de retour, ce qui permet de faire circuler les données entre les règles.

Nous allons apprendre les actions de la grammaire en explorant trois exemples. Premièrement, nous allons construire une calculatrice avec la même fonctionnalité que celle du chapitre [7.4. Étiquetage des Alternatives de Règles pour les Méthodes d'Evénements Précis](../Chapter_07/4). Deuxièmement, nous ajouterons des actions à la grammaire CSV (du chapitre [6.1. Analyser les Valeurs Séparées par des Virgules](../Chapter_06/1) pour explorer les attributs des règles et des jetons. Dans le troisième exemple, nous allons nous familiariser avec les actions dans les règles de lexer en construisant une grammaire pour un langage dont les mots-clés ne sont pas connus avant l'exécution.

Il est temps de mettre la main à la pâte, en commençant par la mise en oeuvre d'une calculatrice basée sur l'action.

### [10.1. Construire une Calculatrice avec des Actions Grammaticales](1)
### [10.2. Accès aux Attributs des Jetons et des Règles](2)
### [10.3. Reconnaître les Langues Dont les Mots-Clés Ne Sont Pas Fixes](3)
