using System;
using System.Collections;
using System.Collections.Generic;
using Banking_Business_Obj_Layer_Sprint_1;
using Banking_DAL_Sprint_1;

namespace Banking_Business_Layer_Sprint_1
{
    public class Bank_Business_Layer
    {
        Class1 ObjDAL = new Class1();
        Customer cus = new Customer();
        Bank_Branch bank = new Bank_Branch();
        Savings sv = new Savings();
        Checking ck = new Checking();
        Transaction tr = new Transaction();
        public double FinalBalance_S = 0;
        public double FinalBalance_C = 0;

        //--------------------------------------  Bank Branch -------------------------------

        public void InsertBankDetails()
        {
            ArrayList ArrBank = new ArrayList();
            ArrBank.Add(Bank_Branch.BranchCode);
            ArrBank.Add(Bank_Branch.BankName);
            ArrBank.Add(Bank_Branch.BranchName);
            ArrBank.Add(Bank_Branch.BPhnNumber);
            ArrBank.Add(Bank_Branch.BAddr);
            ArrBank.Add(Bank_Branch.BEmail);
            Class1.InsertBankDetailsTODB(ArrBank);
            ArrBank.Clear();
        }
        public string UpdateBranchAdd(string brcode, string newaddr)
        {
            Bank_Branch.BAddr = newaddr;
            var s = Class1.UpdateBranchAddresstoDal(brcode, Bank_Branch.BAddr);
            return s;
        }
        public string UpdateBranchPhn(string brcode, int newphn)
        {
            Bank_Branch.BPhnNumber = newphn;
            var s = Class1.UpdateBranchPhntoDal(brcode, Bank_Branch.BPhnNumber);
            return s;
        }
        public string UpdateBranchEmail(string brcode, string newemail)
        {
            Bank_Branch.BEmail = newemail;
            var s = Class1.UpdateBranchEmailAddtoDal(brcode, Bank_Branch.BEmail);
            return s;
        }
        public List<string> FetchBank(string brcode)
        {

            List<string> s = Class1.FetchBankDetails(brcode);
            return s;
        }

        //--------------------------------------  Bank Customer -------------------------------

        public void CreateNewCustomer()
        {
            //Dictionary<string, ArrayList> dict_Cust = new Dictionary<string, ArrayList>();
            ArrayList arr_Customer = new ArrayList();
            arr_Customer.Add(Customer.CustomerId);
            arr_Customer.Add(Customer.CustomerFName);
            arr_Customer.Add(Customer.CustomerMName);
            arr_Customer.Add(Customer.CustomerLName);
            arr_Customer.Add(Customer.CustAddress);
            arr_Customer.Add(Customer.CustEmail);
            arr_Customer.Add(Customer.CustPhnNumber);
            arr_Customer.Add(Bank_Branch.BranchCode);
            Class1.InsertCustomerDetails(arr_Customer);
            arr_Customer.Clear();
        }
        public string UpdateCustAdd(string cusId, string newadd)
        {
            Customer.CustAddress = newadd;
            var s = Class1.UpdateCustAddtoDal(cusId, Customer.CustAddress);
            return s;
        }
        public string UpdateCustPhn(string cusId, long newphn)
        {
            Customer.CustPhnNumber = newphn;
            var s = Class1.UpdateCustPhntoDal(cusId, Customer.CustPhnNumber);
            return s;
        }
        public string UpdateCustEmail(string cusId, string newemail)
        {
            Customer.CustEmail = newemail;
            var s = Class1.UpdateCustEmailtoDal(cusId, Customer.CustEmail);
            return s;
        }
        public string DeleteDetails(string cusID)
        {
            string ss = "";
            
            var s1 = Class1.DeleteSavingsDetails(cusID);
            var s2 = Class1.DeleteCheckingDetails(cusID);
            var s3 = Class1.DeleteTransactionDetails(cusID);
            var s = Class1.DeleteCustomerDetails(cusID);
            if (s != String.Empty || s1 != String.Empty || s2 != String.Empty || s3 != String.Empty)
            {
                ss = s;
            }
            return ss;
        }
        public List<string> FetchCustomer(string cusID)
        {
            var s = Class1.FetchCustomerDetails(cusID);
            return s;
        }

        //--------------------------------------  Bank Savings -------------------------------

        public void InsertSavingsDetails()
        {
            ArrayList ArrSaving = new ArrayList();
            ArrSaving.Add(Customer.CustomerId);
            ArrSaving.Add(Savings.AccountNum);
            ArrSaving.Add(Savings.AccDate);
            ArrSaving.Add(Savings.InterestRate);
            ArrSaving.Add(Savings.InitialDepoAmt);
            ArrSaving.Add(Savings.Balance);
            Class1.InsertSavingsDetailsTODB(ArrSaving);
            ArrSaving.Clear();
        }

        //--------------------------------------  Bank Checking -------------------------------

        public void InsertCheckingDetails()
        {
            ArrayList ArrChecking = new ArrayList();
            ArrChecking.Add(Customer.CustomerId);
            ArrChecking.Add(Checking.AccountNum);
            ArrChecking.Add(Checking.AccDate);
            ArrChecking.Add(Checking.ServiceCharge);
            ArrChecking.Add(Checking.InitialDepoAmt);
            ArrChecking.Add(Checking.Balance);
            Class1.InsertCheckingDetailsTODB(ArrChecking);
            ArrChecking.Clear();
        }

        //--------------------------------------  Bank Transaction -------------------------------
        public double SavingsTransact(string custId,string transacttype, double transAmount)
        {
            if(Class1.iSPresentCustIDSav(custId))
            {
                if (transacttype.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                {
                    if (Savings.Balance > transAmount)
                    {
                        Savings.Balance -= transAmount;
                        FinalBalance_S = Savings.Balance;
                    }
                    else
                    {
                        FinalBalance_S = int.MinValue;
                    }
                }
                else if (transacttype.Equals("Credit", StringComparison.OrdinalIgnoreCase))
                {
                    Savings.Balance += transAmount;
                    FinalBalance_S = Savings.Balance;
                }

            }
            else
            {
                FinalBalance_S = double.MinValue;
            }

            return FinalBalance_S;

        }
        public double CheckingTransact(string custID,string transacttype, double transAmount)
        {
            if (Class1.iSPresentCustIDChk(custID))
            {
                if (transacttype.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                {
                    if (Checking.Balance > transAmount)
                    {
                        Checking.Balance -= transAmount;
                        FinalBalance_C = Checking.Balance;
                    }
                    else
                    {
                        FinalBalance_C = int.MinValue;
                    }
                }
                else if (transacttype.Equals("Credit", StringComparison.OrdinalIgnoreCase))
                {
                    Checking.Balance += transAmount;
                    FinalBalance_C = Checking.Balance;
                }

            }
            else
            {
                FinalBalance_C = double.MinValue;
            }
            return FinalBalance_C;

        }
        public void InsertTransactionDetails()
        {

            //Dictionary<string, ArrayList> arrTransact = new Dictionary<string, ArrayList>();
            ArrayList arrT = new ArrayList();
            //string[] arrT = new string[];
            //List<string> arrT = new List<string>();
            arrT.Add(Transaction.transactionID);
            arrT.Add(Transaction.transaction_date);
            arrT.Add(Transaction.transAmount);
            Class1.InsertTransaction(Customer.CustomerId, arrT);
            arrT.Clear();
        }
        public string UpdateSavingsDetails(string cusId, double savbalance)
        {

            var s = savbalance;
            var ss = Class1.UpdateSavings(cusId, s);
            return ss;

        }
        public string UpdateCheckingDetails(string cusId, double chkbalance)
        {

            var s = chkbalance;
            var ss = Class1.UpdateCheching(cusId, s);
            return ss;

        }
        public ArrayList FetchTransaction(string cusID)
        {
            var ss = Class1.FetchTransactionDetails(cusID);
            return ss;
        }
        public ArrayList FetchAccount(string cusID, string accntype)
        {
            var s = Class1.FetchAccountDetails(cusID, accntype);
            return s;
        }

        public static double SavBalance(string custId)
        {
            var sb = Class1.fetchSavingsBal(custId);
            return sb;
        }
        public static double ChkBalance(string custId)
        {
            var cb = Class1.fetchCheckingsBal(custId);
            return cb;
        }





    }
}
