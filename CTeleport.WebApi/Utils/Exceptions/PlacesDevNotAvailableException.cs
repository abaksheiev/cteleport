namespace CTeleport.WebApi.Utils.Exceptions
{
    public class PlacesDevNotAvailableException : Exception
    {
        public PlacesDevNotAvailableException():
            base("Places-Dev Not Available")
        {
        }

        public PlacesDevNotAvailableException(string message)
            : base(message)
        {
        }

        public PlacesDevNotAvailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
