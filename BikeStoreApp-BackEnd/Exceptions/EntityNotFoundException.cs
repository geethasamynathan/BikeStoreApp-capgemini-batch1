namespace BikeStoreApp_BackEnd.Exceptions
{
    public class EntityNotFoundException:Exception
    {
        public EntityNotFoundException() : base() { }
        public EntityNotFoundException(string message) : base(message) { }
    }
}
