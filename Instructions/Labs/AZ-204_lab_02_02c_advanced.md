# Lab 02: Implement task processing logic by using Azure Functions (Advanced)

## Instructions

### Exercise 2: Configure a local Azure Functions project

#### Task 1: Initialize a function project (Standard Path)

1. On the taskbar, select the **Terminal** icon.

1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** empty directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

    > **Note**: In Windows Explorer remove the **Read-only** attribute from **F:\\Allfiles\\Labs\\02\\Starter\\func\\.gitignore** file.

1. Run the following command to use the **Azure Functions Core Tools** to create a new local Azure Functions project in the current directory using the **dotnet-isolated** runtime:

    ```powershell
    func init --worker-runtime dotnet-isolated --target-framework net8.0 --force
    ```

    > **Note**: You can review the documentation to [create a new project][azure-functions-core-tools-new-project] using the **Azure Functions Core Tools**.
    
1. Close the **Terminal** application.

#### Task 2: Configure a connection string

1. On the **Start** screen, select the **Visual Studio Code** tile.
1. On the **File** menu, select **Open Folder**.
1. In the **File Explorer** window that opens, browse to **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func**, and then select **Select Folder**.
1. On the **Explorer** pane of the **Visual Studio Code** window, open the **local.settings.json** file.
1. Observe the current value of the **AzureWebJobsStorage** setting:

    ```json
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    ```

1. Change the value of the **AzureWebJobsStorage** element to the **connection string** of the storage account that you recorded earlier in this lab.
1. Save the **local.settings.json** file.

#### Task 3: Build and validate a project

1. On the taskbar, select the **Terminal** icon.
1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

1. Run the following command to **build** the .NET project:

    ```powershell
    dotnet build
    ```

#### Review

In this exercise, you created a local project that you'll use for Azure Functions development.

### Exercise 3: Create a function that's triggered by an HTTP request (Standard Path)

#### Task 1: Create an HTTP-triggered function

1. On the taskbar, select the **Terminal** icon.
1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

1. Run the following command to use the **Azure Functions Core Tools** to create a new function named **Echo** using the **HTTP trigger** template:

    ```powershell
    func new --template "HTTP trigger" --name "Echo"
    ```

    > **Note**: You can review the documentation to [create a new function][azure-functions-core-tools-new-function] using the **Azure Functions Core Tools**.

1. Close the currently running **Terminal** application.

#### Task 2: Write HTTP-triggered function code

1. On the **Start** screen, select the **Visual Studio Code** tile.
1. On the **File** menu, select **Open Folder**.
1. In the **File Explorer** window that opens, browse to **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func**, and then select **Select Folder**.
1. On the **File** menu, select **Open File**.
1. Browse to **Allfiles (F):\\Allfiles\\Labs\\02\\Advanced\\Echo.txt** and click open.
1. Copy the entire contents of **Echo.txt** and replace Program the content of **Echo.cs**.
1. Write the appropriate C# code to complete the Echo Azure Function as derected by the comments.

    > **Note**: Tools such as GitHub Copilot and Copilot with Bing can be used to help generate code

1. Select **Save** to save your changes to the **Echo.cs** file.

#### Task 3: Test the HTTP-triggered function by using curl

1. On the taskbar, select the **Terminal** icon.
1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

1. Run the following command to run the function app project:

    ```powershell
    func start --build
    ```

    > **Note**: You can review the documentation to [start the function app project locally](https://docs.microsoft.com/azure/azure-functions/functions-develop-local) using the **Azure Functions Core Tools**.
    
1. On the lab computer, start **Command Prompt**.

1. Run the following command to run test the **POST** REST API call against `http://localhost:7071/api/echo` with HTTP request body set to a numeric value of **3**:

   ```powershell
   curl -X POST -i http://localhost:7071/api/echo -d 3
   ```

1. Run the following command to test the **POST** REST API call against `http://localhost:7071/api/echo` with HTTP request body set to a numeric value of **5**:

   ```powershell
   curl -X POST -i http://localhost:7071/api/echo -d 5
   ```

1. Run the following command to test the **POST** REST API call against `http://localhost:7071/api/echo` with HTTP request body set to a string value of **Hello**:

   ```powershell
   curl -X POST -i http://localhost:7071/api/echo -d "Hello"
   ```

1. Run the following command to test the **POST** REST API call against `http://localhost:7071/api/echo` with HTTP request body set to a JavaScript Object Notation (JSON) value of **{"msg": "Successful"}**:

   ```powershell
   curl -X POST -i http://localhost:7071/api/echo -d "{"msg": "Successful"}"
   ```

1. Close all currently running instances of the **Terminal** application, and the **Command Prompt** application.

#### Review

In this exercise, you created a basic function that echoes the content sent through an HTTP POST request.


#### Task 1: Create a schedule-triggered function

1. On the taskbar, select the **Terminal** icon.
1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

1. Within the terminal, run the following command to use the **Azure Functions Core Tools** to create a new function named **Recurring**, using the **Timer trigger** template:

    ```powershell
    func new --template "Timer trigger" --name "Recurring"
    ```

    > **Note**: You can review the documentation to [create a new function][azure-functions-core-tools-new-function] using the **Azure Functions Core Tools**.
    
1. Close the currently running **Terminal** application.

#### Task 2: Observe function code

1. On the **Start** screen, select the **Visual Studio Code** tile.
1. On the **File** menu, select **Open Folder**.
1. In the **File Explorer** window that opens, browse to **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func**, and then select **Select Folder**.
1. On the **Explorer** pane of the **Visual Studio Code** window, open the **Recurring.cs** file.
1. Configure the function to run every (one) minute.

    > **Note**: Tools such as GitHub Copilot and Copilot with Bing can be used to help configure code

#### Task 3: Observe function runs

1. On the taskbar, select the **Terminal** icon.
1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

1. Within the terminal, run the following command to run the function app project:

    ```powershell
    func start --build
    ```

    > **Note**: You can review the documentation to [start the function app project locally][azure-functions-core-tools-start-function] using the **Azure Functions Core Tools**.
    
1. Observe the function run that occurs about every one minute. Each function run should render a simple message to the log.
1. Close the currently running **Terminal** application.
1. Close the Visual Studio Code window.

#### Review

In this exercise, you created a function that runs automatically based on a fixed schedule.

### Exercise 5: Create a function that integrates with other services (Advanced Path)

#### Task 1: Upload sample content to Azure Blob Storage

1. On the Azure portal's **navigation** pane, select the **Resource groups** link.
1. On the **Resource groups** blade, select the **Serverless** resource group that you created previously in this lab.
1. On the **Serverless** blade, select the **funcstor**_[yourname]_ storage account that you created previously in this lab.
1. On the **Storage account** blade, select the **Containers** link in the **Data storage** section.
1. In the **Containers** section, select **+ Container**.
1. In the **New container** pop-up window, perform the following actions, and then select **Create**:

    | Setting | Action |
    | -- | -- |
    | **Name** text box  | Enter **content** |

1. Return to the **Containers** section, and then select the recently created **content** container.
1. On the **Container** blade, select **Upload**.
1. In the **Upload blob** window, perform the following actions, and then select **Upload**:

    | Setting | Action |
    | -- | -- |
    | **Files** section  | Select **Browse for files** or use the drag and drop feature |
    | **File Explorer** window  | Browse to **Allfiles (F):\\Allfiles\\Labs\\02\\Starter**, select the **settings.json** file, and then select **Open** |
    | **Overwrite if files already exist** check box | Ensure that this check box is selected |

      > **Note**: Wait for the blob to upload before you continue with this lab.

#### Task 2: Create an HTTP-triggered function

1. On the taskbar, select the **Terminal** icon.
1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

1. Within the terminal, run the following command to use the **Azure Functions Core Tools** to create a new function named **GetSettingInfo**, using the **HTTP trigger** template:

    ```powershell
    func new --template "HTTP trigger" --name "GetSettingInfo"
    ```

    > **Note**: You can review the documentation to [create a new function][azure-functions-core-tools-new-function] using the **Azure Functions Core Tools**.
1. Close the currently running **Terminal** application.

#### Task 3: Register Azure Storage Blob extensions

1. On the taskbar, select the **Terminal** icon.
1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

1. Within the terminal, run the following command to register the [Microsoft.Azure.Functions.Worker.Extensions.Storage](https://www.nuget.org/packages/Microsoft.Azure.Functions.Worker.Extensions.Storage/6.2.0) extension:

    ```powershell
    dotnet add package Microsoft.Azure.Functions.Worker.Extensions.Storage --version 6.2.0
    ```

#### Task 4: Write HTTP-triggered function code with blob input

1. On the **Start** screen, select the **Visual Studio Code** tile.
1. On the **File** menu, select **Open Folder**.
1. In the **File Explorer** window that opens, browse to **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func**, and then select **Select Folder**.
1. On the **File** menu, select **Open File**.
1. Browse to **Allfiles (F):\\Allfiles\\Labs\\02\\Advanced\\GetSettingInfo.txt** and click open.
1. Copy the entire contents of **GetSettingInfo.txt** and replace Program the content of **GetSettingInfo.cs**.
1. Write the appropriate C# code return the contents of the settings.json file when invoked by an HTTP triggeras directed by the comments.

    > **Note**: Tools such as GitHub Copilot and Copilot with Bing can be used to help generate code

1. Select **Save** to save your changes to the **GetSettingInfo.cs** file.

#### Task 5: Test the function by using curl

1. On the taskbar, select the **Terminal** icon.
1. Within the terminal, run the following command to run the function app project:

    ```powershell
    func start --build
    ```

    > **Note**: You can review the documentation to [start the function app project locally][azure-functions-core-tools-start-function] using the **Azure Functions Core Tools**.

1. On the lab computer, start **Command Prompt**.

1. Run the following command to test the **GET** REST API call against `http://localhost:7071/api/GetSettingInfo`:

   ```powershell
   curl -X GET -i http://localhost:7071/api/GetSettingInfo
   ```

1. Observe the JSON content of the response from the function app, which should now include:

    ```json
    {
        "version": "0.2.4",
        "root": "/usr/libexec/mews_principal/",
        "device": {
            "id": "21e46d2b2b926cba031a23c6919"
        },
        "notifications": {
            "email": "joseph.price@contoso.com",
            "phone": "(425) 555-0162 x4151"
        }
    }
    ```

1. Close all currently running instances of the **Terminal** application, and the **Command Pormpt** application.

#### Review

In this exercise, you created a function that returns the content of a JSON file from a storage account.

### Exercise 6: Deploy a local function project to an Azure Functions app (Standard Path)

#### Task 1: Deploy using the Azure Functions Core Tools

1. On the taskbar, select the **Terminal** icon.
1. Run the following command to change the current directory to the **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\func** directory:

    ```powershell
    cd F:\Allfiles\Labs\02\Starter\func
    ```

1. From command prompt, run the following command to login to the Azure Command-Line Interface (CLI):

    ```powershell
    az login
    ```

1. In the **Microsoft Edge** browser window, enter the name and password of the Microsoft or Azure Active Directory account you are using in this lab, and then select **Sign in**.
1. Return to the currently open **Terminal** window. Wait for the sign-in process to finish.
1. Within the terminal, run the following command to publish the function app project (replace the `<function-app-name>` placeholder with the name of the function app you created earlier in this lab):

    ```powershell
    func azure functionapp publish <function-app-name> --dotnet-version 8.0
    ```

    > **Note**: For example, if your **Function App name** is **funclogicstudent**, your command would be ``func azure functionapp publish funclogicstudent``. You can review the documentation to [publish the local function app project][azure-functions-core-tools-publish-azure] using the **Azure Functions Core Tools**.

1. Wait for the deployment to finalize before you move forward with the lab.
1. Close the currently running **Terminal** application.

#### Task 2: Validate deployment

1. On the taskbar, select the **Microsoft Edge** icon, and select the tab that displays the Azure portal.
2. On the Azure portal's **navigation** pane, select the **Resource groups** link.
3. On the **Resource groups** blade, select the **Serverless** resource group that you created previously in this lab.
4. On the **Serverless** blade, select the **funclogic**_[yourname]_ function app that you created previously in this lab.
5. On the **Overview** blade in Function App, select the **Functions** pane.
6. On the **Functions** pane, select the existing **GetSettingInfo** function.
7. In the **Function** blade, select the **Code + Test** option in the **Developer** section.
8. In the function editor, select **Test/Run**.
9. In the automatically displayed pane, in the **HTTP method** drop-down list, select **GET**.
10. Select **Run** to test the function.
11. In the **HTTP response content**, review the results of the test run. The JSON content should now include the following code:

    ```json
    {
        "version": "0.2.4",
        "root": "/usr/libexec/mews_principal/",
        "device": {
            "id": "21e46d2b2b926cba031a23c6919"
        },
        "notifications": {
            "email": "joseph.price@contoso.com",
            "phone": "(425) 555-0162 x4151"
        }
    }
    ```

#### Review

In this exercise, you deployed a local function project to Azure Functions and validated that the functions work in Azure.
