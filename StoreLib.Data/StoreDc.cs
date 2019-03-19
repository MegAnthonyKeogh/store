using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreLib.Entities;
using StoreLib.Data;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using StoreLib.Interfaces;
using System.Data.Common;

namespace StoreLib.Data
{
    public class StoreDc : IStoreDc
    {
        private static readonly string _connStr;

        static StoreDc()
        {
            _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        public async Task<Product[]> GetProductsAsync()
        {
            var sqlConn = new SqlConnection(_connStr);

            var cmd = new SqlCommand
            {
                CommandText = "GetProductsAsync",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConn
            };

            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();

            try
            {
                await sqlConn.OpenAsync();
                da.Fill(ds);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            var list = new List<Product>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var p = new Product
                {
                    ProductID = (int)dr["ProductID"],
                    Name = (string)dr["Name"],
                    QuanityOnHand = (int)dr["QuantityOnHnad"],
                    Price = (double)Convert.ChangeType(dr["Price"], typeof(double))
                };
                list.Add(p);
            }

            return list.ToArray();
        }

        public async Task<Order> InsertOrderId(NewOrder order)
        {
            var sqlConn = new SqlConnection(_connStr);
            DataTable table = new DataTable();

            table.Columns.Add("ProductID", typeof(int));
            table.Columns.Add("QuantitytoBuy", typeof(int));

            foreach (var p in order.Items)
            {
                var dr = table.NewRow();

                dr["ProductId"] = p.ProductID;
                dr["QuantityToBuy"] = p.QuantityToBuy;
                
                table.Rows.Add(dr);
            }


            var cmd = new SqlCommand();
            //this is where you pass in the table
            cmd.Parameters.Add(new SqlParameter("@items", SqlDbType.Structured)
            {
                TypeName = "dbo.InsertOrderId",
                Value = table
            });

            cmd.Connection = sqlConn;
            

            // your sp should return the order with its ID and  such
            // so you need to execute a query, not a nonquery
            // and use that returned dataset to populate a new Order

          // await cmd.ExecuteQueryAsync(); // <-- change to fill a data adapter

            var newOrder = new Order();

            // populate newOrder from dataset the data adapter created

            return newOrder;
        }





        public async Task<Order> Checkout(NewOrder order)
        {
            var sqlConn = new SqlConnection(_connStr);

            DataTable table = new DataTable();

            table.Columns.Add("ProductID", typeof(int));
            table.Columns.Add("QuantitytoBuy", typeof(int));

            foreach (var p in order.Items)
            {
                var dr = table.NewRow();
                dr["ProductId"] = p.ProductID;
                dr["QuantityToBuy"] = p.QuantityToBuy;
                table.Rows.Add(dr);
            }           
            
            var cmd = new SqlCommand
            {
                CommandText = "InsertOrderId",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConn
            };

            //this is where you pass in the table
            cmd.Parameters.Add(new SqlParameter("@items", SqlDbType.Structured)
            {
                TypeName = "dbo.items",
                Value =   table
            });
            
            cmd.Parameters.AddWithValue("@taxRate", order.Tax);

            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            try
            {
                await sqlConn.OpenAsync();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }

            var newOrder = new Order
            {
                Items = order.Items
                , OrderId = (int)ds.Tables[0].Rows[0]["orderId"]
                , Tax = order.Tax
                , CreateDate = DateTime.UtcNow
            };

            return newOrder;
        }



       



        //    var cmd = new SqlCommand
        //    {
        //        CommandText = "UpdateProductsAsync",
        //        CommandType = System.Data.CommandType.StoredProcedure,
        //        Connection = sqlConn
        //    };

        //    SqlParameter QuantityPurchase = new SqlParameter();
        //    QuantityPurchase.ParameterName = "@Quantity";

        //    cmd.Parameters.Add(QuantityPurchase);

        //    SqlParameter ProdID = new SqlParameter();
        //    ProdID.ParameterName = "@ProductID";

        //    cmd.Parameters.Add(ProdID);



        //    var da = new SqlDataAdapter(cmd);
        //    var ds = new DataSet();

        //    try
        //    {
        //        await sqlConn.OpenAsync();
        //        da.Fill(ds);

        //    }
        //    finally
        //    {
        //        if (sqlConn.State == ConnectionState.Open)
        //            sqlConn.Close();
        //    }

        //    var UpdateList = new List<Product>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        var p = new Product
        //        {
        //            ProductID = (int)dr["ProductID"],
        //            Name = (string)dr["Name"],
        //            QuanityOnHand = (int)dr["QuantityOnHnad"],
        //            Price = (decimal)Convert.ChangeType(dr["Price"], typeof(decimal))
        //        };
        //        UpdateList.Add(p);
        //    }

        //    return UpdateList.ToArray();
        //}
    }

 }
    

