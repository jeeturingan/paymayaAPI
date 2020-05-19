using System;

namespace paymayAPI.Application.Exceptions {
    public class RecordAlreadyExistsException : Exception {
        public RecordAlreadyExistsException (string message) : base (message) { }
    }
}