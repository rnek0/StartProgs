using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using StartProgs.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace StartProgs.MongoDBSerializer
{
    public class MongoSerialize : DatasIO, IRepository
    {
        IMongoCollection<Dossier> collection = null;
        //IMongoCollection<Dossier> Collection { get => collection; set => collection = value; }

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

        

        public Dossier Create<Dossier>(Dossier toCreate) where Dossier : class
        {
            // throw new NotImplementedException();

            return toCreate;
        }

        public bool Delete<TEntity>(TEntity toDelete) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            throw new NotImplementedException();
        }

        // LECTURE ok :)
        public override List<string> LectureDansFichier()
        {
            List<string> docs = new List<string>();

            var count = collection.Count(new BsonDocument());

            if (count > 0)
            {
                // Test H:\
                //var docu = collection.Find((x)=>x.DossierName=="H:\\").FirstOrDefault();
                //docs.Add(docu.DossierName);
                
                var documents = collection.Find(new BsonDocument()).ToList();
                for (int i = 0; i < documents.Count; i++)
                {
                    docs.Add(documents[i].DossierName);
                }
            }

            return docs;
        }

        public TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            throw new NotImplementedException();
        }

        // SAUVEGARDE 
        // Todo: insert & list is ok. C R manque D U
        public override bool SauvegardeDansFichier(List<string> datas, string dossier = "")
        {
            bool result = false;

            if (!string.IsNullOrEmpty(dossier))
            {
                Dossier d = new Dossier { DossierID = Guid.NewGuid().ToString(), DossierName = dossier };
                try
                {
                    collection.InsertOne(d);
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

        public bool Update<TEntity>(TEntity toUpdate) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
