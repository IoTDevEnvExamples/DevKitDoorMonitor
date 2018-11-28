using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System;
using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

namespace IoTWorkbench
{
    public static class door_monitor
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("door_monitor")]
        public static async void Run([IoTHubTrigger("%eventHubConnectionPath%", Connection = "eventHubConnectionString")]EventData message, ILogger log)
        {
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
            string myEventHubMessage = Encoding.UTF8.GetString(message.Body.Array);
            var httpContent = new StringContent(myEventHubMessage, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://prod-07..yourLogicAppURL..", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                // Show the error for the failure.
                var errorMessage = response.Content.ReadAsStringAsync();
                throw new Exception(
                    $"SendGrid failed to send email. Code: {response.StatusCode}, error: {errorMessage}");
            }
        }
    }
}
