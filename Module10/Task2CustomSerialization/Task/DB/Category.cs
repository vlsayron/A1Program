namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Serializable()]
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Description = "Initial Value";
        }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public ICollection<Product> Products { get; set; }

        public void Print()
        {
            Console.WriteLine($"Description : {Description}");
        }

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Description += " OnSerializingTrigerred";
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Description += " OnSerializedTrigerred";
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Description += " OnDeserializingTrigerred";
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Description += " OnDeserializedTrigerred";
        }
    }
}
