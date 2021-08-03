/*We want to calculate no of companies whose authorized cap falls in given conditions 
1.<= 1L     2.betn 1L-10L     3.betn 10L-1C      4.btn 1C-10C     5.above 10C */

using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsvHelper.CsvReader;
using System.Configuration;
using System.Data;
using ConsoleTables;

namespace Project2_Data_project
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql1;
            SqlCommand sqlCom;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString);
            conn.Open();
            Console.WriteLine("Initially Database is not exist");
/* Creating Database--------------------------------------------------------------------------------------- */
         /*
                      sql1 = "Create Database Data_Project2";
                      sqlCom = new SqlCommand(sql1, conn);
                      sqlCom.ExecuteNonQuery();
                      Console.WriteLine("Now Database is created");
         */
/*  Creating a table--------------------------------------------------------------------------------------- */
         /*
                         sql1 = "USE Data_Project2 "
                                       + " CREATE TABLE Company_Master("
                                       + " AUTHORIZED_CAP float not null, "
                                       + " DATE_OF_REGISTRATION varchar(300) not null, "
                                       + " PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN varchar(300) not null, )";

                         sqlCom = new SqlCommand(sql1, conn);
                         sqlCom.ExecuteNonQuery();
                         Console.WriteLine("Now Table is created");              
        */
/* Inserting Values into Comapany_Master Table--------------------------------------------------------------------------------*/
        /*
                        int year = 0;
                        string s_year = "";
                        var reader = new StreamReader(@"C:/Users/Samiksha/source/repos/Project2_Data_project/WestBengal.csv");
                        var rows = new CsvReader(reader, CultureInfo.InvariantCulture);

                        foreach (var row in rows.GetRecords<WestBengal>())
                        {
                            float Auth_d = row.AUTHORIZED_CAP; 
                            string date = row.DATE_OF_REGISTRATION;
                            string activity = row.PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN;

                            if (date != "NA")
                            {
                                s_year = date.Substring(6);

                                if (s_year.Length == 2)
                                {
                                    int i_year = Convert.ToInt32(s_year);
                                    if (i_year >= 00 && i_year <= 19)
                                        s_year = "20" + s_year;
                                    else
                                        s_year = "19" + s_year;

                                    year = Convert.ToInt32(s_year);
                                }
                                else
                                {
                                    DateTime dt = Convert.ToDateTime(date);
                                    year = dt.Year;
                                }
                            }

                            sql1 = "Insert into Data_Project2.dbo.Company_Master (AUTHORIZED_CAP, DATE_OF_REGISTRATION, PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN)"
                                           + "Values (@AUTHORIZED_CAP, @DATE_OF_REGISTRATION, @PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN)";

                            using (sqlCom = new SqlCommand(sql1, conn))
                            {
                                sqlCom.Parameters.Add("@AUTHORIZED_CAP", SqlDbType.Float).Value = Auth_d;
                                sqlCom.Parameters.Add("@DATE_OF_REGISTRATION", SqlDbType.Int, 150).Value = year;
                                sqlCom.Parameters.Add("@PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN", SqlDbType.VarChar, 300).Value = row.PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN;
                                sqlCom.ExecuteNonQuery();
                                Console.WriteLine("Values are inserting");
                            }
                        }
                        Console.WriteLine("Values Inserted");
         */
/* Problem1 -------------------------------------------------------------------------------*/
         /*   
                             sql1 = "SELECT count(*) FROM Data_Project2.dbo.Company_Master where (AUTHORIZED_CAP <= 100000) ";
                             sqlCom = new SqlCommand(sql1, conn);
                             string count1 = sqlCom.ExecuteScalar().ToString();

                             sql1 = "SELECT count(*) FROM  Data_Project2.dbo.Company_Master where (AUTHORIZED_CAP > 100000 AND AUTHORIZED_CAP <= 1000000) ";
                             sqlCom = new SqlCommand(sql1, conn);
                             string count2 = sqlCom.ExecuteScalar().ToString();

                             sql1 = "SELECT count(*) FROM  Data_Project2.dbo.Company_Master where (AUTHORIZED_CAP > 1000000 AND AUTHORIZED_CAP <= 10000000) ";
                             sqlCom = new SqlCommand(sql1, conn);
                             string count3 = sqlCom.ExecuteScalar().ToString();

                             sql1 = "SELECT count(*) FROM Data_Project2.dbo.Company_Master where (AUTHORIZED_CAP > 10000000 AND AUTHORIZED_CAP <= 100000000) ";
                             sqlCom = new SqlCommand(sql1, conn);
                             string count4 = sqlCom.ExecuteScalar().ToString();

                             sql1 = "SELECT count(*) FROM  Data_Project2.dbo.Company_Master where (AUTHORIZED_CAP > 100000000) ";
                             sqlCom = new SqlCommand(sql1, conn);
                             string count5 = sqlCom.ExecuteScalar().ToString();

                              // sqlCom.ExecuteNonQuery();

                             var table = new ConsoleTable("Bin", "Counts");
                             {               
                               table.AddRow("<= 1L", count1)
                                    .AddRow("1L to 10L", count2)
                                    .AddRow("10L to 1Cr", count3)
                                    .AddRow("1Cr to 10Cr ", count4)
                                    .AddRow("> 10Cr", count5); 
                             }
                             table.Write();
                             Console.WriteLine();
                             Console.WriteLine("Completed with 1st PB");        
         */
/* Problem2----------------------------------------------------------------------------------------- */
        /*
                         sql1 = "Select DATE_OF_REGISTRATION, Count(*) as 'COUNT' from Data_Project2.dbo.Company_Master " +
                                "where DATE_OF_REGISTRATION BETWEEN 2000 AND 2019 " +
                                "GROUP BY DATE_OF_REGISTRATION Order By DATE_OF_REGISTRATION ";

                        sqlCom = new SqlCommand(sql1, conn);

                        //string count = sqlCom.ExecuteReader().ToString();
                         //SqlDataReader rdr = sqlCom.ExecuteReader();


                        SqlDataReader rdr = sqlCom.ExecuteReader();
                        var table = new ConsoleTable("Year", "No Of Registrations");
                        while (rdr.Read())
                        {
                            string YEAR = rdr["DATE_OF_REGISTRATION"].ToString();
                            string COUNT = rdr["COUNT"].ToString();
                            table.AddRow(YEAR, COUNT);
                        }
                        table.Write();
                        rdr.close();
        */
/* Problem3-------------------------------------------------------------------------------------------------------------- */
         /*
                    sql1 = "Select PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN, count(PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN ) AS COUNTS " +
                       "from Data_Project2.dbo.Company_Master where DATE_OF_REGISTRATION = '2015' Group By PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN " +
                       "Order By PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN ";

                    sqlCom = new SqlCommand(sql1, conn);

                    SqlDataReader rdr = sqlCom.ExecuteReader();
                    var table = new ConsoleTable("ACTIVITY", "COUNTS");
                    while (rdr.Read())
                    {
                        string YEAR = rdr["PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN"].ToString();
                        string COUNT = rdr["COUNTS"].ToString();
                        table.AddRow(YEAR, COUNT);
                    }
                    table.Write();
         */
/* PROBLEM 4-------------------------------------------------------------------------------------------------------------------------*/
            sql1 = "Select DATE_OF_REGISTRATION , PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN, Count(PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN ) " +
                "as COUNT from Data_Project2.dbo.Company_Master  where DATE_OF_REGISTRATION BETWEEN 2000 AND 2019" +
                " Group by PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN, DATE_OF_REGISTRATION Order by  DATE_OF_REGISTRATION ";

            sqlCom = new SqlCommand(sql1, conn);
            SqlDataReader rdr = sqlCom.ExecuteReader();

            var dict = new Dictionary<string, Dictionary<string, string>>();  // Creating Nested Dictionary 
            for (int i = 2000; i <= 2019; i++)
            {
                dict.Add(i.ToString(), new Dictionary<string, string>());
            }
            while (rdr.Read())
            {
                string YEAR = rdr["DATE_OF_REGISTRATION"].ToString();   // Retriving values from Database
                int Yr = Convert.ToInt32(YEAR);
                string Activity = rdr["PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN"].ToString();
                string Count = rdr["COUNT"].ToString();

                if (Yr >= 2000 && Yr <= 2019)
                {
                    if (dict[Yr.ToString()].ContainsKey(Activity))
                        dict[Yr.ToString()][Activity] = Count;
                    else
                        dict[Yr.ToString()].Add(Activity, Count);
                }
            }
            var table = new ConsoleTable("PRINCIPAL BUISNESS ACTIVITY", "COUNT");
            foreach (var k1 in dict.Keys)
            {
                var value1 = dict[k1];
                table.AddRow(k1, "");
                foreach (var k2 in value1.Keys)
                {
                    table.AddRow(k2, value1[k2]);
                }
            }
            table.Write();
            Console.ReadLine();
            conn.Close();
            rdr.Close();

        }
    }
}



