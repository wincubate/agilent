using System.Collections.Generic;

namespace Wincubate.UnitOfWorkExamples.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public override string ToString()
            => $"[{Id}] {Category?.ToString() ?? "-"}: \"{Name}\" by {Manufacturer}";

        public Product()
        {
        }

        public Product( int id, string name, string manufacturer, Category? category = null )
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Category = category;
        }
    }
}