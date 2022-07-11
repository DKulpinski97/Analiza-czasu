using Analiza.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analiza_czasu.File
{
    class FileSupport

    {
        public bool CheckExtension(string Readpath)
        {

            string extension = null;
            for (int i = Readpath.Length - 1; i > 0; i--)
            {
                if (Readpath[i] == '.')
                {
                    break;
                }
                else
                {
                    extension += Readpath[i];
                }
            }
            //Odwracanie strniga
            extension = ReviersArryCharToString(extension);
            if (extension == "csv")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Odczytywany plik nie ma roszeżenia csv");
                return false;
            }
        }
        string ReviersArryCharToString(string str)
        {


            char[] charExtension = str.ToCharArray();
            Array.Reverse(charExtension);
            return new string(charExtension);

        }
        public bool CheckPath(string Readpath)
        {
            if (Readpath != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Nie wybrano scieżki");
                return false;
            }
        }
        public string[] Read(string path)
        {
            try
            {
                return System.IO.File.ReadAllLines(path);
            }
            catch
            {
                MessageBox.Show("Wskazany plik jest otwarty lub nie istnieje");
            }
            return null;
        }

        public void CreataFile(string path, List<string> checkList)
        {
            //usuwanie ewentualnego pliku
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            string s = "Kod klawisza;Czy duza litera;Stan Num lock;Stan P Alt;";
            for(int i=0;i< checkList.Count;i++)
            {
                if(checkList[i]== "Średni czas oraz odchylenie standardowe")
                {
                    s += "Sredni czas;Odchylenie standardowe;";
                }
                else
                {
                    s += checkList[i] + ";";
                }
                
            }
        System.IO.File.AppendAllText(path,s+ "\n");

        }
        public void AddLineToFile(string path, List<List<PriperWords>> priperWords, List<string> checkList)
        {
            string word = "";
            for (int i = 0; i < priperWords.Count; i++)
            {
                for (int j = 0; j < priperWords[i].Count; j++)
                {
                    word = priperWords[i][j].code.ToString() + ";" + priperWords[i][j].bigLiter.ToString() + ";" + priperWords[i][j].numLock + ";" +
                        priperWords[i][j].PAlt.ToString() + ";";
                    for(int x=0;x< checkList.Count;x++)
                    {
                        if (checkList[x] == "Średni czas oraz odchylenie standardowe")
                        {
                            word += priperWords[i][j].averageTime + ";" + priperWords[i][j].deviation+";";
                        }
                        else if(checkList[x] == "Mediana")
                        {
                            word += priperWords[i][j].median + ";";
                        }
                        else if (checkList[x] == "Dominanta")
                        {
                            word += priperWords[i][j].dominante + ";";
                        }
                        else if (checkList[x] == "Variancja")
                        {
                            word += priperWords[i][j].variance + ";";
                        }
                        else if (checkList[x] == "Min")
                        {
                            word += priperWords[i][j].min + ";";
                        }
                        else if (checkList[x] == "Max")
                        {
                            word += priperWords[i][j].max + ";";
                        }
                    }
                    System.IO.File.AppendAllText(path, word);
                    System.IO.File.AppendAllText(path, "\n");
                    word = "";
                }
                System.IO.File.AppendAllText(path, "\n");
            }

        }
    }
}
