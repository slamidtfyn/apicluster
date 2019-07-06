using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class Message
    {
        public string name {get;set;}



    }


    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=c:\temp\blogging.db");


            
        }

        
    }

    [Table("blog")
    ]public class Blog
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Message { get; set; }

    }
}
