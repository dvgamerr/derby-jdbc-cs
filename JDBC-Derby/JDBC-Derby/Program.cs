using java.lang;
using java.sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JDBC_Derby
{
    class Program
    {
        static void Main(string[] args)
        {
            DerbytTest2("C:/apache/derby-db");
        }

        //static void DerbytTest1(string dbpath)
        //{
        //    DerbyNET derbyDB = new DerbyNET(dbpath + ";create=true"); // don't use "\" in directory
        //    if (!derbyDB.openConnection())
        //    {
        //        Console.WriteLine(derbyDB.getLastError());
        //        Console.ReadKey();
        //        //Error opening Derby DB
        //        return;
        //    }
        //    DataTable oDT = derbyDB.getRS("SELECT * FROM schemaExample.tblExample") as DataTable;
        //    if (oDT.Columns[0].ColumnName == "Erro")
        //    {
        //        //Read the ** ERRORS ** section below
        //        Thread.sleep(1000);
        //        oDT = derbyDB.getRS("SELECT * FROM schemaExample.tblExample") as DataTable;
        //    }
        //    else if (oDT.Rows.Count == 1 && oDT.Columns.Count == 1)
        //    {
        //        //Some error occured
        //        Console.WriteLine(derbyDB.getLastError());
        //        Console.ReadKey();
        //        return;
        //    }
        //    derbyDB.closeConnection();
        //}
        static void DerbytTest2(string dbpath)
        {
            Console.WriteLine("Set Property: derby.system.home");
            java.lang.System.setProperty("derby.system.home", dbpath);
            Console.WriteLine("Register Driver: EmbeddedDriver");
            DriverManager.registerDriver(new org.apache.derby.jdbc.EmbeddedDriver());
            Console.WriteLine("Connection: jdbc:derby:security");
            Connection derbyConn = DriverManager.getConnection(@"jdbc:derby:security;create=true");

            Console.WriteLine("Create Statement... (ITEM_SEC)");
            Statement sta = derbyConn.createStatement(); 
            ResultSet res = sta.executeQuery("SELECT * from ITEM_SEC");
            ResultSetMetaData rsmd = res.getMetaData();
            Console.WriteLine("List Columns: ITEM_SEC");
            for (var i = 1; i <= rsmd.getColumnCount() - 1; i++)
            {
                Console.WriteLine("- Column: {0}", rsmd.getColumnName(i));
            }

            res = sta.executeQuery("SELECT COUNT(*) nTotal from ITEM_SEC");
            while (res.next())
            {
                Console.WriteLine("ITEM_SEC ({0} rows)", res.getString("nTotal"));
            }

            res.close();
            sta.close();
            derbyConn.close();
            Console.ReadKey();
        }
    }
}
