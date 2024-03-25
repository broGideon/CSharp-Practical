using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_9
{
   public class HotKey
    {
        public string Path;
        public Char Key;
        public  HotKey(string Path, Char Key)
        {
            this.Path = Path;
            this.Key = Key;
        }
    }
}
