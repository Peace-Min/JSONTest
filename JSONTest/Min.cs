using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JSONTest
{
    public class Min
    {
        public string Id { get; set; }
        public Bim Person { get; set; }

        public Min()
        {
            Id = "MMM";
            Person = new Bim();
        }
    }

    public class Bim
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Bim()
        {
            Name = "name";
            Age = 25;
        }
    }
}
