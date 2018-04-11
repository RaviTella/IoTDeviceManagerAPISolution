using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Devices;
using System.Text;
using IoTDeviceManagerAPI.Model;

namespace IoTDeviceManagerAPI.Controllers
{
     [Route("api/DeviceManager")]
    public class DeviceManagerController : Controller
    {
        static ServiceClient serviceClient;
        static string connectionString = "";

        [HttpPost]         
        public MessageContent CloudToDeviceMessage(MessageContent content)
        {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            SendCloudToDeviceMessageAsync(content).Wait();
            return content;
            
        }

        private async static Task SendCloudToDeviceMessageAsync(MessageContent content)
        {
            var commandMessage = new Message(Encoding.ASCII.GetBytes(content.MessageBody));
            await serviceClient.SendAsync(content.DeviceID, commandMessage);
        }
    }
}