using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Pakar
{
    internal class Diseases
    {
        protected string name;
        protected int stats;
        List<Symptoms> symptoms = new List<Symptoms>();

        public Diseases(string name)
        {
            this.name = name;
            
        }

        /*
        public void emptyDiseaseClass()
        {
            symptopms.Clear();
            this.name = "";
        }*/

        public string getDiseaseName()
        {
            return this.name;
        }

        public int getStats()
        {
            return this.stats;
        }

        public string getSymptomName(int index)
        {
            return symptoms[index].getSymptomName();
        }

        public int getSymptomStats(int index)
        {
            return symptoms[index].getSymptomStats();
        }

        public void setDiseaseStats(int value)
        {
            this.stats = value;
        }

        public void setSymptomStats(int index, int value)
        {
            symptoms[index].setSymptomStats(value);
        }

        public void addSymptom(string name)
        {
            Symptoms newSymptom = new Symptoms(name);
            symptoms.Add(newSymptom);
        }

        public int getSymptomSize()
        {
            return symptoms.Count;
        }
    }
}
