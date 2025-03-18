using Microsoft.EntityFrameworkCore;

namespace _06_DB_02_EF_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new MyDbContext();

            var cars = dbContext.Cars.ToList();
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}: {car.Brand} {car.Model} ({car.RegPlate})");
            }

            Car newCar = new Car() { Brand = "Toyota", Model = "Corolla", RegPlate = "ASDFGHJ", Purchased = DateTime.Now };
            dbContext.Cars.Add(newCar);
            dbContext.SaveChanges();

            //update
            newCar.RegPlate = "ERTYJOUI";
            dbContext.SaveChanges();

            //delete
            dbContext.Cars.Remove(newCar);
            dbContext.SaveChanges();

            //foreach (var car in dbContext.Cars.ToList())
            //{
            //    Console.WriteLine($"{car.Id}: {car.Brand} {car.Model} ({car.RegPlate})");
            //}

            foreach (Driver driver in dbContext.Drivers.Include(d => d.Car).ToList())
            {
                Console.WriteLine($"{driver.Surname} {driver.Name}: {driver.Car?.Id}: {driver.Car?.Brand} {driver.Car?.Model} ({driver.Car?.RegPlate})");
            }
        }
    }
}
