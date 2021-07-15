using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemeDachat.Views.UserControl;

namespace SystemeDachat.DB.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public int Stock { get; }
        public string Description { get; }
        public string Brand { get; }
        public decimal Price { get; }
        public string Img { get; private set; } //À MODIFIER, l'image. BitImage???

        public ProductControl ProductControl { get; set; }

        public Product(int id, string name, int stock, string desc, string brand, decimal price) //AJOUTER L'IMG
        {
            this.Id = id;
            this.Name = name;
            this.Stock = stock;
            this.Description = desc;
            this.Brand = brand;
            this.Price = price;
            //this.Img = img;

            CreateProductControl();
        }

        private void CreateProductControl()
        {
            ProductControl = new ProductControl(this);
        }


        public override string ToString()
        {
            return $"id: {Id}\t Name: {Name}\t Stock: {Stock}\t Description: ­{Description}\t Brand: {Brand}\t Price: {Price}\t Img: ImageIcitte";
        }
    }
}
