---
lab:
    az204Title: 'Lab 03: Retrieve Azure Storage resources and metadata by using the Azure Storage SDK for .NET'
    az204Module: 'Learning Path 03: Develop solutions that use blob storage'
---

# Lab 03: Retrieve Azure Storage resources and metadata by using the Azure Storage SDK for .NET(Low-Code Path)

## Microsoft Azure user interface

Given the dynamic nature of Microsoft cloud tools, you might experience Azure user interface (UI) changes that occur after the development of this training content. As a result, the lab instructions and lab steps might not align correctly.

Microsoft updates this training course when the community alerts us to needed changes. However, cloud updates occur frequently, so you might encounter UI changes before this training content updates. **If this occurs, adapt to the changes, and then work through them in the labs as needed.**

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
-   File Explorer

## Lab Scenario

In this lab, you will learn how to use the Azure Storage SDK to access Azure Storage containers within a C# application. You will also learn how to access metadata and expose URI information to gain access to the contents of the containers in the storage account. 

Finally, to ensure compliance with company regulations, you will implement secure access by generating shared access signatures and data lifecycle policies. You will test access to the content through a static website as well.

<em>View this video by right-clicking this **[video link](https://youtu.be/UtDXcgLv8BQ)** and select 'Open link in a new tab / new window'.</em>

![Decorative](media/Lab03-Overview.png) 

## Architecture diagram

![Architecture diagram depicting a user retrieving Azure Storage resources and metadata by using the Azure Storage SDK for .NET.](./media/Lab03-Diagram.png)

### Exercise 1: Create Azure resources

#### Task 1: Open the Azure portal

1. On the taskbar, select the **Microsoft Edge** icon.

1. In the browser window, browse to the Azure portal at `https://portal.azure.com`, and then sign in with the account you'll be using for this lab.

   > **Note**: If this is your first time signing in to the Azure portal, you'll be offered a tour of the portal. Select **Get Started** to skip the tour and begin using the portal.

#### Task 2: Create a Storage account

1. In the Azure portal, use the **Search resources, services, and docs** text box to search for **Storage Accounts**, and then in the list of results, select **Storage Accounts**.

1. On the **Storage accounts** blade, select **+ Create**.

1. On the **Create a storage account** blade, on the **Basics** tab, perform the following actions:

   | Setting | Action |
   | -- | -- |
   | **Subscription** drop-down list | Retain the default value |
   | **Resource group** section | Select **Create new**, enter **StorageMedia**, and then select **OK** |
   | **Storage account name** text box | Enter **mediastor**_[yourname]_ |
   | **Region** drop-down list | Select **(US) East US** |
   | **Performance** section | Select the **Standard** option |
   | **Redundancy** drop-down list | select **Locally-redundant storage (LRS)** |

   The following screenshot displays the configured settings on the **Create a storage account blade**.
 
   ![Create a storage account blade](./media/l03_create_a_storage_account.png)

1. On the **Advanced** tab, ensure **Allow enabling anonymous access on individual containers** is checked. Check the setting if it is not enabled.
    
1. On the **Review** tab, review the options that you selected during the previous steps.

1. Select **Create** to create the storage account by using your specified configuration.

    > **Note**: Wait for the creation task to complete before you move forward with this lab.

1. Select **Go to resource**.

1. On the **Storage account** blade, in the **Settings** section, select the **Endpoints** link.

1. In the **Endpoints** section, copy the value of the **Blob Service** text box to the clipboard.

    > **Note**: You'll use this endpoint value later in the lab.

1. Open Notepad, and then paste the copied blob service value to Notepad.

1. On the **Storage account** blade, in the **Security + networking** section, select **Access keys**.

1. Copy the **Storage account name** value to the clipboard and then paste it into Notepad.

1. On the **Access keys** blade, select **Show keys**.

1. Review any one of the keys, and then copy the value of either of the **Key** boxes to the clipboard.

    > **Note**: You'll use all these values later in this lab.

#### Review

In this exercise, you created a new Storage account to use throughout the remainder of the lab.

### Exercise 2: Upload a blob into a container

#### Task 1: Create storage account containers

1. On the **Storage account** blade, select the **Containers** link in the **Data storage** section.

1. In the **Containers** section, select **+ Container**.

1. In the **New container** pop-up window, perform the following actions, and then select **Create**:

    | Setting | Action |
    | -- | -- |
    | **Name** text box | Enter **raster-graphics** |
    | **Public access level** drop-down list | Select **Private (no anonymous access)** |

1. In the **Containers** section, select **+ Container**.

1. In the **New container** pop-up window, perform the following actions and then select **Create**:

    | Setting | Action |
    | -- | -- |
    | **Name** text box | Enter **compressed-audio** |
    | **Public access level** drop-down list | Select **Private (no anonymous access)** |

1. In the **Containers** section, observe the updated list of containers.

    The following screenshot displays the configured settings on the **Create a storage account blade**.

    ![Create a storage account blade](./media/l03_containers.png)

#### Task 2: Upload a storage account blob

1. In the **Containers** section, select the recently created **raster-graphics** container.

1.	On the **Container** blade, select **Upload**.

1.	In the **Upload blob** window, perform the following actions, and then select **Upload**:

   | Setting | Action |
   | -- | -- |
   | **Files** section | Select **Browse for files** or use the drag and drop feature |
   | **File Explorer** window | Browse to **Allfiles (F):\\Allfiles\\Labs\\03\\Starter\\Images**, select the **graph.jpg** file, and then select **Open** |
   | **Overwrite if files already exist** check box | Ensure that the check box is selected |
   
   > **Note**: Wait for the blob to upload before you continue with this lab.

#### Task 3: Upload a new blob by using the portal

1. On the Azure portal's **navigation** pane, select the **Resource groups** link.

1. On the **Resource groups** blade, select the **StorageMedia** resource group that you created previously in this lab.

1. On the **StorageMedia** blade, select the **mediastor**_[yourname]_ storage account that you created previously in this lab.

1. On the **Storage account** blade, select the **Containers** link in the **Data storage** section.

1. In the **Containers** section, select the newly created **vector-graphics** container. You might need to refresh the page to observe the new container.

1.	On the **Container** blade, select **Upload**.

1.	In the **Upload blob** window, perform the following actions, and then select **Upload**:

    | Setting | Action |
    | -- | -- |
    | **Files** section | Select **Browse for files** or use the drag and drop feature |
    | **File Explorer** window |  **Allfiles (F):\\Allfiles\\Labs\\03\\Starter\\Images**, select the **graph.svg** file, and then select **Open** |
    | **Overwrite if files already exist** check box | Ensure that the check box is selected |

    > **Note**: Wait for the blob to upload before you continue with this lab.
#### Review

In this exercise, you created placeholder containers in the Storage account, and then populated one of the containers with a blob.

### Exercise 3: Access containers by using the .NET SDK

#### Task 1: Create .NET project

1. On the **Start** screen, select the **Visual Studio Code** tile.

1. On the **File** menu, select **Open Folder**, browse to **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\BlobManager**, and then select **Select Folder**.

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
  

#### Task 3: Connect to the Azure Storage blob service endpoint


1. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal**.

1. In the terminal, run the following command to run the .NET web application:

    ```
    dotnet run
    ```
1. Observe the output from the currently running console application. The output contains metadata for the storage account that was retrieved from the service.

2. Observe the output from the currently running console application. The output includes a list of every existing container in the account.

3. Review the output from the currently running console application. The output includes metadata about the existing container and blobs.

4. Observe the output from the currently running console application. The output includes metadata about the existing container and blobs.
  
5. Observe the output from the currently running console application. The output includes the final URL to access the blob online. Record the value of this URL to use later in the lab.
    > **Note**: The URL will likely be similar to the following string: `https://mediastor*[yourname]*.blob.core.windows.net/vector-graphics/graph.svg`
1. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 4: Access blob URI by using the SDK

1. Switch to the **Visual Studio Code** window.

2. Select **Kill Terminal** or the **Recycle Bin** icon to close the currently open terminal and any associated processes.

#### Task 5: Test the URI by using a browser

1. On the taskbar, activate the shortcut menu for the **Microsoft Edge** icon, and then select **New window**.

1. In the new browser window, refer to the URL that you previously copied in this lab for the blob.

1. You should now notice the Scalable Vector Graphics (SVG) file in your browser window.

#### Review

In this exercise, you created containers and managed blobs by using the Storage SDK.
