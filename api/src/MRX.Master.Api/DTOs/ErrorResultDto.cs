using Newtonsoft.Json;

namespace MRX.Master.Api.DTOs
{
    public class ErrorResultDto
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        public string Message { get; set; }
        public string CorrelationId { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
