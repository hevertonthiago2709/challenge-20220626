﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fitness_Foods_LC.Enumeradores;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Foods_LC.Models
{
    public partial class Product
    {
        [Key]
        [Column("code")]
        [StringLength(20)]
        [Unicode(false)]
        public string Code { get; set; }
        [Column("barcode")]
        [StringLength(50)]
        [Unicode(false)]
        public string Barcode { get; set; }
        [Column("status", TypeName = "numeric(1, 0)")]
        public EnumStatus Status { get; set; }
        [Column("imported", TypeName = "datetime")]
        public DateTime? Imported { get; set; }
        [Column("url")]
        [StringLength(50 )]
        [Unicode(false)]
        public string Url { get; set; }
        [Column("product_name")]
        [StringLength(500)]
        [Unicode(false)]
        public string ProductName { get; set; }
        [Column("quantity")]
        [StringLength(500)]
        [Unicode(false)]
        public string Quantity { get; set; }
        [Column("categories")]
        [StringLength(500)]
        [Unicode(false)]
        public string Categories { get; set; }
        [Column("packaging")]
        [StringLength(500)]
        [Unicode(false)]
        public string Packaging { get; set; }
        [Column("brands")]
        [StringLength(500)]
        [Unicode(false)]
        public string Brands { get; set; }
        [Column("image_url")]
        [StringLength(500)]
        [Unicode(false)]
        public string ImageUrl { get; set; }
    }
}