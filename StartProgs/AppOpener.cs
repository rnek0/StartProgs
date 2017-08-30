using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartProgs
{
    /// <summary>
    /// Singleton servant a ouvrir un dossier avec explorer.exe
    /// </summary>
    public sealed class AppOpener
    {
        private static AppOpener _instance;
        static readonly object instanceLock = new object();

        private AppOpener()
        {
            //Chemin = @"C:\";
        }

        public static AppOpener Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
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
            System.Diagnostics.ProcessStartInfo monProcess = new System.Diagnostics.ProcessStartInfo();
            monProcess.FileName = "explorer.exe";

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
                
                MessageBox.Show("Repertoire " + dossier + " existe ? : " + System.IO.Directory.Exists(dossier).ToString());
                if (System.IO.Directory.Exists(dossier)) { 
                    System.Diagnostics.Process.Start(monProcess);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}