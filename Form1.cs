using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Analiza.File;
using Analiza.Shering;
using Analiza_czasu.Button;
using Analiza_czasu.File;
using Analiza_czasu.Funtion;
using Analiza_czasu.Wraiting;

namespace Analiza_czasu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string RedPath = null;
        string PathSave = null;
        FunctionButton functionButton = new FunctionButton();
        FunctionSuport functionSuport = new FunctionSuport();
        List<List<OneLine>> Words = new List<List<OneLine>>();
        List<List<OneLine>> WordsCopy = new List<List<OneLine>>();
        private void LoadPath_Click(object sender, EventArgs e)
        {
            RedPath = null;
            PathToLoad.Text = "";
            var path = new OpenFileDialog();
            RedPath = functionButton.TakePathRead(path, PathToLoad);
        }

        private void SavePath_Click(object sender, EventArgs e)
        {
            PathSave = null;
            PathToSave.Text = "";
            var path = new FolderBrowserDialog();
            PathSave = functionButton.TakePathToSave(path, PathToSave);
        }

        private void LoadFile_Click(object sender, EventArgs e)
        {
            FileSupport fileSupport = new FileSupport();
            List<OneLine> Lains = new List<OneLine>();
            Shering shering = new Shering();
            Sumary.Items.Clear();
            if (RedPath == null)
            {
                MessageBox.Show("Nie wybrano ścierzki do pliku");
                return;
            }
            if (functionButton.CheckPath(RedPath) == true)
            {
                string[] allLine = fileSupport.Read(RedPath);
                if(allLine==null)
                {
                    return;
                }
                //Przepisywanie lnijki do konkretnych zmienych
                for (int i = 1; i < allLine.Length; i++)
                {

                    OneLine oneLine = new OneLine();
                    shering.SheringLine(oneLine, allLine[i]);
                    Lains.Add(oneLine);
                }
                allLine = null;
                //łączenie symboli w jeden ciąg
                Words = shering.CreatWord(Lains);
                //Z powodu błędu przy wczytywaniu nie potrafie znależ trzeba usunąć nadmiarowy wiersz ostati
                Words.RemoveAt(Words.Count - 1);
                //Utworzenie kopi i listy słów oraz usuniecie powturzeń
                WordsCopy = new List<List<OneLine>>(Words);
                functionSuport.DeliteRepit(WordsCopy);
                //Zapisywanie wyników do listy
                Wraiting.wraiting wraiting = new Wraiting.wraiting();
                wraiting.WratingSumary(Sumary, WordsCopy);
            }
            else
            {
                MessageBox.Show("Wybrany plik nie ma roszerzenai CSV");
            }
        }

        private void SetTime_Click(object sender, EventArgs e)
        {
            int HowMenyCanDelite = 0;
            if (HowMenyDelite.Text!="")
            {
                try
                {
                    HowMenyCanDelite = Convert.ToInt32(HowMenyDelite.Text);
                    if(HowMenyCanDelite<0 || HowMenyCanDelite>100)
                        {
                        MessageBox.Show("Ilość usuwanych próbek musi być liczbą z zakresu od 0 do 100");
                        return;
                        }
                }
                catch
                {
                    MessageBox.Show("Należy  podać wartość liczbową z zakresu od 0 do 100");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Należy  podać wartość liczbową z zakresu od 0 do 100");
                return;
            }
            if(Words.Count>0&& PathSave!=null)
            {
                List<string> checkList = new List<string>();
                foreach(string s in CheckStatistic.CheckedItems)
                {
                    checkList.Add(s);
                }
                if(CheckStatistic.CheckedItems.Count==0)
                {
                    MessageBox.Show("Należy wybrać przynajmiej jedną metode statystyczną");
                    return;
                }
                Button.FunctionButton functionButton = new FunctionButton();
                File.FileSupport fileSupport = new FileSupport();
                List<List<PriperWords>> PriperData = new List<List<PriperWords>>();
                DataProcessing dataProcessing = new DataProcessing();
                PriperData=dataProcessing.PriperData(Words, CheckStatistic, HowMenyCanDelite);
                string path=functionButton.PrimerName(PathToSave, PathToLoad);

                fileSupport.CreataFile(path, checkList);
                fileSupport.AddLineToFile(path, PriperData, checkList);

                MessageBox.Show("Plik został stworzony");
            }
            else
            {
                MessageBox.Show("Nie załadowano pliku lub nie wybrano ścierzki do zapisu");
            }
        }
    }
}
