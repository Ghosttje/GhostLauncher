using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace GhostLauncher.Entities.JsonResponse
{
    [DataContract]
    public class ResponseList<T>
    {
        public ResponseList(List<T> result, HttpStatusCode status = HttpStatusCode.OK)
        {
            Result = result;
            Status = status;
        }

        [DataMember(Name = "statusCode")]
        public HttpStatusCode Status { get; set; }

        [DataMember(Name = "result")]
        public List<T> Result { get; set; }
    }
}
