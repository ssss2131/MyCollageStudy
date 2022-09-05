// See https://aka.ms/new-console-template for more information
using EfRelation.AppDbContext;

Console.WriteLine("Hello, World!");
MyDbContext con = new MyDbContext();
con.Database.EnsureCreated();
