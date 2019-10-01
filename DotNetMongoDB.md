# DotNetMongoDB

## Install Mongo.db

[Download community server](https://www.mongodb.com/download-center/community)

Ne pas installer en tant que service !  
Installer Compass Community au besoin (GUI pour MongoDB https://docs.mongodb.com/compass/master/ )

MongoDB a besoin de ce dossier pour fonctionner __C:\data\db__ donc: __mkdir C:\data\db__

* Installer le .msi 
* Exemple de path C:\Program Files\MongoDB\Server\4.2\

## Start MongoDB 

* Ouvrir explorer dans C:\Program Files\MongoDB\Server\4.2\bin + F4 + cmd + enter
* Lancement : __"C:\Program Files\MongoDB\Server\4.2\bin\mongod.exe" --dbpath="C:\data\db"__
* Voir la conn avec Compass Community sur localhost.

Doc : https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/#run-mongodb-from-cmd 

###  Connection

```batch
cd C:\Program Files\MongoDB\Server\4.2\bin && mongo.exe
```

## Arrêt

* __Ctrl + C__

## Nuget pour WPF 

[Dotnet driver](http://mongodb.github.io/mongo-csharp-driver/2.2/getting_started/installation/)

[Docs sur MongoDB & dotnet](https://docs.mongodb.com/ecosystem/drivers/csharp/)

## Using MongoDB CLI

* help : aide basique
* __show dbs__ : voir les bases de données
* __use MesDossiers__ : utiliser la base MesDossiers
* __db.documents.find()__ : lister les documents dans la base MesDossiers
* ...