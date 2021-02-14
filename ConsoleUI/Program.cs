using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("Here are our cars you can rent: ");
            foreach (var cars in carManager.GetAll())
            {  
                Console.WriteLine("Name : " +cars.Description+" , Price : "+cars.DailyPrice+" , Model Year : "+cars.ModelYear);
            }
        }
    }
}
