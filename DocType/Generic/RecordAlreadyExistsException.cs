namespace DocType.Generic
{
    public class RecordAlreadyExistException : Exception
    {
        public RecordAlreadyExistException(string message) : base(message)
        {

        }
    }
}
