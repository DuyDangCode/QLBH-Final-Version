﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUI.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLCuaHangTienLoiEntities : DbContext
    {
        public QLCuaHangTienLoiEntities()
            : base("name=QLCuaHangTienLoiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BillInfo> BillInfoes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Input> Inputs { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<TypeAcc> TypeAccs { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
    }
}
