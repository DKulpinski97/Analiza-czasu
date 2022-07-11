using Analiza.File;
using Analiza_czasu.Translation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Analiza_czasu.Wraiting
{
    class wraiting
    {
        public void WratingSumary(ListBox Sumary,List<List<OneLine>>Words)
        {
            string tmp = "";
            TranslateCode translateCode = new TranslateCode();
            for (int i=0;i<Words.Count;i++)
            {
                for(int j=0;j<Words[i].Count;j++)
                {
                    tmp += translateCode.Char(Words[i][j]) + " ";
                }
                tmp += "   " + Words[i][0].HowMeny.ToString();
                Sumary.Items.Add(tmp);
                tmp = "";
            }
            
        }
        public void WraitingTime(List<int>Time,int HowMenySymbols,List<TextBox>textBoxes)
        {
            Time.Sort();
            int min = Time[0];
            int max = Time[Time.Count-1];
            int midium = 0;
            int midiumTimeToPressButton = 0;
            for(int i=0;i<Time.Count;i++)
            {
                midium += Time[i];
            }
            midium = midium / Time.Count;
            midiumTimeToPressButton = midium / HowMenySymbols;
            textBoxes[0].Text = max.ToString();
            textBoxes[1].Text = midium.ToString();
            textBoxes[2].Text = min.ToString();
            textBoxes[3].Text = midiumTimeToPressButton.ToString();
        }
    }
}
