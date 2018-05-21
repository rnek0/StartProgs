using Microsoft.VisualStudio.TestTools.UnitTesting;
using OuvreurDeDossiers;
using System;
using System.IO;
using System.Windows.Forms;

namespace UnitTestOuvreurDeDossiers
{
    [TestClass]
    public class MesDossiersUnitTest
    {
        [TestMethod]
        public void TestSingleton()
        {
            MesDossiers oneMesDossiers = MesDossiers.Instance;
            MesDossiers twoMesDossiers = MesDossiers.Instance;

            Assert.AreSame(oneMesDossiers, twoMesDossiers, "Le singleton ne marche pas");
        }
    }
}