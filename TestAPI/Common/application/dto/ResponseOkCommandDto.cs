namespace Common.Application.Dto
{

    public class ResponseOkCommandDto
    {
        public int httpStatus { get; set; }//private int httpStatus;
        public string message { get; set; }       //private string message;

        public int getHttpStatus()
        {
            return httpStatus;
        }

        public void setHttpStatus(int httpStatus)
        {
            this.httpStatus = httpStatus;
        }

        public string getMessage()
        {
            return message;
        }

        public void setMessage(string message)
        {
            this.message = message;
        }
    }

}
