using System.Collections.Generic;

namespace OuvreurDeDossiers
{
    public class MesDossiers
    {
        List<string> listeDeDossiers = null;
        public List<string> Dossiers {
            get { return listeDeDossiers;}
            set { listeDeDossiers = value; }
        }

        private MesDossiers()
        {
            MesDossiersServices mesDossiers = new MesDossiersServices();
            Dossiers = mesDossiers.LireDossiers();
        }

        public static readonly MesDossiers Instance = new MesDossiers();
    }
}
