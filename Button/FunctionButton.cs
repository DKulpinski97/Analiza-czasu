using Analiza_czasu.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analiza_czasu.Button
{
    class FunctionButton
    {
        public string TakePathRead(OpenFileDialog Path, TextBox PathToRead)
        {

            string tmp = null;
            if (Path.ShowDialog() == DialogResult.OK)
            {
                //Wyświetlanie plików w folderze
                Path.Filter = "Text files(*.tex)|*.csv|All files(*.*)|*.*";
                tmp = Path.FileName;
                PathToRead.Text = tmp;
            }
            return tmp;
        }
        public string TakePathToSave(FolderBrowserDialog Path, TextBox PathToSave)
        {

            string tmp = null;
            if (Path.ShowDialog() == DialogResult.OK)
            {
                //Wyświetlanie plików w folderze
                PathToSave.Text = Path.SelectedPath;
            }
            return Path.SelectedPath;
        }
        public bool CheckPath(string Path)
        {
            FileSupport file = new FileSupport();
            if (file.CheckPath(Path) == true && file.CheckExtension(Path) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string PrimerName(TextBox PathToSave, TextBox PathToRead)
        {
            string tmp = "";
            string savePath1 = PathToSave.Text;
            string path = PathToRead.Text;
            int lenghData = 0;
            for (int i = path.Length - 1; i > 0; i--)
            {
                if (path[i] == '\\')
                {
                    break;
                }
                lenghData++;

            }
            for (int i = path.Length - lenghData; i < path.Length - 5; i++)
            {
                tmp += path[i];
            }
            string newName = "\\" + tmp + " C.csv";

            savePath1 += newName;
            return savePath1;
        }
    }
}
