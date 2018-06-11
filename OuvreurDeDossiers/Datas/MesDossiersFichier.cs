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

        // Injection du mode de sauvegarde.
        public MesDossiersFichier(SaveChoice choice)
        {
            switch (choice)
            {
                case SaveChoice.xml:
                    persistance = new XmlSerialize();
                    break;
                case SaveChoice.file:
                    persistance = new IOSerialize();
                    break;
                case SaveChoice.sqlite:
                    persistance = new SQLiteSerializer.SQLiteSerialize();
                    break;
                case SaveChoice.mongodb:
                    // persistance = new IOSerialize(); next time
                    // break;
                default:
                    // persistance = null;
                    break;
            }
            if (persistance != null)
            {
                DossiersService = persistance.LectureDansFichier();
            }
        }

        /// <summary>
        /// Ajoute un dossier.
        /// </summary>
        /// <param name="strDossier">string</param>
        /// <param name="laListeDesDossiers">List<string></param>
        public void AjouteDossier(string strDossier, List<string> laListeDesDossiers)
        {
            if (persistance != null) { 
                DossiersService.Add(strDossier);
                persistance.SauvegardeDansFichier(DossiersService);
            }
        }

        /// <summary>
        /// Lecture de la liste de dossiers.
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> LireDossiers()
        {
            if (persistance != null)
            {
                DossiersService = persistance.LectureDansFichier();
            }
            return DossiersService;
        }

        /// <summary>
        /// Modifie l'entrée dans la liste.
        /// </summary>
        /// <param name="ancienneValeur">string</param>
        /// <param name="nouvelleValeur">string</param>
        /// <param name="laListeDesDossiers">List<string></param>
        public void ModifieDossier(string ancienneValeur, string nouvelleValeur, List<string> laListeDesDossiers)
        {
            if (persistance == null)
            {
                return;
            }
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

        /// <summary>
        /// Supprime le dossier passé de la liste.
        /// </summary>
        /// <param name="strDossierPourSuppression">string</param>
        /// <param name="laListeDesDossiers">List<string></param>
        public void SupprimeDossier(string strDossierPourSuppression, List<string> laListeDesDossiers)
        {
            if (persistance == null)
            {
                return;
            }
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

        /// <summary>
        /// Sauvegarde la liste de dossiers.
        /// </summary>
        /// <param name="datas">List<string></param>
        public void SauvegardeDossiers(List<string> datas)
        {
            if (persistance == null)
            {
                return;
            }
            persistance.SauvegardeDansFichier(datas);
        }
    }
}