### 9.3. Stratégie de Récupération Automatique des Erreurs

La récupération des erreurs est ce qui permet à l'analyseur syntaxique de continuer après avoir trouvé une erreur de syntaxe. En principe, la meilleure récupération d'erreurs viendrait de la touche humaine dans un analyseur récursif-descendant écrit à la main. Dans mon expérience, cependant, il est vraiment difficile d'obtenir une bonne récupération d'erreur à la main parce qu'il est si fastidieux et facile de se tromper. Dans cette dernière version d'ANTLR, j'ai incorporé chaque morceau de jujitsu que j'ai appris et ramassé au cours des années pour fournir une bonne récupération d'erreur automatiquement pour les grammaires ANTLR.

Le mécanisme de récupération d'erreur d'ANTLR est basé sur les premières idées de Niklaus Wirth dans _Algorithms + Data Structures = Programs_ \[Wir78\] (ainsi que sur l'article de Rodney Topor intitulé _A Note on Error Recovery in Recursive Descent Parsers_ (Top82), mais aussi sur les bonnes idées de Josef Grosch pour son générateur d'analyseur CoCo (_Efficient and Comfortable Error Recovery in Recursive Descent Parsers_ [Gro90]).

#### [9.3.1. Récupération en Recherchant les Jetons Suivants](1)
#### [9.3.2. Recovering from Mismatched Tokens](2)
#### [9.3.3. Recovering from Errors in Subrules](3)
#### [9.3.4. Catching Failed Semantic Predicates](4)
#### [9.3.5. Error Recovery Fail-Safe](5)
