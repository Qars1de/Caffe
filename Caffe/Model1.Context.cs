﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Caffe
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class user70_dbEntities : DbContext
    {
        public user70_dbEntities()
            : base("name=user70_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C6Menu> C6Menu { get; set; }
        public virtual DbSet<C6Order> C6Order { get; set; }
        public virtual DbSet<C6OrderMenu> C6OrderMenu { get; set; }
        public virtual DbSet<C6OrderStatus> C6OrderStatus { get; set; }
        public virtual DbSet<C6Role> C6Role { get; set; }
        public virtual DbSet<C6User> C6User { get; set; }
        public virtual DbSet<C6UserStatus> C6UserStatus { get; set; }
    }
}