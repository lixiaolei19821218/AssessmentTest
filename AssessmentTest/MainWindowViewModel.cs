using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssessmentTest
{
    class MainWindowViewModel
    {
        public string PricingSpecName { get; set; }
        public IEnumerable<string> PricingSpecs { get; set; }
        public DateTime TimeStamp { get; set; }
        //public IEnumerable<> PricingSpecRows
    }
}
