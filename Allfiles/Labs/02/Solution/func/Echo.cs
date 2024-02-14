using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace func
{
    public class Echo
    {
        private readonly ILogger _logger;

        public Echo(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Echo>();
        }

         // This attribute indicates that this method is an Azure Function named "Echo".
        [Function("Echo")]
        public HttpResponseData Run(
            // This attribute indicates that this function is triggered by an HTTP request.
            // The function can be triggered by either a GET or POST request.
            // The AuthorizationLevel.Function means that the function requires a function key to invoke.
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            // Log an informational message indicating that the function has been triggered.
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Create a response with a status code of 200 (OK).
            var response = req.CreateResponse(HttpStatusCode.OK);
            // Add a header to the response indicating that the content type is plain text.
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            // Read the body of the request.
            StreamReader reader = new StreamReader(req.Body);
            string requestBody = reader.ReadToEnd();
            // Write the body of the request to the response. This makes the function an "echo" function,
            // as it returns exactly what it receives.
            response.WriteString(requestBody);

            // Return the response.
            return response;
        }
    }
}
