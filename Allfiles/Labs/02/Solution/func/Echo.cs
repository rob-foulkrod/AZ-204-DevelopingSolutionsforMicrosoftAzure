using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace func
{
    public class GetSettingInfo
    {
        private readonly ILogger _logger;

        public GetSettingInfo(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetSettingInfo>();
        }

        // This attribute indicates that this method is an Azure Function named "GetSettingInfo".
        [Function("GetSettingInfo")]
        public HttpResponseData Run(
            // This attribute indicates that this function is triggered by an HTTP request.
            // The function can be triggered by either a GET or POST request.
            // The AuthorizationLevel.Function means that the function requires a function key to invoke.
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            // This attribute indicates that the function reads data from a blob in Azure Storage.
            // The blob is located at "content/settings.json" in the storage account specified by the "AzureWebJobsStorage" connection string.
            [BlobInput("content/settings.json", Connection = "AzureWebJobsStorage")] string blobContent
            )
        {
            // Log an informational message indicating that the function has been triggered.
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            // Log the content of the blob.
            _logger.LogInformation($"{blobContent}");

            // Create a response with a status code of 200 (OK).
            var response = req.CreateResponse(HttpStatusCode.OK);
            // Add a header to the response indicating that the content type is plain text.
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            // Write the content of the blob to the response.
            response.WriteString($"{blobContent}");

            // Return the response.
            return response;
        }
    }
