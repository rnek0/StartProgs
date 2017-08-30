using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuvreurDeDossiers
{
    public sealed class MesDossiers
    {
        List<string> listeDeDossiers;
        public List<string> Dossiers { get { return listeDeDossiers;}}
        private MesDossiers()
        {
            //listeDeDossiers = new List<string>() { @"C:\", @"D:\" };
            listeDeDossiers = MesDossiersPersistance.LectureDansFichier();
        }

        public static readonly MesDossiers Instance = new MesDossiers();
    }
}
