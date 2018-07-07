namespace Common.Application.Dto
{

    public class ResponseOkCommandDto
    {
        public int httpStatus { get; set; }
        public string message { get; set; }
        public object content { get; set; }
       
    }

}
