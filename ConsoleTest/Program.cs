using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Helper;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            /* ******  Test 读取json ******** */
            //Console.WriteLine("Program Start");
            //string task = Helper.FileHelper.ReadFile("Data\\data.json");

            //var obj = JsonHelper.FromJson<Data.Model.TaskModel>(task);

            //foreach(var o in obj.data)
            //{

            //}
            //Console.WriteLine($"{obj.name}");

            /* ***** 测试时间转换   ***** */
            //System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区

            //Console.WriteLine( $" 1525948697: { startTime.AddMilliseconds(Convert.ToInt64("1525948697000"))}");


            /* ****** Test  文档下载代码  *********** */
            //HttpPost("http://172.16.75.217:8081/DocumentApi/File/DownloadFile", "5B4C093E1FDD81DCCCEFB0D211043EA93618E36D07BA63A898EFC8C2E91E240A3E199AE1D7095618");
            //string[] testStr = new string[3] { "afbc", "afdjak", "fdsa" };
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject( testStr));

            /*  ******** 测试DAL   ********* */

            DAL.MyTestEntities ef = new DAL.MyTestEntities();
            var kLines = ef.kLine.Where(p => p.type == "1min" && p.symbol == "eth_usd" && p.contract_type == "this_week" && p.id>= 1525873860000).ToList();
            var jsonData = new
            {
                data = kLines
            };
            Console.WriteLine( Newtonsoft.Json.JsonConvert.SerializeObject(jsonData));
            

            /* ****** 测试输入退格 ********* */
            for (int i = 0; i < 100; i++)
            {
                Console.Write("\b");
                Console.Write("/");
                Thread.Sleep(330);
                Console.Write("\b");
                Console.Write("-");
                Thread.Sleep(330);
                Console.Write("\b");
                Console.Write("\\");
                Thread.Sleep(330);
            }
            Console.ReadLine();
        }
        #region POST

        public static void HttpPost(string url, string body)
        {
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url+"/"+body);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/text";

            FileStream fs = null;
            try
            {

                byte[] buffer = encoding.GetBytes(body);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                Stream receiveStream = response.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, encode);
                //Console.WriteLine("\r\nResponse stream received.");
                Char[] read = new Char[256];
                // Reads 256 characters at a time.    
                int count = readStream.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    Console.Write(str);
                    count = readStream.Read(read, 0, 256);
                }



                //Stream newStream = response.GetResponseStream();
                //byte[] data = new byte[0];
                //if (newStream.CanRead)
                //    newStream.Read(data, 0, data.Length);
                //newStream.Close();


                //string filename = "D:\\aa.pdf";
                //string folder = Path.GetDirectoryName(filename);
                //if (!Directory.Exists(folder))
                //    Directory.CreateDirectory(folder);
                ////HttpWebRequest request = CreateRequest(url, "GET");
                ////byte[] data = GetData(request);
                //fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                //fs.Write(data, 0, data.Length);
            }
            finally
            {
                if (fs != null) fs.Close();
            }

        }
        #endregion
    }
    #region
    public class placeOrder
    {
        public placeOrder()
        {
            this.feature = new List<string>();
            this.feature.Add("eth_usd");
        }
        private placeOrder _instance = null;
        public placeOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new placeOrder();
                return _instance;
            }
        }
        public List<string> feature
        {
            get;
            set;
        }
    }
    public class spread
    {
        public spread()
        {
            this.feature = new List<string>();
            this.feature.Add("eth_usd");
        }
        private spread _instance = null;
        public spread Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new spread();
                return _instance;
            }
        }
        public List<string> feature
        {
            get;
            set;
        }
    }
    public class stoploss
    {
        public stoploss()
        {
            this.feature = new List<string>();
            this.feature.Add("eth_usd");
        }
        private stoploss _instance = null;
        public stoploss Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new stoploss();
                return _instance;
            }
        }
        public List<string> feature
        {
            get;
            set;
        }
    }
    public class dealSize
    {
        public dealSize()
        {
            this.size =1;
        }
        private dealSize _instance = null;
        public dealSize Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new dealSize();
                return _instance;
            }
        }
        public int size
        {
            get;
            set;
        }
    }
    public class dealLogic
    {
        public dealLogic()
        {
            this.feature = new List<string>();
            this.feature.Add("eth_usd");
        }
        public List<string> feature
        {
            get;
            set;
        }
    }
    public class market
    {
        public market()
        {
            this.feature = new List<string>();
            this.feature.Add("eth_usd");
        }
        private market _instance = null;
        public market Instance
        {
            get { if (_instance == null)
                    _instance = new market();
                return _instance;
            }
        }
        public List<string> feature
        {
            get;
            set;
        } 
    }
    #endregion
}
