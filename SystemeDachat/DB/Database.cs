using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using SystemeDachat.DB.Models;

namespace SystemeDachat.DB
{
    /// <summary>
    /// Gestion et connection à la base de données distante MySQL.
    /// </summary>
    internal class Database
    {
        private SQLiteConnection _conn;

        public Database()
        {
            _conn = CreateConnection();
        }

        private static SQLiteConnection CreateConnection()
        {
            var sqliteConn = new SQLiteConnection("Data Source= database.db; Version = 3; New = True; Compress = True; ");
            // Ouverture de la connection
            try
            { 
                sqliteConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to connecto to database, please contact the admin.", "Error");
            }
            
            return sqliteConn;
        }

        public Product SearchProduct(String product)
        {
            //Création du DataReader
            string query = $"SELECT * FROM products WHERE name = \'{product}\';";
            SQLiteDataReader dataReader = CreateDataReader(query);

            //Création de l'object product et le return
            if (dataReader.HasRows)
            {
                dataReader.Read();

                return CreateProduct(dataReader);
            }

            return null;
        }

        /// <summary>
        /// Recupère seulement les noms de tous les produits disponibles dans la base de données.
        /// </summary>
        /// <returns>Noms des produits</returns>
        public string[] ReadAllProductsName()
        {
            List<string> productsName = new List<string>();

            string query = "SELECT name FROM products;";
            SQLiteDataReader dataReader = CreateDataReader(query);

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    string name = dataReader.GetString(0);

                    productsName.Add(name);
                }
            }

            dataReader.Close();

            return productsName.ToArray();
        }

        /// <summary>
        /// Ferme la connection de la BD.
        /// </summary>
        public void CloseConnection()
        {
            _conn.Close();
        }

        /// <summary>
        /// Crée un objet Product.
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private Product CreateProduct(SQLiteDataReader dataReader)
        {
            int id = dataReader.GetInt32(0);
            string name = dataReader.GetString(1);
            int stock = dataReader.GetInt32(2);
            string desc = dataReader.GetString(3);
            string brand = dataReader.GetString(4);
            decimal price = dataReader.GetDecimal(5);
            // Type img = dataReader.GetInt32(2); // AJOUTER IMAGE ICITTE
            

            dataReader.Close();

            return new Product(id, name, stock, desc, brand, price);
        }

        /// <summary>
        /// Crée un object SQLiteDataReader avec une requête.
        /// </summary>
        /// <returns></returns>
        private SQLiteDataReader CreateDataReader(string query)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;

            sqlite_cmd = _conn.CreateCommand();
            sqlite_cmd.CommandText = query; //

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            return sqlite_datareader;
        }

        
    }
}
