using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            float ttlPrice = 0f;
            var allProducts = new allProductsList();
            var items = allProducts.InitialiseItem();

            Console.WriteLine("* List of the ALL items in our store * ");
            Console.WriteLine(" ");

            foreach (var i in items)
            {
                Console.WriteLine("Item Identity No : {0}", i.itemID);
                Console.WriteLine("Item Name : {0}", i.itemName);
                Console.WriteLine("Item Color : {0}", i.itemColor);
                Console.WriteLine("Item Price : {0}", i.itemPrice);
                Console.WriteLine("....................................................................");
            }

            var addOn = 0;
            do {



                Console.WriteLine("Please Enter the Identity No of the Item that you want to purchase : ");
                var userID = 0;

                do
                {
                    userID = Convert.ToInt32(Console.ReadLine());

                    if ((userID != 1) && (userID != 2) && (userID != 3) && (userID != 4) && (userID != 5))
                    {
                        Console.WriteLine("Please re-enter the correct ID again : ");
                    }
                    else
                    { }

                } while ((userID != 1) && (userID != 2) && (userID != 3) && (userID != 4) && (userID != 5));



                Console.WriteLine("System have found 1 Item is match with your ID input");

                foreach (var p in items)
                {
                    if (userID == p.itemID)
                    {
                        var itemType = p.GetType();

                        switch (itemType.Name)
                        {
                            case "sportEquipment":
                                {
                                    var s = (sportEquipment)p;
                                    Console.WriteLine("Item ID No : {0}", s.itemID);
                                    Console.WriteLine("Item Name : {0}", s.itemName);
                                    Console.WriteLine("Item Color : {0}", s.itemColor);
                                    Console.WriteLine("Item Price : {0}", s.itemPrice);
                                    Console.WriteLine("Item Suitable for: {0}", s.sDetail);
                                    Console.WriteLine("Item Suggest to : {0}", s.sSex);
                                    Console.WriteLine("....................................................................");
                                    break;
                                }
                            case "Car":
                                {
                                    var c = (Car)p;
                                    Console.WriteLine("Item ID No : {0}", c.itemID);
                                    Console.WriteLine("Item Brand : {0}", c.cBrand);
                                    Console.WriteLine("Item Name : {0}", c.itemName);
                                    Console.WriteLine("Item Color : {0}", c.itemColor);
                                    Console.WriteLine("Item Price: {0}", c.itemPrice);
                                    Console.WriteLine("Item Engine : {0}", c.cEngine);
                                    Console.WriteLine("Item Year : {0}", c.cYear);
                                    Console.WriteLine("....................................................................");
                                    break;
                                }
                            case "Furniture":
                                {
                                    var f = (Furniture)p;
                                    Console.WriteLine("Item ID No : {0}", f.itemID);
                                    Console.WriteLine("Item Name : {0}", f.itemName);
                                    Console.WriteLine("Item Color : {0}", f.itemColor);
                                    Console.WriteLine("Item Price: {0}", f.itemPrice);
                                    Console.WriteLine("Item Quantity : {0}", f.fQty);
                                    Console.WriteLine("Item Size : {0}", f.fSize);
                                    Console.WriteLine("....................................................................");
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        ttlPrice = p.itemPrice + ttlPrice;
                        
                    }
                }
               
                Console.WriteLine("Do you want to add on item? If yes, enter 1. Else enter any digit numbers. ");
                addOn = Convert.ToInt32(Console.ReadLine());


            } while (addOn == 1);

            Console.WriteLine("Do you want to purchase the Item ? If YES, please type 'Y' or 'y', else type 'N' or 'n' ");
            var y = Console.ReadLine();

            if ((y == "Y") || (y == "y"))
            {
                Console.WriteLine("Your payment : {0} ", ttlPrice);
                Console.WriteLine("Thank you for your purchase. ");
            }
            else if ((y == "N") || (y == "n"))
            {
                Console.WriteLine("You are wasting my time! ");
            }
            else
            {
                Console.WriteLine("Are you word blind? Only Y or N.");
            }
            Console.ReadKey();

        }
    }

    public class item
    {
        public int itemID { get; set; }
        public string itemName { get; set; }
        public string itemColor { get; set; }
        public float itemPrice { get; set; }
    }

    public class sportEquipment : item
    {
        public string sDetail { get; set; }
        public string sSex { get; set;}
    }

    public class Car : item
    {
        public string cBrand { get; set; }
        public int cYear { get; set; }
        public string cEngine { get; set; }
    }

    public class Furniture : item
    {
        public int fQty { get; set; }
        public string fSize { get; set; }
    }

    public class allProductsList : IproductRepository
    {
        public List<item> InitialiseItem()
        {
            var items = new List<item>()
            {
                new sportEquipment()
                {
                    itemID = 1,
                    itemName = "Badminton Racket",
                    itemColor = "Blue",
                    itemPrice = 50.50f,
                    sDetail ="Only suitable for kids who below 12 years old",
                    sSex = "Female & Male"
                },

                new sportEquipment()
                {
                    itemID = 2,
                    itemName = "Tennis Racket",
                    itemColor = "Grey",
                    itemPrice = 80.40f,
                    sDetail = "Only suitable for adults who above 12 years old",
                    sSex = "Male"
                },

                new Car()
                {
                    itemID = 3,
                    itemName = "Saga",
                    itemColor = "Red",
                    itemPrice = 3000.00f,
                    cBrand = "Proton",
                    cEngine = "2.0 Petrol",
                    cYear = 1990
                },

                new Car()
                {
                    itemID = 4,
                    itemName = "Wira",
                    itemColor = "Black",
                    itemPrice = 5000.00f,
                    cBrand = "Proton",
                    cEngine = "2.0 Diesel",
                    cYear = 2000
                },

                new Furniture()
                {
                    itemID = 5,
                    itemName = "Chiavari Chair",
                    itemColor = "Yellow",
                    itemPrice = 15.50f,
                    fQty = 5,
                    fSize = "12 * 5"
                },
            };
            return items;
        }
       
    }
}
