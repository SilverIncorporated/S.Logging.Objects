using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace S.Logging.Objects
{
    // <summary>
    // Class <c>LogException</c> models an exception to be passed into the <c>LogMessage</c>
    // </summary>
    [DataContract]
    [JsonObject]
    public class LogException {
    
        public LogException(string message, string source, string stackTrace)
        {
            Message = message;
            Source = source;
            StackTrace = stackTrace;
        }
    
        // <summary>
        // Property <c>message</c> is the message of the exception.
        // </summary>
        [DataMember]
        [JsonProperty]
        public string Message { get; set; }
    
        // <summary>
        // Property <c>Source</c> is the location origination of the exception.
        // </summary>
        [DataMember]
        [JsonProperty]
        public string Source { get; set; }
    
        // <summary>
        // Property <c>StackTrace</c> is the stack trace of the exception.
        // </summary>
        [DataMember]
        [JsonProperty]
        public string StackTrace { get; set; }
    
        // <summary>
        // Method <c>ToJson()</c> builds Json from the LogException object.
        // </summary>
        public string ToJson() {
            return JsonConvert.SerializeObject(this);
        }
    
    }
}