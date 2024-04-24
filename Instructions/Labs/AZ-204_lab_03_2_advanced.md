---
lab:
    az204Title: 'Lab 03: Retrieve Azure Storage resources and metadata by using the Azure Storage SDK for .NET'
    az204Module: 'Learning Path 03: Develop solutions that use blob storage'
---

# Lab 03: Retrieve Azure Storage resources and metadata by using the Azure Storage SDK for .NET (Advanced)

## Instructions

### Exercise 3: Access containers by using the .NET SDK

#### Task 1: Create .NET project

1. On the **Start** screen, select the **Visual Studio Code** tile.

1. On the **File** menu, select **Open Folder**, browse to **Allfiles (F):\\Allfiles\\Labs\\03\\Starter\\BlobManager**, and then select **Select Folder**.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to create a new .NET project named **BlobManager** in the current folder:

    ```
    dotnet new console --framework net8.0 --name BlobManager --output .
    ```

    > **Note**: The **dotnet new** command will create a new **console** project in a folder with the same name as the project.

1. In the terminal, run the following command to import version 12.18.0 of **Azure.Storage.Blobs** from NuGet:

    ```
    dotnet add package Azure.Storage.Blobs --version 12.18.0
    ```

    > **Note**: The **dotnet add package** command will add the **Azure.Storage.Blobs** package from NuGet. For more information, refer to [Azure.Storage.Blobs](https://www.nuget.org/packages/Azure.Storage.Blobs/12.18.0).

1. In the terminal, run the following command to build the .NET web application:

    ```
    dotnet build
    ```

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 2: Modify the Program class to access Storage

1. On the **Explorer** pane of the **Visual Studio Code** window, open the **Program.cs** and **Program.txt** file.

1. Copy the entire contents of Program.txt and replace Program the content of Program.cs.

1. Replace the <primary-blob-service-endpoint> placeholder with the value to the **Primary Blob Service Endpoint** of the storage account that you recorded previously in this lab.

1. Replace the <storageAccountName> placeholder with the value to the **Storage account name** of the storage account that you recorded previously in this lab.

1. Replace the <storageAccountKey> placeholder with the value to the **Key** of the storage account that you recorded previously in this lab.

#### Task 3: Connect to the Azure Storage blob service endpoint

1. In the **Main** method, Write the appropriate C# code to connect to the Azure Storage blob service endpoint and print AccountInfo metadata. Use tools like Copilot to assist if needed.
  
1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to run the .NET web application:

    ```
    dotnet run
    ```

    > **Note**: If there are any build errors, review the **Program.cs** file in the **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\BlobManager** folder.

1. Observe the output from the currently running console application. The output contains metadata for the storage account that was retrieved from the service.

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 4: Enumerate the existing containers

1. In the **Program** class, create the code to complete the method named **EnumerateContainersAsync**, to enumerate containers in storage account.

1. Save the **Program.cs** file.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to run the .NET web application:

    ```
    dotnet run
    ```

    > **Note**: If there are any build errors, review the **Program.cs** file in the **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\BlobManager** folder.

1. Observe the output from the currently running console application. The updated output includes a list of every existing container in the account.

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Review

In this exercise, you accessed existing containers by using the Azure Storage SDK.

### Exercise 4: Retrieve blob Uniform Resource Identifiers (URIs) by using the .NET SDK

#### Task 1: Enumerate the blobs in an existing container by using the SDK

1. In the **Program** class, update method named **EnumerateBlobsAsync** that enumerates blobs in an existing container.
  
1. In the **Main** method, enter the following code at the end of the method to create a variable named *existingContainerName* with a value of **raster-graphics**:

1. In the **Main** method, enter the following code at the end of the method to invoke the **EnumerateBlobsAsync** method, passing in the *serviceClient* and *existingContainerName* variables as parameters:

1. Save the **Program.cs** file.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to run the .NET web application:

    ```
    dotnet run
    ```

    > **Note**: If there are any build errors, review the **Program.cs** file in the **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\BlobManager** folder.

1. Review the output from the currently running console application. The updated output includes metadata about the existing container and blobs.

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 2: Create a new container by using the SDK

1. In the **Program** class, enter the code to create a new **private static** method named **GetContainerAsync** that's asynchronous that creates a new container in storage account.

1. In the **Main** method, enter the following code at the end of the method to create a variable named *newContainerName* with a value of **vector-graphics**:

1. In the **Main** method, enter the following code at the end of the method to invoke the **GetContainerAsync** method, to pass the *serviceClient* and *newContainerName* variables as parameters, and to store the result in a variable named *containerClient* of type **BlobContainerClient**.
1. Save the **Program.cs** file.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to run the .NET web application:

    ```
    dotnet run
    ```

    > **Note**: If there are any build errors, review the **Program.cs** file in the **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\BlobManager** folder.

1. Observe the output from the currently running console application. The updated output includes metadata about the existing container and blobs.

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 3: Upload a new blob by using the portal

1. On the Azure portal's **navigation** pane, select the **Resource groups** link.

1. On the **Resource groups** blade, select the **StorageMedia** resource group that you created previously in this lab.

1. On the **StorageMedia** blade, select the **mediastor**_[yourname]_ storage account that you created previously in this lab.

1. On the **Storage account** blade, select the **Containers** link in the **Data storage** section.

1. In the **Containers** section, select the newly created **vector-graphics** container. You might need to refresh the page to observe the new container.

1. On the **Container** blade, select **Upload**.

1. In the **Upload blob** window, perform the following actions, and then select **Upload**:

    | Setting | Action |
    | -- | -- |
    | **Files** section | Select **Browse for files** or use the drag and drop feature |
    | **File Explorer** window |  **Allfiles (F):\\Allfiles\\Labs\\03\\Starter\\Images**, select the **graph.svg** file, and then select **Open** |
    | **Overwrite if files already exist** check box | Ensure that the check box is selected |

    > **Note**: Wait for the blob to upload before you continue with this lab.

#### Task 4: Access blob URI by using the SDK

1. Switch to the **Visual Studio Code** window.

1. In the **Program** class, enter the code to create a new **private static** method named **GetBlobAsync** that retrieves blob URI.

1. In the **Main** method, enter the following code at the end of the method to create a variable named *uploadedBlobName* with a value of **graph.svg**.

1. In the **Main** method, enter the code at the end of the method to invoke the **GetBlobAsync** method, passing in the *containerClient* and *uploadedBlobName* variables as parameters, and to store the result in a variable named *blobClient* of type **BlobClient**:

1. In the **Main** method, enter the code at the end of the method to render the **Uri** property of the *blobClient* variable:

1. Save the **Program.cs** file.

1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to run the .NET web application:

    ```
    dotnet run
    ```

    > **Note**: If there are any build errors, review the **Program.cs** file in the **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\BlobManager** folder.

1. Observe the output from the currently running console application. The updated output includes the final URL to access the blob online. Record the value of this URL to use later in the lab.

    > **Note**: The URL will likely be similar to the following string: `https://mediastor*[yourname]*.blob.core.windows.net/vector-graphics/graph.svg`

1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 5: Test the URI by using a browser

1. On the taskbar, activate the shortcut menu for the **Microsoft Edge** icon, and then select **New window**.

1. In the new browser window, refer to the URL that you previously copied in this lab for the blob.

1. You should now notice the Scalable Vector Graphics (SVG) file in your browser window.

#### Review

In this exercise, you created containers and managed blobs by using the Storage SDK.
