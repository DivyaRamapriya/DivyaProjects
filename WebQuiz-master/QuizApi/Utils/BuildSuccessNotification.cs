using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace QuizApi.Utils
{
    public static class BuildSuccessNotification
    {
        public static async Task Notify()
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync("http://bartender-demo.cubitonline.com/api/v1/hiring/buildsuccess", 
                    new
                    {
                        Time = DateTime.UtcNow,
                        MAC = GetMacAddress(),
                        IP = GetLocalIpAddress()
                    });
                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync();
            }
        }

        private static string GetMacAddress()
        {
            var macAddresses = string.Empty;

            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus != OperationalStatus.Up) continue;
                macAddresses += nic.GetPhysicalAddress().ToString();
                break;
            }

            return macAddresses;
        }

        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "No-IP";
        }
    }
}
