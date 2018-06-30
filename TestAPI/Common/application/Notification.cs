namespace Common.Application{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Notification {
        private List<Error> errors = new List<Error>();
        //public List<Error> errors = new List<Error>();

        public void addError(String message) {
            addError(message, null);
        }

        public void addError(String message, Exception e) {
            errors.Add(new Error(message, e));
        }

        public string errorMessage() {
            return string.Join(", ", errors.Select(t => t.message));
        }

        public bool hasErrors() {
            return errors.Any();
        }
    }
}

