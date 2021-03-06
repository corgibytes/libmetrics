using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Corgibytes.Freshli.Lib
{
    public class LibYearResult : IEnumerable<LibYearPackageResult>
    {
        public double Total { get; private set; }

        public int Skipped { get; private set; }
        public int UpgradesAvailable { get; private set; }

        private List<LibYearPackageResult> _packageResults =
          new List<LibYearPackageResult>();

        public void Add(LibYearPackageResult result)
        {
            _packageResults.Add(result);

            if (result.UpgradeAvailable)
            {
                UpgradesAvailable++;
            }

            if (result.Skipped)
            {
                Skipped++;
            }
            else
            {
                Total += result.Value;
            }
        }

        public LibYearPackageResult this[string packageName]
        {
            get { return _packageResults.Find(item => item.Name == packageName); }
        }

        public IEnumerator<LibYearPackageResult> GetEnumerator()
        {
            return _packageResults.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var writer = new StringWriter();
            writer.WriteLine("{ _packagesValues: [");
            foreach (var result in this)
            {
                if (!result.Skipped)
                {
                    writer.WriteLine($"{result},");
                }
            }

            writer.Write($"], Total: {Total} }}");

            return writer.ToString();
        }
    }
}
