namespace Common.Application{

    using System;

    public class Error {
        //private string message;
        //private Exception cause;
        public string message { get; set; }
        public Exception cause { get; set; }

        public Error(string message, Exception cause) {
            this.message = message;
            this.cause = cause;
        }

        //public string getMessage() {
        //    return message;
        //}

        //public void setMessage(string message) {
        //    this.message = message;
        //}

        //public Exception getCause() {
        //    return cause;
        //}

        //public void setCause(Exception cause) {
        //    this.cause = cause;
        //}
    }

}
