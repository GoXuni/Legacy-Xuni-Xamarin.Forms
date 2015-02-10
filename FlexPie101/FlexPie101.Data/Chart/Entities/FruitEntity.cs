using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexPieDemo.Data.Chart.Entities
{
    public class FruitEntity
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        public FruitEntity(string name, decimal value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
