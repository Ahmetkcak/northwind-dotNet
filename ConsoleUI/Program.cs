﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();

            //CategoryTest();
        }






        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var result = categoryManager.GetAll();
            foreach (var category in result.Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            //Product product1 = new Product() {ProductName="Ahmet",CategoryId=2,UnitPrice=27,UnitsInStock=3 };
            //productManager.Add(product1);

            var result = productManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "--" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}
