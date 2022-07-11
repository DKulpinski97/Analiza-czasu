
namespace Analiza_czasu
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.PathToLoad = new System.Windows.Forms.TextBox();
            this.PathToSave = new System.Windows.Forms.TextBox();
            this.LoadPath = new System.Windows.Forms.Button();
            this.SavePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadFile = new System.Windows.Forms.Button();
            this.Sumary = new System.Windows.Forms.ListBox();
            this.SetTime = new System.Windows.Forms.Button();
            this.CheckStatistic = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HowMenyDelite = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PathToLoad
            // 
            this.PathToLoad.Location = new System.Drawing.Point(12, 29);
            this.PathToLoad.Name = "PathToLoad";
            this.PathToLoad.Size = new System.Drawing.Size(151, 20);
            this.PathToLoad.TabIndex = 0;
            // 
            // PathToSave
            // 
            this.PathToSave.Location = new System.Drawing.Point(12, 130);
            this.PathToSave.Name = "PathToSave";
            this.PathToSave.Size = new System.Drawing.Size(151, 20);
            this.PathToSave.TabIndex = 1;
            // 
            // LoadPath
            // 
            this.LoadPath.Location = new System.Drawing.Point(12, 55);
            this.LoadPath.Name = "LoadPath";
            this.LoadPath.Size = new System.Drawing.Size(151, 23);
            this.LoadPath.TabIndex = 2;
            this.LoadPath.Text = "Wybierz plik";
            this.LoadPath.UseVisualStyleBackColor = true;
            this.LoadPath.Click += new System.EventHandler(this.LoadPath_Click);
            // 
            // SavePath
            // 
            this.SavePath.Location = new System.Drawing.Point(13, 157);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(150, 23);
            this.SavePath.TabIndex = 3;
            this.SavePath.Text = "Miejsce zapisu";
            this.SavePath.UseVisualStyleBackColor = true;
            this.SavePath.Click += new System.EventHandler(this.SavePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ścieżka do pliku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ścieżka do zapisu";
            // 
            // LoadFile
            // 
            this.LoadFile.Location = new System.Drawing.Point(12, 84);
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.Size = new System.Drawing.Size(151, 23);
            this.LoadFile.TabIndex = 6;
            this.LoadFile.Text = "Załaduj plik";
            this.LoadFile.UseVisualStyleBackColor = true;
            this.LoadFile.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // Sumary
            // 
            this.Sumary.FormattingEnabled = true;
            this.Sumary.Location = new System.Drawing.Point(189, 29);
            this.Sumary.Name = "Sumary";
            this.Sumary.Size = new System.Drawing.Size(176, 147);
            this.Sumary.TabIndex = 7;
            // 
            // SetTime
            // 
            this.SetTime.Location = new System.Drawing.Point(371, 146);
            this.SetTime.Name = "SetTime";
            this.SetTime.Size = new System.Drawing.Size(219, 44);
            this.SetTime.TabIndex = 8;
            this.SetTime.Text = "Wyznacz czasy dla danych i wygeneruj plik";
            this.SetTime.UseVisualStyleBackColor = true;
            this.SetTime.Click += new System.EventHandler(this.SetTime_Click);
            // 
            // CheckStatistic
            // 
            this.CheckStatistic.FormattingEnabled = true;
            this.CheckStatistic.Items.AddRange(new object[] {
            "Średni czas oraz odchylenie standardowe",
            "Mediana",
            "Dominanta",
            "Variancja",
            "Min",
            "Max"});
            this.CheckStatistic.Location = new System.Drawing.Point(371, 29);
            this.CheckStatistic.Name = "CheckStatistic";
            this.CheckStatistic.Size = new System.Drawing.Size(219, 94);
            this.CheckStatistic.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Podsumowanie załadowanego pliki";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Metody statystyczne";
            // 
            // HowMenyDelite
            // 
            this.HowMenyDelite.Location = new System.Drawing.Point(13, 205);
            this.HowMenyDelite.Name = "HowMenyDelite";
            this.HowMenyDelite.Size = new System.Drawing.Size(128, 20);
            this.HowMenyDelite.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Maksymalna ilość odrzuconych próbek w procentach";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 237);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HowMenyDelite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CheckStatistic);
            this.Controls.Add(this.SetTime);
            this.Controls.Add(this.Sumary);
            this.Controls.Add(this.LoadFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.LoadPath);
            this.Controls.Add(this.PathToSave);
            this.Controls.Add(this.PathToLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathToLoad;
        private System.Windows.Forms.TextBox PathToSave;
        private System.Windows.Forms.Button LoadPath;
        private System.Windows.Forms.Button SavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoadFile;
        private System.Windows.Forms.ListBox Sumary;
        private System.Windows.Forms.Button SetTime;
        private System.Windows.Forms.CheckedListBox CheckStatistic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HowMenyDelite;
        private System.Windows.Forms.Label label5;
    }
}

