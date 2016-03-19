using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MhorMail.Data.Conventions
{
    public class BaseDataConvention:Convention
    {
        public BaseDataConvention()
        {
            Properties<byte[]>().Where(x=>x.Name == "Rowversion").Configure(x=>x.HasColumnName("Rowversion").HasColumnType("rowversion"));
            Properties<DateTime>().Where(x=>x.Name == "CreatedOn").Configure(x=>x.HasColumnName("CreatedOn").HasColumnType("DateTime").IsRequired());
            Properties<DateTime>().Where(x => x.Name == "UpdatedOn").Configure(x => x.HasColumnName("CreatedOn").HasColumnType("DateTime"));
            Properties<string>().Where(x => x.Name == "CreatedBy").Configure(x => x.HasColumnName("CreatedBy").HasColumnType("NVARCHAR(200)"));
            Properties<string>().Where(x => x.Name == "UpdatedBy").Configure(x => x.HasColumnName("UpdatedBy").HasColumnType("NVARCHAR(200)"));
        }
    }
}