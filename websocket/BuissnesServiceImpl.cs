using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace websocket
{
    class BuissnesServiceImpl:WebSocketService
    {
        public void onReceive(string msg) {
            Tools.Logger.Info(msg);
            if (msg.Equals("{\"event\":\"pong\"}")) return;
            try
            {
                using (var entity = new MyTestEntities())
                {
                    entity.socketData.Add(new socketData()
                    {
                        dataJson = msg,
                        stime = DateTime.Now
                    });
                    entity.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Tools.Logger.Error(ex.Message);
            }
        }
    }
}
