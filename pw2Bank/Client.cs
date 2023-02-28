using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw2Bank
{
    internal class Client
    {
        private string name = "";
        private string familyName = "";
        private int uniqueAccountNumber = 0;
        private double balance;

        

        public Client(int uniqueAccountNumber) { 
            this.uniqueAccountNumber = 10000+ uniqueAccountNumber;
            this.balance= 0;
        }

        public string getName()
        {
            //Console.WriteLine(name);
            return name;
        }
        public void setName(string name)
        {
            this.name = name;

        }
        public string getFamilyName()
        {
            //Console.WriteLine(familyName);
            return familyName;
        }
        public void setFamilyName(string familyName)
        {
            this.familyName = familyName;
        }
        public int getUniqueAccountNumber()
        {
            //Console.WriteLine(uniqueAccountNumber);
            return uniqueAccountNumber;
        }

        /*public void setUniqueAccountNumber(int uniqueAccountNumber)
        {
            this.uniqueAccountNumber = uniqueAccountNumber;
        }*/

        public double getBalance()
        {

            //Console.WriteLine(balance);
            return balance;
        }

        public void setBalance(double balance)
        {
            this.balance = balance;
        }
    /*    public string Name { get => name; set => name = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public int UniqueAccountNumber { get => uniqueAccountNumber; set => uniqueAccountNumber = value; }
        public double Balance { get => balance; set => balance = value; }
    */
    
    
    }
}
