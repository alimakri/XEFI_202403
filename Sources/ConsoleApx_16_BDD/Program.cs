using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApx_16_BDD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connexion
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
            cnx.Open();

            // Requete
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT Person.Person.BusinessEntityID, Person.Person.FirstName, Person.Person.LastName, Person.Address.City
                                FROM Person.Person INNER JOIN
                                 Person.BusinessEntity ON Person.Person.BusinessEntityID = Person.BusinessEntity.BusinessEntityID INNER JOIN
                                 Person.BusinessEntityAddress ON Person.BusinessEntity.BusinessEntityID = Person.BusinessEntityAddress.BusinessEntityID INNER JOIN
                                 Person.Address ON Person.BusinessEntityAddress.AddressID = Person.Address.AddressID where City='Lyon'";
            SqlDataReader rd = cmd.ExecuteReader();

            // Affichage
            while (rd.Read())
            {
                Console.WriteLine("{0} {1} {2} {3}", rd["BusinessEntityID"], rd["FirstName"], rd["LastName"], rd["City"]);
            }
            rd.Close();

            Console.ReadLine(); 
        }
    }
}
