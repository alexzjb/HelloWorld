﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    public class SaveData
    {
        public string dataPath;


        public SaveData()
        {
            dataPath = System.Configuration.ConfigurationSettings.AppSettings["dataPath"].ToString();
        }
        public void AppendData_kline(string type,string value)
        {
            AppendData("kline", type, value);
        }
        public void AppendData_depth(string type, string value)
        {
            AppendData("depth", type, value);
        }
        public void AppendData_ticker(string type, string value)
        {
            AppendData("ticker", type, value);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="symble">kline</param>
        /// <param name="datatype">1min</param>
        /// <param name="dataValue"></param>
        public void AppendData(string symble,string datatype,string dataValue)
        {
            DotNet.Utilities.FileOperateHelper.FileAdd($"{ dataPath}//{symble}//",$"{symble}_{datatype}_{DateTime.Now.Date.ToString("yyyyMMdd")}", dataValue);
        }
    }
}
