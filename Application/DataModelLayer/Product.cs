//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModelLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Inventories = new HashSet<Inventory>();
            this.ProductPrices = new HashSet<ProductPrice>();
            this.InvoiceItems = new HashSet<InvoiceItem>();
        }
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<long> ProductLastFee { get; set; }
        public int ProductLastSuply { get; set; }
        public byte[] ProductImage { get; set; }
        public string ProductStartDate { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<byte> ProductActive { get; set; }
        public Nullable<long> LastPurchFee { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
