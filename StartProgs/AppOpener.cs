using System;
using System.Diagnostics;
namespace StartProgs
{
    /// <summary>
    /// Singleton servant a ouvrir un dossier avec explorer.exe.
    /// </summary>
    public sealed class AppOpener
    {
        private static AppOpener _instance;
        static readonly object instanceLock = new object();

        private AppOpener(){}

        public static AppOpener Instance
        {
            get
            {
                // Les locks prennent du temps !
                if (_instance == null) 
                {
                    lock (instanceLock)
                    {
                        // donc on vérifie encore, 
                        // au cas où l'instance aurait été créée entretemps.
                        if (_instance == null) 
                            _instance = new AppOpener();
                    }
                }
                return _instance;
            }
        }


        /// <summary>
        /// Chemin du dossier a ouvrir par l'explorateur.
        /// </summary>
        public string Chemin { get; set; }

        
        /// <summary>
        /// Ouvre le dossier spécifié dans l'explorateur windows.
        /// </summary>
        /// <param name="dossier">string du dossier a ouvrir.</param>
        public void OuvreLeDossier(string dossier="")
        {
            dossier = Chemin;
            ProcessStartInfo monProcess = new ProcessStartInfo
            {
                FileName = "explorer.exe"
            };

            if (dossier == "")
            { 
                monProcess.Arguments = Chemin;
            }
            else
            {
                monProcess.Arguments = dossier;
            }

            try
            {
                if (System.IO.Directory.Exists(dossier)) { 
                    Process.Start(monProcess);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}