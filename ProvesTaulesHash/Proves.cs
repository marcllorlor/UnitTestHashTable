using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BibliotecaTaulesHash;
using System.Collections.Generic;
using System.IO;
using ProvesCalculadora;

namespace ProvesTaulesHash
{
    [TestClass]
    public class Proves
    {
        String prova = "";
        ClTaulesHash taula = new ClTaulesHash();
        ClProveidorProves proveidor = null;

        [TestMethod]
        public void TestParaulesRepetides()
        {
            String s1 = "";
            String s2 = "";
            List<String> llistaResultat = new List<String>();

            proveidor = new ClProveidorProves("paraulesrepetides.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();
                while (prova.Trim() != "")
                {
                    llistaResultat = proveidor.getListParaulesProva(prova, ref s1, ref s2, 3);
                    CollectionAssert.AreEqual(llistaResultat, taula.ParaulesRepetides(s1, s2));
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }

        [TestMethod]
        public void TestParaulesNoRepetides()
        {
            String s1 = "";
            String s2 = "";
            List<String> llistaResultat = new List<String>();

            proveidor = new ClProveidorProves("paraulesnorepetides.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();
                while (prova.Trim() != "")
                {
                    llistaResultat = proveidor.getListParaulesProva(prova, ref s1, ref s2, 3);
                    CollectionAssert.AreEqual(llistaResultat, taula.ParaulesNoRepetides(s1, s2));
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }

        [TestMethod]
        public void TestParaulesMesRepetides()
        {
            String s1 = "";
            String s2 = "";
            List<String> llistaResultat = new List<String>();

            proveidor = new ClProveidorProves("paraulesmesrepetides.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();
                while (prova.Trim() != "")
                {
                    llistaResultat = proveidor.getListParaulesProva(prova, ref s1, ref s2, 3);
                    CollectionAssert.AreEqual(llistaResultat, taula.ParaulesMesRepetides(s1, s2));
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }

        [TestMethod]
        public void TestParaulesRepetidesFile()
        {
            List<String> llistaResultat = new List<String>();
            StreamReader sR1 = null;
            StreamReader sR2 = null;

            proveidor = new ClProveidorProves("paraulesrepetidesfile.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();
                while (prova.Trim() != "")
                {
                    llistaResultat = proveidor.getListParaulesProvaFile(prova, ref sR1, ref sR2, 3);
                    CollectionAssert.AreEqual(llistaResultat, taula.ParaulesRepetidesFile(ref sR1, ref sR2));
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }

        [TestMethod]
        public void TestParaulesNoRepetidesFile()
        {
            List<String> llistaResultat = new List<String>();
            StreamReader sR1 = new StreamReader("primer.txt");
            StreamReader sR2 = new StreamReader("segon.txt");

            proveidor = new ClProveidorProves("paraulesnorepetidesfile.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();
                while (prova.Trim() != "")
                {
                    llistaResultat = proveidor.getListParaulesProvaFile(prova, ref sR1, ref sR2, 3);
                    CollectionAssert.AreEqual(llistaResultat, taula.ParaulesNoRepetidesFile(ref sR1, ref sR2));
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }

        [TestMethod]
        public void TestParaulesMesRepetidesFile()
        {
            List<String> llistaResultat = new List<String>();
            StreamReader sR1 = new StreamReader("tercer.txt");
            StreamReader sR2 = new StreamReader("quart.txt");

            proveidor = new ClProveidorProves("paraulesmesrepetidesfile.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();
                while (prova.Trim() != "")
                {
                    llistaResultat = proveidor.getListParaulesProvaFile(prova, ref sR1, ref sR2, 3);
                    CollectionAssert.AreEqual(llistaResultat, taula.ParaulesMesRepetidesFile(ref sR1, ref sR2));
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }
    }
}
