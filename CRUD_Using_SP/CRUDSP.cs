using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Using_SP
{
    public class CRUDSP
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source = MOBACK; Initial Catalog = demo; Integrated Security = True");
        public void Create()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Enter Employee Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Employee Age:");
                int Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Department ID:");
                Console.WriteLine("1 for HR\n2 for Developer\n3 for Devops");
                int DepId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Salary ID:");
                Console.WriteLine("1 for 15000\n2 for 20000\n3 for 40000");
                int SalId = Convert.ToInt32(Console.ReadLine());
                
                string createQuery = "EXEC AddEmpSP'" + name + "',"+Age+"," + DepId + "," + SalId;
                SqlCommand createCommand = new SqlCommand(createQuery, sqlConnection);
                createCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void DisplayAll()
        {
            try
            {
                sqlConnection.Open();
                
                string retrieveAllQuery = "EXEC DisplayAllEmployeeSP";
                SqlCommand retrieveAllCommand = new SqlCommand(retrieveAllQuery, sqlConnection);
                SqlDataReader dataReader = retrieveAllCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.Write("\nEmployee Id:"+dataReader.GetValue(0)); 
                    Console.Write("\tEmployee Name:" + dataReader.GetString(1));
                    Console.Write("\tDepartment:" + dataReader.GetString(2));
                    Console.Write("\tSalary:" + dataReader.GetValue(3));
                }
                dataReader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Display()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Enter the Employee Id you want to display");
                string EmpID = Console.ReadLine();
                
                string retrieveQuery = "EXEC DisplaySP'" + EmpID+"'";
                SqlCommand retrieveCommand = new SqlCommand(retrieveQuery, sqlConnection);
                SqlDataReader dataReader = retrieveCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.Write("\nEmployee ID:" + dataReader.GetValue(0));
                    Console.Write("\tName:" + dataReader.GetString(1));
                    Console.Write("\tDepartment ID:" + dataReader.GetValue(2));
                    Console.Write("\tSalary ID:" + dataReader.GetValue(3));
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Update()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Enter Employee ID that you want to update:");
                string EmpID = Console.ReadLine();
                Console.WriteLine("Re-Name Employee Name:");
                string Mname = Console.ReadLine();
                Console.WriteLine("Enter Employee Age:");
                int Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Department ID you want to modify:");
                Console.WriteLine("1 for HR\n2 for Developer\n3 for Devops");
                int DepId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Salary ID you want to modify:");
                Console.WriteLine("1 for 15000\n2 for 20000\n3 for 40000");
                int SalId = Convert.ToInt32(Console.ReadLine());
                
                string updateQuery = "EXEC UpdateSP'"+EmpID+"','"+Mname+"',"+Age+","+DepId+","+SalId;
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Delete()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Enter Employee ID that you want to delete:");
                string EmpID = Console.ReadLine();
                
                string deleteQuery = "EXEC DeleteSP'" + EmpID+"'";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
