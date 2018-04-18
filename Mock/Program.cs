using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class customer
    {
        public bool addCustomer()
        {
            var objmail = new mymail();
            objmail.send();

            //ADO. Net code..#
            return true;
        }

    }

    public class mymail
    {
        public mymail()
        {
        }

        public bool send()
        {
            throw new NotImplementedException();
        }
    }
}
