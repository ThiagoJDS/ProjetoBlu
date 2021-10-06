using System;
using System.Collections.Generic;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                        .HasData(
                            new List<Empresa>()
                            {
                                new Empresa (1,"Santa Catarina", "Cervejaria Top", "12345678910112"),
                                new Empresa (2,"Santa Catarina", "Sorveteria Japonesa", "98765432121313"),
                                new Empresa (3,"Santa Catarina", "Mercado Compre Mais", "45678912341525"),
                                new Empresa (4,"Santa Catarina", "Luminárias Do Sucesso", "78451236955441"),
                                new Empresa (5,"Santa Catarina", "Norte Calçados", "26987453122447"),

                                new Empresa (6,"Rio de Janeiro", "Alegria Musical", "55577741233112"),
                                new Empresa (7,"Rio de Janeiro", "Academia Do Conhecimento", "22244498788994"),

                                new Empresa (8,"São Paulo", "Batatão Alemão", "11177799911224"),
                                new Empresa (9,"São Paulo", "Livraria Mundo Bacana", "26987453122447"),

                                new Empresa (10,"Bahia", "Chapéu Colorido", "56421378954132")
                            }
                        );

            modelBuilder.Entity<Telefone>()
                        .HasData(
                            new List<Telefone>()
                            {
                                new Telefone (1, "(47)9 9214-7879", "Thiago"),
                                new Telefone (2, "(47)9 1234-4321", "Lucian"),
                                new Telefone (3, "(47)9 9091-9294", "Jaqueline"),
                                new Telefone (4, "(47)9 2021-2324", "Maria"),
                                new Telefone (5, "(47)9 3031-3235", "Arthur"),
                                new Telefone (6, "(47)9 5453-5759", "Gabrielle"),
                                new Telefone (7, "(47)9 7080-9050", "David"),
                                new Telefone (8, "(47)9 2010-4060", "Robson"),
                                new Telefone (9, "(47)9 7585-9555", "Diego"),
                                new Telefone (10, "(47)9 7686-9612", "Roberto"),
                                new Telefone (11, "(21)9 0220-2059", "Daisy"),
                                new Telefone (12, "(21)9 9319-3344", "Camila"),
                                new Telefone (13, "(21)9 1598-7542", "Pedro"),
                                new Telefone (14, "(21)9 3331-1119", "Felipe"),
                                new Telefone (15, "(11)9 2224-4445", "Rhuan"),
                                new Telefone (16, "(11)9 5570-5551", "Manuelle"),
                                new Telefone (17, "(11)9 7997-0102", "Ademar"),
                                new Telefone (18, "(11)9 9990-0005", "Gustavo"),
                                new Telefone (19, "(71)9 9103-1250", "Marcia"),
                                new Telefone (20, "(71)9 1444-2470", "Invonesio")
                            }
                        );

            modelBuilder.Entity<Fornecedor>()
                        .HasData(
                            new List<Fornecedor>()
                            {
                                new Fornecedor (1, 1, "Thiago", "12345678922", 1, 32, "9871234563", DateTime.Parse("06-07-1989"), DateTime.Parse("18-03-2011"), 1,"thiago@thiago.com"),
                                new Fornecedor (2, 1, "Lucian", "98765432111", 1, 28, "1234567899", DateTime.Parse("15-04-1993"), DateTime.Parse("10-04-2011"), 2, "lucian@lucian.com"),

                                new Fornecedor (3, 2, "Jaqueline", "45678912344", 2, 22, "1748511236", DateTime.Parse("24-06-1999"), DateTime.Parse("11-02-2015"), 3, "jaqueline@jaqueline.com"),
                                new Fornecedor (4, 2, "Maria", "32145698733", 2, 25, "0144100255", DateTime.Parse("12-01-1996"), DateTime.Parse("04-02-2015"), 4, "maria@maria.com"),

                                new Fornecedor (5, 3, "Arthur", "87645921387", 3, 19, "7899871599", DateTime.Parse("17-07-2002"), DateTime.Parse("22-05-2019"), 5, "arthur@arthur.com"),
                                new Fornecedor (6, 3, "Gabrielle", "79846513279", 3, 20, "1590590870", DateTime.Parse("02-04-2001"), DateTime.Parse("03-04-2019"), 6, "gabrielle@gabrielle.com"),

                                new Fornecedor (7, 4, "David", "31264597843", 4, 39, "9806503024", DateTime.Parse("06-05-1982"), DateTime.Parse("25-09-2005"), 7, "david@david.com"),
                                new Fornecedor (8, 4, "Robson", "21354687972", 4, 37, "5302548951", DateTime.Parse("24-07-1984"), DateTime.Parse("08-11-2005"), 8, "robson@robson.com"),

                                new Fornecedor (9, 5, "Diego", "95874543223", 5, 35, "4870009870", DateTime.Parse("12-05-1986"), DateTime.Parse("13-06-2009"), 9, "diego@diego.com"),
                                new Fornecedor (10, 5, "Roberto", "65342178941", 5, 27, "5595585573", DateTime.Parse("28-08-1994"), DateTime.Parse("15-09-2009"), 10, "roberto@roberto.com"),

                                new Fornecedor (11, 6, "Daisy", "97594814724", 6, 23, "9632587419", DateTime.Parse("19-10-1998"), DateTime.Parse("18-03-2016"), 11, "daisy@daisy.com"),
                                new Fornecedor (12, 6, "Camila", "23556889717", 6, 27, "5465644566", DateTime.Parse("22-03-1994"), DateTime.Parse("18-03-2016"), 12, "camila@camila.com"),

                                new Fornecedor (13, 7, "Pedro", "74125896359", 7, 19, "3577535915", DateTime.Parse("06-07-2002"), DateTime.Parse("12-01-2017"), 13, "pedro@pedro.com"),
                                new Fornecedor (14, 7, "Felipe", "85274196369", 7, 28, "5438732102", DateTime.Parse("03-11-1993"), DateTime.Parse("23-07-2017"), 14, "felipe@felipe.com"),

                                new Fornecedor (15, 8, "Rhuan", "02305809901", 8, 29, "2295584491", DateTime.Parse("14-09-1992"), DateTime.Parse("10-09-2013"), 15, "rhuan@rhuan.com"),
                                new Fornecedor (16, 8, "Manuelle", "01475098088", 8, 25, "2699874563", DateTime.Parse("18-12-1996"), DateTime.Parse("26-09-2013"), 16, "manuelle@manuelle.com"),

                                new Fornecedor (17, 9, "Ademar", "32078094041", 9, 23, "1221231251", DateTime.Parse("13-11-1998"), DateTime.Parse("08-08-2009"), 17, "ademar@ademar.com"),
                                new Fornecedor (18, 9, "Gustavo", "51009548903", 9, 30, "2232242252", DateTime.Parse("22-02-1991"), DateTime.Parse("27-05-2007"), 18, "gustavo@gustavo.com"),

                                new Fornecedor (19, 10, "Marcia", "55077011037", 10, 31, "7787797747", DateTime.Parse("09-01-1990"), DateTime.Parse("14-11-2006"), 19, "marcia@marcia.com"),
                                new Fornecedor (20, 10, "Invonesio", "98078045012", 10, 45, "0980331115", DateTime.Parse("23-03-1976"), DateTime.Parse("21-04-2003"), 20, "invonesio@invonesio.com")
                            }
                        );
        }
    }
}