using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.model
{
    public class klineModel
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 开
        /// </summary>
        public double start { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public double high { get; set; }
        /// <summary>
        /// 低
        /// </summary>
        public double low { get; set; }
        /// <summary>
        /// 收
        /// </summary>
        public double end { get; set; }
        /// <summary>
        /// 交易量
        /// </summary>
        public int vol { get; set; }
        /// <summary>
        /// 交易量转化BTC或LTC数量
        /// </summary>
        public double num { get; set; }
    }
}
