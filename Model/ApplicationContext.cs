using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bim_Service.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DB_Client> DB_Clients { get; set; }
        public DbSet<DB_File> DB_Files { get; set; }
        public DbSet<DB_Object> DB_Objects { get; set; }
        public DbSet<DB_Plugin> DB_Plugins { get; set; }
        public DbSet<DB_Plugin_const> DB_Plugin_consts { get; set; }
        public DbSet<DB_Stage> DB_Stages { get; set; }
        public DbSet<DB_Stage_const> DB_Stage_consts { get; set; }
        public DbSet<DB_Template> DB_Templates { get; set; }

        //создание базы данных
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        //заполнение бд начальными данными
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Добавить возможность каскадного удаления
            modelBuilder.Entity<DB_Object>()
               .HasOne(p => p.DB_Client)
               .WithMany(t => t.DB_Objects)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DB_Stage>()
              .HasOne(p => p.DB_Object)
              .WithMany(t => t.DB_Stages)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DB_File>()
              .HasOne(p => p.DB_Stage)
              .WithMany(t => t.DB_Files)             
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DB_Template>()
             .HasOne(p => p.DB_Stage)
             .WithMany(t => t.DB_Templates)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DB_Plugin>()
             .HasOne(p => p.DB_Stage)
             .WithMany(t => t.DB_Plugins)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DB_Plugin>()
           .HasOne(p => p.DB_Template)
           .WithMany(t => t.DB_Plugins)
           .OnDelete(DeleteBehavior.Cascade);
            #endregion

            //стадии проектирования
            modelBuilder.Entity<DB_Stage_const>()
                            .HasData(
                    new DB_Stage_const { Id = 1, Name = "Обследования и изыскания" },
                    new DB_Stage_const { Id = 2, Name = "Проектная документация" },
                    new DB_Stage_const { Id = 3, Name = "Рабочая документация" },
                    new DB_Stage_const { Id = 4, Name = "Исполнительная документация" },
                    new DB_Stage_const { Id = 5, Name = "Эксплуатационная документация" });
        }
    }
}
