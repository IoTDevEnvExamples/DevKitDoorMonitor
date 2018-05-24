# Door Monitor

## Steps to start

1. Setup development environment by following [Get Started](https://microsoft.github.io/azure-iot-developer-kit/docs/get-started/)
1. Open VS Code
1. Press **F1** or **Ctrl + Shift + P** - `IoT Workbench: Examples` and select DoorMonitor

## Deploy SendGrid service in Azure

1. click the Deploy to Azure button below and deploy SendGrid Service.

    [![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FIoTDevEnvExamples%2FDevKitDoorMonitor%2Fdeploy%2FSendGridDeploy%2Fazuredeploy.json)

1. After the deployment succeeds, click the resource and then click the **Manage** button. You are taken to your SendGrid page, and need to verify your email address.

1. On the SendGrid page, click Settings > API Keys > Create API Key. Input the API Key Name and click Create & View.

1. Copy the API key.

## Creating the Azure Logic App

1. Open the [Azure Portal](https://portal.azure.com)
1. Select the **+** or **Create a resource** button and under **Enterprise Integration** choose **Logic App**
1. Give it a Name, Resource Group, and Region (any will do) and click **Create**
1. After the logic app is created, open it
1. The designer should automatically load - if not click the **Edit** button
1. Select the **When an HTTP request is received** trigger
1. Click **New Step** to add a step to the workflow and **Add an action**
1. Search for the key word of **Send email** action.
    > NOTE: You are more than welcome to use any action you want to perform on an IoT event
1. Select the **SendGrid - Send email(V2)** action and provide the detailed information of the email.
1. Authenticate this logic app by using the SendGrid API key you created before..

1. Click the **Save** button to save this serverless workflow.
1. Click the **When a HTTP request is received** card to open and reveal the URL generated after saving.  Copy that URL.



## Provision Azure Services

1. Press **F1** or **Ctrl + Shift + P** in Visual Studio Code - **IoT Workbench:Cloud** and click **Azure Provision**
1. Select a subscription.
1. Select or choose a resource group.
1. Select or create an IoT Hub.
1. Wait for the deployment.
1. Select or create an IoT Hub device. Please take a note of the device name.
1. Create Function App.
1. Wait for the deployment.

## Deploy Function App
1. Open shakeshake\run.csx and modify the following line with the URL you created in the previous step.
```
var response = await client.PostAsync("https://prod-1....", httpContent);
```
1. ress **F1** or **Ctrl + Shift + P** in Visual Studio Code - **IoT Workbench: Cloud** and click **Azure Deploy**.
1. Wait for function app code uploading.

## Configure IoT Hub Device Connection String in DevKit

1. Connect your DevKit to your machine.
1. Press **F1** or **Ctrl + Shift + P** in Visual Studio Code - **IoT Workbench: Device** and click **config-device-connection**.
1. Hold button A on DevKit, then press rest button, and then release button A to enter config mode.
1. Wait for connection string configuration to complete.

## Upload Arduino Code to DevKit

1. Connect your DevKit to your machine.
1. Press **F1** or **Ctrl + Shift + P** in Visual Studio Code - **IoT Workbench:Device** and click **Device Upload**.
1. Wait for arduino code uploading.