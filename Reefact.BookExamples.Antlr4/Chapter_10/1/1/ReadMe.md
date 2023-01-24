#### 10.1.1. Utiliser des Actions en Dehors des Règles de Grammaire

En dehors des règles de grammaire, il y a deux types de choses que nous voulons injecter dans les parsers et les lexers générés : les déclarations de `using`/`namespace` et les membres de classe comme les champs et les méthodes.

Voici un modèle idéalisé de génération de code qui illustre l'endroit où nous voulons injecter des extraits de code pour, par exemple, l'analyseur syntaxique :

```
<header>
public class <grammarName>Parser: Parser {
  <members>
  ...
}
```

Pour spécifier une action d'en-tête, nous utilisons `@header {...}` dans notre grammaire. Pour injecter des champs ou des méthodes dans le code généré, nous utilisons `@members {...}`. Dans une grammaire combinée parser/lexer, ces actions nommées s'appliquent à la fois au parser et au lexer. (L'option ANTLR `-package` nous permet de définir le paquetage sans action d'en-tête). Pour restreindre une action au parser ou au lexer généré, nous utilisons `@parser::name` ou `@lexer::name`.

Voyons à quoi cela ressemble pour notre calculatrice. La grammaire d'expression commence par une déclaration de grammaire comme précédemment, mais nous allons maintenant déclarer que le code généré se trouve dans un namespace spécifique. Nous devrons également importer certaines classes utilitaires du SDK .Net.
