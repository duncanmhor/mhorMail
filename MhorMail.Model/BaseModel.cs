using System;

namespace MhorMail.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public byte[] Rowversion { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public int Id { get; set; }
    }
}
