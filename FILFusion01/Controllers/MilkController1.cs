using FILFusion01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FILFusion01.Controllers
{
    public class MilkController1 : Controller
    {
        private readonly IConfiguration _configuration;

        public MilkController1(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult GetAllData()
        {
            List<ModelMain> logs = new List<ModelMain>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UniCoreDpCNS")))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Total_Milk_Table", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ModelMain log = new ModelMain
                            {
                                tblDate = Convert.ToDateTime (reader["createdOn"]),
                                tblqty = Convert.ToInt32(reader["Quantity"]),
                                tblamount = Convert.ToInt32(reader["Price"]),
                               

                            };
                            logs.Add(log);
                        }
                    }

                    return Ok(logs);
                }

            }
        }
    }
}
