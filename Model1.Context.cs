﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicSmth
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Music : DbContext
    {
        public Music()
            : base("name=Music")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Bands> Bands { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Concerts> Concerts { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<Tracked_Concerts> Tracked_Concerts { get; set; }
    }
}