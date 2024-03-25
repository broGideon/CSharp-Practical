using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract___6
{
    public class Figure
    {
        public string Name;
        public int Dlina;
        public int Shirina;
        public Figure(string Name, int Dlina, int Shirina) 
        {
            this.Name = Name;
            this.Dlina = Dlina;
            this.Shirina = Shirina;
        }
        public Figure() { }
    }
}
