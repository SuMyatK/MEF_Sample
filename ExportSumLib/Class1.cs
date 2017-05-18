using Contracts;
using System.ComponentModel.Composition;

namespace ExportSumLib
{
    [Export(typeof(IComponent))]
    public class SumOfNumberComponent : IComponent
    {
        public string Description
        {
            get { return "Summation of components"; }
        }

        public string ManipulateOperation(params double[] args)
        {
            string result = "";
            double count = 0;
            bool first = true;

            foreach (double d in args)
            {
                if(first)
                {
                    count = d;
                    first = false;
                }else
                {
                    count += d;
                }

                result += d.ToString() + " + ";
            }

            return result.Trim('+', ' ') + "=" + count.ToString();
            
        }
    }
}
