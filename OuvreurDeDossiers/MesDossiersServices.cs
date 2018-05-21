using System.Collections.Generic;

namespace OuvreurDeDossiers
{
    public static class MesDossiersServices
    {
        /// <summary>
        /// Ajoute un dossier.
        /// </summary>
        /// <param name="strDossier">string</param>
        /// <param name="laListeDesDossiers">List<string></param>
        public static void AjouteDossier(string strDossier, 
                                        List<string> laListeDesDossiers)
        {
            laListeDesDossiers.Add(strDossier);
        }

        /// <summary>
        /// Modifie l'entrée dans la liste.
        /// </summary>
        /// <param name="ancienneValeur"></param>
        /// <param name="nouvelleValeur"></param>
        /// <param name="laListeDesDossiers"></param>
        public static void ModifieDossier(string ancienneValeur, 
                                         string nouvelleValeur, 
                                         List<string> laListeDesDossiers)
        {
            // TODO: string.IsNullOrWhiteSpace
            if (nouvelleValeur == "")
            {
                // pas de valeur pas de traitement -> pas de bras pas de chocolat ! :D
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
            }
        }

        /// <summary>
        /// Supprime le dossier passé dans la liste.
        /// </summary>
        /// <param name="strDossierPourSuppression"></param>
        /// <param name="laListeDesDossiers"></param>
        public static void SupprimeDossier(string strDossierPourSuppression, 
                                           List<string> laListeDesDossiers)
        {
            int indice = 0;
            int monID = 0;
            foreach (var item in laListeDesDossiers)
            {
                if (item.ToString().Equals(strDossierPourSuppression))
                {
                    monID = indice;
                }
                indice++;
            }
            laListeDesDossiers.RemoveAt(monID);
            // TODO : Faire un evenement pour notifier a la liste 
            // qu'elle doit se remettre au premier item.
        }
    }
}
