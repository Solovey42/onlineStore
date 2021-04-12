using Domain.Entities;
using System;
using System.Linq;

namespace Domain
{
    public class InitialData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role()
                    {
                        Name = "Admin"
                    },
                    new Role()
                    {
                        Name = "User",
                    }
                );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User()
                    {
                        FirstName = "Иванов",
                        LastName = "Иван",
                        Email = "123@gmail.com",
                        Password = "123",
                        ContactPhone = "+79239993333",
                        RoleId = 2
                    },
                    new User()
                    {
                        FirstName = "Соловьев",
                        LastName = "Вячеслав",
                        Email = "admin@gmail.com",
                        Password = "admin",
                        ContactPhone = "+79239999999",
                        RoleId = 1
                    }
                );
                context.SaveChanges();
            }
            if (!context.TypeOfProducts.Any())
            {
                context.TypeOfProducts.AddRange(
                    new TypeOfProduct()
                    {
                        Name = "Лист горячекатный",
                    },
                    new TypeOfProduct()
                    {
                        Name = "Лист холоднокатный",
                    },
                    new TypeOfProduct()
                    {
                        Name = "Арматура",
                    },
                    new TypeOfProduct
                    {
                        Name = "Профнастил",
                    }
                );
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product()
                    {
                        Name = "Лист г/к 2 ст.3",
                        Cost = 300,
                        Size = "1,25*2,5 м",
                        TypeOfProductId = 1
                    },
                    new Product()
                    {
                        Name = "Лист г/к 3 ст.20",
                        Cost = 700,
                        Size = "1,25*2,5 м",
                        TypeOfProductId = 1
                    },
                    new Product()
                    {
                        Name = "Лист х/к 0,5 ст.08пс",
                        Cost = 400,
                        Size = "1,25*2,5 м",
                        TypeOfProductId = 2
                    },
                    new Product()
                    {
                        Name = "Арматура А500С 8",
                        Cost = 500,
                        Size = "6 м",
                        TypeOfProductId = 3
                    },
                    new Product()
                    {
                        Name = "Профнастил С-8 0,4",
                        Cost = 500,
                        Size = "1,2*6 м",
                        TypeOfProductId = 4
                    }
                );
                context.SaveChanges();
            }
            if (!context.Carts.Any())
            {
                context.Carts.AddRange(
                    new Cart()
                    {
                        UserId = 2
                    }
                );
                context.SaveChanges();
            }
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                   new Order()
                   {
                       Date = DateTime.Parse("2021-04-12 12:30:00"),
                       UserId = 2,
                       CartId = 1
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
