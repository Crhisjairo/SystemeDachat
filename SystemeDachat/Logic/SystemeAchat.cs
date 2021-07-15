using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemeDachat.DB;
using SystemeDachat.DB.Models;

namespace SystemeDachat.Logic
{
    internal static class SystemeAchat
    {
        private static Database _db = new Database();
        private static List<Product> _products = new List<Product>();
        
        private const decimal TPS = 0.05M;
        private const decimal TVQ = 0.09975M;

        public static decimal SousTotal { get; private set; }
        public static decimal Total { get; private set; }

        public static bool IsListEmpty
        {
            get
            {
                if (_products.Any())
                {
                    return false;
                }

                return true;
            }
            private set
            {
                IsListEmpty = value;
            }
        }

        public static Product SearchProduct(string product)
        {
            //À VÉRIFIER SI ON FAIT UNE REQUETE ET LE PRODUIT N'EXISTE PAS.
            Product productObject = _db.SearchProduct(product); //Vérifier SQL Injection

            if (productObject == null)
            {
                return null;
            }

            return productObject;
        }

        public static List<Product> GetAllProducts()
        {
            return _products;
        }

        public static void AddProductToList(Product product)
        {
            if (product == null)
            {
                throw new NullProductException("Impossible to treat this product because it is null");
            }

            //Calcul du subtotal et total lorsqu'on ajoute un produit
            SousTotal += product.Price;
            CalculateTotal();

            _products.Add(product);
        }

        public static void RemoveProductFromList(Product product)
        {
            if (product == null)
            {
                throw new NullProductException("Impossible to treat this product because it is null");
            }

            //Enlève montant du subtotal et total lorsqu'on enlève un produit
            SousTotal -= product.Price;
            CalculateTotal();

            _products.Remove(product);
        }

        private static void CalculateTotal()
        {
            decimal tps = SousTotal * TPS;
            decimal tvq = SousTotal * TVQ;


            Total = Math.Round(tps + tvq, 2) + SousTotal;
        }

        public static Product GetLastProductAdded()
        {
            return _products.Last();
        }

        /// <summary>
        /// Redémarre le système au complèt.
        /// 
        /// Redémarre la connection à la BD, la liste des produits, le subtotal et le total.
        /// </summary>
        public static void RestartSystem()
        {
            _db.CloseConnection();

            _db = new Database();
            _products = new List<Product>();

            SousTotal = 0;
            Total = 0;
        }

        /// <summary>
        /// Recupère les noms de tous les produits disponibles dans la base de données.
        /// 
        /// Cette méthode est juste utilisé lorsqu'une BD local est utilisée.
        /// </summary>
        /// <returns>Noms des produits</returns>
        public static string[] GetAllProductsName()
        {
            return _db.ReadAllProductsName();
        }

    }
}
