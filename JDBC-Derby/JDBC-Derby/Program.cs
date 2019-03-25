using java.lang;
using java.sql;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDBC_Derby
{
    class Program
    {
        static void Main(string[] args)
        {
            DriverManager.registerDriver(new org.apache.derby.jdbc.EmbeddedDriver());
            Connection derbyConn = DriverManager.getConnection(@"jdbc:derby:D:\_SCO\SCO Tools\Razor 64 bit + Key\db-derby-10.10.2.0-bin\derby-db\security;create=true");
            Statement sta = derbyConn.createStatement();
            ResultSet res = sta.executeQuery("SELECT * FROM tablename");
            java.lang.System.@out.println("tablename: ");
            while (res.next())
            {

                java.lang.System.@out.println("  " + res.getString("1stColumn") + ", " + res.getString("2ndColumn"));
            }
            res.close()
            sta.close();
            derbyConn.close();
        }
    }
}
