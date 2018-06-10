using System.Collections.Generic;
using StartProgs.Entities;

namespace OuvreurDeDossiers
{
    /// <summary>
    /// Actions sur la liste de dossiers.
    /// </summary>    
    public class MesDossiersFichier : IDatasOperations
    {
        List<string> DossiersService { get; set; }

        DatasIO persistance = null;

        // Ici injection du mode de sauvegarde !!!
        public MesDossiersFichier(string datasIO)
        {
            switch (datasIO)
            {
                case "xml":
                    persistance = new FoldersSerializer();
                    break;

                case "sqlite":
                    persistance = new SQLiteSerializer.SQLiteSerialize();
                    break;

                case "file":
                    // TODO : renomer cette classe !
                    persistance = new FoldersPersistance();
                    break;

                default:
                    break;
            }
            //DossiersService = new List<string>();
            if (persistance != null)
            {
                DossiersService = persistance.LectureDansFichier();
            }
            
        }

        // CREATE
        /// <summary>
        /// Ajoute un dossier.
        /// </summary>
        /// <param name="strDossier">string</param>
        /// <param name="laListeDesDossiers">List<string></param>
        public void AjouteDossier(string strDossier, List<string> laListeDesDossiers)
        {
            DossiersService.Add(strDossier);
            persistance.SauvegardeDansFichier(DossiersService);
        }
        
        // READ.
        /// <summary>
        /// Lecture de la liste de dossiers.
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> LireDossiers()
        {
            DossiersService = persistance.LectureDansFichier();
            return DossiersService;
        }

        // UPDATE.
        /// <summary>
        /// Modifie l'entrée dans la liste.
        /// </summary>
        /// <param name="ancienneValeur"></param>
        /// <param name="nouvelleValeur"></param>
        /// <param name="laListeDesDossiers"></param>
        public void ModifieDossier(string ancienneValeur, string nouvelleValeur, List<string> laListeDesDossiers)
        {
            if (!string.IsNullOrWhiteSpace(nouvelleValeur))
            { 
                int indice = 0;
                int monID = 0;
                foreach (string item in laListeDesDossiers)
                {
                    if (item.Equals(ancienneValeur))
                    {
                        monID = indice;
                    }
                    indice++;
                }
                laListeDesDossiers[monID] = nouvelleValeur;
                DossiersService = laListeDesDossiers;
                persistance.SauvegardeDansFichier(DossiersService);
            }
        }

        // DEL.
        /// <summary>
        /// Supprime le dossier passé de la liste.
        /// </summary>
        /// <param name="strDossierPourSuppression"></param>
        /// <param name="laListeDesDossiers"></param>
        public void SupprimeDossier(string strDossierPourSuppression, List<string> laListeDesDossiers)
        {
            //int index_old = laListeDesDossiers.FindIndex((o) => {return o == strDossierPourSuppression; });// Fixed ?
            var index = 0;
            for (int i = 0; i < laListeDesDossiers.Count; i++)
            {
                if (laListeDesDossiers[i] == strDossierPourSuppression)
                {
                    index = i;
                    break;
                }
            }

            laListeDesDossiers.RemoveAt(index);

            persistance.SauvegardeDansFichier(laListeDesDossiers);
        }
        
        // SAVE.
        public void SauvegardeDossiers(List<string> datas)
        {
            persistance.SauvegardeDansFichier(datas);
        }
    }
}
