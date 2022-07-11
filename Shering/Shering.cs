using Analiza.File;
using System;
using System.Collections.Generic;
using System.Text;

namespace Analiza.Shering
{
    class Shering
    {
        public void SheringLine(OneLine priper, string line)
        {
            string code = null;
            int tmp = 0;
            for(int i=0;i< line.Length;i++)
            {
                if (line[i] == ';')
                {
                    //Jest to wartość pustego wiersza
                    if (line != ";;;;;")
                    {
                        if (tmp == 0)
                        {
                            priper.code = Int32.Parse(code);
                        }
                        if (tmp == 1)
                        {
                            priper.bigLiter = Boolean.Parse(code);
                        }
                        if (tmp == 2)
                        {
                            priper.numLock = Boolean.Parse(code);
                        }
                        if (tmp == 3)
                        {
                            priper.PAlt = Boolean.Parse(code);
                        }
                        if (tmp == 4)
                        {
                            priper.milisekend = Int32.Parse(code);
                        }
                        tmp++;
                        code = "";
                        i++;
                    }

                }
                code += line[i];

            }
            priper.focus = code;
        }

        public List<List<OneLine>>CreatWord(List<OneLine> Lains)
        {
            List<List<OneLine>> Words = new List<List<OneLine>>();
            List<OneLine> Word = new List<OneLine>();
            for(int i =0;i<Lains.Count;i++)
            {
                if(Lains[i].code!=0)
                {
                    Word.Add(Lains[i]);
                }
                else
                {
                    Words.Add(Word);
                    Word = new List<OneLine>();
                }
            }
            Words.Add(Word);
            return Words;
        }
    }
}
