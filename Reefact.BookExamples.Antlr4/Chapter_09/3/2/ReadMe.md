#### 9.3.2. Récupéreration des Tokens Dépareillés

L'une des opérations les plus courantes lors de l'analyse syntaxique est "match token". Pour chaque référence de token, `T`, dans la grammaire, l'analyseur syntaxique invoque `match(T)`. Si le token actuel n'est pas `T`, `match()` notifie les listeners d'erreur et tente de se resynchroniser. Pour se resynchroniser, il a trois choix. Il peut soit supprimer un jeton, soit il peut en faire apparaître un, soit il peut lancer une exception pour engager le mécanisme de synchronisation et de retour de base.
La suppression du jeton actuel est le moyen le plus simple de resynchroniser, si cela a un sens. Revoyons la règle `classDef` de notre langage de définition de classe dans la grammaire `Simple`.

