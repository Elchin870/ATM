using System;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static void Pul_Cixilma(Card card, decimal amount)
            {
                if (card.Balans < amount)
                {
                    throw new Exception("Balansda yeterli qeder mebleg yoxdur");
                }
                card.Balans -= amount;
                Console.WriteLine("Pul balansinizdan cixildi");
            }


            User[] users = new User[] {
                new User { Name = "Elchin", Surname = "Aliyev", CreditCard = new Card { PAN = "4169738812345678", PIN = "1234", CVC = "123", Expire_Date = "06/25", Balans = 1000.00m } },
                new User { Name = "Nadir", Surname = "Aliyev", CreditCard = new Card { PAN = "4169738887654321", PIN = "4321", CVC = "432", Expire_Date = "05/28", Balans = 800.00m } },
                new User { Name = "Ismayil", Surname = "Esgerli", CreditCard = new Card { PAN = "4169738813579846", PIN = "9876", CVC = "246", Expire_Date = "07/26", Balans = 1500.00m } },
                new User { Name = "Vuqar", Surname = "Hesenli", CreditCard = new Card { PAN = "4169738824683157", PIN = "6789", CVC = "135", Expire_Date = "08/27", Balans = 750.00m } },
                new User { Name = "Vaqif", Surname = "Kerimli", CreditCard = new Card { PAN = "4169738814792586", PIN = "1379", CVC = "234", Expire_Date = "09/29", Balans = 1200.00m } },
            };

            while (true)
            {
                Console.WriteLine("Enter PAN: ");
                var pan = Console.ReadLine();
                Console.WriteLine("Enter PIN: ");
                var pin = Console.ReadLine();

                User user_giris = null;

                foreach (var item in users)
                {
                    if (item.CreditCard.PAN == pan && item.CreditCard.PIN == pin)
                    {
                        user_giris = item;
                        break;
                    }
                }

                if (user_giris != null)
                {
                    Console.WriteLine($"Welcome {user_giris.Name} {user_giris.Surname}");
                    while (true)
                    {
                        Console.WriteLine("1) Balans");
                        Console.WriteLine("2) Nagd Pul");
                        Console.WriteLine("3) Kartdan karta");
                        Console.WriteLine("4) Main");
                        Console.WriteLine("Secim edin: ");
                        var secim = Console.ReadLine();

                        if (Convert.ToInt32(secim) == 1)
                        {
                            Console.WriteLine($"{user_giris.CreditCard.Balans} azn");
                        }
                        else if (Convert.ToInt32(secim) == 2)
                        {
                            Console.WriteLine("1)10 AZN");
                            Console.WriteLine("2)20 AZN");
                            Console.WriteLine("3)50 AZN");
                            Console.WriteLine("4)100 AZN");
                            Console.WriteLine("5)Diger");
                            Console.Write("Secim edin: ");
                            var pul = Console.ReadLine();

                            try
                            {
                                decimal cixilan_pul = 0;
                                switch (pul)
                                {
                                    case "1":
                                        cixilan_pul = 10m;
                                        break;
                                    case "2":
                                        cixilan_pul = 20m;
                                        break;
                                    case "3":
                                        cixilan_pul = 50m;
                                        break;
                                    case "4":
                                        cixilan_pul = 100m;
                                        break;
                                    case "5":
                                        Console.Write("Meblegi daxil edin: ");
                                        cixilan_pul = Convert.ToDecimal(Console.ReadLine());
                                        break;
                                    default:
                                        Console.WriteLine("Wrong input!!!");
                                        continue;
                                }
                                Pul_Cixilma(user_giris.CreditCard, cixilan_pul);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (Convert.ToInt32(secim) == 3)
                        {              
                            Console.WriteLine("Enter PAN: ");
                            var alan_PAN = Console.ReadLine();
                            User alan_user = null;

                            foreach (var item in users)
                            {
                                if (item.CreditCard.PAN == alan_PAN)
                                {
                                    alan_user = item;
                                    break;
                                }
                            }                   

                            if (alan_user != null)
                            {
                                Console.WriteLine($"{alan_user.Name} {alan_user.Surname}");
                                Console.WriteLine("Meblegi daxil edin: ");
                                var transferAmount = Convert.ToDecimal(Console.ReadLine());

                                try
                                {
                                    Pul_Cixilma(user_giris.CreditCard, transferAmount);
                                    alan_user.CreditCard.Balans += transferAmount;
                                    Console.WriteLine("Pul ugurla transfer edildi!!!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong input!!!");
                                break;
                            }
                        }
                        else if(Convert.ToInt32(secim) == 4)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input!!!");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Invalid PAN or PIN");
                }
                }
            }
        }

    }
