namespace MhorMail.Model
{
    public class ServerConfiguration:BaseModel
    {
        public string ServerName { get; set; }
        public int ServerPort { get; set; }
    }
}