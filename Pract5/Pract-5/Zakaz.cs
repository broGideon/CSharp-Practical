using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_5
{
    public class Zakaz
    {
        public string Name;
        public List<PodZakaz> PodZakazs;
        public Zakaz(string Name, List<PodZakaz> podZakazs)
        {
            this.Name = Name;
            this.PodZakazs = podZakazs;
        }
    }
   
}
