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
                    Price = (double)Convert.ChangeType(dr["Price"], typeof(double)),
                    Image = (string)dr["Image"]
                };
                list.Add(p);
            }

            return list.ToArray();
        }


        public async Task<Order> Checkout(NewOrder order)
        {
            var sqlConn = new SqlConnection(_connStr);

            DataTable table = new DataTable();

            table.Columns.Add("ProductID", typeof(int));
            table.Columns.Add("QuantitytoBuy", typeof(int));
            table.Columns.Add("Price", typeof(double));
            table.Columns.Add("Name", typeof(string));
            //table.Columns.Add("Image", typeof(string));

            foreach (var p in order.Items)
            {
                var dr = table.NewRow();
                dr["ProductId"] = p.ProductID;
                dr["QuantityToBuy"] = p.QuantityToBuy;
                dr["Price"] = p.Price;
                dr["Name"] = p.Name;
                //dr["Image"] = p.Image;
                table.Rows.Add(dr);
            }

            var cmd = new SqlCommand
            {
                CommandText = "InsertOrderId",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConn
            };

            //this is where you pass in the table
            cmd.Parameters.Add(new SqlParameter("@items3", SqlDbType.Structured)
            {
                TypeName = "dbo.items3",
                Value = table
            });

            cmd.Parameters.AddWithValue("@taxRate", order.Tax);


            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            try
            {
                await sqlConn.OpenAsync();
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                if (ex.Errors[0].Class == 16)
                {
                    throw;
                }
            }
            finally
            {
                sqlConn.Close();
            }


            
                var newOrder = new Order   
                {
                    Items = order.Items
                    ,
                    OrderId = (int)ds.Tables[0].Rows[0]["orderId"]

                    ,
                    CreateDate = DateTime.UtcNow
                    ,
                    Tax = order.Tax
                };
            
             return newOrder;
        }
    

        public async Task<ReturnOrder> GetOrderAsync(ReturnOrder Order)
        {



            var sqlConn = new SqlConnection(_connStr);

            var cmd = new SqlCommand
            {
                CommandText = "GetOrderAsync",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConn
            };

            cmd.Parameters.AddWithValue("@orderId", Order.OrderId);


            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();

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
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            //trying to create the instance to retrieve info about the order from dbo.ORDERS And dbo.OrderDetails
            // right now just trying to get the info from OrderDetails.
            //should I pass the OrderId in to this function? 
            var order = new ReturnOrder()
            {
                OrderId = Order.OrderId,
               // Tax = new ReturnOrder().Tax,
                //DateTime CreatedDate = (DateTime)dr["DateCreated"]
                Items = new List<OrderProduct>()
            };

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var p = new OrderProduct()
                {
                    QuantityToBuy = (int)dr["Quantity"],
                    ProductID = (int)dr["ProductID"],
                    Price = (double)Convert.ChangeType(dr["Price"], typeof(double)),
                    Name = (string)dr["Name"]
                    //Image = (string)dr["Image"]
                };
                order.Items.Add(p);

            }
          
            order.Tax = (decimal)Convert.ChangeType(ds.Tables[0].Rows[0]["TaxRate"], typeof(decimal));
            


            return order;

        }



    }
}
   
 
    

