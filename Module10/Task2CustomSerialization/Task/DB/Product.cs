namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Serializable]
    public class Product : ISerializable
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Product(SerializationInfo info, StreamingContext context)
        {
            ProductId = (int)info.GetValue("SerializedProductId", typeof(int));
            ProductName = (string)info.GetValue("SerializedProductName", typeof(string));
            SupplierId = (int?)info.GetValue("SerializedSupplierID", typeof(int?));
            CategoryId = (int?)info.GetValue("SerializedCategoryID", typeof(int?));
            QuantityPerUnit = (string)info.GetValue("SerializedQuantityPerUnit", typeof(string));
            UnitPrice = (decimal?)info.GetValue("SerializedUnitPrice", typeof(decimal?));
            UnitsInStock = (short?)info.GetValue("SerializedUnitsInStock", typeof(short?));
            UnitsOnOrder = (short?)info.GetValue("SerializedUnitsOnOrder", typeof(short?));
            ReorderLevel = (short?)info.GetValue("SerializedReorderLevel", typeof(short?));
        }
        public int ProductId { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Supplier Supplier { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SerializedProductId", ProductId, typeof(int));
            info.AddValue("SerializedProductName", ProductName, typeof(string));
            info.AddValue("SerializedSupplierID", SupplierId, typeof(int?));
            info.AddValue("SerializedCategoryID", CategoryId, typeof(int?));
            info.AddValue("SerializedQuantityPerUnit", QuantityPerUnit, typeof(string));
            info.AddValue("SerializedUnitPrice", UnitPrice, typeof(decimal?));
            info.AddValue("SerializedUnitsInStock", UnitsInStock, typeof(short?));
            info.AddValue("SerializedUnitsOnOrder", UnitsOnOrder, typeof(short?));
            info.AddValue("SerializedReorderLevel", ReorderLevel, typeof(short?));
        }
    }
}
