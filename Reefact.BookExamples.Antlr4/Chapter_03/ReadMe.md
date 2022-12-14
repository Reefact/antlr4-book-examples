## 3. Un Projet ANTLR Pour Démarrer 

Pour notre premier projet, construisons une grammaire pour un petit sous-ensemble de C ou un de ses dérivés comme Java. En particulier, reconnaissons les entiers dans des accolades, éventuellement imbriquées, comme {1, 2, 3} et {1, {2, 3}, 4}. Ces constructions pourraient être des initialisateurs de tableaux `int` ou de `struct`. Une grammaire pour cette syntaxe serait utile dans de nombreuses situations. Par exemple, nous pourrions l'utiliser pour construire un outil de refactoring de code source en C qui convertirait les tableaux d'entiers en tableaux d'octets si toutes les valeurs initialisées tenaient dans un octet. Nous pourrions également utiliser cette grammaire pour convertir des initialisation de tableaux de `short` Java en chaînes de caractères. Par exemple, nous pourrions transformer ce qui suit :

```java
static short[] data = {1,2,3};
```

en la chaîne équivalente suivante avec des constantes Unicode :

```java
static String data = "\u0001\u0002\u0003" ; // Les caractères Java sont des shorts non signés.
```

où les spécificateurs de caractères Unicode, tels que \u0001, utilisent quatre chiffres hexadécimaux représentant une valeur de caractère de 16 bits, c'est-à-dire un short.

La raison pour laquelle nous pouvons vouloir effectuer cette traduction est de surmonter une limitation du format de fichier de classe Java. Un fichier de classe Java stocke les initialisateurs de tableau sous la forme d'une séquence d'initialisateurs d'éléments de tableau explicites, équivalant à `data[0]=1 ; data[1]=2 ; data[2]=3 ;`, au lieu d'un bloc compact d'octets packagés. Comme Java limite la taille des méthodes d'initialisation, il limite la taille des tableaux que nous pouvons initialiser. En revanche, un fichier de classe Java stocke une chaîne de caractères sous la forme d'une séquence contiguë de shorts. La conversion des initialisateurs de tableaux en chaînes de caractères permet d'obtenir un fichier de classe plus compact et d'éviter la limite de taille des méthodes d'initialisation de Java.
En travaillant sur cet exemple de démarrage, vous apprendrez un peu de la syntaxe de la grammaire ANTLR, ce qu'ANTLR génère à partir d'une grammaire, comment incorporer le parser généré dans une application Java, et comment construire un traducteur avec un listener d'arbre d'analyse.

### [3.1. L'outil ANTLR, le Moteur d'Exécution et le Code Généré](1)
### [3.2. Test du parser généré](2)
### [3.3. Intégration d'un parser généré dans un programme en C#](3)
### [3.4. Création d'une application linguistique](4)
