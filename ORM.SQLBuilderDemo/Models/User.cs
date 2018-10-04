using ORM.SqlBuilder.Attributes;

namespace ORM.SQLBuilderDemo
{
    [Schema("dbo")] // default schema = dbo
    [Alias("tblUsers")] // this will change table name User into tblUsers in a query
    public class User
    {
        [Key(Identity = true)] // primary key
        public int ID { get; set; }

        //[Alias("FName")] // this will change property name Firstname into FName in a query
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Ignore] // Fullname will not included in a query
        public int Fullname { get; set; }
    }
}
