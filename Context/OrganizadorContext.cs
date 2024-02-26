using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ProjetoDesafioMvc.Controllers;
using ProjetoDesafioMvc.Models;

namespace ProjetoDesafioMvc.Context
{
    public class OrganizadorContext : DbContext
    {
        public DbSet<Tarefa> Tarefas {get; set;}
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {    
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().HasKey(i => i.Id);
        }
    }
}