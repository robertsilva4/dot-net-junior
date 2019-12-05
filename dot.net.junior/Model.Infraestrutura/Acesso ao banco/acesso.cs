using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Model.Infraestrutura.Acesso_ao_banco
{
    namespace sqltest
    {
        class acesso
        {
            static void Main(string[] args)
            {
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "ROBERT-PC";
                    builder.UserID = "RICHARD";
                    builder.Password = "123456";
                    builder.InitialCatalog = "CADASTRO";

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        //Console.WriteLine("\nQuery data example:");
                        //Console.WriteLine("=========================================\n");

                        connection.Open();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("SELECT");
                        sb.Append("SELEC");
                        sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                        sb.Append("JOIN [SalesLT].[Product] p ");
                        sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                        String sql = sb.ToString();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                                }
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.ReadLine();
            }
        }
    }
}
