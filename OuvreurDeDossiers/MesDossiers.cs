using System.Collections.Generic;

namespace OuvreurDeDossiers
{
    public class MesDossiers
    {
        //List<string> listeDeDossiers = null;
        //public List<string> Dossiers {
        //    get { return listeDeDossiers;}
        //    set { listeDeDossiers = value; }
        //}

        //private MesDossiers()
        //{
        //    MesDossiersFichier mesDossiers = new MesDossiersFichier();
        //    Dossiers = mesDossiers.LireDossiers();
        //}

        //public static readonly MesDossiers Instance = new MesDossiers();

        List<string> listeDeDossiers = null;
        MesDossiersFichier mesDossiers;
        string SerializationMode = "";

        public List<string> Dossiers
        {
            get { return listeDeDossiers; }
            set { listeDeDossiers = value; }
        }

        private MesDossiers()
        {
            // TODO: mettre dans appsettings
            SerializationMode = "file";

            mesDossiers = new MesDossiersFichier(SerializationMode);

            Dossiers = mesDossiers.LireDossiers();
        }

        public static readonly MesDossiers Instance = new MesDossiers();

    }
}
