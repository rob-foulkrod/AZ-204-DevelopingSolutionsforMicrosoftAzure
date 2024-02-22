---
lab:
    az204Title: 'Lab 10: Asynchronously process messages by using Azure Service Bus Queues'
    az204Module: 'Learning Path 10: Develop message-based solutions'
---

# Lab 10: Asynchronously process messages by using Azure Service Bus Queues (Advanced Path)

## Microsoft Azure user interface

Given the dynamic nature of Microsoft cloud tools, you might experience Azure UI changes that occur after the development of this training content. As a result, the lab instructions and lab steps might not align correctly.

Microsoft updates this training course when the community alerts us to needed changes. However, cloud updates occur frequently, so you might encounter UI changes before this training content updates. **If this occurs, adapt to the changes, and then work through them in the labs as needed.**

## Multi Path Labs

This lab has been structured to give learners a choice in their lab experience. There are three approaches to progress through this lab. The default experience is the standard path.

- Path 1 (Low-Code - quick or non-dev approach)
- Path 2 (Standard - typical lab implementation - recommended)
- Path 3 (Advanced - limited code given)

## Instructions


### Before you start

#### Sign in to the lab environment

Sign in to your Windows 10 virtual machine (VM) by using the following credentials:

- Username: `Admin`
- Password: `Pa55w.rd`

> **Note**: Your instructor will provide instructions to connect to the virtual lab environment.

#### Review the installed applications

Find the taskbar on your Windows 10 desktop. The taskbar contains the icons for the applications that you'll use in this lab, including:
    
-   Microsoft Edge
-   Visual Studio Code

## Lab Scenario

In this lab, you will create a proof of concept for this scenario by employing an Azure Service Bus Queue. To demonstrate how the system could function, you will create a .NET project that will publish messages to the system, and a second .NET application that will read messages from the queue. The first app will simulate data coming from a sensor, while the second app will simulate the system that will read the messages from the queue for processing.

## Architecture diagram

![Architecture diagram depicting a user asynchronously processing messages by using Azure Service Bus Queues](./media/Lab10-Diagram.png)

### Exercise 1: Create Azure resources

#### Task 1: Open the Azure portal

1. On the taskbar, select the **Microsoft Edge** icon.

1. In the browser window, browse to the Azure portal at `https://portal.azure.com`, and sign in with the account you'll be using for this lab.

    > **Note**: If this is your first time signing in to the Azure portal, you'll be offered a tour of the portal. Select **Get Started** to skip the tour and begin using the portal.

#### Task 2: Create an Azure Service Bus queue

1. In the Azure portal, use the **Search resources, services, and docs** text box to search for **Service Bus** and then, in the list of results, select **Service Bus**.

1. On the **Service Bus** blade, select **+ Create**.

1. On the **Create namespace** blade, on the **Basics** tab, perform the following actions, and select **Review + create**:
        
    | Setting | Action |
    | -- | -- |
    | **Subscription** drop-down list |Retain the default value |
    | **Resource group** section | Select **Create new**, enter **AsyncProcessor**, and then select **OK** |
    | **Namespace name** text box | Enter **sbnamespace**_[yourname]_ |
    | **Region** drop-down list | Select any Azure region in which you can deploy an Azure Service Bus |
    | **Pricing tier** drop-down list | Select **Basic** |

    The following screenshot displays the configured settings on the **Basics** tab on the **Create namespace** blade.
    
    ![Create an Azure Service Bus namespace blade](./media/l10_create_sb_namespace.png)
     
1. On the **Review + create** tab, review the options that you selected during the previous steps.

1. Select **Create** to create the **Service Bus** namespace by using your specified configuration.

    > **Note**: Wait for the creation task to complete before you proceed with this lab.

1. On the **Deployment** blade, select the **Go to resource** button to navigate to the blade of the newly created **Service Bus** namespace.

1. On the **Service Bus** namespace blade, in the **Settings** section, select **Shared access policies**.

1. In the list of policies, select **RootManageSharedAccessKey**.

1. On the **SAS Policy: RootManageSharedAccessKey** pane, next to the **Primary Connection String** entry, select the **Copy to clipboard** button, and record the copied value. You'll use it later in this lab.

    > **Note**: It doesn't matter which of the two available keys you choose. They are interchangeable.

1. On the **Service Bus** namespace blade, in the **Entities** section, select **Queues**, and then select **+ Queue**.

1. On the **Create queue** blade, review the available settings, in the **Name** text box, enter **messagequeue**, and then select **Create**.

1. Select **messagequeue** to display the properties of the **Service Bus** queue.

1. Leave the browser window open. You'll use it again later in this lab.

#### Review

In this exercise, you created an Azure **Service Bus** namespace and a **Service Bus** queue that you'll use through the remainder of the lab.

### Exercise 2: Create a .NET Core project to publish messages to a Service Bus queue (Advanced Path)

#### Task 1: Create a .NET Core project

1. From the lab computer, start Visual Studio Code.

1. In Visual Studio Code, in the **File** menu, select **Open Folder**.

1. In the **Open Folder** window, browse to **Allfiles (F):\\Allfiles\\Labs\\10\\Starter\\MessagePublisher**, and then select **Select Folder**.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. At the terminal prompt, run the following command to create a new .NET project named **MessagePublisher** in the current folder:

    ```
    dotnet new console --framework net6.0 --name MessagePublisher --output .
    ```

    > **Note**: The **dotnet new** command will create a new **console** project in a folder with the same name as the project.

1. Run the following command to import version 7.8.1 of the **Azure.Messaging.ServiceBus** package from NuGet:

    ```
    dotnet add package Azure.Messaging.ServiceBus --version 7.8.1
    ```

    > **Note**: The **dotnet add package** command will add the **Azure.Messaging.ServiceBus** package from NuGet. For more information, go to [Azure.Messaging.ServiceBus](https://www.nuget.org/packages/Azure.Messaging.ServiceBus/).

1. At the terminal prompt, run the following command to build the .NET Core console application:

    ```
    dotnet build
    ```

1. Select **Kill Terminal** (the **Recycle Bin** icon) to close the terminal pane and any associated processes.

#### Task 2: Publish messages to an Azure Service Bus queue

1. On the **File** menu, select **Open File**.

1. Browse to **Allfiles (F):\\Allfiles\\Labs\\10\\Advanced\\Publisher-Program.txt** and click open.

1. Copy the entire contents of **Publisher-Program.txt** and replace Program the content of **Program.cs**.

1. Update the **serviceBusConnectionString** string constant by setting its value to **Primary Connection String** of the Service Bus namespace.

1. verify that the **queueName** constant is set to **messagequeue**, matching the name of the Service Bus queue you created earlier in this exercise.

    > **Note**: The Service Bus client is safe to cache and use as a singleton for the lifetime of the application. This is considered one of the best practices when publishing and reading messages on a regular basis.

1. Write the appropriate C# code to send **numOfMessages** messages as a batch to the messagequeue endpoint .

    > **Note**: Tools such as GitHub Copilot and Copilot with Bing can be used to help generate code

1. Save the **Program.cs** file.

1. At the terminal prompt, run the following command to launch the .NET Core console app:

    ```
    dotnet run
    ```

    > **Note**: If you encounter any errors, review the **Program.cs** file in the **Allfiles (F):\\Allfiles\\Labs\\10\\Solution\\MessagePublisher** folder.

1. Verify that the console message displayed at the terminal prompt states that a batch of three messages has been published to queue.

1. Select **Kill Terminal** (the **Recycle Bin** icon) to close the terminal pane and any associated processes.

1. Switch to the Microsoft Edge browser displaying the Service Bus queue **messagequeue** in the Azure portal.

1. Review the **Essentials** pane and note that the queue contains three active messages.

    The following screenshot displays the Service Bus queue metrics and message count.
     
    ![Service Bus queue metrics and message count in the Azure portal](./media/l10_display_queue_with_messages_portal.png)
     
1. Select **Service Bus Explorer**.

1. With the **Peek Mode** tab header selected, on the **Queue** tab, select the **Peek from start** button.

1. Verify that the queue contains three messages.

1. Select the first message and review its content in the **Message** pane.

    The following screenshot displays the first message's content.
         
    ![Service Bus queue content in Service Bus Explorer](./media/l10_peek_queue_with_messages_explorer.png)

1. Close the **Message** pane.

#### Review

In this exercise, you configured your .NET project that published messages into an Azure Service Bus queue.

### Exercise 3: Create a .NET Core project to read messages from a Service Bus queue (Advanced Path)

#### Task 1: Create a .NET project

1. From the lab computer, start Visual Studio Code.

1. In Visual Studio Code, in the **File** menu, select **Open Folder**.

1. In the **Open Folder** window, browse to **Allfiles (F):\\Allfiles\\Labs\\10\\Starter\\MessageReader**, and then select **Select Folder**.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. At the terminal prompt, run the following command to create a new .NET project named **MessageReader** in the current folder:

    ```
    dotnet new console --framework net8.0 --name MessageReader --output .
    ```

1. Run the following command to import version 7.8.1 of the **Azure.Messaging.ServiceBus** package from NuGet:

    ```
    dotnet add package Azure.Messaging.ServiceBus --version 7.8.1
    ```

1. At the terminal prompt, run the following command to build the .NET Core console application:

    ```
    dotnet build
    ```

1. Select **Kill Terminal** (the **Recycle Bin** icon) to close the terminal pane and any associated processes.

#### Task 2: Read messages from an Azure Service Bus queue

1. On the **File** menu, select **Open File**.

1. Browse to **Allfiles (F):\\Allfiles\\Labs\\10\\Advanced\\Reader-Program.txt** and click open.

1. Copy the entire contents of **Reader-Program.txt** and replace Program the content of **Program.cs**.

 1. Update the **serviceBusConnectionString** string constant by setting its value to **Primary Connection String** of the Service Bus namespace.

1. verify that the **queueName** constant is set to **messagequeue**, matching the name of the Service Bus queue you created earlier in this exercise.

1. Follow the comments in the program to recieve and display messages from the queue. 

1. Save the **Program.cs** file.

1. At the terminal prompt, run the following command to launch the .NET Core console app:

    ``` powershell
    dotnet run
    ```

    > **Note**: If you encounter any errors, review the **Program.cs** file in the **Allfiles (F):\\Allfiles\\Labs\\10\\Solution\\MessageReader** folder.

1. Verify that the console message displayed at the terminal prompt states that each of the three messages in the queue has been received.

1. At the terminal prompt, press any key to stop the receiver and terminate the app execution.

1. Select **Kill Terminal** (the **Recycle Bin** icon) to close the terminal pane and any associated processes.

1. Switch back to the Microsoft Edge browser displaying the Service Bus queue **messagequeue** in the Azure portal.

1. On the **Service Bus Explorer (preview)** blade, select **Peek from start**, and note that the number of active messages in the queue has changed to **0**.

#### Review

In this exercise, you read and deleted messages from the Azure Service Bus queue by using the .NET library.
