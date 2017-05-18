using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ImportingLib
{
    public class Importer
    {
        [ImportMany(typeof(IComponent))]
        private IEnumerable<Lazy<IComponent>> operations;

        public void DoImport()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Add all the parts found in all assembilies in the same directory as the executing program
            catalog.Catalogs.Add(
                new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                );

            //Create the CompositionContainer with the parts in the catalog
            CompositionContainer container = new CompositionContainer(catalog);

            //Fill the imports of this object
            container.ComposeParts(this);
        }

        public int AvailableNumberOfOperation
        {
            get { return operations != null ? operations.Count() : 0; }
        }

        public List<string> CallAllComponents(params double[] args)
        {
            var result = new List<string>();
            foreach(Lazy<IComponent> com in operations)
            {
                Console.WriteLine(com.Value.Description);
                result.Add(com.Value.ManipulateOperation(args));
            }

            return result;
        }
    }
}
