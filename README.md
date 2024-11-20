# Application client Gestion des frais de scolarité Caltech

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
Un docker file permet de l'executer dans un environnement conteneurisé. 
