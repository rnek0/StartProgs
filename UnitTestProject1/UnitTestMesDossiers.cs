using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OuvreurDeDossiers;

// Ctrl R, L to run test.

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestMesDossiers
    {
        [TestMethod]
        public void TestSingleton()
        {
            MesDossiers md1 = MesDossiers.Instance;
            md1.Dossiers.Add("toto");

            MesDossiers md2 = MesDossiers.Instance;

            Assert.AreSame(md1, md2, "Ce n'est pas le même objet de type MesDossiers.");
            Assert.AreEqual(md1.Dossiers.Count, md2.Dossiers.Count, "Les listes sont pas ok ?");
            Assert.IsFalse(md2.Dossiers == null,"La liste doit être initialisée.");
            Assert.AreEqual(md1.Dossiers[0], md2.Dossiers[0], "Les contenus des listes sont pas les mêmes");
        }
    }
}
