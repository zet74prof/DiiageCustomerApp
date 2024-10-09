# Utilisation de SonarCloud avec GitHub dans une CI/CD (40 minutes)

## Prérequis matériels et logiciels

- **Ordinateur portable** avec accès à Internet.
- **Navigateur web** (Chrome, Firefox, Edge, etc.).
- **Compte GitHub** : si vous n'en avez pas, créez-en un gratuitement [ici](https://github.com/join).
- **Compte SonarCloud** : peut être créé pendant l'atelier.

---

## Déroulé de l'atelier pratique

### Étape 1 : Forker le dépôt GitHub

#### Accéder au dépôt source

- Rendez-vous sur le dépôt GitHub de l'application que nous allons utiliser pour l'atelier : [https://github.com/Erikvdv/realworldapiminimal](https://github.com/Erikvdv/realworldapiminimal).
- Ce dépôt fait partie du projet **RealWorld**, qui regroupe une collection d'applications exemplaires. Plus d'informations sur [codebase.show](https://codebase.show/projects/realworld?category=backend).

#### Forker le dépôt

- Cliquez sur le bouton **"Fork"** en haut à droite de la page du dépôt.
- Sélectionnez votre compte personnel pour créer une copie du dépôt dans votre espace GitHub.

---

### Étape 2 : Créer un compte SonarCloud et configurer une organisation

#### Créer un compte SonarCloud avec votre compte GitHub

- Rendez-vous sur [sonarcloud.io](https://sonarcloud.io/).
- Cliquez sur **"Sign up with GitHub"** ou utilisez ce lien direct : [Inscription SonarCloud via GitHub](https://sonarcloud.io/sessions/new?return_to=%2F&service=github).
- Autorisez SonarCloud à accéder à votre compte GitHub si demandé.

#### Créer une organisation avec le plan gratuit

- Une fois connecté sur SonarCloud, cliquez sur **"Create Organization"**.
- Sélectionnez **"Choose an organization on GitHub"**.
- Choisissez **votre nom d'utilisateur GitHub** comme organisation.
- Choisissez le **plan gratuit** ("Free plan") lorsque cela est proposé.

---

### Étape 3 : Lancer la première analyse de code

#### Importer le projet GitHub dans SonarCloud

- Dans SonarCloud, après avoir créé l'organisation, cliquez sur **"Analyze new project"**.
- Sélectionnez le dépôt que vous avez forké (par exemple, `votre-nom-utilisateur/realworldapiminimal`).
- Cliquez sur **"Set Up"** pour commencer la configuration du projet.

#### Configurer le projet SonarCloud

- **Nom du projet** : laissez le nom par défaut ou personnalisez-le.
- **Clé du projet** : laissez la valeur par défaut.
- Cliquez sur **"Continue"**.

#### Choisir la méthode d'analyse

- Sur la page **"Choose how to analyze your project"**, sélectionnez **"With GitHub Actions"**.

#### Suivre les instructions de SonarCloud pour configurer l'analyse

- SonarCloud va vous fournir un fichier YAML préconfiguré pour GitHub Actions.

#### Ajouter le jeton comme secret dans votre dépôt GitHub

- Allez sur votre dépôt forké sur GitHub.
- Cliquez sur **"Settings"** (Paramètres) > **"Secrets and variables"** > **"Actions"** > **"New repository secret"**.
- **Nom du secret** : `SONAR_TOKEN`
- **Valeur du secret** : collez le jeton SonarCloud que vous avez généré.
- Cliquez sur **"Add secret"**.

#### Créer le fichier GitHub Actions pour l'analyse SonarCloud

- Dans votre dépôt GitHub, cliquez sur **"Actions"** en haut.
- Vous pouvez voir des workflows suggérés ; nous allons créer un workflow personnalisé.
- Cliquez sur **"New workflow"**, puis sur **"set up a workflow yourself"**.
- **Nom du fichier** : `.github/workflows/sonarcloud.yml`

---

### Étape 4 : Vérifier l'exécution de l'analyse

#### Déclencher le workflow GitHub Actions

- Le fait de committer le fichier de workflow déclenche automatiquement l'exécution du workflow.
- Allez dans l'onglet **"Actions"** de votre dépôt pour voir le workflow en cours d'exécution.
- Vous pouvez cliquer sur le workflow pour voir les détails et suivre l'exécution des étapes.

#### Vérifier les résultats sur SonarCloud

- Une fois le workflow terminé, retournez sur **SonarCloud**.
- Dans votre tableau de bord, cliquez sur votre projet pour voir les résultats de l'analyse.
- Vous verrez des métriques telles que les **Bugs**, les **Vulnérabilités**, les **Code Smells**, la **Couverture de code**, etc.

---

### Étape 5 : Modifier le fichier YAML pour inclure la couverture de code

#### Ajouter l'étape pour installer l'outil de couverture de code

- Dans le fichier `sonarcloud.yml`, ajoutez l'étape suivante après l'installation de .NET :

  ```yaml
  - name: Install Dotnet Coverage
    shell: pwsh
    run: |
      dotnet tool install --global dotnet-coverage


Cette étape installe l'outil `dotnet-coverage`, nécessaire pour collecter les données de couverture de code.

#### Modifier l'étape "Build and analyze" pour inclure la couverture de code

- Remplacez l'étape existante par le code suivant :

  ```yaml
  - name: Build and analyze
    env:
      GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}  # Nécessaire pour obtenir les informations de PR, le cas échéant
      SONAR_TOKEN: ${{ secrets.SONAR_TOKEN }}
    shell: pwsh
    run: |
      dotnet tool install --global dotnet-sonarscanner
      dotnet-sonarscanner begin /k:"[NOM_DE_VOTRE_PROJET_SONAR_CLOUD]" /o:"votre-nom-utilisateur" /d:sonar.token="${{ secrets.SONAR_TOKEN }}" /d:sonar.host.url="https://sonarcloud.io/" /d:sonar.cs.vscoveragexml.reportsPaths="coverage.xml"
      dotnet build
      dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"
      dotnet-sonarscanner end /d:sonar.token="${{ secrets.SONAR_TOKEN }}"

**Remplacez** `[NOM_DE_VOTRE_PROJET_SONAR_CLOUD]` par le nom de votre projet dans SonarCloud.
- **Remplacez** `votre-nom-utilisateur` par votre nom d'utilisateur GitHub.

#### Commiter le fichier

- Enregistrez les modifications et commitez le fichier `sonarcloud.yml`.

#### Vérifier la couverture de code sur SonarCloud

- Une fois le workflow exécuté, retournez sur **SonarCloud**.
- Vérifiez que la **couverture de code** est bien affichée dans les métriques du projet.

Félicitations ! Vous avez intégré SonarCloud à votre projet GitHub et configuré une analyse continue avec couverture de code via GitHub Actions.
