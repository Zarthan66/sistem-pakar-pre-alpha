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
        //const int maxColDataset = 100;
        //const int maxRowDataset = 100;
        //List<string> pData = new List<string>();
        //List<string> gMemoryData = new List<string>();
        //string[,] gData = new string[maxRowDataset, maxColDataset];
        //int maxColCurrentData = 0;
        Rule rule = new Rule();
        string nextData;
        enum statsCondition { Unassigned = 0, True, False} 

        public Form1()
        {
            InitializeComponent();
        }

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
                    //totalGRow++;
                    dataInput = "";
                    firstColumn = false;
                }
                else if(dataset[i] == ';')
                {
                    rule.addSymptom(dataInput, indexRule);
                    indexRule++;
                    dataInput = "";
                    //totalGRow++;
                    //totalGRow = 0;
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
                    ruleTextBox.AppendText(rule.getDiseaseName(i) + " = [");
                    for (int j = 0; j < rule.getSymptomSize(i); j++)
                    {
                        ruleTextBox.AppendText(rule.getSymptomName(i, j));
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

        private void reset()
        {
            rule.clearDiseases();
            datasetTextBox.Text = "";
            ruleTextBox.Text = "";
            totalRuleTxtBox.Clear();
        }

        private void setText(string text)
        {
            datasetTextBox.Text = text;
        }

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
                    readDataset();
                    totalRuleTxtBox.AppendText(rule.getDiseaseSize().ToString());
                    datasetBtn.Text = "Open Dataset";
                    datasetBtn.ForeColor = Color.Black;
                    // start data from top left
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

        private void generateQuestion()
        {
            questionTextBox.Clear();
            bool foundResult = false;
            int counter = 0;
            for (int i = 0; i < rule.getDiseaseSize(); i++)
            {
                if (rule.getDiseaseStats(i) == (int)statsCondition.True)
                {
                    questionTextBox.AppendText("You are having " + rule.getDiseaseName(i));
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
                    questionTextBox.AppendText("Does " + nextData + " is true?");
                }
                else
                {
                    questionTextBox.AppendText("Cannot found the disease from dataset");
                }
            }
        }

        private void proccedBtn_Click(object sender, EventArgs e)
        {
            if (trueRadioBtn.Checked == true || falseRadioBtn.Checked == true)
            {
                proccedBtn.Text = "Proccessing...";
                proccedBtn.ForeColor = Color.Black;

                if(trueRadioBtn.Checked == true)
                {
                    for(int i = 0; i < rule.getDiseaseSize(); i++)
                    {
                        if (rule.getDiseaseStats(i) != (int)statsCondition.Unassigned)
                            continue;
                        for (int j = 0; j < rule.getSymptomSize(i); j++)
                        {
                            if (nextData != "" && nextData != null)
                            {
                                if (nextData == rule.getSymptomName(i, j))
                                {    
                                    rule.setSymptomStats(i, j, (int)statsCondition.True);
                                }
                                
                            }
                        }
                    }
                   
                }
                else
                {
                    for (int i = 0; i < rule.getDiseaseSize(); i++)
                    {
                        if (rule.getDiseaseStats(i) != (int)statsCondition.Unassigned)
                            continue;
                        for (int j = 0; j < rule.getSymptomSize(i); j++)
                        {
                            if(nextData != "" || nextData != null)
                            {
                                if (nextData == rule.getSymptomName(i, j))
                                {
                                    rule.setSymptomStats(i, j, (int)statsCondition.False);
                                    
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < rule.getDiseaseSize(); i++)
                {
                    if (rule.getDiseaseStats(i) != (int)statsCondition.Unassigned)
                    {
                        continue;
                    }
                    for (int j = 0; j < rule.getSymptomSize(i); j++)
                    {
                        if (rule.getSymptomStats(i, j) == (int)statsCondition.Unassigned)
                        {
                            nextData = rule.getSymptomName(i, j);
                        }
                        else if (rule.getSymptomStats(i, j) == (int)statsCondition.False)
                        {
                            rule.setDiseaseStats(i, (int)statsCondition.False);
                        }
                    }
                    
                }
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
                resultTextBox.AppendText(" = [");
                for (int j = 0; j < rule.getSymptomSize(i); j++)
                {
                    resultTextBox.AppendText(" " + rule.getSymptomStats(i, j).ToString());
                }
                resultTextBox.AppendText(" ]");
                
                
            }
        }

     
    }
}
