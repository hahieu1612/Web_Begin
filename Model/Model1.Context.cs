﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASM.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class blog_wedEntities1 : DbContext
    {
        public blog_wedEntities1()
            : base("name=blog_wedEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<idea> ideas { get; set; }
        public virtual DbSet<reaction> reactions { get; set; }
        public virtual DbSet<topic> topics { get; set; }
    }
}