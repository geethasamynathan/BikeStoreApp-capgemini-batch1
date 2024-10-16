namespace BikeStoreApp_BackEnd.Exceptions
{
    public class InvalidOperationException:Exception
    {
        public InvalidOperationException() : base() { }

        public InvalidOperationException(string message) : base(message) { }
    }
}
