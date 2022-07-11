using Analiza.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analiza_czasu.Translation
{
    class TranslateCode
    {
        public string Char(OneLine code)
        {
            string button = "";
            char chars = '\0';
            Dictionary dictionary = new Dictionary();
            int Numberbutton = Convert.ToInt32(code.code);
            bool Bigliter = Convert.ToBoolean(code.bigLiter);
            bool PAlt = Convert.ToBoolean(code.PAlt);
            bool NumLock = Convert.ToBoolean(code.numLock);


            if (Numberbutton >= 1 && Numberbutton <= 4)
            {
                button = dictionary.mause(Numberbutton);
            }
            else if (Numberbutton >= 37 && Numberbutton <= 40)
            {
                button = dictionary.arrow(Numberbutton);
            }
            else if (Numberbutton >= 48 && Numberbutton <= 57)
            {
                if (Bigliter == true)
                {
                    button = dictionary.ShiftNumber(Numberbutton);
                }
                else
                {
                    chars = (char)Numberbutton;
                    button = Convert.ToString(chars);
                }

            }
            else if (Numberbutton >= 65 && Numberbutton <= 90)
            {
                if (Bigliter == true && PAlt == true)
                {
                    button = dictionary.BigAltChar(Numberbutton);
                }
                else if (Bigliter == false && PAlt == true)
                {
                    button = dictionary.SmalAltChar(Numberbutton);
                }
                else if (Bigliter == false && PAlt == false)
                {
                    button = Convert.ToChar(Numberbutton + 32).ToString();
                }
                else
                {
                    button = Convert.ToChar(Numberbutton).ToString();
                }
            }
            else if (NumLock == true && (Numberbutton >= 96 && Numberbutton <= 111))
            {
                button = dictionary.NumLock(Numberbutton);
            }
            else if (Numberbutton >= 112 && Numberbutton <= 123)
            {
                button = dictionary.F(Numberbutton);
            }
            else if (Numberbutton >= 186 && Numberbutton <= 222)
            {
                if (Bigliter == true)
                {
                    button = dictionary.ShiftOtherButon(Numberbutton);
                }
                else
                {
                    button = dictionary.OtherButon(Numberbutton);
                }

            }
            else
            {
                button = dictionary.RareButtons(Numberbutton);
            }
            if (button == null)
            {
                button = dictionary.button(Numberbutton);
            }
            return button;
        }
    }
}
