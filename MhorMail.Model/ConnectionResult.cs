namespace MhorMail.Model
{
    public class ConnectionResult
    {
        /// <summary>
        /// Were we able to connect to the server?
        /// </summary>
        public bool IsConnected { get; set; }
        /// <summary>
        /// Were we able to authenticate against the server
        /// </summary>
        public bool IsAuthenticated { get; set; }
        /// <summary>
        /// Failure message or "Connection Successfull"
        /// </summary>
        public string Message { get; set; }
       
        public bool Success => IsConnected && IsAuthenticated;
    }
}