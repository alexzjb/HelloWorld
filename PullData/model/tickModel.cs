using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.model
{
    public class Ticker
    {
        /// <summary>
        /// 
        /// </summary>
        public double last { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double buy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double sell { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double high { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double low { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double vol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long contract_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double unit_amount { get; set; }
    }

    public class tickModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Ticker ticker { get; set; }
    }
}
