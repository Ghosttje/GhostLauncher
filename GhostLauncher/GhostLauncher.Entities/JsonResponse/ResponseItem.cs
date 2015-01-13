using System.Net;
using System.Runtime.Serialization;

namespace GhostLauncher.Entities.JsonResponse
{
    [DataContract]
    public class ResponseItem<T>
    {
        public ResponseItem(T result, HttpStatusCode status = HttpStatusCode.OK)
        {
            Result = result;
            Status = status;
        }

        [DataMember(Name = "statusCode")]
        public HttpStatusCode Status { get; set; }

        [DataMember(Name = "result")]
        public T Result { get; set; }
    }
}
