using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZProject_TD
{
    enum VerbeEnum { None, Get, Set, Add, Delete }
    enum NomEnum { None, Product, Categorie, Commande }
    internal class Program
    {
        static void Main(string[] args)
        {
            var saisie = Console.ReadLine();
            VerbeEnum verbe = VerbeEnum.None;
            NomEnum nom = NomEnum.None; string paramName = null; string paramValue = null;
            List<object> liste = null;
            if (!Extraire(saisie, ref verbe, ref nom, ref paramName, ref paramValue))
            {
                Console.WriteLine("Instruction non valide");
            }
            else
            {
                liste = Requeter(verbe, nom, paramName, paramValue);
            }
            if (liste != null) Afficher(liste); else Console.WriteLine("Erreur !");
            Console.ReadLine();
        }

        private static void Afficher(List<object> liste)
        {
            foreach (var p in liste)
            {
                Console.WriteLine(p);
            }
        }

        private static List<object> Requeter(VerbeEnum verbe, NomEnum nom, string paramName, string paramValue)
        {
            string requete = null;
            if (verbe == VerbeEnum.Get && nom == NomEnum.Product && paramName == "Categorie")
            {
                requete = $@"SELECT p.ProductID, 
                                    p.Name, 
                                    p.ListPrice, c.Name AS Cat
                                FROM Production.Product p 
                                    INNER JOIN Production.ProductSubcategory sc ON p.ProductSubcategoryID = sc.ProductSubcategoryID 
                                    INNER JOIN Production.ProductCategory c ON sc.ProductCategoryID = c.ProductCategoryID
                                WHERE (c.Name = N'{paramValue}')";
                return GetProduct(requete, paramValue);
            }
            else if (verbe == VerbeEnum.Get && nom == NomEnum.Product)
            {
                requete = @"select ProductID, Name, ListPrice from Production.Product";
                return GetProduct(requete);
            }
            else if (verbe == VerbeEnum.Get && nom == NomEnum.Categorie)
            {
                requete = @"select ProductCategoryID, Name from Production.ProductCategory";
                return GetCategorie(requete);
            }
            else if (verbe == VerbeEnum.Get && nom == NomEnum.Commande)
            {
                requete = $@"select 
	                             Year(OrderDate) as Annee, 
	                            SUM(d.UnitPrice * d.OrderQty) Total
                            from 
	                            Sales.SalesOrderHeader h
	                            inner join Sales.SalesOrderDetail d on d.SalesOrderID = h.SalesOrderID
                            group by Year(OrderDate)
                            having Year(OrderDate)={paramValue}
                            order by Annee desc";
                return GetCommande(requete, paramValue);
            }
            return null;
        }
        private static List<object> GetCategorie(string requete)
        {
            var liste = new List<object>(); SqlDataReader rd;
            // Connexion
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
            try
            {
                cnx.Open();
            }
            catch (Exception ex) { return null; }
            // Requete
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = requete;
            try
            {
                rd = cmd.ExecuteReader();
            }
            catch (Exception ex) { return null; }


            // Affichage
            while (rd.Read())
            {
                liste.Add(new Categorie
                {
                    Id = (int)rd["ProductCategoryID"],
                    Nom = rd["Name"].ToString(),
                });
            }
            rd.Close();
            return liste;
        }
        private static List<object> GetCommande(string requete, string value = null)
        {
            var liste = new List<object>(); SqlDataReader rd;
            // Connexion
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
            try
            {
                cnx.Open();
            }
            catch (Exception ex) { return null; }
            // Requete
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = requete;
            try
            {
                rd = cmd.ExecuteReader();
            }
            catch (Exception ex) { return null; }


            // Affichage
            while (rd.Read())
            {
                liste.Add(new Commande
                {
                    Annee = (int) rd["Annee"],
                    Total = (decimal)rd["Total"]
                });
            }
            rd.Close();
            return liste;
        }

        private static List<object> GetProduct(string requete, string value = null)
        {
            var liste = new List<object>(); SqlDataReader rd;
            // Connexion
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
            try
            {
                cnx.Open();
            }
            catch (Exception ex) { return null; }
            // Requete
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = requete;
            try
            {
                rd = cmd.ExecuteReader();
            }
            catch (Exception ex) { return null; }


            // Affichage
            while (rd.Read())
            {
                liste.Add(new Produit
                {
                    Id = (int)rd["ProductID"],
                    Nom = rd["Name"].ToString(),
                    Prix = (decimal)rd["ListPrice"]
                });
            }
            rd.Close();
            return liste;
        }

        //private static List<Produit> GetProductByCategorie(string value)
        //{
        //    var liste = new List<Produit>(); SqlDataReader rd;
        //    // Connexion
        //    SqlConnection cnx = new SqlConnection();
        //    cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
        //    try
        //    {
        //        cnx.Open();
        //    }
        //    catch (Exception ex) { return null; }
        //    // Requete
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = cnx;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = $@"SELECT        
        //                            p.ProductID, 
        //                            p.Name, 
        //                            p.ListPrice, c.Name AS Cat
        //                        FROM Production.Product p 
        //                            INNER JOIN Production.ProductSubcategory sc ON p.ProductSubcategoryID = sc.ProductSubcategoryID 
        //                            INNER JOIN Production.ProductCategory c ON sc.ProductCategoryID = c.ProductCategoryID
        //                        WHERE (c.Name = N'{value}')";
        //    try
        //    {
        //        rd = cmd.ExecuteReader();
        //    }
        //    catch (Exception ex) { return null; }


        //    // Affichage
        //    while (rd.Read())
        //    {
        //        liste.Add(new Produit
        //        {
        //            Id = (int)rd["ProductID"],
        //            Nom = rd["Name"].ToString(),
        //            Prix = (decimal)rd["ListPrice"]
        //        });
        //    }
        //    rd.Close();
        //    return liste;
        //}

        //private static List<Produit> GetProduct()
        //{
        //    var liste = new List<Produit>(); SqlDataReader rd;
        //    // Connexion
        //    SqlConnection cnx = new SqlConnection();
        //    cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=true";
        //    try
        //    {
        //        cnx.Open();
        //    }
        //    catch (Exception ex) { return null; }
        //    // Requete
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = cnx;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = @"select ProductID, Name, ListPrice from Production.Product";

        //    try
        //    {
        //        rd = cmd.ExecuteReader();
        //    }
        //    catch (Exception ex) { return null; }


        //    // Affichage
        //    while (rd.Read())
        //    {
        //        liste.Add(new Produit { Id = (int)rd["ProductID"], Nom = rd["Name"].ToString(), Prix = (decimal)rd["ListPrice"] });
        //    }
        //    rd.Close();
        //    return liste;
        //}

        private static bool Extraire(
            string saisie,
            ref VerbeEnum verbe,
            ref NomEnum nom,
            ref string paramName,
            ref string paramValue)
        {
            Regex regex = new Regex("(\\w+)-(\\w+) *-?(\\w+)? *(\\w+)?");

            // Trouver les correspondances dans le texte d'entrée
            MatchCollection matches = regex.Matches(saisie);

            // Parcourir les correspondances et extraire les captures
            foreach (Match match in matches)
            {
                // Captures
                Enum.TryParse<VerbeEnum>(match.Groups[1].Value, true, out verbe);
                Enum.TryParse<NomEnum>(match.Groups[2].Value, true, out nom);
                paramName = match.Groups[3].Value;
                paramValue = match.Groups[4].Value;
            }
            return verbe != VerbeEnum.None && nom != NomEnum.None;
        }
    }
}
