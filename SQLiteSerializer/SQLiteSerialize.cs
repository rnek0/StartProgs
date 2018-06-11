using StartProgs.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace StartProgs.SQLiteSerializer
{
    public class SQLiteSerialize : DatasIO, IRepository
    {
        DossierDBContext context;

        public SQLiteSerialize()
        {
            context = new DossierDBContext();
        }

        // CREATE
        public Dossier Create<Dossier>(Dossier toCreate) where Dossier : class
        {
            Dossier Result = default(Dossier);
            try
            {
                context.Set<Dossier>().Add(toCreate);
                context.SaveChanges();
                Result = toCreate;
            }
            catch { }
            return Result;
        }

        // DELETE
        public bool Delete<Dossier>(Dossier toDelete) where Dossier : class
        {
            throw new NotImplementedException();
        }

        // DISPOSE
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        // FILTER
        public List<Dossier> Filter<Dossier>(Expression<Func<Dossier, bool>> criteria) where Dossier : class
        {
            List<Dossier> Result = null;
            try
            {
                return context.Set<Dossier>().Where(criteria).ToList();
            }
            catch { }
            return Result;
        }

        #region LECTURE

        public override List<string> LectureDansFichier()
        {
            var Result = new List<string>();
            //List<Dossier> dossiers = context.Dossiers.Select(x => x).ToList();
            List<Dossier> dossiers = Filter<Dossier>((x) => true);
            foreach (var item in dossiers)
            {
                Result.Add(item.DossierName);
            }
            return Result;
        }

        #endregion

        public Dossier Retrieve<Dossier>(Expression<Func<Dossier, bool>> criteria) where Dossier : class
        {
            throw new NotImplementedException();
        }

        #region SAUVEGARDE

        public override bool SauvegardeDansFichier(List<string> datas, string dossier = "")
        {
            // Todo: POUR L'INSTANT ON EFFACE ET ON RECREE (pas tres propre), 
            // PASSER LA List<string> en Dictionnary pour utiliser les guid ?
            // Cette méthode devra passer en async egalement.
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var result = false;
            List<string> dossiers = datas;
            try
            {
                Dossier s = null;
                for (int i = 0; i < dossiers.Count; i++)
                {
                    s = Create<Dossier>(
                        new Dossier { DossierID = Guid.NewGuid().ToString(), DossierName = dossiers[i].ToString() });
                }
                s = null;
                result = true;
            }
            catch { }
            dossiers = null;            
            return result;
        }

        #endregion

        public bool Update<Dossier>(Dossier toUpdate) where Dossier : class
        {
            throw new NotImplementedException();
        }
    }
}
