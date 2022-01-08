using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace Sistem_Pakar
{
    public partial class Form1 : Form
    {
        Rule rule = new Rule();
        // Kondisi ditemukannya penyakit yang semua gejalanya sudah terpenuhi dengan value True
        bool foundResult = false;
        // nextData representasikan gejala yang dicari atau ditanyakan
        string nextData;
        enum statsCondition { Unassigned = 0, True, False} 

        public Form1()
        {
            InitializeComponent();
        }

        // Membaca dataset berupa file dengan format .txt dengan pembacaan ( p1,g1,g2,g3,...,gx; )
        // ke local array
        private void readDataset()
        {
            var dataset = datasetTextBox.Text;
            string dataInput = "";
            int indexRule = 0;

            bool firstColumn = true;
            for(int i = 0; i < dataset.Length; i++)
            {
                if(dataset[i] == ',' && firstColumn == true)
                {
                    rule.addDisease(dataInput);
                    dataInput = "";
                    firstColumn = false;
                    
                }
                else if(dataset[i] == ',' && firstColumn == false)
                {
                    rule.addSymptom(dataInput, indexRule);
                    dataInput = "";
                    firstColumn = false;
                }
                else if(dataset[i] == ';')
                {
                    rule.addSymptom(dataInput, indexRule);
                    indexRule++;
                    dataInput = "";
                    firstColumn = true;
                }
                else
                {
                    dataInput += dataset[i];
                }
                
            }

            // membuat rule berdasarkan file atau dataset yang telah dimasukan
            if (rule.getDiseaseSize() > 0)
            {
                for (int i = 0; i < rule.getDiseaseSize(); i++)
                {
                    ruleTextBox.AppendText(rule.getDiseaseName(i) + " = [" + rule.getSymptomName(i, 0));
                    for (int j = 1; j < rule.getSymptomSize(i); j++)
                    {
                        ruleTextBox.AppendText(", " + rule.getSymptomName(i, j));
                    }
                    ruleTextBox.AppendText("]");
                    ruleTextBox.AppendText(Environment.NewLine);
                }
            }
            else
            {
                ruleTextBox.Text = "Rule are empty";
            }
        }

        // Mereset semua local variabel
        private void reset()
        {
            rule.clearDiseases();
            datasetTextBox.Text = "";
            ruleTextBox.Text = "";
            totalRuleTxtBox.Clear();
        }

        // Membuka dataset
        private void btnDataset_Click(object sender, EventArgs e)
        {
            datasetBtn.Text = "Opening...";
            datasetBtn.ForeColor = Color.Gray;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    reset();
                    var sr = new StreamReader(openFileDialog1.FileName);
                    datasetTextBox.AppendText(sr.ReadToEnd());
                    // Proses pemasukan dataset ke local variabel
                    readDataset();
                    totalRuleTxtBox.AppendText(rule.getDiseaseSize().ToString());
                    datasetBtn.Text = "Open Dataset";
                    datasetBtn.ForeColor = Color.Black;
                    // bertanya tentang gejala mulai dari gejala paling kiri atas (0,0)
                    if(rule.getDiseaseSize() > 0)
                    {
                        nextData = rule.getSymptomName(0,0);
                        generateQuestion();
                    }
                    
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            else
            {
                datasetBtn.Text = "Open Dataset";
                datasetBtn.ForeColor = Color.Black;
            }
        }

        // Melempar pertanyaan dan kesimpulan
        private void generateQuestion()
        {
            questionTextBox.Clear();
            int counter = 0;
            for (int i = 0; i < rule.getDiseaseSize(); i++)
            {
                if (rule.getDiseaseStats(i) == (int)statsCondition.True)
                {
                    questionTextBox.AppendText("Anda terdiagnosa memiliki penyakit " + rule.getDiseaseName(i));
                    questionTextBox.AppendText(Environment.NewLine);
                    foundResult = true;
                    nextData = "";
                }
                else if(rule.getDiseaseStats(i) == (int)statsCondition.False)
                {
                    counter++;
                    if (counter == rule.getDiseaseSize())
                    {
                        nextData = "";
                    }
                }
            }

            if(!foundResult)
            {
                if (nextData != "" && nextData != null)
                {
                    questionTextBox.AppendText("Apakah anda mengalami gejala \"" + nextData + "\"");
                }
                else
                {
                    questionTextBox.AppendText("Penyakit tidak ditemukan berdasarkan data yang ada");
                }
            }
        }

        // Set status gejala
        private void proccedBtn_Click(object sender, EventArgs e)
        {
            // pencegahan agar nextData di set hanya sekali
            bool newNextDataFound = false;
            // var sementara nextData, di masukan ke nextData setelah iterasi pencarian gejala selesai
            string newNextData = "";

            if (trueRadioBtn.Checked == true || falseRadioBtn.Checked == true)
            {
                // jika user menyatakan gejalanya adalah true
                if(trueRadioBtn.Checked == true)
                {
                    // Cari gejala, jika ditemukan set value 
                    for(int i = 0; i < rule.getDiseaseSize(); i++)
                    {
                        // Berhenti jika penyakit ditemukan
                        if (foundResult == true)
                            break;

                        if (rule.getDiseaseStats(i) != (int)statsCondition.Unassigned)
                        {
                            // Berhenti jika penyakit ditemukan, tampilkan hasil
                            if (rule.getDiseaseStats(i) == (int)statsCondition.True)
                            {
                                foundResult = true;
                                generateQuestion();
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        
                        // Jika stats penyakit = 0 (Unassigned)
                        for (int j = 0; j < rule.getSymptomSize(i); j++)
                        {
                            if (nextData != "" && nextData != null)
                            {
                                // ketika gejala ditemukan
                                if (nextData == rule.getSymptomName(i, j))
                                {    
                                    rule.setSymptomStats(i, j, (int)statsCondition.True);
                                  
                                    // Setelah gejala ketemu, langsung lanjut ke penyakit selanjutnya
                                    break;
                                }
                            }
                        }
                    }
                }
                // jika user menyatakan gejalanya adalah false
                else
                {
                    // Cari gejala, jika ditemukan set value 
                    for (int i = 0; i < rule.getDiseaseSize(); i++)
                    {
                        // Berhenti jika penyakit ditemukan
                        if (foundResult == true)
                            break;

                        if (rule.getDiseaseStats(i) != (int)statsCondition.Unassigned)
                        {
                            // Berhenti jika penyakit ditemukan, tampilkan hasil
                            if (rule.getDiseaseStats(i) == (int)statsCondition.True)
                            {
                                foundResult = true;
                                generateQuestion();
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        // Jika stats penyakit = 0 (Unassigned)
                        for (int j = 0; j < rule.getSymptomSize(i); j++)
                        {
                            if (nextData != "" && nextData != null)
                            {
                                // ketika gejala ditemukan
                                if (nextData == rule.getSymptomName(i, j))
                                {
                                    rule.setSymptomStats(i, j, (int)statsCondition.False);
                                    rule.setDiseaseStats(i, (int)statsCondition.False);
                                    // Setelah gejala ketemu, langsung lanjut ke penyakit selanjutnya
                                    break;
                                }
                            }
                        }
                    }
                }

                for(int i = 0; i < rule.getDiseaseSize(); i++)
                {
                    if(rule.getDiseaseStats(i) == (int)statsCondition.Unassigned)
                    {
                        for(int j = 0; j < rule.getSymptomSize(i); j++)
                        {
                            if(rule.getSymptomStats(i,j) == (int)statsCondition.Unassigned)
                            {
                                // Set data yang akan di tanyakan
                                nextData = rule.getSymptomName(i,j);
                                newNextDataFound = true;
                                break;
                            }
                        }
                        if (newNextDataFound)
                            break;
                    }
                }
                
                
                

                // cek kalau ada penyakit dengan gejala semua true
                checker();
                generateQuestion();
                proccedBtn.Text = "Procced";
                proccedBtn.ForeColor = Color.Black;
            }
            else
            {
                proccedBtn.Text = "[Error]";
                proccedBtn.ForeColor = Color.Red;
                
            }
            cekRuleStats();
        }

        // cek kalau ada penyakit dengan gejala semua true
        private void checker()
        {
            int counter = 0;
            for(int i = 0; i < rule.getDiseaseSize(); i++)
            {
                for(int j = 0; j < rule.getSymptomSize(i); j++)
                {
                    if(rule.getSymptomStats(i,j) == (int)statsCondition.True)
                    {
                        counter++;
                        if(counter == rule.getSymptomSize(i))
                        {
                            rule.setDiseaseStats(i, (int)statsCondition.True);
                        }
                    }
                        
                }
                counter = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            for (int x = 0; x < rule.getDiseaseSize(); x++)
            {
                resultTextBox.AppendText(rule.getDiseaseName(x));
                resultTextBox.AppendText(Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            for (int y = 0; y < rule.getDiseaseSize(); y++)
            {
                resultTextBox.AppendText("[");
                for (int z = 0; z < rule.getSymptomSize(y); z++)
                {
                    resultTextBox.Text += " " + rule.getSymptomName(y, z);

                }
                resultTextBox.AppendText(" ]");
                resultTextBox.AppendText(Environment.NewLine);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cekRuleStats();
        }

        private void cekRuleStats()
        {
            resultTextBox.Clear();
            for (int i = 0; i < rule.getDiseaseSize(); i++)
            {
                resultTextBox.AppendText(rule.getDiseaseName(i).ToString());
                resultTextBox.AppendText(" (" + rule.getDiseaseStats(i).ToString() + ")");
                resultTextBox.AppendText(" = [" + rule.getSymptomStats(i, 0).ToString());
                for (int j = 1; j < rule.getSymptomSize(i); j++)
                {
                    resultTextBox.AppendText("," + rule.getSymptomStats(i, j).ToString());
                }
                resultTextBox.AppendText(" ]");
            }
        }
    }
}
