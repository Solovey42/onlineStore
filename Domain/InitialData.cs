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
                        FirstName = "Алексей",
                        LastName = "Алексеев",
                        Email = "alex@gmail.com",
                        Password = "alex",
                        ContactPhone = "+79282328766",
                        RoleId = 2
                    },
                    new User()
                    {
                        FirstName = "Соловьев",
                        LastName = "Вячеслав",
                        Email = "admin@gmail.com",
                        Password = "admin",
                        ContactPhone = "+79239999999",
                        RoleId = 1,
                    }
                );
                context.SaveChanges();
            }
            if (!context.CategoryOfProducts.Any())
            {
                context.CategoryOfProducts.AddRange(
                   new CategoryOfProduct()
                   {
                       Name = "Плоский прокат",
                       ImagePath = "/images/1_catalog.png"
                   },
                   new CategoryOfProduct()
                   {
                       Name = "Сортовой прокат",
                       ImagePath = "/images/2_catalog.png"
                   },
                   new CategoryOfProduct()
                   {
                       Name = "Кровельные и фасадные материалы",
                       ImagePath = "/images/3_catalog.png"
                   },
                   new CategoryOfProduct()
                   {
                       Name = "Труба",
                       ImagePath = "/images/4_catalog.png"
                   }
                );
            }
            if (!context.TypeOfProducts.Any())
            {
                context.TypeOfProducts.AddRange(
                     new TypeOfProduct()
                     {
                         Name = "Арматура",
                         CategoryOfProductId = 1
                     },
                    new TypeOfProduct()
                    {
                        Name = "Круг",
                        CategoryOfProductId = 1
                    },
                    new TypeOfProduct()
                    {
                        Name = "Квадрат",
                        CategoryOfProductId = 1
                    },
                    new TypeOfProduct()
                    {
                        Name = "Лист горячекатный",
                        CategoryOfProductId = 2
                    },
                    new TypeOfProduct()
                    {
                        Name = "Лист холоднокатный",
                        CategoryOfProductId = 2
                    },
                    new TypeOfProduct()
                    {
                        Name = "Лист оцинкованный",
                        CategoryOfProductId = 2
                    },
                    new TypeOfProduct
                    {
                        Name = "Профнастил",
                        CategoryOfProductId = 3
                    },
                    new TypeOfProduct
                    {
                        Name = "Труба электросварная",
                        CategoryOfProductId = 4
                    },
                    new TypeOfProduct
                    {
                        Name = "Труба профильная",
                        CategoryOfProductId = 4
                    },
                    new TypeOfProduct
                    {
                        Name = "Труба оцинкованная",
                        CategoryOfProductId = 4
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
                        Unit = "Тонна",
                        TypeOfProductId = 4
                    },
                    new Product()
                    {
                        Name = "Лист г/к 4 ст.09Г2С",
                        Cost = 300,
                        Size = "1,5х6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 4
                    },
                    new Product()
                    {
                        Name = "Лист г/к 4 ст.3",
                        Cost = 300,
                        Size = "1,5х6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 4
                    },
                    new Product()
                    {
                        Name = "Лист г/к 3 ст.20",
                        Cost = 700,
                        Size = "1,25*2,5 м",
                        Unit = "Тонна",
                        TypeOfProductId = 4
                    },
                    new Product()
                    {
                        Name = "Лист х/к 0,5 ст.08пс",
                        Cost = 400,
                        Size = "1,25*2,5 м",
                        Unit = "Тонна",
                        TypeOfProductId = 5
                    },
                    new Product()
                    {
                        Name = "Лист х/к 0,7 ст.08пс",
                        Cost = 500,
                        Size = "1,25*2,5 м",
                        Unit = "Тонна",
                        TypeOfProductId = 5
                    },
                    new Product()
                    {
                        Name = "Лист х/к 0,8 ст.08пс",
                        Cost = 450,
                        Size = "1,25*2,5 м",
                        Unit = "Тонна",
                        TypeOfProductId = 5
                    },
                    new Product()
                    {
                        Name = "Лист оцинк. 0,4",
                        Cost = 600,
                        Size = "1,25*2,5 м",
                        Unit = "Тонна",
                        TypeOfProductId = 6
                    },
                    new Product()
                    {
                        Name = "Лист оцинк. 0,5",
                        Cost = 620,
                        Size = "1,25*2,5 м",
                        Unit = "Тонна",
                        TypeOfProductId = 6
                    },
                    new Product()
                    {
                        Name = "Арматура А500С 8",
                        Cost = 570,
                        Size = "6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 1
                    },
                    new Product()
                    {
                        Name = "Арматура B500С 8",
                        Cost = 550,
                        Size = "6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 1
                    },
                    new Product()
                    {
                        Name = "Арматура A-I 8 ст.3",
                        Cost = 500,
                        Size = "6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 1
                    },
                    new Product()
                    {
                        Name = "Катанка 6,5 ст.3",
                        Cost = 700,
                        Size = "6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 2
                    },
                    new Product()
                    {
                        Name = "Круг 12Х1МФ",
                        Size = "20 мм",
                        Cost = 200,
                        Unit = "Тонна",
                        TypeOfProductId = 2
                    },
                    new Product()
                    {
                        Name = "Квадрат ст.3",
                        Cost = 350,
                        Size = "8*8 мм",
                        Unit = "Тонна",
                        TypeOfProductId = 3
                    },
                    new Product()
                    {
                        Name = "Квадрат ст.3",
                        Cost = 370,
                        Size = "10*10 мм",
                        Unit = "Тонна",
                        TypeOfProductId = 3
                    },
                    new Product()
                    {
                        Name = "Труба эл/св 51х1,5 ст.3-20",
                        Cost = 370,
                        Size = "12 м",
                        Unit = "Тонна",
                        TypeOfProductId = 8
                    },
                    new Product()
                    {
                        Name = "Труба эл/св 51х2,5 ст.3-20",
                        Cost = 400,
                        Size = "12 м",
                        Unit = "Тонна",
                        TypeOfProductId = 8
                    },
                    new Product()
                    {
                        Name = "Труба профильная 15х15х1,2 ст.2-20",
                        Cost = 390,
                        Size = "6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 9
                    },
                    new Product()
                    {
                        Name = "Труба профильная 15х15х1,5 ст.2-20",
                        Cost = 430,
                        Size = "6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 9
                    },
                    new Product()
                    {
                        Name = "Труба оцинк. 15х2, 8",
                        Cost = 530,
                        Size = "6 м",
                        Unit = "Тонна",
                        TypeOfProductId = 10
                    },
                    new Product()
                    {
                        Name = "Труба оцинк. 15х2, 8 7",
                        Cost = 550,
                        Size = "8 м",
                        Unit = "Тонна",
                        TypeOfProductId = 10
                    },
                    new Product()
                    {
                        Name = "Профнастил С-8 0,4",
                        Cost = 500,
                        Size = "1,2*6 м",
                        Unit = "Метр²",
                        TypeOfProductId = 7
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
                    },
                    new Cart()
                    {
                        UserId = 3
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
                       UserId = 2
                   },
                   new Order()
                   {
                       Date = DateTime.Parse("2021-04-20 12:27:32"),
                       UserId = 2
                   },
                   new Order()
                   {
                       Date = DateTime.Parse("2021-04-21 17:41:37"),
                       UserId = 3
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
