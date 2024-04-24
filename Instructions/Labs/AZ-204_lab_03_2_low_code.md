---
lab:
    az204Title: 'Lab 03: Retrieve Azure Storage resources and metadata by using the Azure Storage SDK for .NET'
    az204Module: 'Learning Path 03: Develop solutions that use blob storage'
---

# Lab 03: Retrieve Azure Storage resources and metadata by using the Azure Storage SDK for .NET (Low-Code)

## Instructions

### Exercise 3: Access containers by using the .NET SDK

#### Task 1: Open .NET project

1. On the **Start** screen, select the **Visual Studio Code** tile.

1. On the **File** menu, select **Open Folder**, browse to **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\BlobManager**, and then select **Select Folder**.

1. On the **Explorer** pane of the **Visual Studio Code** window, Open the BlobManager.csproj. Observe the reference to Azure.Storage.Blobs version 12.18.0.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to build the .NET web application:

    ```
    dotnet build
    ```

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 2: Modify the Program class to access Storage

1. On the **Explorer** pane of the **Visual Studio Code** window, open the **Program.cs** file.

1. Update the **blobServiceEndpoint** string constant by setting its value to the **Primary Blob Service Endpoint** of the storage account that you recorded previously in this lab.

1. Update the **storageAccountName** string constant by setting its value to the **Storage account name** of the storage account that you recorded previously in this lab.

1. Update the **storageAccountKey** string constant by setting its value to the **Key** of the storage account that you recorded previously in this lab.

1. Observe the creation of the BlobServiceClient and the GetAccountInfoAsync method call.

1. Observe the implementation of the EnumerateContainersAsync method. Use Copilot to explain the code, or write down any questions you may have about it.

1. Observe the implementation of the EnumerateBlobsAsync method. Use Copilot to explain the code, or write down any questions you may have about it.
  
1. Observe the implementation of the GetContainerAsync method. Use Copilot to explain the code, or write down any questions you may have about it.

1. Observe the implementation of the GetBlobAsync method. Use Copilot to explain the code, or write down any questions you may have about it.

#### Task 3: Connect to the Azure Storage blob service endpoint

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to run the .NET web application:

    ```
    dotnet run
    ```

1. Observe the output from the currently running console application. The output contains metadata for the storage account that was retrieved from the service.

1. Observe the output from the currently running console application. The output includes a list of every existing container in the account.

1. Review the output from the currently running console application. The output includes metadata about the existing container and blobs.

1. Observe the output from the currently running console application. The output includes metadata about the existing container and blobs.

#### Task 4: Access blob URI by using the SDK

1. Observe the output from the currently running console application. The output includes the final URL to access the blob online. Record the value of this URL to use later in the lab.
    > **Note**: The URL will likely be similar to the following string: `https://mediastor*[yourname]*.blob.core.windows.net/vector-graphics/graph.svg`

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 5: Test the URI by using a browser

1. On the taskbar, activate the shortcut menu for the **Microsoft Edge** icon, and then select **New window**.

1. In the new browser window, refer to the URL that you previously copied in this lab for the blob.

1. You should now notice the Scalable Vector Graphics (SVG) file in your browser window.

#### Review

In this exercise, you created containers and managed blobs by using the Storage SDK.
