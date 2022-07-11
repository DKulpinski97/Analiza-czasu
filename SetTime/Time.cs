using Analiza.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analiza_czasu.SetTime
{
    class Time
    {
        public List<List<PriperWords>> deviation(List<List<OneLine>> TheSeimWords, List<List<PriperWords>> OneLine)
        {
            //Wyliczanie odchylenia standardowego
            for (int i = 1; i < TheSeimWords[0].Count; i++)
            {

                double sumary = 0;
                for (int j = 0; j < TheSeimWords.Count; j++)
                {
                    sumary += Math.Pow((TheSeimWords[j][i].milisekend - OneLine[0][i].averageTime), 2);
                }
                sumary = sumary / TheSeimWords.Count;
                sumary = Math.Sqrt(sumary);
                OneLine[0][i].deviation = Math.Round(sumary, 2);
            }
            return OneLine;
        }
        public List<List<PriperWords>> AverageTime(List<List<OneLine>> TheSeimWords, List<List<PriperWords>> OneLine)
        {
            List<List<PriperWords>> tmp = new List<List<PriperWords>>(OneLine);

            for (int i = 1; i < TheSeimWords[0].Count; i++)
            {

                int averageTime = 0;
                for (int j = 0; j < TheSeimWords.Count; j++)
                {
                    averageTime += TheSeimWords[j][i].milisekend;
                }
                tmp[0][i].averageTime = averageTime / TheSeimWords.Count;
            }
            return tmp;

        }
        public List<float> AverageTime1(List<List<OneLine>> TheSeimWords)
        {
            List<float> tmp = new List<float>();

            if(TheSeimWords.Count>=1)
            { 
                for (int i = 1; i < TheSeimWords[0].Count; i++)
                {

                    int averageTime = 0;
                    for (int j = 0; j < TheSeimWords.Count; j++)
                    {
                        averageTime += TheSeimWords[j][i].milisekend;
                    }
                    tmp.Add(averageTime / TheSeimWords.Count);
                }
            }
            return tmp;

        }
        public void Median(List<List<OneLine>> TheSeimWords, List<List<PriperWords>> OneLine)
        {
            List<float> allElements = new List<float>();
            for (int j = 1; j < TheSeimWords[0].Count; j++)
            {
                float mediane = 0;
                for (int i = 0; i < TheSeimWords.Count; i++)
                {
                    allElements.Add(TheSeimWords[i][j].milisekend);

                }
                allElements.Sort();
                if (allElements.Count % 2 == 0)
                {
                    float sumary = allElements[allElements.Count / 2];
                    sumary += allElements[(allElements.Count / 2) + 1];
                    sumary /= 2;
                    OneLine[0][j].median = sumary;
                }
                else
                {
                    //dodanie 1 bo automatycznie zaokrągla w dół 
                    float sumary = allElements[(allElements.Count / 2) + 1];
                    OneLine[0][j].median = sumary;
                }
                allElements = new List<float>();

            }
        }
        public void Dominant(List<List<OneLine>> TheSeimWords, List<List<PriperWords>> OneLine)
        {
            List<float> allElements = new List<float>();
            for (int j = 1; j < TheSeimWords[0].Count; j++)
            {
                float dominant = 0;
                for (int i = 0; i < TheSeimWords.Count; i++)
                {
                    allElements.Add(TheSeimWords[i][j].milisekend);

                }
                allElements.Sort();
                //Lista przechowująca ile wystąpień
                List<int> HowMenyDominant = new List<int>();
                //Lista zawierająca wartości 
                List<float> Time = new List<float>();
                for (int x = 0; x < allElements.Count; x++)
                {
                    //Inicjowanie czasu i wystąpień 
                    Time.Add(allElements[x]);
                    HowMenyDominant.Add(1);
                    //Sprawdzanie czy element występuje jeżeli tak usuniecie z listy i zwiększenie ilości wystąpień
                    for (int y = x + 1; y < allElements.Count; y++)
                    {
                        if (allElements[x] == allElements[y])
                        {
                            allElements.RemoveAt(y);
                            HowMenyDominant[HowMenyDominant.Count - 1]++;
                            y--;
                        }
                    }
                }
                //Jeżeli liczba elementów nie jest równa ilości liczbie dostarczonych czasów może istnieć dominanta wiec sprawdzamy
                if (allElements.Count != TheSeimWords.Count)
                {
                    int poziotion = 0;
                    int max = HowMenyDominant[0];
                    //wyszukujemy liczbę najwięcej wystąpień czasu
                    for (int x = 0; x < allElements.Count; x++)
                    {
                        if (max < HowMenyDominant[x])
                        {
                            poziotion = x;
                            max = HowMenyDominant[x];
                        }
                    }
                    //Sprawdzamy czy występuje tylko jeden max
                    int HowMenyMax = 0;
                    for (int x = 0; x < allElements.Count; x++)
                    {
                        if (max == HowMenyDominant[x])
                        {
                            HowMenyMax++;
                        }
                    }
                    if (HowMenyMax != 1)
                    {
                        OneLine[0][j].dominante = 0;
                    }
                    else
                    {
                        OneLine[0][j].dominante = Time[poziotion];
                    }
                }
                else
                {
                    OneLine[0][j].dominante = 0;
                }
                allElements = new List<float>();

            }
        }
        public void Variance(List<List<OneLine>> TheSeimWords, List<List<PriperWords>> OneLine)
        {

            for (int i = 1; i < TheSeimWords[0].Count; i++)
            {
                List<float> allElements = new List<float>();
                float sumary = 0;
                double sumaryVariance = 0;
                for (int j = 0; j < TheSeimWords.Count; j++)
                {

                    allElements.Add(TheSeimWords[j][i].milisekend);

                }
                //liczeniem średniej
                for (int j = 0; j < allElements.Count; j++)
                {
                    sumary += allElements[j];
                }
                sumary = sumary / allElements.Count;
                //liczenie wariancji
                for (int j = 0; j < allElements.Count; j++)
                {
                    sumaryVariance += Math.Round(Math.Pow((allElements[j] - sumary), 2), 4);
                }
                sumaryVariance /= allElements.Count;
                OneLine[0][i].variance = Math.Round(sumaryVariance, 2);

            }
        }
        public void Min(List<List<OneLine>> TheSeimWords, List<List<PriperWords>> OneLine)
        {
            
            for (int j = 1; j < TheSeimWords[0].Count; j++)
            {
                List<float> allElements = new List<float>();
                for (int i = 0; i < TheSeimWords.Count; i++)
                {
                    allElements.Add(TheSeimWords[i][j].milisekend);

                }
                allElements.Sort();
                OneLine[0][j].min = allElements[0];
            }
        }
        public void Max(List<List<OneLine>> TheSeimWords, List<List<PriperWords>> OneLine)
        {
            
            for (int j = 1; j < TheSeimWords[0].Count; j++)
            {
                List<float> allElements = new List<float>();
                for (int i = 0; i < TheSeimWords.Count; i++)
                {
                    allElements.Add(TheSeimWords[i][j].milisekend);

                }
                allElements.Sort();
                OneLine[0][j].max = allElements[allElements.Count-1];
            }
        }
    }
}
