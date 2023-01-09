### 9.3. Stratégie de Récupération Automatique des Erreurs

La récupération des erreurs est ce qui permet à l'analyseur syntaxique de continuer après avoir trouvé une erreur de syntaxe. En principe, la meilleure récupération d'erreurs viendrait de la touche humaine dans un analyseur récursif-descendant écrit à la main. Dans mon expérience, cependant, il est vraiment difficile d'obtenir une bonne récupération d'erreur à la main parce qu'il est si fastidieux et facile de se tromper. Dans cette dernière version d'ANTLR, j'ai incorporé chaque morceau de jujitsu que j'ai appris et ramassé au cours des années pour fournir une bonne récupération d'erreur automatiquement pour les grammaires ANTLR.

Le mécanisme de récupération d'erreur d'ANTLR est basé sur les premières idées de Niklaus Wirth dans _Algorithms + Data Structures = Programs_ [Wir78](https://github.com/Reefact/antlr4-book-examples/blob/30450a07adbce355410fe56f4b246858e34a9f26/Reefact.BookExamples.Antlr4/Bibliography.md?plain=1#L9) (ainsi que sur l'article de Rodney Topor intitulé _A Note on Error Recovery in Recursive Descent Parsers_ [Top82](https://github.com/Reefact/antlr4-book-examples/blob/30450a07adbce355410fe56f4b246858e34a9f26/Reefact.BookExamples.Antlr4/Bibliography.md?plain=1#L8)), mais aussi sur les bonnes idées de Josef Grosch pour son générateur d'analyseur CoCo (_Efficient and Comfortable Error Recovery in Recursive Descent Parsers_ [Gro90](https://github.com/Reefact/antlr4-book-examples/blob/30450a07adbce355410fe56f4b246858e34a9f26/Reefact.BookExamples.Antlr4/Bibliography.md?plain=1#L6)).

En un mot, Voici comment ANTLR utilise ces idées: les analyseurs syntaxiques effectuent l'insertion d'un seul token et la suppression d'un seul token en cas d'erreurs de tokens mal assortis si possible. Si ce n'est pas le cas, les parseurs avalent les tokens jusqu'à ce qu'ils trouvent un token qui pourrait raisonnablement suivre la règle actuelle, puis retournent, continuant comme si rien ne s'était passé. Dans ce chapitre, nous allons voir ce que ces termes signifient et explorer comment ANTLR récupère les erreurs dans diverses situations. Commençons par la stratégie fondamentale de récupération qu'utilise ANTLR.

#### [9.3.1. Récupération en Recherchant les Jetons Suivants](1)
#### [9.3.2. Récupération à Partir de Jetons Non Concordants](2)
#### [9.3.3. Récupération d'Erreurs Dans les Sous-Règles](3)
#### [9.3.4. Catching Failed Semantic Predicates](4)
#### [9.3.5. Error Recovery Fail-Safe](5)
