using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace dbtest.Pages
{
    public class dbtestModel : PageModel
    {
        public string output;
        public void OnGet()
        {
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "changeit"; // update me
                builder.UserID = "changeit"; // update me
                builder.Password = "changeit"; // update me
                builder.InitialCatalog = "changeit";



                // Connect to SQL
                Console.WriteLine("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Done.");
                    output = "Connection established";

                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                output = "Unsuccessfull";
            }



            ViewData["testresult"] = output;



            Console.WriteLine("All done. Press any key to finish...");

        }

    }
}