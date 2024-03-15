using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace S.Logging.Objects;

// <summary>
// Class <c>LogMessage</c> models a Log Message that is utilized for the SCALE Platform
// </summary>
[DataContract]
[JsonObject]
public class LogMessage
{
    public LogMessage(string workflowName, string message, string env, Dictionary<string, object> metadata, string processKey = "", string processName = "")
    {
        Message = message;
        ProcessKey = processKey;
        ProcessName = processName;
        WorkflowName = workflowName;
        Env = env;
        Metadata = metadata;
    }

    // <summary>
    // Property <c>message</c> is the message that is logged.
    // </summary>
    [DataMember]
    [JsonProperty]
    public string Message { get; set; }

    // <summary>
    // Property <c>ProcessKey</c> is the name of the workflow that logged the message.
    // </summary>
    [DataMember]
    [JsonProperty]
    public string ProcessKey { get; set; }

    // <summary>
    // Property <c>ProcessName</c> is the name of the Process that logged the message.
    // </summary>
    [DataMember]
    [JsonProperty]
    public string ProcessName { get; set; }

    // <summary>
    // Property <c>WorkflowName</c> is the name of the workflow that logged the message.
    // </summary>
    [DataMember]
    [JsonProperty]
    public string WorkflowName { get; set; }

    // <summary>
    // Property <c>Environment</c> is the environment that logs the message.
    // </summary>
    [DataMember]
    [JsonProperty]
    public string Env { get; set; }

    // <summary>
    // Property <c>Metadata</c> contains all metadata logged along with the message.
    // </summary>
    [DataMember]
    [JsonProperty]
    public Dictionary<string, object> Metadata { get; set; }

    // <summary>
    // Method <c>ToJson()</c> builds Json from the LogMessage object.
    // </summary>
    public string ToJson() {
        return JsonConvert.SerializeObject(this);
    }
    
    // <summary>
    // Method <c>BuildMessage()</c> builds the log message from the object.
    // </summary>
    public string BuildMessage(bool logMetaObject)
    {
        var message = !string.IsNullOrWhiteSpace(Env) ? (Env) : "";
        message += !string.IsNullOrWhiteSpace(ProcessKey) ? " | " + ProcessKey : "";
        message += !string.IsNullOrWhiteSpace(ProcessKey)&&!string.IsNullOrWhiteSpace(ProcessName) ? (" - " + ProcessName + " | ") : " | ";
        message += WorkflowName + " | " + Message + (logMetaObject ? "\n\t||\n\t" + JsonConvert.SerializeObject(Metadata) : "");
        return message;
    }
}