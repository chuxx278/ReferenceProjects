using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesseractScripter
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        String FolderPath;
        ArrayList pdfNames = new ArrayList();
        Dictionary<string,string> dict = new Dictionary<string,string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                pdfNames = new ArrayList();
                FolderPath = folderBrowserDialog1.SelectedPath;
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                ArrayLoad(FolderPath);
                for(int x = 0; x < pdfNames.Count; x++){
                listBox1.Items.Add(pdfNames[x]);
                }
                
            }
        }
        private void ArrayLoad(string path)
        {
            System.IO.DriveInfo di = new System.IO.DriveInfo(path);
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(path);
            
            string[] extensions = new[] { ".jpg", ".tif", ".png" };
            System.IO.FileInfo[] fileNames = dirInfo.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
            foreach (System.IO.FileInfo fi in fileNames)
            {
                pdfNames.Add(fi.Name);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                
                textBox2.Text = folderBrowserDialog1.SelectedPath;
               
                
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }
        private void createDictionary(){
            dict = new Dictionary<string, string>();
            dict.Add("Czech", "ces" );
            dict.Add("Chinese (Simplified)", "chi_sim" );
            dict.Add("Chinese (Traditional)", "chi_tra" );
            dict.Add("Danish", "dan" );
            dict.Add("German", "deu" );
            dict.Add("Greek", "ell" );
            dict.Add("Croatian", "hrv" );
            dict.Add("Hungarian", "hun" );
            dict.Add("Finnish", "fin" );
            dict.Add("French","fra"  );
            dict.Add("Icelandic", "isl" );
            dict.Add("Italian", "ita" );
            dict.Add("Japanese", "jpn" );
            dict.Add("Korean", "kor" );
            dict.Add("Latvian", "lav" );
            dict.Add("Norwegian","nor" );
            dict.Add("Portuguese", "por" );
            dict.Add("Romanian", "ron" );
            dict.Add("Russian", "rus" );
            dict.Add("Slovenian", "slv" );
            dict.Add("Spanish", "spa" );
            dict.Add("Swedish", "swe" );
            dict.Add("Turkish", "tur" );
            dict.Add("Dutch", "nld" );
            dict.Add("Polish", "pol" );
            dict.Add("Afrikaans", "afr" );
            dict.Add("Arabic", "ara" );
            dict.Add("Azerbauijani", "aze" );
            dict.Add("Bulgarian", "bul" );
            dict.Add("Bengali", "ben" );
            dict.Add("Catalan", "cat" );
            dict.Add("Cherokee", "chr" );
            dict.Add("Estonian", "est" );
            dict.Add("Basque", "eus" );
            dict.Add("Frankish", "frk" );
            dict.Add("Galician", "glg" );
            dict.Add("Hebrew", "heb" );
            dict.Add("Hindi", "hin" );
            dict.Add("Indonesian", "ind" );
            dict.Add("Kannada", "kan" );
            dict.Add("Lithuanian", "lit" );
            dict.Add("Malayalam", "mal" );
            dict.Add("Maltese", "mlt" );
            dict.Add("Macedonian", "mkd" );
            dict.Add("Malay", "msa" );
            dict.Add("Albanian", "sqi" );
            dict.Add("Serbian", "srp" );
            dict.Add("Swahili", "swa" );
            dict.Add("Slovakian","slk" );
            dict.Add("Tamil","tam" );
            dict.Add("Telugu","tel" );
            dict.Add("Tagalog","tgl" );
            dict.Add("Thai","tha");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            createDictionary();
            
            string abrev = dict[comboBox1.Text];
            string fileName = "OCRBatch." + abrev + ".bat";
            string path = System.IO.Path.Combine(FolderPath, fileName);
            ArrayList pureNames = new ArrayList();
            for (int x = 0; x < pdfNames.Count; x++)
            {
                pureNames.Add(Path.GetFileNameWithoutExtension(FolderPath + "\\" + pdfNames[x]));
            }
                if (!System.IO.File.Exists(path))
                {
                    using (System.IO.StreamWriter fs = new System.IO.StreamWriter(path))
                    {
                        for (int x = 0; x < pdfNames.Count; x++)
                        {
                            string inp = "tesseract" + " " + '"' + FolderPath + "\\" + pdfNames[x] + '"' + " " + '"'+  FolderPath + "\\" + pureNames[x] + "" + '"' + " " + "-l" + " " + abrev;
                            fs.WriteLine(inp);                           
                        }
                        fs.WriteLine("del " + path);
                        fs.Close();
                    }
                }
                System.Diagnostics.Process.Start(path);
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
