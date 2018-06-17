using StartProgs.Entities;
using System.Collections.Generic;

namespace OuvreurDeDossiers
{
    public interface IDatasOperations
    {
        void AjouteDossier(string strDossier, List<string> laListeDesDossiers);

        void ModifieDossier(string ancienneValeur, string nouvelleValeur, List<string> laListeDesDossiers);

        void SupprimeDossier(string strDossierPourSuppression, List<string> laListeDesDossiers);
        
        List<string> LireDossiers(); // TODO : passer en async ?

        void SauvegardeDossiers(List<string> datas);
    }
}
