using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_CRUD_ADO_DOT_NET_STORPROCEDURE.Models
{
    public class EmployeeServices
    {
        string connection = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
        private SqlConnection con;
        private SqlCommand command;
        private SqlDataReader dataReader;


        public IEnumerable<Employee> Employees
        {
            get
            {
                List<Employee> employees = new List<Employee>();
                using (con = new SqlConnection(connection))
                {
                    using (command = new SqlCommand("getEmployee", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Id = Convert.ToInt32(dataReader["Id"]);
                            employee.EmployeeName = dataReader["EmployeeName"].ToString();
                            employee.Gender = dataReader["Gender"].ToString();
                            employee.City = dataReader["City"].ToString();
                            employee.EmailAddress = dataReader["EmailAddress"].ToString();
                            employee.PhoneNumber = dataReader["PhoneNumber"].ToString();
                            employees.Add(employee);
                        }
                        con.Close();
                    }
                }
                return employees;
            }
        }

        public string SaveEmployee(Employee employee)
        {
            string message = string.Empty;
            int rowAfected;
            using (con = new SqlConnection(connection))
            {
                using (command = new SqlCommand("SaveEmployee", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlParameterEmployeeName = new SqlParameter();
                    sqlParameterEmployeeName.ParameterName = "@EmployeeName";
                    sqlParameterEmployeeName.Value = employee.EmployeeName;
                    command.Parameters.Add(sqlParameterEmployeeName);

                    SqlParameter sqlParameterGender = new SqlParameter();
                    sqlParameterGender.ParameterName = "@Gender";
                    sqlParameterGender.Value = employee.Gender;
                    command.Parameters.Add(sqlParameterGender);

                    SqlParameter sqlParameterCity = new SqlParameter();
                    sqlParameterCity.ParameterName = "@City";
                    sqlParameterCity.Value = employee.City;
                    command.Parameters.Add(sqlParameterCity);

                    SqlParameter sqlParameterEmailAddress = new SqlParameter();
                    sqlParameterEmailAddress.ParameterName = "@EmailAddress";
                    sqlParameterEmailAddress.Value = employee.EmailAddress;
                    command.Parameters.Add(sqlParameterEmailAddress);

                    SqlParameter sqlParameterPhoneNumber = new SqlParameter();
                    sqlParameterPhoneNumber.ParameterName = "@PhoneNumber";
                    sqlParameterPhoneNumber.Value = employee.PhoneNumber;
                    command.Parameters.Add(sqlParameterPhoneNumber);
                    con.Open();
                    rowAfected = command.ExecuteNonQuery();
                    con.Close();
                    if (rowAfected > 0)
                    {
                        message = "Data save succesfully";
                    }
                    else
                    {
                        message = "Data save faild!";
                    }
                }
            }
            return message;
        }

        public string UpdateEmployee(Employee employee)
        {
            string message = string.Empty;
            int rowAfected;
            using (con = new SqlConnection(connection))
            {
                using (command = new SqlCommand("UpdateEmployee", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlParameterEmployeeId = new SqlParameter();
                    sqlParameterEmployeeId.ParameterName = "@Id";
                    sqlParameterEmployeeId.Value = employee.Id;
                    command.Parameters.Add(sqlParameterEmployeeId);

                    SqlParameter sqlParameterEmployeeName = new SqlParameter();
                    sqlParameterEmployeeName.ParameterName = "@EmployeeName";
                    sqlParameterEmployeeName.Value = employee.EmployeeName;
                    command.Parameters.Add(sqlParameterEmployeeName);

                    SqlParameter sqlParameterGender = new SqlParameter();
                    sqlParameterGender.ParameterName = "@Gender";
                    sqlParameterGender.Value = employee.Gender;
                    command.Parameters.Add(sqlParameterGender);

                    SqlParameter sqlParameterCity = new SqlParameter();
                    sqlParameterCity.ParameterName = "@City";
                    sqlParameterCity.Value = employee.City;
                    command.Parameters.Add(sqlParameterCity);

                    SqlParameter sqlParameterEmailAddress = new SqlParameter();
                    sqlParameterEmailAddress.ParameterName = "@EmailAddress";
                    sqlParameterEmailAddress.Value = employee.EmailAddress;
                    command.Parameters.Add(sqlParameterEmailAddress);

                    SqlParameter sqlParameterPhoneNumber = new SqlParameter();
                    sqlParameterPhoneNumber.ParameterName = "@PhoneNumber";
                    sqlParameterPhoneNumber.Value = employee.PhoneNumber;
                    command.Parameters.Add(sqlParameterPhoneNumber);
                    con.Open();
                    rowAfected = command.ExecuteNonQuery();
                    con.Close();
                    if (rowAfected > 0)
                    {
                        message = "Data Update succesfully";
                    }
                    else
                    {
                        message = "Data Update faild!";
                    }
                }
            }
            return message;
        }

        public void DeleteEmployee(int id)
        {
            using (con = new SqlConnection(connection))
            {
                using (command = new SqlCommand("DeleteEmployee", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@Id";
                    sqlParameter.Value = id;
                    command.Parameters.Add(sqlParameter);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}