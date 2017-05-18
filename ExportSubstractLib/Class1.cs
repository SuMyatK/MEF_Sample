using Contracts;
using System.ComponentModel.Composition;

namespace ExportSubstractLib
{
    [Export(typeof(IComponent))]
    public class SubstractOfNumberComponent : IComponent
    {
        public string Description
        {
            get { return "Subtraction of components"; }
        }

        public string ManipulateOperation(params double[] args)
        {
            string result = "";
            double count = 0;
            bool first = true;

            foreach(double d in args)
            {
                if(first)
                {
                    count = d;
                    first = false;
                }else
                {
                    count -= d;
                }
                result += d.ToString() + " - ";
            }

            return result.Trim('-', ' ') + " = " + count.ToString();
        }
    }
}
