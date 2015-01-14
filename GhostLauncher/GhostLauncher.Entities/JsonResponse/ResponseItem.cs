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

        [DataMember]
        public HttpStatusCode Status { get; set; }

        [DataMember]
        public T Result { get; set; }
    }
}
