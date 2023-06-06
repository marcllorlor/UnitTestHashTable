using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace BibliotecaTaulesHash
{
    public class ClTaulesHash
    {
        private Hashtable taulaH = new Hashtable();

        public List<String> ParaulesRepetides(String frase1, String frase2)
        {
            List<String> llistaParaulesRepetides = new List<string>();

            taulaH.Clear();
            String[] vParaules = frase1.Split(' ');
            foreach (String s in vParaules) {
                if (s.Trim().Length > 0)
                {
                    if (!taulaH.Contains(s.ToLower()))
                    {
                        taulaH.Add(s.ToLower(), 0);
                    }
                }
            }

            vParaules = frase2.Split(' ');
            foreach (String s in vParaules)
            {
                if (s.Trim().Length > 0)
                {
                    if (taulaH.Contains(s.ToLower()))
                    {
                        taulaH[s.ToLower()] = ((Int32)taulaH[s.ToLower()]) + 1;
                    }
                }
            }

            llistaParaulesRepetides.Clear();
            foreach (String k in taulaH.Keys)
            {
                if ((Int32)taulaH[k] > 0)
                {
                    llistaParaulesRepetides.Add(k);
                }
            }
            llistaParaulesRepetides.Sort();
            return (llistaParaulesRepetides);
        }

        public List<String> ParaulesNoRepetides(String frase1, String frase2)
        {
            List<String> llistaParaulesNoRepetides = new List<string>();
            Hashtable taulaH2=new Hashtable();

            taulaH.Clear();
            llistaParaulesNoRepetides.Clear();
            String[] vParaules = frase1.Split(' ');
            foreach (String s in vParaules)
            {
                if (s.Trim().Length > 0)
                {
                    if (!taulaH.Contains(s.ToLower()))
                    {
                        taulaH.Add(s.ToLower(), 0);
                    }
                }
            }

            taulaH2.Clear();
            vParaules = frase2.Split(' ');
            foreach (String s in vParaules)
            {
                if (s.Trim().Length > 0)
                {
                    if (!taulaH2.Contains(s.ToLower()))
                    {
                        taulaH2.Add(s.ToLower(),0);
                    } 
     
                }
            }

            foreach (String k in taulaH.Keys)
            {
                if (!taulaH2.Contains(k))
                {
                    llistaParaulesNoRepetides.Add(k);
                }
            }
            foreach (String k in taulaH2.Keys)
            {
                if (!taulaH.Contains(k))
                {
                    llistaParaulesNoRepetides.Add(k);
                }
            }
            llistaParaulesNoRepetides.Sort();
            return (llistaParaulesNoRepetides);
        }

        public List<String> ParaulesMesRepetides(String frase1, String frase2)
        {
            Hashtable taulaH2=new Hashtable();
            List<String> llistaParaulesMesRepetides = new List<string>();

            String[] vParaules = frase1.Split(' ');
            foreach (String s in vParaules)
            {
                if (s.Trim().Length > 0)
                {
                    if (taulaH.Contains(s.ToLower()))
                    {
                        taulaH[s.ToLower()] = ((Int32)taulaH[s.ToLower()]) + 1;
                    }
                    else
                    {
                        taulaH.Add(s.ToLower(), 0);
                    }
                }
            }

            vParaules = frase2.Split(' ');

            foreach (String s in vParaules)
            {
                if (s.Trim().Length > 0)
                {
                    if (taulaH.Contains(s.ToLower()))
                    {
                        taulaH[s.ToLower()] = ((Int32)taulaH[s.ToLower()]) + 1;
                        if (!taulaH2.Contains(s.ToLower()))
                        {
                            taulaH2.Add(s.ToLower(), 0);
                        }
                    }
                }
            }

            llistaParaulesMesRepetides.Clear();
            foreach (String k in taulaH.Keys)
            {
                if ((Int32)taulaH[k] > 0)
                {
                    if (taulaH2.Contains(k))
                    {
                        llistaParaulesMesRepetides.Add(((Int32)taulaH[k]).ToString().PadLeft(5, '0') + k);
                    }
                }
            }
            llistaParaulesMesRepetides.Sort();
            llistaParaulesMesRepetides.Reverse();
            for (int i=0; i < llistaParaulesMesRepetides.Count;i++)
            {
                llistaParaulesMesRepetides[i] = llistaParaulesMesRepetides[i].Substring(5, llistaParaulesMesRepetides[i].Length - 5);
            }
            return (llistaParaulesMesRepetides);
        }

        public List<String> ParaulesRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            String frase1 = f1.ReadToEnd().Replace('\r',' ').Replace('\n',' ');
            String frase2 = f2.ReadToEnd().Replace('\r', ' ').Replace('\n', ' ');

            f1.Close(); f2.Close();
            return (ParaulesRepetides(frase1, frase2));
        }

        public List<String> ParaulesNoRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            List<String> llistaParaulesNoRepetides = new List<string>();

            String frase1 = f1.ReadToEnd().Replace('\r', ' ').Replace('\n', ' ');
            String frase2 = f2.ReadToEnd().Replace('\r', ' ').Replace('\n', ' ');

            f1.Close(); f2.Close();
            return (ParaulesNoRepetides(frase1, frase2));
        }

        public List<String> ParaulesMesRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            List<String> llistaParaulesMesRepetides = new List<string>();
            
            String frase1 = f1.ReadToEnd().Replace('\r', ' ').Replace('\n', ' ');
            String frase2 = f2.ReadToEnd().Replace('\r', ' ').Replace('\n', ' ');

            f1.Close(); f2.Close();
            return (ParaulesMesRepetides(frase1, frase2));
        }
    }       
}