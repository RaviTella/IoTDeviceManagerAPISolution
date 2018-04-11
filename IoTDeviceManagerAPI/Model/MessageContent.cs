using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTDeviceManagerAPI.Model
{
    public class MessageContent
    {
        public virtual string DeviceID { get; set; }
        public virtual string MessageBody { get; set; }
    }
}
