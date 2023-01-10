#### 9.3.3. Récupération d'Erreurs Dans les Sous-Règles

Il y a quelques années, le groupe JavaFX de Sun m'a contacté parce que leur parseur généré via ANTLRgenerated ne se rétablissait pas bien dans certains cas. Il s'est avéré que l'analyseur syntaxique sortait des boucles de sous-règles comme `member+` au premier signe de problème, forçant la récupération sync-and-return pour la règle englobante. Une petite erreur dans une déclaration de membre comme `var width Number ;` (il manque un deux-points après `width`) forcerait l'analyseur à sauter tous les membres restants.

Jim Idle, un contributeur à la liste de diffusion ANTLR et consultant, a mis au point ce que j'appelle la récupération d'erreur "Jim Idle's magic sync". Sa solution était d'insérer manuellement des références à une règle vide dans la grammaire qui contenait une action spéciale qui déclenchait la récupération d'erreur lorsque nécessaire. ANTLR v4 insère maintenant automatiquement des vérifications de synchronisation au début et à la suite du test de la boucle pour éviter une telle récupération drastique. Le mécanisme ressemble à ceci :

- _Début de sous-règle_:  Au début de toute sous-règle, les analyseurs syntaxiques tentent la suppression d'un seul token.
simple. Mais, contrairement aux correspondances de tokens, les analyseurs syntaxiques ne tentent pas l'insertion de tokens uniques. ANTLR aurait du mal à faire apparaître un token car il devrait deviner laquelle de plusieurs alternatives serait finalement réussie.
- _Test de continuation de sous-règle en boucle_:  Si la sous-règle est une construction en boucle, `(..)*` ou `(.)+`, l'analyseur syntaxique essaie de récupérer agressivement l'erreur pour rester dans la boucle. Après avoir réussi à faire correspondre une alternative de la boucle, l'analyseur consomme jusqu'à ce qu'il trouve un token cohérent avec l'un de ces ensembles :
	(a) Une autre itération de la boucle
	(b) Ce qui suit la boucle
	(c) L'ensemble de resynchronisation du courant 
	
Examinons d'abord la suppression d'un seul jeton devant une sous-règle. Considérons la construction `membre+` en boucle dans la règle `classDef` de la grammaire Simple. Si nous bégayons et tapons un `(` supplémentaire, la sous-règle `member+` supprimera le token supplémentaire avant de passer à `member`, comme le montre l'arbre d'analyse suivant :

https://github.com/Reefact/antlr4-book-examples/blob/b73a4316662e27068ee68dade49459fe0d11d4c4/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.cs#L17-L28
```mermaid
﻿graph TD
	1["prog"] --> 2["classDef"]
	2 --> 3["class"]
	2 --> 4["T"]
	2 --> 5["{"]
	2 --> 6["{"]:::error
	2 --> 7["member"]
	7 --> 8["int"]
	7 --> 9["i"]
	7 --> 10[";"]
	2 --> 11["}"]

classDef default fill:#fff,stroke:#000,stroke-width:0.25px;
classDef error color:#fff,fill:#FF0000,stroke:#000,stroke-width:0.25px;
```

La session suivante confirme la récupération correcte car elle identifie correctement la variable `i` :

https://github.com/Reefact/antlr4-book-examples/blob/b73a4316662e27068ee68dade49459fe0d11d4c4/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.cs#L30-L39
https://github.com/Reefact/antlr4-book-examples/blob/b73a4316662e27068ee68dade49459fe0d11d4c4/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.single_token_deletion_output.approved.txt#L1-L3

Maintenant, essayons de passer une entrée vraiment désordonnée et voyons si la boucle `membre+` peut se rétablir et continuer à chercher des membres.

https://github.com/Reefact/antlr4-book-examples/blob/1827f94ab4ed8ac1c39b47712c79314b8cc1f08c/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.cs#L41-L50
https://github.com/Reefact/antlr4-book-examples/blob/1827f94ab4ed8ac1c39b47712c79314b8cc1f08c/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.messed_up_input_output.approved.txt#L1-L5

Nous savons que l'analyseur syntaxique s'est resynchronisé et est resté à l'intérieur de la boucle parce qu'il a identifié la variable `z`. L'analyseur syntaxique gobble `y;;;` jusqu'à ce qu'il voie le début d'un autre membre (voir ensemble (c) plus ci-avant), puis revient à `member`. Si l'entrée ne comprenait pas `int z;`, le parser aurait gobé jusqu'à ce qu'il ait vu '}' (voir ensemble (b) ci-avant) et sortirait de la boucle. L'arbre d'analyse met en évidence les tokens supprimés et montre que le parser interprète toujours `int z;` comme un membre valide.

https://github.com/Reefact/antlr4-book-examples/blob/1827f94ab4ed8ac1c39b47712c79314b8cc1f08c/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.cs#L52-L61
```mermaid
graph TD
	1["prog"] --> 2["classDef"]
	2 --> 3["class"]
	2 --> 4["T"]
	2 --> 5["{"]
	2 --> 6["{"]:::error
	2 --> 7["member"]
	7 --> 8["int"]
	7 --> 9["x"]
	7 --> 10[";"]
	2 --> 11["y"]:::error
	2 --> 12[";"]:::error
	2 --> 13[";"]:::error
	2 --> 14[";"]:::error
	2 --> 15["member"]
	15 --> 16["int"]
	15 --> 17["z"]
	15 --> 18[";"]
	2 --> 19["}"]

classDef default fill:#fff,stroke:#000,stroke-width:0.25px;
classDef error color:#fff,fill:#FF0000,stroke:#000,stroke-width:0.25px;
```

Si l'utilisateur fournit un membre de règle avec une mauvaise syntaxe et oublie également le `}` de fermeture d'une classe, nous ne voudrions pas que l'analyseur syntaxique balaye jusqu'à ce qu'il trouve `}`. La resynchronisation du parser pourrait jeter toute la définition de la classe suivante à la recherche de `}`. Au lieu de cela, l'analyseur syntaxique arrête de gober s'il voit un token dans l'ensemble (c), comme le montre la session suivante :

https://github.com/Reefact/antlr4-book-examples/blob/daf442c8ef8a38389a999a4b2f5f0690abb2defc/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.cs#L63-L72
https://github.com/Reefact/antlr4-book-examples/blob/daf442c8ef8a38389a999a4b2f5f0690abb2defc/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.resynchronisation_set_of_the_current_output.approved.txt#L1-L5

L'analyseur syntaxique arrête la resynchronisation lorsqu'il voit le mot-clé `class`, comme on peut le voir dans l'arbre d'analyse.

https://github.com/Reefact/antlr4-book-examples/blob/daf442c8ef8a38389a999a4b2f5f0690abb2defc/Reefact.BookExamples.Antlr4/Chapter_09/3/3/Examples.cs#L74-L83
```mermaid
graph TD
	1["prog"] --> 2["classDef"]
	2 --> 3["class"]
	2 --> 4["T"]
	2 --> 5["{"]
	2 --> 6["member"]
	6 --> 7["int"]
	6 --> 8["x"]
	6 --> 9[";"]
	2 --> 10[";"]:::error
	2 --> 11["#0060;missing '}'#0062;"]:::error
	1 --> 12["classDef"]
	12 --> 13["class"]
	12 --> 14["U"]
	12 --> 15["{"]
	12 --> 16["member"]
	16 --> 17["int"]
	16 --> 18["y"]
	16 --> 19[";"]
	12 --> 20["}"]

classDef default fill:#fff,stroke:#000,stroke-width:0.25px;
classDef error color:#fff,fill:#FF0000,stroke:#000,stroke-width:0.25px;
```

Outre la reconnaissance des tokens et des sous-règles, les analyseurs syntaxiques peuvent également échouer dans la reconnaissance des prédicats sémantiques.

⏭ Chapitre suivant: [9.3.4. Rattraper les Prédicats Sémantiques Ratés](../4)