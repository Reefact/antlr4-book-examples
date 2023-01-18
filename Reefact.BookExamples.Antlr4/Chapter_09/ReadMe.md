## 9. Reporting et Récupération des Erreurs

Au fur et à mesure que nous développons une grammaire, il y aura beaucoup d'erreurs à corriger, comme pour tout logiciel. L'analyseur syntaxique résultant ne reconnaîtra pas toutes les phrases valides tant que nous n'aurons pas terminé (et débogué) notre grammaire. En attendant, des messages d'erreur informatifs nous aident à repérer les problèmes de grammaire. Une fois que nous disposons d'une grammaire correcte, nous devons traiter les phrases non grammaticales saisies par les utilisateurs ou même les phrases non grammaticales générées par d'autres programmes qui ont mal tourné.

Dans les deux cas, la manière dont notre analyseur syntaxique réagit aux entrées non grammaticales est un facteur important de productivité. En d'autres termes, un analyseur syntaxique qui répond par "Eh ?" et s'arrête à la première erreur de syntaxe n'est pas très utile pour nous pendant le développement ou pour nos utilisateurs pendant le déploiement.

Les développeurs qui utilisent ANTLR bénéficient gratuitement d'une bonne fonction de reporting des erreurs et d'une stratégie sophistiquée de récupération des erreurs. ANTLR génère des analyseurs syntaxiques qui émettent automatiquement de riches messages d'erreur en cas d'erreur de syntaxe et qui réussissent à se resynchroniser la plupart du temps. Les analyseurs syntaxiques évitent même de générer plus d'un message d'erreur pour chaque erreur de syntaxe.

Dans ce chapitre, nous allons découvrir la stratégie de signalement et de récupération automatique des erreurs utilisée par les analyseurs syntaxiques générés par ANTLR. Nous verrons également comment modifier le mécanisme de traitement des erreurs par défaut pour répondre à des besoins atypiques et comment personnaliser les messages d'erreur pour un domaine d'application spécifique.

### [9.1. Une Parade aux Erreurs](1)
### [9.2. Modifier et Rediriger les Messages d'Erreur ANTLR](2)
### [9.3. Stratégie de Récupération Automatique des Erreurs](3)
### [9.4. Alternatives aux erreurs](4)
