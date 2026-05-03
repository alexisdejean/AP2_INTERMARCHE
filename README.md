# AP2_INTERMARCHE

## Prep'Order

Application Windows Forms de gestion de preparation de commandes pour une base logistique Intermarche.

## Raison d'etre du projet

Prep'Order sert a relier les equipes qui interviennent sur une meme commande mais n'ont pas les memes actions :

- le responsable attribue et supervise
- le preparateur controle les palettes et signale les ecarts
- le cariste corrige le stock physique pour debloquer la commande

L'objectif metier est de reduire les blocages terrain, mieux suivre les palettes et fiabiliser les expeditions magasin.

## Comment les donnees se comportent

### 1. Flux principal

Les donnees tournent autour de quatre elements :

- `Commande` : represente une commande a preparer pour un magasin
- `Commander` : table de liaison entre une commande et les produits demandes avec leurs quantites
- `Palette` : represente le stock physique disponible et sa position dans l'entrepot
- `Notification` : signale un ecart ou un manque rencontre pendant la preparation

Le comportement global est le suivant :

1. un responsable cree une commande magasin
2. les lignes du CSV sont injectees dans la base comme produits a preparer
3. le responsable attribue la commande a un preparateur compatible avec la zone
4. le preparateur consulte les palettes trouvees pour la commande
5. si une palette ne couvre pas le besoin, il cree une notification
6. le cariste traite la notification, ajuste la quantite palette si necessaire, puis clot l'alerte
7. quand la quantite est suffisante, la commande peut passer a l'etat valide

### 2. Roles et etat applicatif

L'application garde un etat minimal dans `AP2_INTERMARCHE/Global.cs` :

- `connection` : chaine de connexion SQL Server
- `role` : role courant connecte
- `user` : identifiant utilisateur courant, reserve pour des evolutions futures

Le role determine l'espace charge apres connexion :

- `1` : responsable
- `2` : preparateur
- `3` : cariste

### 3. Procedures stockees utilisees

L'application consomme principalement des procedures stockees pour :

- authentifier et identifier le role utilisateur
- lister les commandes, palettes, notifications et logs
- attribuer une commande
- creer une notification
- valider une commande
- mettre a jour la quantite d'une palette
- supprimer une notification une fois traitee

## Comment les fonctionnalites sont faites

### Connexion

Le point d'entree est `AP2_INTERMARCHE/Program.cs`, qui ouvre `Accueil`.

`Accueil.cs` :

- verifie le couple identifiant / mot de passe avec `VerifieIdentification`
- recupere le role avec `VerifierRole`
- ouvre ensuite l'ecran metier correspondant

### Responsable

`home_R.cs` est le tableau de bord du responsable. Il ouvre :

- `information_cmd_R.cs` pour voir les commandes et leur avancement
- `attrib_com_R.cs` pour attribuer une commande a un preparateur par zone
- `GestionUtilisateur.cs` pour supprimer des utilisateurs
- `ajout_util_R.cs` pour creer des utilisateurs
- `ajout_commande_R.cs` pour creer une commande et injecter les lignes d'un CSV

### Preparateur

`home_P.cs` ouvre `Commande_P.cs`.

Cet ecran :

- charge les commandes disponibles
- recupere les palettes liees a la commande choisie
- permet de saisir un message d'alerte si le stock trouve pose probleme
- compare quantite palette et quantite demandee
- valide la commande quand le stock est suffisant

### Cariste

`home_C.cs` ouvre deux ecrans :

- `Notification_C.cs` pour traiter les alertes en cours
- `Log_produit_C.cs` pour consulter l'historique des notifications et mouvements lies

`Notification_C.cs` :

- charge les notifications
- retrouve la palette concernee
- verifie la quantite deja presente
- calcule la quantite attendue
- met a jour la palette si le cariste ajoute du stock
- supprime la notification une fois le traitement termine

## Lancement du projet

### Prerequis

- Windows
- .NET 8 SDK
- SQL Server avec la base `bdd_intermarche`

La chaine de connexion actuelle pointe vers :

`Server=LAPTOP-C8LQR30P;Database=bdd_intermarche;Trusted_Connection=True;TrustServerCertificate=True;`

Si la base est hebergee ailleurs, il faut adapter `AP2_INTERMARCHE/Global.cs`.

### Comptes de test

- Responsable
  Identifiant : `Admin.MD`
  Mot de passe : `Admin123`
- Preparateur
  Identifiant : `Preparateur.PL`
  Mot de passe : `UserP123`
- Cariste
  Identifiant : `Cariste.SB`
  Mot de passe : `UserC123`

## Verification realisee

Une compilation complete du projet a ete relancee avec succes sur la solution :

`dotnet build AP2_INTERMARCHE.sln`

Le projet compile sans erreur. Il reste cependant des avertissements de nullabilite et quelques incoherences de nommage non bloquantes, a traiter dans un second passage si besoin.

## Technologies

- C#
- Windows Forms
- SQL Server
- Transact-SQL

## Contributeurs

- Alexis Dejean
- Arthur Chevalier
