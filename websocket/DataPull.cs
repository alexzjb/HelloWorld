using System;
using System.Linq;
using System.Timers;
using Tools;
using Topshelf;

namespace websocket
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Logger.Info("Start");
                var rc = HostFactory.Run(x =>
                {
                    x.Service<TaskRunner>(s =>
                    {
                        s.ConstructUsing(name => new TaskRunner());
                        s.WhenStarted(tc => tc.Start());
                        s.WhenStopped(tc => tc.Stop());
                    });
                    x.RunAsLocalSystem();

                    x.SetDescription("Sample Topshelf Host");
                    x.SetDisplayName("Stuff");
                    x.SetServiceName("Stuff");
                });

                var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
                Environment.ExitCode = exitCode;

            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    }


    public class TaskRunner
    {
        string url = System.Configuration.ConfigurationSettings.AppSettings["url"]?.ToString();
        string channel = System.Configuration.ConfigurationSettings.AppSettings["channels"]?.ToString();
        WebSocketService wss;
        WebSocketBase wb;

        public TaskRunner()
        {
            StartWebSocket();
        }
        void StartWebSocket()
        {
            wss = new BuissnesServiceImpl();
            wb = new WebSocketBase(url, wss);
            wb.start();
            wb.send(channel);
            //断开重连时，需要重新订阅
            while (true)
            {
                if (wb.isReconnect())
                {
                    wb.send(channel);
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
        public void Start()
        {
            Tools.Logger.Info("TaskRunner Start");

        }
        public void Stop()
        {
            wb.stop();
            Tools.Logger.Info("TaskRunner Stop");
        }
    }
}
