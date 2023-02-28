using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw2Bank
{
    internal class Program
    {

        public static Client[] clients = new Client[100];
        public static bool closerChecker = false;

        static void choices(Bank b1)
        {
            
            int value = 0;

            Console.WriteLine("*********************************");
            Console.WriteLine("****\t welcome to pw2Bank \t");
            Console.WriteLine("*********************************");
            Console.WriteLine("****\t 1. Add a bank account!\t\t\t\t\t****");
            Console.WriteLine("****\t 2. Remove a bank account!");
            Console.WriteLine("****\t 3. Display the information of specific client's account!");
            Console.WriteLine("****\t 4. Deposit to a specific account!");
            Console.WriteLine("****\t 5. Withdrawal from a specific account!");
            Console.WriteLine("****\t 6. Sort the information of client's list based on balance, family name, name!");
            Console.WriteLine("****\t 7. Display the average balance value of the accounts!");
            Console.WriteLine("****\t 8. Display the total balance value of the accounts!");
            Console.WriteLine("****\t 9. You should be capable to create an account and insert it at any position of the Array!");
            Console.WriteLine("****\t 10. Exit the application!");
            

            Console.WriteLine("please enter value : ");
            value = int.Parse(Console.ReadLine());

            
            

            switch(value)
            {
                case 1:
                    b1.addBankAccount();
                    break;
                case 2:
                {
                      Console.WriteLine("Enter the account number which you wanna delete : ");
                      b1.removeBankAccount(int.Parse(Console.ReadLine()) - 10000);
                      break;
                }
                case 3:
                {
                    Console.WriteLine("Enter client's account number : ");
                    int accountNum = int.Parse(Console.ReadLine());
                    b1.displayClientInfo(accountNum-10000);
                    break;

                }
                case 4:
                {
                        Console.WriteLine("hello ");
                        break;

                }
                case 5:
                {
                    Console.WriteLine("hii");
                        break;
                }
                case 6:
                    break;
                case 7:
                {
                        Console.WriteLine("7");
                        break;
                }
                case 8:
                {
                    break;
                }
                case 9:
                {
                    break;
                }
                case 10:
                    closerChecker = true;
                    Console.WriteLine("Good bye...");
                    break;
            }


        }

        static void Main(string[] args)
        {
            /*
                        Bank b1 = new Bank();
                        b1.printRemoveAccount();*/
            
                Bank b1 = new Bank();
            while(!closerChecker)
            {
                choices(b1);

            }

            /*
                        b1.addBankAccount();
                        b1.addBankAccount();
                        b1.addBankAccount();
                        b1.addBankAccount();
                        b1.addBankAccount();



                        Console.WriteLine("Enter the account number of client's : ");
                        b1.displayClientInfo(int.Parse(Console.ReadLine())-10000);
            */





            //Client cl1 = new Client("Hetul", "Chaudhary", 1, 10000);
            //clients[0] = cl1;
            //cl1.getFamilyName();
            /*for(int i= 0; i< clients.Length; i++)
            {
                Console.WriteLine(clients[i]);
            }
*/
        }
    }
}
