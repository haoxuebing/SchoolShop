﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolShop.Data.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class schoolshopEntities : DbContext
    {
        public schoolshopEntities()
            : base("name=schoolshopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SS_Catalogs> SS_Catalogs { get; set; }
        public virtual DbSet<SS_UserBrowse> SS_UserBrowse { get; set; }
        public virtual DbSet<SS_Users> SS_Users { get; set; }
        public virtual DbSet<SS_UserAttention> SS_UserAttention { get; set; }
        public virtual DbSet<SS_Products> SS_Products { get; set; }
        public virtual DbSet<View_WhoAttention> View_WhoAttention { get; set; }
        public virtual DbSet<SS_Dialog> SS_Dialog { get; set; }
        public virtual DbSet<SS_ShopCart> SS_ShopCart { get; set; }
        public virtual DbSet<View_ShopCartView> View_ShopCartView { get; set; }
        public virtual DbSet<View_MyAttentions> View_MyAttentions { get; set; }
        public virtual DbSet<View_UserOrder> View_UserOrder { get; set; }
        public virtual DbSet<SS_UserOrder> SS_UserOrder { get; set; }
    }
}
