namespace TT2.Payload.Response
{
    public class ResponseObject<T>
    {
        public int Status { get; set; }
        public string Messages { get; set; }
        public T Data { get; set; }
        public ResponseObject() { }
        public ResponseObject(int status, string messages, T data)
        {
            Status = status;
            Messages = messages;
            Data = data;
        }
        public ResponseObject<T> ResponseSucess(String messages, T data)
        {
            return new ResponseObject<T>(StatusCodes.Status200OK, messages, data);
        }
        public ResponseObject<T> ResponeError(int status,  String messages, T data)
        {
            return new ResponseObject<T>(status, messages, data);   
        }
    }
}
