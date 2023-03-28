using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Accounting
{
    internal class Transactions
    {
        public Transaction[] Transaction { get; set; }
     }

    public class Transaction
    {
        public string ID { get; set; }
        public string Mt940content { get; set; }


    }

}
