using System;
using System.Text;

static HttpClient client = new HttpClient();
public static async Task Run(string myIoTHubMessage, TraceWriter log)
{
    log.Info($"C# IoT Hub trigger function processed a message: {myIoTHubMessage}");
    var httpContent = new StringContent(myIoTHubMessage, Encoding.UTF8, "application/json");
    var response = await client.PostAsync("https://prod-1....", httpContent);

    if (!response.IsSuccessStatusCode)
    {
        // Show the error for the failure.
        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception(
            $"SendGrid failed to send email. Code: {response.StatusCode}, error: {errorMessage}");
    }
}
  