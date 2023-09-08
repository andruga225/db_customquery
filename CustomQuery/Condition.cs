using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQuery
{
    class Condition
    {
        public string TableName { get; init; }

        public string AttributeName { get; init; }

        public string Operator { get; init; }

        public object Value { get; init; }
    }
}
