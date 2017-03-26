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
                CustomerOrder customerOrder;
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                    {
                        customerOrder = new CustomerOrder(reader.GetInt32(0), reader.GetInt32(1));
                        if (!reader.IsDBNull(1))
                            customerOrder.CustomerId = reader.GetInt32(1);
                        if (!reader.IsDBNull(2))
                            customerOrder.StatusId = reader.GetInt32(2);
                        if (!reader.IsDBNull(3))
                            customerOrder.GrandTotal = reader.GetDecimal(3);
                        if (!reader.IsDBNull(4))
                            customerOrder.PaymentType = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                            customerOrder.OrderDate = reader.GetDateTime(5);
                        if (!reader.IsDBNull(6))
                            customerOrder.ShipToAddressId = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                            customerOrder.OrderNumber = reader.GetString(7);
                        if (!reader.IsDBNull(8))
                            customerOrder.CreatedBy = reader.GetString(8);
                        if (!reader.IsDBNull(9))
                            customerOrder.CreatedDate = reader.GetDateTime(9);
                        if (!reader.IsDBNull(10))
                            customerOrder.LastModifiedBy = reader.GetString(10);
                        if (!reader.IsDBNull(11))
                            customerOrder.LastModifiedDate = reader.GetDateTime(11);
                        //TO BE DONE, ORM process, map table data to class object
                        return customerOrder;
                    }
                }          
            }
            return null;
        }

        public List<CustomerOrder> GetAll()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from CustomerOrder", con);
               

                SqlDataReader reader = cmd.ExecuteReader();
                List<CustomerOrder> customerOrders = new List<CustomerOrder>();
                CustomerOrder customerOrder;
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                    {
                        customerOrder = new CustomerOrder(reader.GetInt32(1), reader.GetInt32(2));
                        if (!reader.IsDBNull(0))
                            customerOrder.Id = reader.GetInt32(0);

                        if (!reader.IsDBNull(3))
                            customerOrder.GrandTotal = reader.GetDecimal(3);
                        if (!reader.IsDBNull(4))
                            customerOrder.PaymentType = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                            customerOrder.OrderDate = reader.GetDateTime(5);
                        if (!reader.IsDBNull(6))
                            customerOrder.ShipToAddressId = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                            customerOrder.OrderNumber = reader.GetString(7);
                        if (!reader.IsDBNull(10))
                            customerOrder.CreatedBy =  reader.GetString(10);
                        if (!reader.IsDBNull(9))
                            customerOrder.CreatedDate = reader.GetDateTime(9);
                        if (!reader.IsDBNull(11))
                            customerOrder.LastModifiedBy = reader.GetString(11);
                        if (!reader.IsDBNull(8))
                            customerOrder.LastModifiedDate = reader.GetDateTime(8);
                        customerOrders.Add(customerOrder);
                        //TO BE DONE, ORM process, map table data to class object
                    }
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
                        if (!reader.IsDBNull(0))
                            co.Id = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                            co.CustomerId = reader.GetInt32(1);
                        if (!reader.IsDBNull(2))
                            co.StatusId = reader.GetInt32(2);
                        if (!reader.IsDBNull(3))
                            co.GrandTotal = reader.GetDecimal(3);
                        if (!reader.IsDBNull(4))
                            co.PaymentType = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                            co.OrderDate = reader.GetDateTime(5);
                        if (!reader.IsDBNull(6))
                            co.ShipToAddressId = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                            co.OrderNumber = reader.GetString(7);
                        if (!reader.IsDBNull(8))
                            co.CreatedBy = reader.GetString(8);
                        if (!reader.IsDBNull(9))
                            co.CreatedDate = reader.GetDateTime(9);
                        if (!reader.IsDBNull(10))
                            co.LastModifiedBy = reader.GetString(10);
                        if (!reader.IsDBNull(11))
                            co.LastModifiedDate = reader.GetDateTime(11);
                    }

                    //TO BE DONE, ORM process, map table data to class object

                }
                return customerOrders;
            }
        }

    }
}
