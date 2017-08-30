using System.Collections.Generic;

namespace OuvreurDeDossiers
{
    public static class MesDossiersServices
    {
        public static void AjouteDossier(string strDossier, List<string> laListeDesDossiers){
            laListeDesDossiers.Add(strDossier);
        }

        public static void ModifieDossier(string ancienneValeur, string nouvelleValeur, List<string> laListeDesDossiers)
        {
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

        public static void SupprimeDossier(string strDossierPourSuppression, List<string> laListeDesDossiers)
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
        }
    }
}
