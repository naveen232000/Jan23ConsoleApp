using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jan23ConsoleApp
{
    public class EmpDml { 
    private string cStr = ConfigurationManager.ConnectionStrings["EmpDetails"].ToString();
     public string myConn
        {
            get { return cStr; }
        }   
        public void DmlAdaptor()
        {
            try { 
            
                using (SqlConnection c=new SqlConnection(myConn))
                {
                SqlDataAdapter adapter = new SqlDataAdapter("select * from employeedetails", c);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                adapter.Fill(ds,"e");
                DataTable dt = ds.Tables["e"];
                DataRow dr = dt.NewRow();
                dr["empId"] = 110;
                dr["empName"] = "Jon";
                dr["salary"] = 109256;
                dr["city"] = "USA";
                dt.Rows.Add(dr);
                Console.WriteLine("Insertd Successfull");
                dt.Rows[2]["salary"] = 412;
                Console.WriteLine("Updated Salary @ row 2");
                dt.Rows[7].Delete();
                Console.WriteLine("Deleted row "+(7-1));
                adapter.Update(dt);
            }

            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            EmpDml empDml = new EmpDml();
            empDml.DmlAdaptor();
            Console.ReadLine();
        }
    }
}
