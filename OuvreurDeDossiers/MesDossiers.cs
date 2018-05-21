using System.Collections.Generic;

namespace OuvreurDeDossiers
{
    public sealed class MesDossiers
    {
        readonly List<string> listeDeDossiers;
        public List<string> Dossiers { get { return listeDeDossiers;}}
        private MesDossiers()
        {
            listeDeDossiers = MesDossiersPersistance.LectureDansFichier();
        }

        public static readonly MesDossiers Instance = new MesDossiers();
    }
}
