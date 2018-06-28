namespace Common.Application.Dto
{
    public class ErrorDto {
        private string message;
        
        public ErrorDto() {
        }
        
        public ErrorDto(string message) {
            this.message = message;
        }

        public string getMessage() {
            return message;
        }

        public void setMessage(string message) {
            this.message = message;
        }
    }
}

