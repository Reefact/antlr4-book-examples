### 10.2. Accès aux Attributs de Règles et de Tokens

Utilisons la grammaire CSV du chapitre [6.1. Analyse des valeurs séparées par des virgules](../../Chapter_06/1), comme base pour explorer d'autres fonctionnalités liées aux actions. Nous allons construire une application qui crée une correspondance entre le nom de la colonne et le champ pour chaque ligne et qui imprime les informations obtenues lors de l'analyse des données. Notre objectif est de mieux connaître les actions et les attributs liés aux règles.

Tout d'abord, voyons comment définir des variables locales à l'aide de la section locals. Comme pour les paramètres et les valeurs de retour, les déclarations dans une section `locals` deviennent des champs dans l'objet de contexte de règle. Puisque nous obtenons un nouvel objet de contexte de règle pour chaque invocation de règle, nous obtenons une nouvelle copie des `locals` comme nous nous y attendions. La version augmentée suivante du fichier de règles fait un certain nombre de choses intéressantes, mais commençons par nous concentrer sur ce qu'elle fait avec les sections locales.

// CSV.g4

Le fichier de règles définit une variable locale, `i`, et l'utilise pour compter combien de lignes il y a dans l'entrée en utilisant l'action `$i++ ;`. Pour référencer les variables locales, n'oubliez pas le préfixe du caractère `$`, ou le compilateur se plaindra de variables non définies. ANTLR traduit `$i` en `_localctx.i ;` il n'y a pas de variable locale `i` dans la fonction de règle générée pour le fichier.

Ensuite, examinons l'appel à la règle `row`. L'invocation de règle `row[$hdr.text.split(",")]` illustre le fait que nous utilisons des crochets au lieu de parenthèses pour passer des paramètres aux règles (ANTLR utilise des parenthèses pour la syntaxe des sous-règles). L'expression d'argument `$hdr.text.split(",")` divise le texte correspondant à l'invocation de la règle `hdr` pour obtenir un tableau de chaînes de caractères nécessaires à `row`.

Décomposons cela. `$hdr` est une référence à la seule invocation hdr et évalue son objet `HdrContext`. Nous n'avons pas besoin d'étiqueter la référence `hdr` dans ce cas (comme `h=hdr`) car `$hdr` est unique. `$hdr.text` est donc le texte correspondant à la ligne d'en-tête. Nous scindons les colonnes d'en-tête séparées par des virgules à l'aide de la méthode C# `string.split()` standard, qui renvoie un tableau de chaînes de caractères. Nous verrons bientôt que rule `row` prend un paramètre array-of-string.

L'appel à `row` introduit également un nouveau type d'étiquette qui utilise `+=` à la place de la balise `=` opérateur d'étiquetage. Plutôt que de suivre une valeur unique, label `rows` est une liste de tous les objets `RowContext` renvoyés par toutes les invocations de `row`. Après avoir imprimé le nombre de lignes, l'action finale du fichier comporte une boucle qui itère à travers les objets `RowContext`. À chaque fois que la boucle est parcourue, elle imprime la plage d'index de token correspondant à l'invocation de rangée (en utilisant `getSourceInterval()`).

Cette boucle utilise `r`, et non `$r`, car `r` est une variable locale créée dans une action C#. ANTLR ne peut voir que les variables locales définies avec le mot-clé `locals`, pas dans les actions intégrées arbitraires définies par l'utilisateur. La différence est que le noeud de l'arbre d'analyse pour le fichier de règles définirait le champ `i` mais pas `r`.

En ce qui concerne la règle `hdr`, nous allons simplement imprimer la ligne d'en-tête. Nous pouvons le faire en faisant référence à `$row.text`, qui est le texte correspondant à la référence de la règle de la ligne. Alternativement, nous pouvons demander le texte de la règle environnante avec `$text`.

// CSV.g4

Dans ce cas, il s'agira également du texte correspondant à la ligne, car c'est tout ce qu'il y a dans cette règle.

Voyons maintenant comment convertir chaque ligne de données en une carte du nom de la colonne à la valeur avec les actions de la règle `row`. Pour commencer, `row` prend le tableau des noms de colonnes comme paramètre et renvoie la carte. Ensuite, pour se déplacer dans le tableau des noms de colonnes, nous avons besoin d'une variable locale, `col`. Avant d'analyser la règle, nous devons initialiser la carte des valeurs de retour et, pour le plaisir, nous allons imprimer la carte après la fin de la règle. la carte après la fin de la ligne. Tout cela va dans l'en-tête de la règle.

// CSV.g4

L'action `init` se produit avant que la règle ne corresponde à quoi que ce soit, quel que soit le nombre d'alternatives. De même, l'action `after` se produit après que la règle ait trouvé une correspondance avec l'une des alternatives. Dans ce cas, nous pouvons exprimer la fonctionnalité de l'action après en plaçant l'instruction `print` dans une action à la fin de l'alternative extérieure de `row`.

Une fois tout mis en place, nous pouvons collecter les données et remplir la carte.

// CSV.g4

Les parties charnues des actions stockent la valeur du champ au nom de la colonne dans la carte des valeurs en utilisant $values.put(...) . Le premier paramètre récupère le nom de la colonne, incrémente le nombre de colonnes et supprime les espaces du nom : `$columns[$col++].trim()`. Le second paramètre permet d'ajuster le texte du dernier champ correspondant : `$field.text.trim()`. (Les deux actions en ligne sont identiques, il peut donc être judicieux de factoriser cela en une méthode dans une action membre).

Tout le reste dans CSV.g4 nous est familier, alors passons à la construction de cette chose et à son essai. Nous n'avons pas besoin d'écrire un banc d'essai spécial grâce à grun, donc nous pouvons simplement générer le parseur et le compiler.

```bat
antlr4 -no-listener CSV.g4 -Dlanguage=CSharp
```

Voici des données CSV que nous pouvons utiliser :

// utilisateurs.csv

Et, voici le résultat :

// grun

La règle `hdr` imprime la première ligne de sortie, et les trois appels à `row` impriment les `values = ...` lignes. De retour dans le fichier de règles, l'action imprime le nombre de lignes et les intervalles de token associés à chaque ligne de données.

À ce stade, nous avons une très bonne maîtrise de l'utilisation des actions intégrées, à l'intérieur et à l'extérieur des règles. Nous connaissons également assez bien les attributs des règles. D'un autre côté, les exemples de la calculatrice et du CSV utilisent tous deux actions exclusivement dans les règles de l'analyseur. Il s'avère que les actions peuvent être très utiles dans les règles de lexer également. Nous allons maintenant explorer ce sujet en voyant comment gérer un ensemble important ou dynamique de mots-clés.

⏭ Chapitre suivant: [10.3 Reconnaître les Langues Dont les Mots-Clés Ne Sont Pas Fixes](../3)
