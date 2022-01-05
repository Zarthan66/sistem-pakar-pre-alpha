using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Pakar
{
    internal class Symptoms
    {
        
        string name;
        int stats;
        public Symptoms(string name)
        {
            this.name = name;
            
        }

        public string getSymptomName()
        {
            return name;
        }

        public int getSymptomStats()
        {
            return stats;
        }

        public void setSymptomStats(int value)
        {
            this.stats = value;
        }
    }
}
