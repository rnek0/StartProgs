using System.Collections.Generic;
using System.IO;

namespace StartProgs.Entities
{
    public abstract class DatasIO
    {
        /// <summary>
        /// Save a List of string.
        /// </summary>
        /// <param name="datas">List of strings</param>
        /// <returns>bool</returns>
        public abstract bool SauvegardeDansFichier(List<string> datas, string dossier = "");

        /// <summary>
        /// Retrieves a List of string.
        /// </summary>
        /// <returns>List<string></returns>
        public abstract List<string> LectureDansFichier();

        /// <summary>
        /// Checking the existence of the file.
        /// </summary>
        /// <returns>bool</returns>
        protected bool FichierExiste(string FichierXml)
        {
            return (File.Exists(FichierXml)) ? true : false;
        }
    }
}