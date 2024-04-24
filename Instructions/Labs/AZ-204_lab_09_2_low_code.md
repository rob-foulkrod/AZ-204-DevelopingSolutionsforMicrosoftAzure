---
lab:
    az204Title: 'Lab 09: Publish and subscribe to Event Grid events'
    az204Module: 'Learning Path 09: Develop event-based solutions'
---

# Lab 09: Publish and subscribe to Event Grid events

## Instructions

In this exercise, you created a new subscription, validated its registration, and then recorded the credentials required to publish a new event to the topic.

### Exercise 3: Publish Event Grid events from .NET

#### Task 1: Create a .NET project

1. On the **Start** screen, select the **Visual Studio Code** tile.

1. On the **File** menu, select **Open Folder**.

1. In the **File Explorer** window that opens, browse to **Allfiles (F):\\Allfiles\\Labs\\09\\Starter\\EventPublisher**, and then select **Select Folder**.

1. In the **Visual Studio Code** window, from its top menu bar, go to **Terminal** menu and select **New Terminal**.

1. Run the following command to create a new .NET project named **EventPublisher** in the current folder:

    ```powershell
    dotnet new console --framework net8.0 --name EventPublisher --output . 
    ```

    > **Note**: The **dotnet new** command will create a new **console** project in a folder with the same name as the project.

1. Run the following command to import version 4.11.0 of **Azure.Messaging.EventGrid** from NuGet:

    ```powershell
    dotnet add package Azure.Messaging.EventGrid --version 4.11.0
    ```
    

    > **Note**: The **dotnet add package** command will add the **Microsoft.Azure.EventGrid** package from NuGet. For more information, go to [Azure.Messaging.EventGrid](https://www.nuget.org/packages/Azure.Messaging.EventGrid/4.11.0).


1. Run the following command to build the .NET web application:

    ```powershell
    dotnet build
    ```

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 2: Modify the Program class to connect to Event Grid

1. On the **Explorer** pane of the **Visual Studio Code** window, open the **Program.cs** file.

1. On the code editor tab for the **Program.cs** file, delete all the code in the existing file.
  
1. Add the following of code:

    ```csharp
    using Azure;
    using Azure.Messaging.EventGrid;
    using System;
    using System.Threading.Tasks;    
    public class Program
    {
        private const string topicEndpoint = "<topic-endpoint>";
        /* Update the topicEndpoint string constant by setting its value to the Topic
           Endpoint of the Event Grid topic that you recorded previously in this lab. */
        private const string topicKey = "<topic-key>";
        /* Update the topicKey string constant by setting its value to the Key of the Event Grid topic that you recorded previously in this lab. */     
        public static async Task Main(string[] args)
        {
            //Add Main code here
        }
    }
    ```
1. In line 7, replace the `<topic-endpoint>` placeholder with the value of the Event Grid topic endpoint you recorded earlier in this lab.

1. In line 10, replace the `<topic-key>` placeholder with the value of the Event Grid topic access key you recorded earlier in this lab.

#### Task 3: Publish new events

1. Replace the **Main** method of **Program.cs** file with the following code:
   
    ```csharp
    public static async Task Main(string[] args)
    {   
        /* To create a new variable named "endpoint" of type "Uri", 
           using the "topicEndpoint" string constant as a constructor parameter */
        Uri endpoint = new Uri(topicEndpoint);

        /* To create a new variable named "credential" of type "AzureKeyCredential",
           use the "topicKey" string constant as a constructor parameter. */
        AzureKeyCredential credential = new AzureKeyCredential(topicKey);

        /* To create a new variable named "client" of type "EventGridPublisherClient", 
           using the "endpoint" and "credential" variables as constructor parameters */
        EventGridPublisherClient client = new EventGridPublisherClient(endpoint, credential);

        /* To create a new variable named "firstEvent" of type "EventGridEvent",
           and populate that variable with sample data */        
        EventGridEvent firstEvent = new EventGridEvent(
            subject: $"New Employee: Alba Sutton",
            eventType: "Employees.Registration.New",
            dataVersion: "1.0",
            data: new
            {
                FullName = "Alba Sutton",
                Address = "4567 Pine Avenue, Edison, WA 97202"
            }
        );

        /* To create a new variable named "secondEvent" of type "EventGridEvent",
           and populate that variable with sample data */
        EventGridEvent secondEvent = new EventGridEvent(
            subject: $"New Employee: Alexandre Doyon",
            eventType: "Employees.Registration.New",
            dataVersion: "1.0",
            data: new
            {
                FullName = "Alexandre Doyon",
                Address = "456 College Street, Bow, WA 98107"
            }
        );

        /* To asynchronously invoke the "EventGridPublisherClient.SendEventAsync"
           method using the "firstEvent" variable as a parameter */
        await client.SendEventAsync(firstEvent);
        Console.WriteLine("First event published");

        /* To asynchronously invoke the "EventGridPublisherClient.SendEventAsync"
           method using the "secondEvent" variable as a parameter */
        await client.SendEventAsync(secondEvent);
        Console.WriteLine("Second event published");
    }
    ```
    > **Note**: To know more about **[AzureKeyCredential](https://docs.microsoft.com/dotnet/api/azure.azurekeycredential)**
  
    > **Note**: To know more about Event Grid, click the following links: 
    - **[EventGridPublisherClient](https://learn.microsoft.com/dotnet/api/azure.messaging.eventgrid.eventgridpublisherclient)**
    
    - **[EventGridEvent](https://learn.microsoft.com/dotnet/api/azure.messaging.eventgrid.eventgridevent)**

    - **[EventGridPublisherClient.SendEventAsync](https://learn.microsoft.com/dotnet/api/azure.messaging.eventgrid.eventgridpublisherclient.sendeventasync)**


1. Save the **Program.cs** file.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. Run the following command to run the .NET web application:

    ```powershell
    dotnet run
    ```

    > **Note**: If there are any build errors, review the **Program.cs** file in the **Allfiles (F):\\Allfiles\\Labs\\09\\Solution\\EventPublisher** folder.

1. Observe the success message output from the currently running console application.

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 4: Observe published events

1. Return to the browser window with the **Azure Event Grid Viewer** web application.

1. Review the **Employees.Registration.New** events that were created by your console application.

1. Select any of the events and review its JSON content.

1. Return to the Azure portal.

#### Review

In this exercise, you published new events to your Event Grid topic by using a .NET console application.
