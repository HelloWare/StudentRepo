using HWA.ECom.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWA.ECom.Repository
{
    public class CustomerOrderRepository
    {
        #region Fields
        private String _connectionString;
        #endregion

        #region Constructors
        public CustomerOrderRepository()
        {
        }
        public CustomerOrderRepository(String connectionString)
        {
            this._connectionString = connectionString;
        }
        #endregion

        //CRUD, 
        public Boolean Insert(CustomerOrder customerOrder)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_CustomerOrder_Insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CustomerId", customerOrder.CustomerId);
                cmd.Parameters.AddWithValue("StatusId", customerOrder.StatusId);
                cmd.Parameters.AddWithValue("GrandTotal", customerOrder.GrandTotal);
                cmd.Parameters.AddWithValue("PaymentType", customerOrder.PaymentType);
                cmd.Parameters.AddWithValue("ShipToAddressId", customerOrder.ShipToAddressId);
                cmd.Parameters.AddWithValue("OrderNumber", customerOrder.OrderNumber);
                cmd.Parameters.AddWithValue("LastModifiedDate", customerOrder.LastModifiedDate);
                cmd.Parameters.AddWithValue("CreatedDate", customerOrder.CreatedDate);
                cmd.Parameters.AddWithValue("CreatedBy", customerOrder.CreatedBy);
                cmd.Parameters.AddWithValue("LastModifiedBy", customerOrder.LastModifiedBy);
                //Add more parameters from SP

                Int32 id = cmd.ExecuteNonQuery();

                if (id > 0)
                {
                    customerOrder.Id = id;
                    return true;
                }
            }
            return false;
        }

        public Boolean Update(CustomerOrder customerOrder)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_CustomerOrder_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", customerOrder.Id);
                cmd.Parameters.AddWithValue("CustomerId", customerOrder.CustomerId);
                cmd.Parameters.AddWithValue("StatusId", customerOrder.StatusId);
                cmd.Parameters.AddWithValue("GrandTotal", customerOrder.GrandTotal);
                cmd.Parameters.AddWithValue("PaymentType", customerOrder.PaymentType);
                cmd.Parameters.AddWithValue("ShipToAddressId", customerOrder.ShipToAddressId);
                cmd.Parameters.AddWithValue("OrderNumber", customerOrder.OrderNumber);
                cmd.Parameters.AddWithValue("LastModifiedDate", customerOrder.LastModifiedDate);
                cmd.Parameters.AddWithValue("LastModifiedBy", customerOrder.LastModifiedBy);
                //Add more parameters from SP

                Int32 id = cmd.ExecuteNonQuery();

                if (id > 0)
                {
                    customerOrder.Id = id;
                    return true;
                }
            }
            return false;
        }

        public Boolean Delete(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_CustomerOrder_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);
          

                Int32 counts = cmd.ExecuteNonQuery();

                if (counts > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public CustomerOrder GetById(Int32 id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_ECom_GetCustomerOrder", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                CustomerOrder customerOrder = new CustomerOrder();
                while (reader.Read())
                {
                    customerOrder.Id = id;
                    customerOrder.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    customerOrder.StatusId = Convert.ToInt32(reader["StatusId"]);
                    customerOrder.GrandTotal = Convert.ToDecimal(reader["GrandTotal"]);
                    customerOrder.PaymentType = Convert.ToString(reader["PaymentType"]);
                    customerOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    customerOrder.ShipToAddressId = Convert.ToString(reader["ShipToAddressId"]);
                    customerOrder.OrderNumber = Convert.ToString(reader["OrderNumber"]);
                    customerOrder.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    customerOrder.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    customerOrder.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    customerOrder.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    //TO BE DONE, ORM process, map table data to class object

                }
                return customerOrder;
            }
        }

        public List<CustomerOrder> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from CustomerOrder", con);
               

                SqlDataReader reader = cmd.ExecuteReader();
                List<CustomerOrder> customerOrders = new List<CustomerOrder>();
                while (reader.Read())
                {
                    CustomerOrder customerOrder = new CustomerOrder();
                    customerOrder.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    customerOrder.StatusId = Convert.ToInt32(reader["StatusId"]);
                    customerOrder.GrandTotal = Convert.ToDecimal(reader["GrandTotal"]);
                    customerOrder.PaymentType = Convert.ToString(reader["PaymentType"]);
                    customerOrder.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    customerOrder.ShipToAddressId = Convert.ToString(reader["ShipToAddressId"]);
                    customerOrder.OrderNumber = Convert.ToString(reader["OrderNumber"]);
                    customerOrder.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                    customerOrder.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    customerOrder.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    customerOrder.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    customerOrders.Add(customerOrder);
                    //TO BE DONE, ORM process, map table data to class object

                }
                return customerOrders;
            }
        }

        public List<CustomerOrder> GetCustomerOrderWithStatusId(int StatusId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from  [dbo].[CustomerOrder] where StatusId="+StatusId,con);
                

                cmd.Parameters.AddWithValue("StatusId", StatusId);

                SqlDataReader reader = cmd.ExecuteReader();
                List<CustomerOrder> customerOrders = new List<CustomerOrder>();


                
                while (reader.Read())
                {

                    foreach (var co in customerOrders)
                    {
                        co.Id = Convert.ToInt32(reader["Id"]);
                        co.CustomerId= Convert.ToInt32(reader["CustomerId"]);
                        co.GrandTotal= Convert.ToDecimal(reader["GrandTotal"]);
                        co.PaymentType= Convert.ToString(reader["PaymentType"]);
                        co.OrderDate= Convert.ToDateTime(reader["OrderDate"]);
                        co.ShipToAddressId = Convert.ToString(reader["ShipToAddressId"]);
                        co.OrderNumber = Convert.ToString(reader["OrderNumber"]);
                        co.LastModifiedDate = Convert.ToDateTime(reader["LastModifiedDate"]);
                        co.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        co.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                        co.LastModifiedBy = Convert.ToString(reader["LastModifiedBy"]);
                    }

                    //TO BE DONE, ORM process, map table data to class object

                }
                return customerOrders;
            }
        }

    }
}
