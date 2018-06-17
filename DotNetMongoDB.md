# DotNetMongoDB

## Install Mongo.db

[Download community server](https://www.mongodb.com/download-center#community)

MongoDB a besoin de ce dossier pour fonctionner __C:\data\db__ donc: __mkdir C:\data\db__

* Installer le .msi 
* Exemple de path C:\Program Files\MongoDB\Server\3.6\bin

## Start MongoDB 

* Ouvrir explorer dans C:\Program Files\MongoDB\Server\3.6\bin + F4 + cmd + enter
* Lancement : __C:\Program Files\MongoDB\Server\3.6\bin\mongod.exe__

```batch
cd C:\Program Files\MongoDB\Server\3.6\bin\ && mongod.exe
```

## Connection

* Ouvrir explorer dans C:\Program Files\MongoDB\Server\3.6\bin + F4 + cmd + enter
* Lancement : __C:\Program Files\MongoDB\Server\3.6\bin\mongo.exe__ 

Dans une autre cmd:

```batch
cd C:\Program Files\MongoDB\Server\3.6\bin\ && mongo.exe
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