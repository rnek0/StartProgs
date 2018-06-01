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
        public bool OuvreLeDossier(string dossier="")
        {
            dossier = Chemin;
            var ouvertureEffectuee = false;

            ProcessStartInfo monProcess = new ProcessStartInfo
            {
                FileName = "explorer.exe"
            };

            if (string.IsNullOrWhiteSpace(dossier))
            {
                ouvertureEffectuee = false;
                monProcess.Arguments = Chemin;
            }
            else
            {
                var navigationWeb = true;
                ouvertureEffectuee = true;
                monProcess.Arguments = dossier;
                
                navigationWeb = (dossier.Contains("https:") == true) ? true : false;

                try
                {
                    if (navigationWeb == true)
                    {
                        // TODO : choix de navigateur ? 
                        // 
                        monProcess.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                        Process.Start(monProcess);
                    }
                    else
                    {
                        if (System.IO.Directory.Exists(dossier))
                        {
                            Process.Start(monProcess);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }

            return ouvertureEffectuee;
        }
    }
}