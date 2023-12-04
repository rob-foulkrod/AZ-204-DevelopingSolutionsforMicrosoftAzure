using Azure;
using Azure.Messaging.EventGrid;
using System;
using System.Threading.Tasks;

public class Program
{
    // Constants for the topic endpoint and key. You can find these in the Azure portal.
    private const string topicEndpoint = "[PLACE YOUR TOPIC ENDPOINT HERE]";
    private const string topicKey = "[PLACE YOUR TOPIC KEY HERE]";

    public static async Task Main(string[] args)
    {
        // Create a new URI object with the topic endpoint.
        Uri endpoint = new Uri(topicEndpoint);
        
        // Create a new AzureKeyCredential object with the topic key.
        AzureKeyCredential credential = new AzureKeyCredential(topicKey);

        // Create a new EventGridPublisherClient object with the endpoint and credential.
        EventGridPublisherClient client = new EventGridPublisherClient(endpoint, credential);
        
        // Create a new EventGridEvent object with the necessary event data including the event type and subject
        // and data payload with the employee's full name and address.
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

        // creating a second event similar to the first
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

        // Publish the first event to the event grid topic.
        await client.SendEventAsync(firstEvent);
        Console.WriteLine("First event published");

        // Publish the second event to the event grid topic.
        await client.SendEventAsync(secondEvent);
        Console.WriteLine("Second event published");
    }
}
