using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexPieDemo.Data.Model
{
    public class FruitEntity
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public FruitEntity(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
