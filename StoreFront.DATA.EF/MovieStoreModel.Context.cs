

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace StoreFront.DATA.EF
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class MovieStoreEntities : DbContext
{
    public MovieStoreEntities()
        : base("name=MovieStoreEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<AspectRatio> AspectRatios { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    public virtual DbSet<MovieRating> MovieRatings { get; set; }

    public virtual DbSet<MovieStatus> MovieStatus1 { get; set; }

    public virtual DbSet<MovieTitle> MovieTitles { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

}

}

