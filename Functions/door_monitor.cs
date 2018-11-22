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
            var response = await client.PostAsync("https://prod-00.eastasia.logic.azure.com:443/workflows/7c2424a2aae24f2eaf0dae5e89ca1e5b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=XDsdlVvlgPeC4kjdM3EgiiAm-5c5Rzv0Ny53u6C5cFI", httpContent);

        if (!response.IsSuccessStatusCode)
        {
            // Show the error for the failure.
            var errorMessage = response.StatusCode.ToString();
            throw new Exception(
                $"SendGrid failed to send email. Code: {response.StatusCode}, error: {errorMessage}");
        }            
        }
    }
}
