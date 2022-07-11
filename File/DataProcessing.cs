using Analiza.File;
using Analiza_czasu.SetTime;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Analiza_czasu.File
{
    class DataProcessing
    {
        public List<List<PriperWords>> PriperData(List<List<OneLine>>words, CheckedListBox CheckStatistic,int HowMenyCanDelite)
        {
            List<List<OneLine>> wordsCopi = new List<List<OneLine>>(words);
            List<List<PriperWords>> PriperData = new List<List<PriperWords>>();
            List<List<PriperWords>> tmp1 = new List<List<PriperWords>>();
            //Wybieranie pasujących słów które są identyczne
            for (int i=0;i< wordsCopi.Count;i++)
            {
                List<List<OneLine>> TheSeimWords = new List<List<OneLine>>();
                TheSeimWords.Add(wordsCopi[i]);
                for (int j=i+1;j< wordsCopi.Count;j++)
                {
                    int tmp = 0;
                    if(wordsCopi[i].Count==wordsCopi[j].Count)
                    {
                        for(int x=0;x<wordsCopi[j].Count;x++)
                        {
                            //Sprawdzanie czy podane symbole są identyczne
                            if (wordsCopi[i][x].code == wordsCopi[j][x].code && wordsCopi[i][x].bigLiter == wordsCopi[j][x].bigLiter &&
                                wordsCopi[i][x].focus == wordsCopi[j][x].focus && wordsCopi[i][x].numLock== wordsCopi[j][x].numLock &&
                                wordsCopi[i][x].PAlt == wordsCopi[j][x].PAlt)
                            {
                                tmp++;
                            }
                            else
                            {
                                break;
                            }
                            if(tmp==wordsCopi[j].Count)
                            {
                                TheSeimWords.Add(wordsCopi[j]);
                                wordsCopi.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                tmp1 = new List<List<PriperWords>>();
                //Wyznaczanie średniego czasu oraz odchylenia standardowego
                tmp1 = SetTimeWord(TheSeimWords, CheckStatistic);
                //Wyuznaczanie Mediany
                PriperData.Add(tmp1[0]);
            }
            DeliteWordsNotSatisfyingTheDeviations(words, PriperData, HowMenyCanDelite);


            return PriperData;
        }
        //Zawracanie zmian w Priper data nastąpi przez wysyłanie
        public void DeliteWordsNotSatisfyingTheDeviations(List<List<OneLine>> words, List<List<PriperWords>> PriperData,int HowMenyCanDelite)
        {

            List<List<OneLine>> wordsCopi = new List<List<OneLine>>(words);
            //Wybieranie pasujących słów które są identyczne
            for (int i = 0; i < wordsCopi.Count; i++)
            {
                List<List<OneLine>> TheSeimWords = new List<List<OneLine>>();
                TheSeimWords.Add(wordsCopi[i]);
                
                for (int j = i + 1; j < wordsCopi.Count; j++)
                {
                    int tmp = 0;
                    if (wordsCopi[i].Count == wordsCopi[j].Count)
                    {
                        for (int x = 0; x < wordsCopi[j].Count; x++)
                        {
                            //Sprawdzanie czy podane symbole są identyczne
                            if (wordsCopi[i][x].code == wordsCopi[j][x].code && wordsCopi[i][x].bigLiter == wordsCopi[j][x].bigLiter &&
                                wordsCopi[i][x].focus == wordsCopi[j][x].focus && wordsCopi[i][x].numLock == wordsCopi[j][x].numLock &&
                                wordsCopi[i][x].PAlt == wordsCopi[j][x].PAlt)
                            {
                                tmp++;
                            }
                            else
                            {
                                break;
                            }
                            if (tmp == wordsCopi[j].Count)
                            {
                                TheSeimWords.Add(wordsCopi[j]);
                                wordsCopi.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                for(int j=0;j< TheSeimWords.Count;j++)
                {
                    float HowMenySample = TheSeimWords.Count;
                    for (int x=1;x<TheSeimWords[0].Count;x++)
                    {
                        //Sprawdzanie czy ciągi spełniają warunek czyli czas wprowadzania 2 znaków nie przekracza czasu średniego +- odchylenie standardowe 
                        if ((TheSeimWords[j][x].milisekend>= PriperData[i][x].averageTime- PriperData[i][x].deviation)&& (TheSeimWords[j][x].milisekend <= PriperData[i][x].averageTime + PriperData[i][x].deviation))
                        {

                        }
                        else
                        {
                            TheSeimWords.RemoveAt(j);
                            j--;
                            break;
                        }
                    }
                    //Jeżeli liczba wykasowanych próbek nie przekracza wskazanej ilości wylicz nowy średni czas
                    if (TheSeimWords.Count >= HowMenySample * ((100- HowMenyCanDelite)/100))
                    {
                        Time time = new Time();
                        List<float> tmp = new List<float>();
                        tmp=time.AverageTime1(TheSeimWords);
                        for(int x=1;x< tmp.Count;x++)
                        {
                            PriperData[i][x].averageTime = tmp[x-1];
                        }
                        
                    }
                }
            }
        }
        public List<List<PriperWords>> SetTimeWord(List<List<OneLine>> TheSeimWords, CheckedListBox CheckStatistic)
        {
            Time time = new Time();
            List<List<PriperWords>> OneLine = new List<List<PriperWords>>();
            TheSeimWords = DeliteBadWords(TheSeimWords);
            OneLine.Add(priperString(TheSeimWords));
            foreach (string s in CheckStatistic.CheckedItems)
            {
                if (s == "Średni czas oraz odchylenie standardowe")
                {
                    //Wyznaczanie czasu średniego
                    time.AverageTime(TheSeimWords, OneLine);
                    //Wyznaczanie odchylenia standardowego
                    time.deviation(TheSeimWords, OneLine);
                }
                else if (s == "Mediana")
                {
                    //Wyznaczanie mediany
                    time.Median(TheSeimWords, OneLine);
                }
                else if (s == "Dominanta")
                {
                    //Dominanta
                    time.Dominant(TheSeimWords, OneLine);
                }
                else if (s == "Variancja")
                {
                    //Wariancia
                    time.Variance(TheSeimWords, OneLine);
                }
                else if (s == "Min")
                {
                    //Wariancia
                    time.Min(TheSeimWords, OneLine);
                }
                else if (s == "Max")
                {
                    //Wariancia
                    time.Max(TheSeimWords, OneLine);
                }
            }
            return OneLine;
        }
        public List<PriperWords> priperString(List<List<OneLine>> TheSeimWords)
        {
            List<PriperWords> tmp = new List<PriperWords>();

            //Kopiowanie danych
            for (int i = 0; i < TheSeimWords[0].Count; i++)
            {
                PriperWords oneLine = new PriperWords();
                oneLine.code = TheSeimWords[0][i].code;
                oneLine.bigLiter = TheSeimWords[0][i].bigLiter;
                oneLine.numLock = TheSeimWords[0][i].numLock;
                oneLine.PAlt = TheSeimWords[0][i].PAlt;
                tmp.Add(oneLine);
            }
            return tmp;
        }
        public List<List<OneLine>>  DeliteBadWords(List<List<OneLine>> TheSeimWords)
        {
            //Usuwanie słów które mają przekroczony czas pisania miedzy znakami
            for (int i=0;i< TheSeimWords.Count;i++)
            {
                for(int j=1;j< TheSeimWords[i].Count;j++)
                {
                    if(TheSeimWords[i][j].milisekend==-1)
                    {
                        TheSeimWords.RemoveAt(i);
                        i--;
                        break;
                    }
                }
                
            }
            //Usuwanie słów kture zmieniły fokus
            for (int i = 0; i < TheSeimWords.Count; i++)
            {
                for (int j = 0; j < TheSeimWords[i].Count; j++)
                {
                    if (j+1!=TheSeimWords[i].Count && TheSeimWords[i][j].focus != TheSeimWords[i][j+1].focus)
                    {
                        TheSeimWords.RemoveAt(i);
                        i--;
                        break;
                    }
                }

            }
            return TheSeimWords;
        }
    }
}
