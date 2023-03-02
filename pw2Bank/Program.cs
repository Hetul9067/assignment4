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
                        Console.WriteLine("Enter client's account number : ");
                        int accountNum = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter deposit amount : ");    
                        double amount = double.Parse(Console.ReadLine());

                        b1.depositAmount(accountNum - 10000, amount);

                        Console.WriteLine("4");
                        break;

                }
                case 5:
                {
                        Console.WriteLine("5");
                        Console.WriteLine("Enter client's account number : ");
                        int accountNum = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter withdrawal amount : ");    
                        double amount = double.Parse(Console.ReadLine());

                        b1.withdrawAmount(accountNum - 10000, amount);

                        break;

                    }
                case 6:
                    {
                        Console.WriteLine("1. Sort according to their balance!");
                        Console.WriteLine("2. Sort according to their family name!");
                        Console.WriteLine("3. Sort according to their name!");
                        Console.WriteLine("Enter the value (1/2/3) : ");
                        int ans = int.Parse(Console.ReadLine());
                        switch (ans)
                        {
                            case 1:
                                {
                                    Console.WriteLine("1. sorting by ascending order!");
                                    Console.WriteLine("2. sorting by descending order!");
                                    Console.WriteLine("Enter the value : ");
                                    int a = int.Parse(Console.ReadLine());
                                    switch (a)
                                    {
                                        case 1:
                                            {

                                                b1.sortDisplayByBalance(true);
                                                break;
                                            }
                                        case 2:
                                            {
                                                b1.sortDisplayByBalance(false);
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("1. sorting by ascending order!");
                                    Console.WriteLine("2. sorting by descending order!");
                                    Console.WriteLine("Enter the value : ");
                                    int a = int.Parse(Console.ReadLine());
                                    switch (a)
                                    {
                                        case 1:
                                            {

                                                b1.sortDisplayByFamilyName(true);
                                                break;
                                            }
                                        case 2:
                                            {
                                                b1.sortDisplayByFamilyName(false);
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("1. sorting by ascending order!");
                                    Console.WriteLine("2. sorting by descending order!");
                                    Console.WriteLine("Enter the value : ");
                                    int a = int.Parse(Console.ReadLine());
                                    switch (a)
                                    {
                                        case 1:
                                            {

                                                b1.sortDisplayByName(true);
                                                break;
                                            }
                                        case 2:
                                            {
                                                b1.sortDisplayByName(false);
                                                break;
                                            }
                                    }
                                    break; 
                                }
                        }
                        break;
                    }
                case 7:
                {
                    b1.avgBal();
                    break;
                }
                case 8:
                {
                    Console.WriteLine("total balance is : " +b1.totalBalance());
                    break;
                }
                case 9:
                {
                        Console.WriteLine("Enter the account number : ");
                        int uniqueAccountNumber = int.Parse(Console.ReadLine());
                    b1.createAccount(uniqueAccountNumber-10000);
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
