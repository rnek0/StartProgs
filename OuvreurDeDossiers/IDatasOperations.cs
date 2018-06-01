using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuvreurDeDossiers
{
    public interface IDatasOperations
    {
        void AjouteDossier(string strDossier, List<string> laListeDesDossiers);

        void ModifieDossier(string ancienneValeur, string nouvelleValeur, List<string> laListeDesDossiers);

        void SupprimeDossier(string strDossierPourSuppression, List<string> laListeDesDossiers);

        // TODO : refactoriser ici, passer en async avant que ce soit trop tard.
        List<string> LireDossiers();

        void SauvegardeDossiers(List<string> datas);
    }
}
