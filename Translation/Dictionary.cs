using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analiza_czasu.Translation
{
    class Dictionary
    {
        public string mause(int i)
        {
            string button = null;
            switch (i)
            {
                case 1:
                    button = "LP";
                    break;
                case 2:
                    button = "PP";
                    break;
                case 4:
                    button = "SP";
                    break;


            }
            return button;
        }
        public string button(int i)
        {
            string button = null;
            switch (i)
            {
                case 8:
                    button = "Backspace";
                    break;
                case 13:
                    button = "Enter";
                    break;
                case 9:
                    button = "Tab";
                    break;
                case 20:
                    button = "CapsLock";
                    break;
                case 160:
                    button = "Shift";
                    break;
                case 16:
                    button = "Shift";
                    break;
                case 162:
                    button = "L Ctrl";
                    break;
                case 163:
                    button = "P Ctrl";
                    break;
                case 91:
                    button = "L Start";
                    break;
                case 92:
                    button = "P Start";
                    break;
                case 164:
                    button = "L ALT";
                    break;
                case 165:
                    button = "P ALT";
                    break;
                case 32:
                    button = "Spa";
                    break;
                case 144:
                    button = "Num Lock";
                    break;
                case 27:
                    button = "Esc";
                    break;
            }
            return button;
        }
        public string arrow(int i)
        {
            string button = null;
            switch (i)
            {
                case 37:
                    button = "w lewo";
                    break;
                case 38:
                    button = "w góre";
                    break;
                case 39:
                    button = "w prawo";
                    break;
                case 40:
                    button = "w dół";
                    break;


            }
            return button;
        }
        public string ShiftNumber(int i)
        {
            string button = null;
            switch (i)
            {
                case 48:
                    button = ")";
                    break;
                case 49:
                    button = "!";
                    break;
                case 50:
                    button = "@";
                    break;
                case 51:
                    button = "#";
                    break;
                case 52:
                    button = "$";
                    break;
                case 53:
                    button = "%";
                    break;
                case 54:
                    button = "^";
                    break;
                case 55:
                    button = "&";
                    break;
                case 56:
                    button = "*";
                    break;
                case 57:
                    button = "(";
                    break;



            }
            return button;
        }
        public string F(int i)
        {
            string button = "F" + (i - 111).ToString();
            return button;
        }
        public string RareButtons(int i)
        {
            string button = null;
            switch (i)
            {
                case 45:
                    button = "Insert";
                    break;
                case 46:
                    button = "Delete";
                    break;
                case 36:
                    button = "Home";
                    break;
                case 35:
                    button = "End";
                    break;
                case 33:
                    button = "Page UP";
                    break;
                case 34:
                    button = "Page Down";
                    break;
                case 44:
                    button = "Prt Scr";
                    break;
                case 145:
                    button = "Scroll Lock";
                    break;
            }
            return button;
        }
        public string NumLock(int i)
        {
            string button = null;
            if (i >= 96 && i <= 105)
            {
                return "N" + (i - 96);
            }

            switch (i)
            {

                case 111:
                    button = "N /";
                    break;
                case 106:
                    button = "N *";
                    break;
                case 109:
                    button = "N -";
                    break;
                case 107:
                    button = "N +";
                    break;
                case 110:
                    button = "N Del";
                    break;

            }
            return button;
        }

        public string OtherButon(int i)
        {
            string button = null;
            switch (i)
            {
                case 189:
                    button = "-";
                    break;
                case 187:
                    button = "=";
                    break;
                case 219:
                    button = "[";
                    break;
                case 221:
                    button = "]";
                    break;
                case 186:
                    button = ";";
                    break;
                case 222:
                    button = "'";
                    break;
                case 220:
                    button = "\\";
                    break;
                case 188:
                    button = ",";
                    break;
                case 190:
                    button = ".";
                    break;
                case 191:
                    button = "/";
                    break;
                case 192:
                    button = "`";
                    break;
            }
            return button;
        }
        public string ShiftOtherButon(int i)
        {
            string button = null;
            switch (i)
            {
                case 186:
                    button = ":";
                    break;
                case 187:
                    button = "+";
                    break;
                case 189:
                    button = "_";
                    break;
                case 188:
                    button = "<";
                    break;
                case 190:
                    button = ">";
                    break;
                case 191:
                    button = "?";
                    break;
                case 192:
                    button = "~";
                    break;
                case 219:
                    button = "{";
                    break;
                case 220:
                    button = "|";
                    break;
                case 221:
                    button = "}";
                    break;

                    break;
                case 222:
                    button = "\"";
                    break;


            }

            return button;
        }
        public string BigAltChar(int i)
        {
            string button = null;
            switch (i)
            {
                case 65:
                    button = "Ą";
                    break;
                case 67:
                    button = "Ć";
                    break;
                case 69:
                    button = "Ę";
                    break;
                case 76:
                    button = "Ł";
                    break;
                case 78:
                    button = "Ń";
                    break;
                case 79:
                    button = "Ó";
                    break;
                case 83:
                    button = "Ś";
                    break;
                case 88:
                    button = "Ź";
                    break;
                case 90:
                    button = "Ż";
                    break;

            }
            return button;
        }
        public string SmalAltChar(int i)
        {
            string button = null;
            switch (i)
            {
                case 65:
                    button = "ą";
                    break;
                case 67:
                    button = "ć";
                    break;
                case 69:
                    button = "ę";
                    break;
                case 76:
                    button = "ł";
                    break;
                case 78:
                    button = "ń";
                    break;
                case 79:
                    button = "ó";
                    break;
                case 83:
                    button = "ś";
                    break;
                case 88:
                    button = "ź";
                    break;
                case 90:
                    button = "ż";
                    break;

            }
            return button;
        }
    }
}
