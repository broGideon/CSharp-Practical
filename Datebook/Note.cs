using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebook
{
    public class Note
    {
        public string Name {get; set;}
        public string Description;
        public DateTime Date;
        public Note(string Name, string Description, DateTime Date) 
        { 
            this.Name = Name;
            this.Description = Description;
            this.Date = Date;
        }

    }
}
