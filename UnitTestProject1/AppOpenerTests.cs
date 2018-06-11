using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StartProgs;

namespace UnitTestProject1
{
    [TestClass]
    public class AppOpenerTests
    {
        [TestMethod]
        public void TestNavigateurWeb()
        {
            AppOpener appOpener = StartProgs.AppOpener.Instance;

            Assert.IsNotNull(appOpener,"appOpener est null");

            appOpener.Chemin = @"C:\";
            Assert.IsTrue(appOpener.OuvreLeDossier(),"Pas d'ouverture de dossier dans OuvreLeDossier");

            appOpener.Chemin = "https://www.google.fr";
            Assert.IsTrue(appOpener.OuvreLeDossier(),"Pas d'ouverture de navigateur avec OuvreLeDossier");

            appOpener.Chemin = "";
            Assert.IsFalse(appOpener.OuvreLeDossier(),"Ne doit pas s'ouvrir avec chaine vide !");
        }
    }
}