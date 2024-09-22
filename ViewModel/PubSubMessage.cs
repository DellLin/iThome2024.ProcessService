using System.Text.Json.Serialization;

namespace iThome2024.ProcessService.ViewModel;

public class PubSubMessage
{
    [JsonPropertyName("message")]
    public Message? Message { get; set; }

    [JsonPropertyName("subscription")]
    public string? Subscription { get; set; }
}

public class Message
{
    [JsonPropertyName("attributes")]
    public Attributes? Attributes { get; set; }

    [JsonPropertyName("data")]
    public string? Data { get; set; }

    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }


    [JsonPropertyName("publishTime")]
    public DateTime PublishTime { get; set; }
}

public class Attributes
{
    [JsonPropertyName("Content-Type")]
    public string? ContentType { get; set; }
}

