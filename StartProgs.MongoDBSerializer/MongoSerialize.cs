using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using StartProgs.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StartProgs.MongoDBSerializer
{
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0534 // 'MongoSerialize' n'implémente pas le membre abstrait hérité 'DatasIO.SauvegardeDansFichier(List<string>, string)'
#pragma warning disable CS0012 // Le type 'IDisposable' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0012 // Le type 'IDisposable' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
    public class MongoSerialize : DatasIO, IRepository
#pragma warning restore CS0012 // Le type 'IDisposable' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0012 // Le type 'IDisposable' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0534 // 'MongoSerialize' n'implémente pas le membre abstrait hérité 'DatasIO.SauvegardeDansFichier(List<string>, string)'
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
    {
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
        IMongoCollection<Dossier> collection = null;
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
        
        public MongoSerialize()
        {
            // pour BsonDocument
            BsonClassMap.RegisterClassMap<Dossier>(
                cm =>
                {
                    cm.MapMember(c => c.DossierID);
                    cm.MapMember(c => c.DossierName);
                }
                );

            var client = new MongoClient("mongodb://localhost:27017");

            // Get database.
            var database = client.GetDatabase(DbConfig.DbName);

            // GetCollection.
            collection = database.GetCollection<Dossier>("dossiers");
            
        }

        // CREATE. (OK)
        public TEntity Create<TEntity>(TEntity toCreate) where TEntity : class
        {
            var d = toCreate as Dossier;
            collection.InsertOne(d);
            return toCreate;
        }

        // DELETE. (OK)
        public bool Delete<TEntity>(TEntity toDelete) where TEntity : class
        {
            DeleteResult res;
            if (toDelete is string)
            {
                var d = new Dossier();
                var _filter = Builders<Dossier>.Filter.Eq("DossierName", toDelete);
                res = collection.DeleteOne(_filter);
            }
            else
            { 
                var dossier = toDelete as Dossier;
                
                var filter = Builders<Dossier>.Filter.Eq("DossierName", dossier.DossierName);
                res = collection.DeleteOne(filter);
            }
            return res.DeletedCount > 0? true: false;
        }

        // LECTURE List<string> (OK)
#pragma warning disable CS0012 // Le type 'List<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0508 // 'MongoSerialize.LectureDansFichier()' : le type de retour doit être 'List<string>' pour correspondre au membre substitué 'DatasIO.LectureDansFichier()'
        public override List<string> LectureDansFichier()
#pragma warning restore CS0508 // 'MongoSerialize.LectureDansFichier()' : le type de retour doit être 'List<string>' pour correspondre au membre substitué 'DatasIO.LectureDansFichier()'
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0012 // Le type 'List<>' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
        {
            List<string> docs = new List<string>();
            //var count = collection.Count(new BsonDocument()); <- OBSOLETE
            var count = collection.CountDocuments(new BsonDocument());
            if (count > 0)
            {
                var documents = collection.Find(new BsonDocument()).ToList();
                for (int i = 0; i < documents.Count; i++)
                {
                    docs.Add(documents[i].DossierName);
                }
            }
            return docs;
        }

        // TODO: UPDATE (a tester)
        public bool Update<TEntity>(TEntity toUpdate) where TEntity : class
        {
            var Result = false;
            var dossier = toUpdate as Dossier;
            try
            {
                var filter = Builders<Dossier>.Filter.Eq("DossierID", dossier.DossierID);
                var update = Builders<Dossier>.Update.Set("DossierName", dossier.DossierName);
                var result = collection.UpdateOne(filter, update);

                Result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        // Pas utilisée pour le moment.
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
        public List<Dossier> Filter<Dossier>(Expression<Func<Dossier, bool>> criteria) where Dossier : class
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
        {
            List<Dossier> res = null;

            // ??
            
            return res;
        }

        // READ ONE ENTITY
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
        public Dossier Retrieve<Dossier>(Expression<Func<Dossier, bool>> criteria) where Dossier : class
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
        {
            Dossier result = null;

            var t = criteria.Parameters.ToBsonDocument(typeof(Dossier));

            result = collection.Find(t).FirstOrDefault() as Dossier;

            return result;
        }
        
        // SAUVEGARDE 
#pragma warning disable CS0115 // 'MongoSerialize.SauvegardeDansFichier(List<string>, string)' : aucune méthode appropriée n'a été trouvée pour la substitution
#pragma warning disable CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
        public override bool SauvegardeDansFichier(List<string> datas, string dossier = "")
#pragma warning restore CS0012 // Le type 'Object' est défini dans un assembly qui n'est pas référencé. Vous devez ajouter une référence à l'assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'.
#pragma warning restore CS0115 // 'MongoSerialize.SauvegardeDansFichier(List<string>, string)' : aucune méthode appropriée n'a été trouvée pour la substitution
        {
            bool result = false;

            if (!string.IsNullOrEmpty(dossier))
            {
                Dossier d = new Dossier { DossierID = Guid.NewGuid().ToString(), DossierName = dossier };
                try
                {
                    //collection.InsertOne(d);
                    Create(d);
                    result = true;
                }
                catch (Exception ex)
                {
                    // todo : lancer exception avec un event?
                    var cause = ex.Message;
                    throw;
                }
            }
            else
            {
                // parcours les docs avec la liste pour voir s'il y a du neuf et add si c'est le cas.
            }
            return result;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
