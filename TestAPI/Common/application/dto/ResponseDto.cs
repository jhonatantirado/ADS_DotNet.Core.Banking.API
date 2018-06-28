namespace Common.Application.Dto
{
    public class ResponseDto
    {
        public object response { get; set; } //public object response;

        public object getResponse()
        {
            return response;
        }

        public void setResponse(object response)
        {
            this.response = response;
        }
    }
}


