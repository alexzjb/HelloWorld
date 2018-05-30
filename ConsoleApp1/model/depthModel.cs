using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.model
{
    public class depthModel
    {
        /// <summary>
        /// asks
        /// </summary>
        public List<List<double>> asks { get; set; }
        /// <summary>
        /// bids
        /// </summary>
        public List<List<double>> bids { get; set; }
    }
}
