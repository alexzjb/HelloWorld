using System.Collections.Generic;

namespace Data.Model
{
    public class TaskModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TaskInfo> data { get; set; }
    }
    public class TaskInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int timespan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ParaItem> para { get; set; }
    }
    public class ParaItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string paraid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string paralist { get; set; }
    }

}
