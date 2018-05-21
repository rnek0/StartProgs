using System.Collections.Generic;

namespace OuvreurDeDossiers
{
    /// <summary>
    /// Actions sur la liste de dossiers.
    /// </summary>    
    public class MesDossiersServices: IDatasOperations
    {
        List<string> DossiersService { get; set; }

        MesDossiersPersistance persistance = null;

        /// <summary>
        /// Ctor.
        /// </summary>
        public MesDossiersServices()
        {
            persistance = new MesDossiersPersistance();
            DossiersService = persistance.LectureDansFichier();
        }

        // ADD
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

        // UPDATE
        /// <summary>
        /// Modifie l'entrée dans la liste.
        /// </summary>
        /// <param name="ancienneValeur"></param>
        /// <param name="nouvelleValeur"></param>
        /// <param name="laListeDesDossiers"></param>
        public void ModifieDossier(string ancienneValeur, string nouvelleValeur, List<string> laListeDesDossiers)
        {
            // TODO: string.IsNullOrWhiteSpace. refactoriser ici (pas beau)
            if (nouvelleValeur == "")
            {
                // pas de valeur donc pas de traitement.
            }
            else { 
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

        // DEL
        /// <summary>
        /// Supprime le dossier passé de la liste.
        /// </summary>
        /// <param name="strDossierPourSuppression"></param>
        /// <param name="laListeDesDossiers"></param>
        public void SupprimeDossier(string strDossierPourSuppression, List<string> laListeDesDossiers)
        {
            int i = laListeDesDossiers.FindIndex((o) => {return o.Equals(strDossierPourSuppression); });

            laListeDesDossiers.RemoveAt(i);

            persistance.SauvegardeDansFichier(laListeDesDossiers);
        }

        // READ
        public List<string> LireDossiers()
        {
            DossiersService = persistance.LectureDansFichier();
            return DossiersService;
        }

        // SAVE
        public void SauvegardeDossiers(List<string> datas)
        {
            persistance.SauvegardeDansFichier(datas);
        }
    }
}
