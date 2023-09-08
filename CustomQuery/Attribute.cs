using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQuery
{
    class Attribute
    {
        public string Name { get; init; }

        public string TableName { get; init; }

        public char Type { get; init; }

        public override string ToString()
        {
            return $"{Name} <{Type}>";
        }
    }
}
