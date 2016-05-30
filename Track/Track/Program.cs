using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track
{
    //Homework2
    class Products
    {
        int id, quantity, categoryID, total_sold;
        string name;
        double price;

        //Properties
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Total_sold { get; set; }
        //Constructors
        public Products() { }
        public Products(int quantity, int categoryID, string name, double price)
        {
            this.quantity = quantity; this.categoryID = categoryID;
            this.name = name; this.price = price;
        }
    }
    class Product_manager
    {
        List<Products> products;
        public List<Products> Products { get; set; }

        public Product_manager()
        {
            products = new List<Products>();
        }
        public Product_manager(List<Products> products)
        {
            this.products = products;
        }

        public void Add(Products product)
        { products.Add(product); }

        public void Remove(int id)
        {
            foreach (var item in products)
            {
                if (item.ID == id)
                {
                    products.Remove(item);
                }
            }
        }

        public void Remove(Products item)
        {
            products.Remove(item);
        }

        public void RemoveAt(int position)
        {
            products.RemoveAt(position);
        }

        public Products Search(string name)
        {
            foreach (var item in products)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        public Products Search(int id)
        {
            foreach (var item in products)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public int Position(int id)
        {

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ID == id)
                    return i;
            }
            return -1;
        }
        public int Position(string name)
        {

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name == name)
                    return i;
            }
            return -1;
        }
        public void Update_price(int id, int price)
        {
            int pos = this.Position(id);
            if (pos != -1)
            {
                products[pos].Price = price;
            }

        }

        public void Sell(int id, int quantity)
        {
            int pos = this.Position(id);
            if (pos != -1)
            {
                products[pos].Total_sold += quantity;
                products[pos].Quantity -= quantity;
            }

        }
        public int Report_sold(string name)
        {
            return Search(name).Total_sold;
        }
        public int Report_sold(int id)
        {
            return Search(id).Total_sold;
        }
    }
    // HomeWork1
    public class Program
    {
        /// <summary>
        /// Interfaces
        /// </summary>
        public interface IPasswordChecker
        {
            bool CheckPassword(string password);

        }
        public class PasswordChecker : IPasswordChecker
        {
            public bool CheckPassword(string password)
            {
                return password.Length >= 8;
            }
        }
        public class PasswordChecker2 : IPasswordChecker
        {
            public bool CheckPassword(string password)
            {
                string temp = password.ToUpper();
                return password[0].Equals(temp[0]);
            }
        }
        public static bool PassCheck(string pass, IPasswordChecker passchecker)
        {
            return passchecker.CheckPassword(pass);
        }
        /// <summary>
        /// Class Rectangle
        /// </summary>
        class Rectangle
        {
            double sideA;
            double sideB;
            public Rectangle()
            { }
            public Rectangle(double sideA, double sideB)
            {
                this.sideA = sideA;
                this.sideB = sideB;
            }
            public double Area()
            {
                return sideA * sideB;
            }
        }
        /// <summary>
        /// Functions
        /// </summary>

        public static int[,] Multiplication(int n)
        {
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i > 0 && j > 0)
                    {
                        result[i, j] = result[0, j] + result[i - 1, j];
                    }
                    else
                    {
                        result[i, j] = i + j + 1;
                    }

                }
            return result;
        }

        public static int Max(int[] param)
        {
            int max = param[0];
            for (int i = 1; i < param.Length; i++)
            {
                if (param[i] > max)
                    max = param[i];
            }
            return max;
        }
        class Validator
        {
            public static bool Validation(int value)
            {
                if (value % 2 == 0)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Main
        /// </summary>
        static void Main(string[] args)
        {
            //double sideA,sideB;
            //Console.WriteLine("Side A");
            //if (double.TryParse(Console.ReadLine(), out sideA)) { }
            //Console.WriteLine("Side B");
            //if (double.TryParse(Console.ReadLine(), out sideB)) { }
            //Rectangle rectangle = new Rectangle(sideA, sideB);
            //Console.WriteLine(rectangle.Area());
            //Console.ReadLine();
            ////////////////////////////////////////////////////////////
            int n = 0;
            Console.WriteLine("n\n");
            int.TryParse(Console.ReadLine(), out n);
            int[,] mult = Multiplication(n);
            for (int i = 0; i < mult.GetLength(0); i++)
            {
                for (int j = 0; j < mult.GetLength(1); j++)
                {
                    Console.Write(mult[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.ReadLine();
            ////////////////////////////////////////////////////////////
            //int[] param = { 1, 2, 9, 3, 4, 5 };
            //Console.WriteLine(Max(param));
            //Console.ReadLine();

            //Console.WriteLine(PassCheck("Mima", new PasswordChecker()));
            //Console.WriteLine("\n");
            //Console.WriteLine(PassCheck("Mima", new PasswordChecker2()));
            //Console.ReadLine();
        }
    }
}
