using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace Comformation.CustomResources
{
    public class CloudFormationEvent<T>
    {
        public string StackId { get; set; }
        public string ResponseURL { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RequestType RequestType { get; set; }
        public string ResourceType { get; set; }
        public string RequestId { get; set; }
        public string LogicalResourceId { get; set; }
        public T ResourceProperties { get; set; }
    }

    public enum RequestType
    {
        Create,
        Update,
        Delete
    }
}
