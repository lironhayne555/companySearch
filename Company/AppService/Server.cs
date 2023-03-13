using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;
using Company.Module;
using System.Data;

namespace Company.AppService
{
    public class Server
    {
       private SqlConnection cn;
        private SqlCommand cmd;
        private  SqlDataReader da;
        private SqlDataAdapter dr;
        private DataTable dt;
    public List<Customer> GetDataSearch(string company, string name, string phone)
        {
            List<Customer> myList = new List<Customer>();
            try
            {
                string query = @"Select DISTINCT CU.[CustomerID],CU.[CompanyName],CU.[ContactName],CU.[Address],CU.[Phone],Orders.Total_Orders
                  FROM [Customers] AS CU
                 LEFT JOIN  ( SELECT [Orders].[CustomerID] ,[Orders].[OrderID],  COUNT(*) OVER (PARTITION BY [CustomerID]) AS Total_Orders FROM [Orders] )  AS Orders
                  ON CU.[CustomerID]=Orders.[CustomerID]
                  WHERE CU.[CompanyName] LIKE @Company AND CU.[ContactName] LIKE  @Name
              AND CU.[Phone] LIKE @Phone
              ORDER BY CU.CompanyName DESC ";

                this.cn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\liron\\Desktop\\c#\\Company\\Company\\App_Data\\companyData.mdf;Integrated Security=True");
                this.dr = new SqlDataAdapter(query, cn);
                this.dr.SelectCommand.Parameters.Add(new SqlParameter { ParameterName = "@Company", Value = company, SqlDbType = SqlDbType.VarChar });
                this.dr.SelectCommand.Parameters.Add(new SqlParameter { ParameterName = "@Name", Value = name, SqlDbType = SqlDbType.VarChar });
                this.dr.SelectCommand.Parameters.Add(new SqlParameter { ParameterName = "@Phone", Value = phone, SqlDbType = SqlDbType.VarChar });
                DataTable dt = new DataTable();
                this.dr.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Customer cust = new Customer();
                   cust.ID = row["CustomerID"].ToString();
                   cust.CompanyName = row["CompanyName"].ToString();
                    cust.ContactName = row["ContactName"].ToString();
                    cust.Address = row["Address"].ToString();
                    cust.Phone = row["Phone"].ToString();
                    cust.TotalOrders = (int)row["Total_Orders"];
                    myList.Add(cust);
                }
                
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            
            }

            return myList;
        }
    }
}