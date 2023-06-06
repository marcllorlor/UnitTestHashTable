using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ProvesCalculadora
{
    public class ClProveidorProves
    {
        public StreamReader fitxer;             // fitxer TXT amb les proves

        public ClProveidorProves(String xnomfitxer)
        {
            if (File.Exists(xnomfitxer))
            {
                fitxer = new StreamReader(xnomfitxer);
            }
            else
            {
                MessageBox.Show("No trobo el fitxer " + xnomfitxer, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fitxer = null;
            }
        }

        public String NextProva()
        {
            String xs = "";

            if (!fitxer.EndOfStream)
            {
                xs = fitxer.ReadLine();
            }
            else
            {
                fitxer.Close();
            }
            return (xs);
        }

        public void TancarProveidor()
        {
            fitxer.Close();
        }


        /// <summary>
        /// entrada : 1 col·lecció - sortida : Int32
        /// </summary>        
        public Int32 getProva(string prova, ref List<Int32> llNum, Int32 nDades)
        {

            Int32 res = -1;
            String msg = "";
            String[] vdades;

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                res = Int32.Parse(vdades[nDades - 1]);
                llNum.Clear();
                // posem els números a la llista
                foreach (string s in vdades[0].Split(','))
                {
                    llNum.Add(Int32.Parse(s));
                }
                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (res);
        }

        /// <summary>
        /// entrada : 2 col·leccions - sortida : Int32
        /// </summary>        
        public Int32 getProva(string prova, ref List<Int32> llNum1, ref List<Int32> llNum2, Int32 nDades)
        {

            Int32 res = -1;
            String msg = "";
            String[] vdades;

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                res = Int32.Parse(vdades[nDades - 1]);
                llNum1.Clear();
                // posem els números a les llistes
                foreach (string s in vdades[0].Split(','))
                {
                    llNum1.Add(Int32.Parse(s));
                }
                llNum2.Clear();
                foreach (string s in vdades[1].Split(','))
                {
                    llNum2.Add(Int32.Parse(s));
                }
                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (res);
        }

        /// <summary>
        /// entrada : 1 string, 1 char - sortida : Int32
        /// </summary>        
        public Int32 getProva(string prova, ref String xs, ref Char xch, Int32 nDades)
        {

            Int32 res = -1;
            String msg = "";
            String[] vdades;

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                res = Int32.Parse(vdades[nDades - 1]);
                xs = vdades[0];
                xch = Char.Parse(vdades[1]);
                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (res);
        }

        /// <summary>
        /// entrada : 1 string - sortida : Int32
        /// </summary>        
        public Int32 getProva(string prova, ref String xs, Int32 nDades)
        {

            Int32 res = -1;
            String msg = "";
            String[] vdades;

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                res = Int32.Parse(vdades[nDades - 1]);
                xs = vdades[0];
                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (res);
        }

        /// <summary>
        /// entrada : 1 string - sortida : string
        /// </summary>        
        public String getProvaString(string prova, ref String xs, Int32 nDades)
        {

            String res = "";
            String msg = "";
            String[] vdades;

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                res = vdades[nDades - 1];
                xs = vdades[0];
                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (res);
        }

        /// <summary>
        /// entrada : 1 List<Int32> - sortida : 1 List<Int32>
        /// </summary>        
        public List<Int32> getListProva(string prova, ref List<Int32> llNum, Int32 nDades)
        {

            String msg = "";
            String[] vdades;
            List<Int32> llResultat = new List<Int32>();

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                llNum.Clear();
                // posem els números a les llistes
                foreach (string s in vdades[0].Split(','))
                {
                    llNum.Add(Int32.Parse(s));
                }
                llResultat.Clear();
                foreach (string s in vdades[1].Split(','))
                {
                    llResultat.Add(Int32.Parse(s));
                }
                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (llResultat);
        }

        /// <summary>
        /// entrada : 1 string, 1 char - sortida : List<Int32>
        /// </summary>        
        public List<Int32> getListProva(string prova, ref String xs, ref Char xch, Int32 nDades)
        {

            String msg = "";
            String[] vdades;
            List<Int32> llResultat = new List<Int32>();

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                xs = vdades[0];
                xch = Char.Parse(vdades[1]);
                llResultat.Clear();
                foreach (string s in vdades[2].Split(','))
                {
                    llResultat.Add(Int32.Parse(s));
                }

                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (llResultat);
        }

        /// <summary>
        /// entrada : 1 string, 1 char - sortida : List<Char>
        /// </summary>        
        public List<Char> getListProva(string prova, ref String xs, Int32 nDades)
        {

            String msg = "";
            String[] vdades;
            List<Char> llResultat = new List<Char>();

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                xs = vdades[0];
                llResultat.Clear();
                foreach (string s in vdades[1].Split(','))
                {
                    llResultat.Add(Char.Parse(s));
                }

                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (llResultat);
        }
        /// <summary>
        /// entrada : 2 string - sortida : List<Char>
        /// </summary>        
        public List<String> getListParaulesProva(string prova, ref String xs1, ref String xs2, Int32 nDades)
        {

            String msg = "";
            String[] vdades;
            List<String> llResultat = new List<String>();

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                xs1 = vdades[0];
                xs2 = vdades[1];
                llResultat.Clear();
                foreach (string s in vdades[2].Split(','))
                {
                    llResultat.Add(s);
                }

                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (llResultat);
        }

        /// <summary>
        /// entrada : 2 StreamReader - sortida : List<Char>
        /// </summary>        
        public List<String> getListParaulesProvaFile(string prova, ref StreamReader xsR1, ref StreamReader xsR2, Int32 nDades)
        {
            String msg = "";
            String[] vdades;
            List<String> llResultat = new List<String>();

            vdades = prova.Split('#');
            if (vdades.Length != nDades)
            {
                Console.WriteLine("***ERROR*** ---> " + prova);
            }
            else
            {
                xsR1 = new StreamReader(vdades[0]);
                xsR2 = new StreamReader(vdades[1]);
                llResultat.Clear();
                foreach (string s in vdades[2].Split(','))
                {
                    llResultat.Add(s);
                }

                msg = generarMsg(vdades);
                Console.WriteLine(msg);
            }
            return (llResultat);
        }

        // generem el missatge a mostrar a la consola
        private String generarMsg(String[] xv)
        {
            String res = "";

            res = "TESTING ---> ";
            foreach (String s in xv)
            {
                res += s + " - ";
            }
            res = res.Substring(0, res.Length - 3);

            return (res);
        }
    }
}

