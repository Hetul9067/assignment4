using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pw2Bank
{
    //bank class give functionality for banking
    internal class Bank
    {
        public static Client[] clients = new Client[100];
        public static int currentAccount = 0;
        public static bool[] removeAccounts = new bool[100] ;
        
        public static int lastRemoveAccount = 0;
        public static int lastAddedRemoveAccountIndex = 0;
        public int totalRemovedAcc = 0;

        /*public void addRemovedAccountNumber(int removedAccNumber)
        {
            for(int i=0; i< removeAccounts.Length; i++)
            {
                Console.WriteLine("hello "+ i + " " + removeAccounts[i]);
            }
            removeAccounts[removedAccNumber] = true;
            totalRemovedAcc++;
            *//*removeAccount[5] = 1;
            removeAccount[99] = 1;
            *//*for(int i=0; i< removeAccount.Length; i++)
            {
                if (removeAccount[i] != 0)
                    
                {

                    Console.WriteLine(removeAccount[i]);
                }
            }*//*
        }
*/
        //taking available account number from removed account number list
        public int availableAccFromRemovedAccList()
        {
            int i;
            for(i = 0; i< removeAccounts.Length; i++)
            {
                if (removeAccounts[i])
                {
                    break;
                }
            }
            for (int j = 0; j < removeAccounts.Length; j++)
            {
                Console.WriteLine("hello " + j + " " + removeAccounts[j]);
            }
            removeAccounts[i] = false; 
            totalRemovedAcc--;
            return i;
            
        }

        public int removedAccCounter(int acc)
        {
            int count = 0;
            for(int i=0; i<= acc; i++)
            {
                if (removeAccounts[i]) 
                    count++;

            }
            return count;
        }
       
        //it will checked availability of the account in removed account array
        public bool accountAvlCheckerInRemovedAccs(int acc)
        {

            if (removeAccounts[acc])
            {
                totalRemovedAcc--;
                currentAccount++;
                removeAccounts[acc] = false;

                return true;
            }
            return false;

        }
        //adding a new account
        public void addBankAccount()
        {

            if(currentAccount >= 100)
            {
                Console.WriteLine("Accounts are full.");
                return;
            }

            int accountNum;
            //first check available removed account number in array
            if (totalRemovedAcc > 0)
            {
                accountNum = availableAccFromRemovedAccList();

                Client[] tempClients = new Client[100];
                int i ;
                for (i =0;i < accountNum; i++)
                {
                    tempClients[i] = clients[i];
                }



                for(i = accountNum ; i< currentAccount; i++)
                {
                    tempClients[i +1] = clients[i];
                }
                currentAccount++;
                for(i = 0; i< currentAccount; i++)
                {
                    clients[i] = tempClients[i];
                }
                
                
            }
            else
            {
                accountNum = currentAccount;
                currentAccount++;
            }    
  
            
            clients[accountNum] = new Client(accountNum);
           /* 
            clients[0].setName("hetul");
            clients[0].setFamilyName("chaudhary");

            clients[1] = new Client(accountNum);
            clients[1].setName("hardik");
            clients[1].setFamilyName("chaudhary");

            clients[2] = new Client(accountNum);
            clients[2].setName("seemant");
            clients[2].setFamilyName("kumar");
*/
            Console.WriteLine("Enter the name of the clients : ");
            
            clients[accountNum].setName(Console.ReadLine());
            
            Console.WriteLine("Enter the family name of the clients : ");
            clients[accountNum].setFamilyName(Console.ReadLine());

            Console.WriteLine("Enter the balance of the clients : ");
            clients[accountNum].setBalance(double.Parse(Console.ReadLine()));

            


        }

        public void addBankAccount(int uniqueAccountNumber)
        {




            Client[] tempClients = new Client[100];
            int i;
            for (i = 0; i < uniqueAccountNumber; i++)
            {
                tempClients[i] = clients[i];
            }



            for (i = uniqueAccountNumber; i < currentAccount; i++)
            {
                tempClients[i + 1] = clients[i];
            }
            //currentAccount++;
            for (i = 0; i < currentAccount; i++)
            {
                clients[i] = tempClients[i];
            }

    

            clients[uniqueAccountNumber] = new Client(uniqueAccountNumber);

            Console.WriteLine("Enter the name of the clients : ");

            clients[uniqueAccountNumber].setName(Console.ReadLine());

            Console.WriteLine("Enter the family name of the clients : ");
            clients[uniqueAccountNumber].setFamilyName(Console.ReadLine());

            Console.WriteLine("Enter the balance of the clients : ");
            clients[uniqueAccountNumber].setBalance(double.Parse(Console.ReadLine()));




        }


public void removeBankAccount(int uniqueAccountNumber)
        {
            int accountNum = uniqueAccountNumber;
            if(totalRemovedAcc > 0)
            {
                uniqueAccountNumber -= removedAccCounter(uniqueAccountNumber);
            }
            removeAccounts[accountNum] = true;

            Client[] tempClients = new Client[100];
            for(int i=0; i < uniqueAccountNumber; i++)
            {
                tempClients[i] = clients[i];
            }
            currentAccount--;
            for(int i=uniqueAccountNumber; i < currentAccount; i++)
            {
                tempClients[i] = clients[i + 1];
            }
            clients = tempClients;
            totalRemovedAcc++;

            for(int i= 0; i< currentAccount; i++)
            {
                displayClientInfo(i);
            }
        }

        public int accountNumberVerifier(int uniqueAccountNumber)
        {
            /*if (uniqueAccountNumber > currentAccount)
            {
                
                return -1;
            }*/
            if (totalRemovedAcc > 0)
            {
                if (removeAccounts[uniqueAccountNumber])
                {
                    
                    return -1;
                }
                else
                {
                    int count = removedAccCounter(uniqueAccountNumber);
                    uniqueAccountNumber = uniqueAccountNumber - count;

                }

            }

            return uniqueAccountNumber;
        }

        public void displayClientInfo(int uniqueAccountNumber)
        {
            

            for (int i = 0; i < currentAccount; i++)
            {
                Console.WriteLine("hello focus here : " + uniqueAccountNumber);
                Console.WriteLine("Account number is " + clients[i].getUniqueAccountNumber());
                Console.WriteLine("Name of the client is : " + clients[i].getName());
                Console.WriteLine("Family name of the client is : " + clients[i].getFamilyName());
                Console.WriteLine("Bank balance : " + clients[i].getBalance());



            }
            /*foreach(Client c in clients)
            {
                Console.WriteLine(c.getName());
                Console.WriteLine(c.getFamilyName());
                Console.WriteLine(c.getUniqueAccountNumber());
                if (currentAccount == count) break;
                count++;

            }*/
            /*for (int i=0; i< currentAccount; i++)
            {
                Console.WriteLine("hello focus here : " + uniqueAccountNumber);
                Console.WriteLine("Account number is " + clients[i].getUniqueAccountNumber());
                Console.WriteLine("Name of the client is : "+ clients[i].getName());
                Console.WriteLine("Family name of the client is : " + clients[i].getFamilyName());
                Console.WriteLine("Bank balance : "+ clients[i].getBalance());

            }*/
/*
            if (uniqueAccountNumber > currentAccount)
            {
                Console.WriteLine("We don't have an any account of this number!");
                return;
            }
            else if (totalRemovedAcc > 0)
            {
                if (removeAccounts[uniqueAccountNumber])
                {
                    Console.WriteLine("We don't have an any account of this number!");
                    return;
                }
                else
                {
                    int count = removedAccCounter(uniqueAccountNumber);
                    uniqueAccountNumber = uniqueAccountNumber - count;

                }

            }
*/

            uniqueAccountNumber = accountNumberVerifier(uniqueAccountNumber);
            if(uniqueAccountNumber == -1)
            {
                Console.WriteLine("We don't have an any account of this number!");
                return;
            }
            Console.WriteLine("hello focus here : " + uniqueAccountNumber);
            Console.WriteLine("Account number is " + clients[uniqueAccountNumber].getUniqueAccountNumber());
            Console.WriteLine("Name of the client is : "+ clients[uniqueAccountNumber].getName());
            Console.WriteLine("Family name of the client is : " + clients[uniqueAccountNumber].getFamilyName());
            Console.WriteLine("Bank balance : "+ clients[uniqueAccountNumber].getBalance());

            
            


        }


        //deposit amount to a particular account
        public void depositAmount(int uniqueAccountNumber, double amount)
        {
            uniqueAccountNumber = accountNumberVerifier(uniqueAccountNumber);
            if (uniqueAccountNumber == -1)
            {
                Console.WriteLine("We don't have an any account of this number!");
                return;
            }






            double availableBalance = clients[uniqueAccountNumber].getBalance();
            clients[uniqueAccountNumber].setBalance(availableBalance+ amount);

            Console.WriteLine("Amount added successfully!");
            Console.WriteLine("Current account balance is " + clients[uniqueAccountNumber].getBalance());

        }

        //withdraw an amount from a particular account
        public void withdrawAmount(int uniqueAccountNumber, double amount)
        {

            uniqueAccountNumber = accountNumberVerifier(uniqueAccountNumber);
            if (uniqueAccountNumber == -1)
            {
                Console.WriteLine("We don't have an any account of this number!");
                return;
            }

            double availableBalance = clients[uniqueAccountNumber].getBalance();

            if(availableBalance < amount)
            {
                Console.WriteLine("You don't have a sufficient balance!");
                return;
            }
            clients[uniqueAccountNumber].setBalance(availableBalance - amount);

            Console.WriteLine("Withdrawal request successfully processed!");
            Console.WriteLine("Current account balance is " + clients[uniqueAccountNumber].getBalance());

        }


        //sort the data based on clients' balance
        public void sortDisplayByBalance(bool ascChecker)
        {
            Client[] sortBalance = new Client[currentAccount];
            
            for(int i=0; i< sortBalance.Length; i++)
            {
                sortBalance[i] = clients[i];
            }

            if (ascChecker)
            {

                for(int i=0; i< currentAccount; i++)
                {
                    for(int j=0; j< currentAccount-i-1; j++)
                    {
                        if(sortBalance[j].getBalance() > sortBalance[j + 1].getBalance())
                        {
                            Client temp = sortBalance[j];
                            sortBalance[j] = sortBalance[j + 1];
                            sortBalance[j + 1] = temp;
                        }
                    }
                }

            }
            else
            {
                for (int i = 0; i < currentAccount; i++)
                {
                    for (int j = 0; j < currentAccount - i - 1; j++)
                    {
                        if (sortBalance[j].getBalance() < sortBalance[j + 1].getBalance())
                        {
                            Client temp = sortBalance[j];
                            sortBalance[j] = sortBalance[j + 1];
                            sortBalance[j + 1] = temp;
                        }
                    }
                }
            }
            Console.WriteLine("\t\tAccount number\t\tFirst name\tFamily Name\t\tBalance");
            for(int i= 0; i< sortBalance.Length; i++)
            {
                Console.WriteLine("\t\t" + sortBalance[i].getUniqueAccountNumber() + "\t\t" + sortBalance[i].getName() + "\t\t" + sortBalance[i].getFamilyName() + "\t\t" + sortBalance[i].getBalance());

            }
        }

        //sort the data based on clients' family name
        public void sortDisplayByFamilyName(bool ascChecker)
        {
            Client[] sortArr = new Client[currentAccount];

            for (int i = 0; i < sortArr.Length; i++)
            {
                sortArr[i] = clients[i];
            }

            if (ascChecker)
            {

                for (int i = 0; i < currentAccount; i++)
                {
                    for (int j = 0; j < currentAccount - i - 1; j++)
                    {
                        if (String.Compare(sortArr[j].getFamilyName(),sortArr[j + 1].getFamilyName()) > 0)
                        {
                            Client temp = sortArr[j];
                            sortArr[j] = sortArr[j + 1];
                            sortArr[j + 1] = temp;
                        }
                    }
                }

            }
            else
            {
                for (int i = 0; i < currentAccount; i++)
                {
                    for (int j = 0; j < currentAccount - i - 1; j++)
                    {
                        if (String.Compare(sortArr[j].getFamilyName(), sortArr[j + 1].getFamilyName()) < 0)
                        {
                            Client temp = sortArr[j];
                            sortArr[j] = sortArr[j + 1];
                            sortArr[j + 1] = temp;
                        }
                    }
                }
            }
            Console.WriteLine("\t\tAccount number\t\tFirst name\tFamily Name\t\tBalance");
            for (int i = 0; i < sortArr.Length; i++)
            {
                Console.WriteLine("\t\t" + sortArr[i].getUniqueAccountNumber() + "\t\t" + sortArr[i].getName() + "\t\t" + sortArr[i].getFamilyName() + "\t\t" + sortArr[i].getBalance());

            }
        }


        //sort the data based on clients' name
        public void sortDisplayByName(bool ascChecker)
        {
            Client[] sortArr = new Client[currentAccount];

            for (int i = 0; i < sortArr.Length; i++)
            {
                sortArr[i] = clients[i];
            }

            if (ascChecker)
            {

                for (int i = 0; i < currentAccount; i++)
                {
                    for (int j = 0; j < currentAccount - i - 1; j++)
                    {
                        if (String.Compare(sortArr[j].getName(), sortArr[j + 1].getName()) > 0)
                        {
                            Client temp = sortArr[j];
                            sortArr[j] = sortArr[j + 1];
                            sortArr[j + 1] = temp;
                        }
                    }
                }

            }
            else
            {
                for (int i = 0; i < currentAccount; i++)
                {
                    for (int j = 0; j < currentAccount - i - 1; j++)
                    {
                        if (String.Compare(sortArr[j].getName(), sortArr[j + 1].getName()) < 0)
                        {
                            Client temp = sortArr[j];
                            sortArr[j] = sortArr[j + 1];
                            sortArr[j + 1] = temp;
                        }
                    }
                }
            }
            Console.WriteLine("\t\tAccount number\t\tFirst name\tFamily Name\t\tBalance");
            for (int i = 0; i < sortArr.Length; i++)
            {
                Console.WriteLine("\t\t" + sortArr[i].getUniqueAccountNumber() +"\t\t" + sortArr[i].getName() + "\t\t" + sortArr[i].getFamilyName() + "\t\t" + sortArr[i].getBalance());

            }
        }

        //for finding total balance of this bank
        public double totalBalance()
        {
            double total = 0;
            for(int i=0; i < currentAccount; i++)
            {
                total += clients[i].getBalance();
            }
            
            return total;
        }

        //for finding average balance of this bank
        public void avgBal()
        {

            double total = totalBalance();
            double avg = total / currentAccount;
            
            Console.WriteLine("Average balance of this bank is : "+ avg);

        }



        public void createAccount(int uniqueAccountNumber)
        {
            if(currentAccount > uniqueAccountNumber)
            {
                if (accountAvlCheckerInRemovedAccs(uniqueAccountNumber)) {
                    addBankAccount(uniqueAccountNumber);



                }
                else
                {
                    Console.WriteLine("This account number is not available!");
                }
            }
            else
            {
                if (removeAccounts[uniqueAccountNumber])
                {
                    totalRemovedAcc--;
                }
                removeAccounts[uniqueAccountNumber] = false; 

                for(int i= 0; i< uniqueAccountNumber; i++)
                {
                    if (!removeAccounts[i])
                    {
                        removeAccounts[i] = true;
                        totalRemovedAcc++;

                    }
                }
                int counter = removedAccCounter(uniqueAccountNumber);
                uniqueAccountNumber -= counter;
                clients[uniqueAccountNumber] = new Client(uniqueAccountNumber+ counter);

                Client[] dummyClient = new Client[100];

                for(int i= 0; i< uniqueAccountNumber; i++)
                {
                    dummyClient[i] = clients[i];
                }


                //maybe we will have error at endpoint
                for(int i= uniqueAccountNumber; i< dummyClient.Length -1; i++)
                {
                    dummyClient[i+1] = clients[i];
                }


                Console.WriteLine("Enter the name of the clients : ");

                clients[uniqueAccountNumber].setName(Console.ReadLine());

                Console.WriteLine("Enter the family name of the clients : ");
                clients[uniqueAccountNumber].setFamilyName(Console.ReadLine());

                Console.WriteLine("Enter the balance of the clients : ");
                clients[uniqueAccountNumber].setBalance(double.Parse(Console.ReadLine()));

                for(int i=0; i< dummyClient.Length; i++)
                {
                    clients[i]  = dummyClient[i];
                }

                currentAccount++;

            }
        }

        
        public Bank() { 
            clients = new Client[100];

        }
    }
}
