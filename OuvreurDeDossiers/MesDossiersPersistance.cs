using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OuvreurDeDossiers
{
    public static class MesDossiersPersistance
    {
        private static string MonFichier = "";

        static MesDossiersPersistance()
        {
            MonFichier = System.Environment.CurrentDirectory + "\\" + "MesDossiers.dat";
        }

        private static bool fichierExiste()
        {
            StringBuilder CheminFichier = new StringBuilder();
            CheminFichier.Append(System.Environment.CurrentDirectory);
            CheminFichier.Append(@"\");
            CheminFichier.Append("MesDossiers.dat");
            MonFichier = CheminFichier.ToString();
            return (File.Exists(MonFichier))? true : false;
        }
        
        // ENREGISTREMENT DES DATAS
        public static void SauvegardeDansFichier(List<string> lesDossiers) {
            if (MesDossiersPersistance.fichierExiste() == true)
            {
                try
                {
                    using (FileStream monStream = File.OpenWrite(MonFichier))
                    {
                        using (StreamWriter ecrivain = new StreamWriter(monStream) )
                        {
                            StringBuilder contenu = new StringBuilder();
                            foreach (string item in lesDossiers)
                            {
                                contenu.Append(item);
                                contenu.Append(Environment.NewLine);
                            }
                            ecrivain.Write(contenu.ToString());
                        }
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    File.Create(MonFichier);
                }
                catch (Exception e)
                {
                    throw new Exception("Ooups ! Problème d'enregistement des datas.", e);                    
                }
            }
        }
        
        // RECUPERATION DES DATAS
        public static List<string> LectureDansFichier() 
        {
            List<string> listeSauvegardee = new List<string>();
            if (MesDossiersPersistance.fichierExiste() == true)
            {
                try
                {
                    using (FileStream monStream = File.OpenRead(MonFichier))
                    {
                        using (StreamReader lecteur = new StreamReader(monStream) )
                        {   
                            while (!lecteur.EndOfStream)
                            {
                                listeSauvegardee.Add(lecteur.ReadLine());
                            }
                        }
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    // Le fichier n'existe pas alors je le crée !!!!
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return listeSauvegardee;
        }
    }
}