using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Pakar
{
    internal class Rule
    {
        List<Diseases> diseases = new List<Diseases>();
        public void addDisease(string name)
        {
            Diseases newDisease = new Diseases(name);
            diseases.Add(newDisease);
        }

        public int getDiseaseStats(int index)
        {
            return diseases[index].getStats();
        }

        public void setDiseaseStats(int index, int value)
        {
            diseases[index].setDiseaseStats(value);
        }

        public void setSymptomStats(int diseaseIndex, int symptomIndex, int value)
        {
            diseases[diseaseIndex].setSymptomStats(symptomIndex, value);
        }

        public int getSymptomStats(int diseaseIndex, int symptomIndex)
        {
            return diseases[diseaseIndex].getSymptomStats(symptomIndex);
        }

        public void removeDisease(int diseaseIndex)
        {
            diseases.Remove(diseases[diseaseIndex]);
        }

        public void clearDiseases()
        {
            diseases.Clear();
        }

        public void addSymptom(string symptomName, string diseaseName)
        {
            bool found = false;
            for(int i = 0; i < diseases.Count; i++)
            {
                if(diseases[i].getDiseaseName() == symptomName)
                {
                    diseases[i].addSymptom(symptomName);
                    found = true;
                    break;
                }
            }
            if(found == false)
                Console.WriteLine("[Error] Cant find the disease for addSymptom(), Value = " + symptomName);
        }

        public void addSymptom(string symptomName, int diseaseIndex)
        {
            bool found = false;
            if(diseases.Count > diseaseIndex)
            {
                diseases[diseaseIndex].addSymptom(symptomName);
                found = true;
            }
            if (found == false)
                Console.WriteLine("[Error] Cant find the disease for addSymptom(), Value = " + symptomName);
        }

        public int getDiseaseSize()
        {
            return diseases.Count;
        }

        public int getSymptomSize(int diseaseIndex)
        {
            return diseases[diseaseIndex].getSymptomSize();
        }

        public string getDiseaseName(int diseaseIndex)
        {
            return diseases[diseaseIndex].getDiseaseName();
        }

       

        public string getSymptomName(int diseaseIndex, int symptomIndex)
        {
            if (diseaseIndex < diseases.Count())
                return diseases[diseaseIndex].getSymptomName(symptomIndex);
            else
                return "NULL";
        }
    }
}
