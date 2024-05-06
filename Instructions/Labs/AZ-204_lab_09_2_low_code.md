---
lab:
    az204Title: 'Lab 09: Publish and subscribe to Event Grid events'
    az204Module: 'Learning Path 09: Develop event-based solutions'
---

# Lab 09: Publish and subscribe to Event Grid events

## Instructions

In this exercise, you created a new subscription, validated its registration, and then recorded the credentials required to publish a new event to the topic.

### Exercise 3: Publish Event Grid events from .NET (Low-Code Path)

#### Task 1: Open Project File (Low-Code Option)

1. On the **Start** screen, select the **Visual Studio Code** tile.

1. On the **File** menu, select **Open Folder**.

1. In the **File Explorer** window that opens, browse to **Allfiles (F):\\Allfiles\\Labs\\09\\Solution\\EventPublisher**, and then select **Select Folder**.

1. Open Program.cs.

1. Update the topicEndpoint string constant by setting its value to the Topic Endpoint of the Event Grid topic that you recorded previously in this lab.

1. Update the topicKey string constant by setting its value to the Key of the Event Grid topic that you recorded previously in this lab.

1. Read thru the code comments. Use tools like Copilot to explain unknown code to you, or make note of any questions you have about the code.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. Run the following command to run the .NET web application:

    ```powershell
    dotnet run
    ```

1. Observe the success message output from the currently running console application.

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 2: (not needed in Low-Code Path)

#### Task 3: (not needed in Low-Code Path)

#### Task 4: Observe published events

1. Return to the browser window with the **Azure Event Grid Viewer** web application.

1. Review the **Employees.Registration.New** events that were created by your console application.

1. Select any of the events and review its JSON content.

1. Return to the Azure portal.

#### Review

In this exercise, you published new events to your Event Grid topic by using a .NET console application.
