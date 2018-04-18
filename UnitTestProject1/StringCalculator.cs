using System;

namespace UnitTestProject1
{
    public class StringCalculator
    {
        private IStore _objectstore;

        public StringCalculator()
        {

        }
        public StringCalculator(IStore objStore)
        {
            this._objectstore = objStore;
        }
        public bool IsPrime(int num)
        {
            return true;
        }
        public int add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            var allnums = input.Split(',');
            int sum = 0;
            foreach (var eachnum in allnums)
            {
                sum += int.Parse(eachnum);
            }
           
            if (_objectstore != null)
            {
                if (IsPrime(sum))
                {
                    _objectstore.Save(sum);
                }
            }
            return sum;

            
        }
     }
 }