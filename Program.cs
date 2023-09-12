using System.Data.SqlClient;
namespace cSharp_ExperienceADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);Initial Catalog=ITI; Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                string UpdateString = "Update dbo.Student set St_Age = St_Age / 10";
                SqlCommand Command = new SqlCommand(UpdateString, sqlConnection);
                int returns = Command.ExecuteNonQuery();
                Console.WriteLine("Number of affecte rows = " + returns);

                
                string queryString = "select * from Student order by St_Age DESC;";


                Command = new SqlCommand(queryString, sqlConnection);



                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)// check reader is not empty
                {
                    while (reader.Read())
                    {

                        Console.WriteLine(reader[0] + " " + reader["St_Fname"].ToString() + " " + reader["St_Age"]);
                    }

                    reader.Close();
                }
                else
                {
                    Console.WriteLine("No data retrieved");
                }


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


            Console.ReadLine();
        }
    }
}