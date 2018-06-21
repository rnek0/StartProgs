using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using StartProgs.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StartProgs.MongoDBSerializer
{
    public class MongoSerialize : DatasIO, IRepository
    {
        IMongoCollection<Dossier> collection = null;
        
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
        public override List<string> LectureDansFichier()
        {
            List<string> docs = new List<string>();
            var count = collection.Count(new BsonDocument());
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
        public List<Dossier> Filter<Dossier>(Expression<Func<Dossier, bool>> criteria) where Dossier : class
        {
            List<Dossier> res = null;

            // ??
            
            return res;
        }

        // READ ONE ENTITY
        public Dossier Retrieve<Dossier>(Expression<Func<Dossier, bool>> criteria) where Dossier : class
        {
            Dossier result = null;

            var t = criteria.Parameters.ToBsonDocument(typeof(Dossier));

            result = collection.Find(t).FirstOrDefault() as Dossier;

            return result;
        }
        
        // SAUVEGARDE 
        public override bool SauvegardeDansFichier(List<string> datas, string dossier = "")
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
