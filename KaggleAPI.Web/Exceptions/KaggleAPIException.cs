using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace KaggleAPI.Web.Exceptions
{
    [Serializable]
    public class KaggleAPIException : Exception
    {
        public HttpResponseMessage Response { get; private set; }

        public KaggleAPIException(HttpResponseMessage response, string message)
            : base(message)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            Response = response;
        }

        public KaggleAPIException() { }

        public KaggleAPIException(string message)
            : base(message) { }

        public KaggleAPIException(string message, Exception innerException)
            : base(message, innerException) { }

        protected KaggleAPIException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Response =
                info.GetValue("KaggleAPIException.Response", typeof(HttpResponseMessage))
                as HttpResponseMessage;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("KaggleAPIException.Response", Response);
        }
    }
}
