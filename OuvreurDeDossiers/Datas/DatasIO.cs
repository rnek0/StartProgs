using System.Collections.Generic;
using System.IO;

namespace OuvreurDeDossiers
{
    public abstract class DatasIO
    {
        public abstract bool SauvegardeDansFichier(List<string> datas);

        public abstract List<string> LectureDansFichier();

        /// <summary>
        /// Verifie l'existance du fichier xml.
        /// </summary>
        /// <returns>bool</returns>
        protected bool FichierExiste(string FichierXml)
        {
            return (File.Exists(FichierXml)) ? true : false;
        }
    }
}
