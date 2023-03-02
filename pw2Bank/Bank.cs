using System;
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

            if (totalRemovedAcc > 0 )
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
            Console.WriteLine("hello focus here : " + uniqueAccountNumber);
            Console.WriteLine("Account number is " + clients[uniqueAccountNumber].getUniqueAccountNumber());
            Console.WriteLine("Name of the client is : "+ clients[uniqueAccountNumber].getName());
            Console.WriteLine("Family name of the client is : " + clients[uniqueAccountNumber].getFamilyName());
            Console.WriteLine("Bank balance : "+ clients[uniqueAccountNumber].getBalance());

            
            


        }

        public Bank() { 
            clients = new Client[100];

        }
    }
}
