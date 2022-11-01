# Application client pour projet diiage 2 P2

## les consignes 
Voici ce que vous avez à faire avec cette application : 

1. Vous devrez effectuer un audit de cette application (retro ingéniering de la solution, analyse des points fort et des points à amélioré dans la solution),
2. mettre en place une CI/CD,
3. herberger dans le cloud suivant les consignes du ppt, 
4. Assurer la maintenance applicative (correction de bug, de problème de perf, de sécurité, et developpement d'évolution mineur),

## La solution

Les sources se trouvent dans le répertoire src de la solution 

La solution est developpement en Asp.Net Core 6, toutes les pages sont en serveur side rendering

Pour executer l'application il faut faire :

```bash
dotnet restore
```    
Puis
```bash
dotnet build
```

Vous devez avoir les outils dotnet ef installés sur votre poste pour gérer les migrations de la base de données.
```bash
dotnet tool install --global dotnet-ef
```

L'application necessite une base de données SQL Server pour fonctionner. 

Un doxker file permet de l'executer dans un environnement conteneurisé. 