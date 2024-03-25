using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract___8
{
    internal class Result
    {
        public string Name;
        public int CharMinute;
        public float CharSecond;
        public int Error;
        public Result(string Name, int CharMinute, float CharSecond, int Error)
        {
            this.Name = Name;
            this.CharMinute = CharMinute;
            this.CharSecond = CharSecond;
            this.Error = Error;
        }
        public Result() { }
    }
}
