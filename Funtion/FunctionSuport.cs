using System;
using System.Collections.Generic;
using System.Text;
using Analiza.File;

namespace Analiza_czasu.Funtion
{
    class FunctionSuport
    {

        public void DeliteRepit(List<List<OneLine>> Words)
        {
            List<List<OneLine>> WordsCopy = new List<List<OneLine>>(Words);
            int tmp = 0;
            List<List<OneLine>> WordsWithDeliteRepit = new List<List<OneLine>>();
            for (int i = 0; i < Words.Count; i++)
            {
                for (int j = i + 1; j < WordsCopy.Count; j++)
                {
                    for (int x = 0; x < Words[i].Count; x++)
                    {
                        //Sprawdzanie czy porównujemy słowa tej samej długości
                        if (Words[i].Count == WordsCopy[j].Count)
                        {
                            //Sprawdzanie znaków czy są identyczne
                            if (Words[i][x].code == WordsCopy[j][x].code &&
                                Words[i][x].bigLiter == WordsCopy[j][x].bigLiter &&
                                Words[i][x].numLock == WordsCopy[j][x].numLock &&
                                Words[i][x].PAlt == WordsCopy[j][x].PAlt
                                )
                            {
                                tmp++;
                            }
                        }
                        else
                        {
                            tmp = 0;
                            break;
                        }
                    }
                    if (tmp == Words[i].Count)
                    {
                        Words[i][0].HowMeny++;
                        Words.RemoveAt(j);
                        WordsCopy.RemoveAt(j);
                        j--;
                    }
                    tmp = 0;
                }

            }
        }

    }    
}
