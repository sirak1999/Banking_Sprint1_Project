using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_Business_Layer_Sprint_1;
using Banking_Business_Obj_Layer_Sprint_1;


namespace Banking_Sprint1_UI_LAYER
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank_Branch obj_bank = new Bank_Branch();
            Customer obj_cust = new Customer();
            Savings obj_sav = new Savings();
            Checking obj_chk = new Checking();
            Transaction obj_trn = new Transaction();
            Bank_Business_Layer obj_bbl = new Bank_Business_Layer();

            Console.WriteLine("----------------Welcome to Banking Account Management System---------------");
            Console.WriteLine("----------------Options available are---------------");
            Console.WriteLine("Press 1 for Bank Branch Maintenance \n Press 2 for Customer maintenance \n Press 3 for Accounts maintenance");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("----------- This is Bank Branch Maintenance Screen. How May I Help You!!!-----------");
                    Console.WriteLine("For Insert press 1 OR Updation press 2 OR For Fetching press 3");
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n==1)
                    {
                        Console.WriteLine("Enter the Bank Name : ");
                        Bank_Branch.BankName = Console.ReadLine();
                        //Console.WriteLine("Bank name is " + Bank_Branch.BankName);
                        Console.WriteLine("Enter the Branch Code : ");
                        Bank_Branch.BranchCode = Console.ReadLine();
                        Console.WriteLine("Enter the Branch Name : ");
                        Bank_Branch.BranchName = Console.ReadLine();
                        Console.WriteLine("Enter the Bank Phone Number : ");
                        Bank_Branch.BPhnNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Bank Email Address : ");
                        Bank_Branch.BEmail = Console.ReadLine();
                        Console.WriteLine("Enter the Bank Address : ");
                        Bank_Branch.BAddr = Console.ReadLine();
                        //Insertion operation for bank
                        obj_bbl.InsertBankDetails();
                        Console.WriteLine("Bank details inserted");
                    }
                   
                    //Updation Operation Bank
                    else if (n == 2)
                    {
                        Console.WriteLine("Press A for Address Updation \n Press P for Phone Number Updation \n Press E for Email Updation");
                        string s = Console.ReadLine();
                        if (s == "A")
                        {
                            Console.WriteLine("Enter the branch code where updation has to be done");
                            string br = Console.ReadLine();
                            Console.WriteLine("Enter the new address for updation");
                            string add = Console.ReadLine();
                            string p = obj_bbl.UpdateBranchAdd(br, add);
                            if (p == "")
                            {
                                Console.WriteLine("Updation Successfull");
                            }
                            else
                            {
                                Console.WriteLine(p);
                            }
                        }
                        else if (s == "P")
                        {
                            Console.WriteLine("Enter the branch code where updation has to be done");
                            string br = Console.ReadLine();
                            Console.WriteLine("Enter the new phone number for updation");
                            int phn = Convert.ToInt32(Console.ReadLine());
                            string p = obj_bbl.UpdateBranchPhn(br, phn);
                            if (p == "")
                            {
                                Console.WriteLine("Updation Successfull");
                            }
                            else
                            {
                                Console.WriteLine(p);
                            }

                        }
                        else if (s == "E")
                        {
                            Console.WriteLine("Enter the branch code where updation has to be done");
                            string br = Console.ReadLine();
                            Console.WriteLine("Enter the new email address for updation");
                            string email = Console.ReadLine();
                            string p = obj_bbl.UpdateBranchEmail(br, email);
                            if (p == "")
                            {
                                Console.WriteLine("Updation Successfull");
                            }
                            else
                            {
                                Console.WriteLine(p);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Choice, please refer to the menu for correct one");
                        }
                    }
                    //Fetching operation Bank
                    else if (n == 3)
                    {
                        Console.WriteLine("Enter the branch code for fetching");
                        string brcode = Console.ReadLine();
                        List<string> bank_list = new List<string>();
                        bank_list = obj_bbl.FetchBank(brcode);
                        if (bank_list.Count > 1)
                        {
                            Console.WriteLine("Branch Code           ---- " + bank_list[0]);
                            Console.WriteLine("Bank Name             ---- " + bank_list[1]);
                            Console.WriteLine("Branch Name           ---- " + bank_list[2]);
                            Console.WriteLine("Branch Phone Number   ---- " + bank_list[3]);
                            Console.WriteLine("Branch Address        ---- " + bank_list[4]);
                            Console.WriteLine("Branch Email          ---- " + bank_list[5]);
                        }
                        else
                        {
                            Console.WriteLine(bank_list[0]);
                        }

                    }
                    //Wrong Choice
                    else
                    {

                        Console.WriteLine("Wrong Choice, please refer to the menu for correct one");
                    }
                    break;
                case 2:
                    Console.WriteLine("----------- This is Customer Maintenance Screen. How May I Help You!!!-----------");
                    Console.WriteLine("For Insert press 1 OR Updation press 2 OR For Fetching press 3 OR For Delete press 4");
                    int m = Convert.ToInt32(Console.ReadLine());
                    if(m==1)
                    {
                        Console.WriteLine("Enter the Customer ID");
                        Customer.CustomerId = Console.ReadLine();
                        Console.WriteLine("Enter the Customer First Name");
                        Customer.CustomerFName = Console.ReadLine();
                        Console.WriteLine("Enter the Customer Middle Name");
                        Customer.CustomerMName = Console.ReadLine();
                        Console.WriteLine("Enter the Customer Last Name");
                        Customer.CustomerLName = Console.ReadLine();
                        Console.WriteLine("Enter the Customer Address");
                        Customer.CustAddress = Console.ReadLine();
                        Console.WriteLine("Enter the Customer Email");
                        Customer.CustEmail = Console.ReadLine();
                        Console.WriteLine("Enter the Customer Phone Number");
                        Customer.CustPhnNumber = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter the Branch Code");
                        Bank_Branch.BranchCode = Console.ReadLine();

                        //Insertion operation customer
                        obj_bbl.CreateNewCustomer();
                        Console.WriteLine("Customer data has been saved");
                        Console.WriteLine("For opening Savings account press S and For opening Checking account press C");
                        string t = Console.ReadLine();
                        if(t=="S"||t=="s")
                        {
                            Console.WriteLine("Enter the Account Number ");
                            Savings.AccountNum = Convert.ToInt64(Console.ReadLine());
                            // Console.WriteLine("Enter the Account opening date ");
                            Savings.AccDate = DateTime.Now;
                            Console.WriteLine("Enter the Initial account balance ");
                            Savings.InitialDepoAmt = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter the Interest Rate ");
                            Savings.InterestRate = Convert.ToDouble(Console.ReadLine());
                            Savings.Balance = Savings.InitialDepoAmt;
                            //Console.WriteLine("Enter the Customer ID");
                            //Customer.CustomerId = Console.ReadLine();
                            obj_bbl.InsertSavingsDetails();
                        }
                        else if(t=="C"||t=="c")
                        {
                            Console.WriteLine("Enter the Account Number ");
                            Checking.AccountNum = Convert.ToInt64(Console.ReadLine());
                            //Console.WriteLine("Enter the Account opening date ");
                            Checking.AccDate = DateTime.Now;
                            Console.WriteLine("Enter the Initial account balance ");
                            Checking.InitialDepoAmt = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter the Interest Rate ");
                            Checking.ServiceCharge = Convert.ToDouble(Console.ReadLine());
                            Checking.Balance = Checking.InitialDepoAmt;
                            //Console.WriteLine("Enter the Customer ID");
                            //Customer.CustomerId = Console.ReadLine();
                            obj_bbl.InsertCheckingDetails();

                        }
                        else
                        {
                            Console.WriteLine("Entered choice is incorrect.");
                        }
                    }
                    //Updation Operation Customer                   
                    else if (m == 2)
                    {

                        Console.WriteLine("Press A for Address Updation \n Press P for Phone Number Updation \n Press E for Email Updation");
                        string s = Console.ReadLine();
                        if (s == "A")
                        {
                            Console.WriteLine("Enter the customer id whhose updation has to be done");
                            string cId = Console.ReadLine();
                            Console.WriteLine("Enter the new address for updation");
                            string add = Console.ReadLine();
                            string p = obj_bbl.UpdateCustAdd(cId, add);
                            if (p == "")
                            {
                                Console.WriteLine("Updation Successfull");
                            }
                            else
                            {
                                Console.WriteLine(p);
                            }
                        }
                        else if (s == "P")
                        {
                            Console.WriteLine("Enter the customer id whhose updation has to be done");
                            string cId = Console.ReadLine();
                            Console.WriteLine("Enter the new phone number for updation");
                            long phn = Convert.ToInt64(Console.ReadLine());
                            string p = obj_bbl.UpdateCustPhn(cId, phn);
                            if (p == "")
                            {
                                Console.WriteLine("Updation Successfull");
                            }
                            else
                            {
                                Console.WriteLine(p);
                            }
                        }
                        else if (s == "E")
                        {
                            Console.WriteLine("Enter the customer id whhose updation has to be done");
                            string cId = Console.ReadLine();
                            Console.WriteLine("Enter the new email address for updation");
                            string email = Console.ReadLine();
                            string p = obj_bbl.UpdateCustEmail(cId, email);
                            if (p == "")
                            {
                                Console.WriteLine("Updation Successfull");
                            }
                            else
                            {
                                Console.WriteLine(p);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Choice, please refer to the menu for correct one");
                        }


                    }
                    //Fetching Operation Customer
                    else if (m == 3)
                    {
                        List<string> list_cust = new List<string>();
                        Console.WriteLine("Enter the customer id whose details has to be fetched");
                        string cusID = Console.ReadLine();
                        list_cust = obj_bbl.FetchCustomer(cusID);
                        if (list_cust.Count > 1)
                        {
                            Console.WriteLine("Customer ID                      ---- " + list_cust[0]);
                            Console.WriteLine("Customer First Name              ---- " + list_cust[1]);
                            Console.WriteLine("Customer Middle Name             ---- " + list_cust[2]);
                            Console.WriteLine("Customer Last Name               ---- " + list_cust[3]);
                            Console.WriteLine("Customer Address                 ---- " + list_cust[4]);
                            Console.WriteLine("Customer Email                   ---- " + list_cust[5]);
                            Console.WriteLine("Customer Phone Number            ---- " + list_cust[6]);
                            Console.WriteLine("Branch Code                      ---- " + list_cust[7]);
                        }
                        else
                        {
                            Console.WriteLine("Customer not found");
                        }

                    }
                    //Deletion Operation Customer
                    else if (m == 4)
                    {
                        Console.WriteLine("Enter the customer id whose details has to be deleted");
                        string cusID = Console.ReadLine();
                        string p = obj_bbl.DeleteDetails(cusID);
                        if (p == "")
                        {
                            Console.WriteLine("Deletion Successfull");
                        }
                        else
                        {
                            Console.WriteLine(p);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice, please refer to the menu for correct one");
                    }
                    break;
                case 3:
                    double savbal = 0.0;
                    double chkbal = 0.0;
                    Console.WriteLine("----------- This is Accounts Maintenance Screen. How May I Help You!!!-----------");
                    Console.WriteLine("Press 1 for doing new transaction OR Press 2 for Fetching Account details OR Press 3 for fetching transaction details ");
                    int o = Convert.ToInt32(Console.ReadLine());
                    //if (o == 1)
                    //{
                    //    Console.WriteLine("Enter the Account Number ");
                    //    Savings.AccountNum = Convert.ToInt64(Console.ReadLine());
                    //   // Console.WriteLine("Enter the Account opening date ");
                    //    Savings.AccDate = DateTime.Now;
                    //    Console.WriteLine("Enter the Initial account balance ");
                    //    Savings.InitialDepoAmt = Convert.ToDouble(Console.ReadLine());
                    //    Console.WriteLine("Enter the Interest Rate ");
                    //    Savings.InterestRate = Convert.ToDouble(Console.ReadLine());
                    //    Console.WriteLine("Enter the Customer ID");
                    //    Customer.CustomerId = Console.ReadLine();
                    //    obj_bbl.InsertSavingsDetails();

                    //}
                    //else if (o == 2)
                    //{
                    //    Console.WriteLine("Enter the Account Number ");
                    //    Checking.AccountNum = Convert.ToInt64(Console.ReadLine());
                    //    //Console.WriteLine("Enter the Account opening date ");
                    //    Checking.AccDate = DateTime.Now;
                    //    Console.WriteLine("Enter the Initial account balance ");
                    //    Checking.InitialDepoAmt = Convert.ToDouble(Console.ReadLine());
                    //    Console.WriteLine("Enter the Interest Rate ");
                    //    Checking.ServiceCharge = Convert.ToDouble(Console.ReadLine());
                    //    Console.WriteLine("Enter the Customer ID");
                    //    Customer.CustomerId = Console.ReadLine();
                    //    obj_bbl.InsertCheckingDetails();

                    //}
                    //else
                    //{
                    //    Console.WriteLine("Entered choice is incorrect.");
                    //}
                    if(o==1)
                    {
                        Console.WriteLine("Enter the transaction amount");
                        Transaction.transAmount = Convert.ToDouble(Console.ReadLine());
                        System.Guid guid = System.Guid.NewGuid();
                        Transaction.transactionID = guid.ToString();
                        // Console.WriteLine("Enter the transaction date");
                        Transaction.transaction_date = DateTime.Now;
                        Console.WriteLine("Enter the Customer ID");
                        Customer.CustomerId = Console.ReadLine();
                        obj_bbl.InsertTransactionDetails();
                        

                        Console.WriteLine("Press 1 for savings account trasaction OR Press 2 for checking account trasaction ");
                        int x = Convert.ToInt32(Console.ReadLine());
                        if (x == 1)
                        {
                            //Console.WriteLine("Please mention your previous balance");
                            Savings.Balance = Bank_Business_Layer.SavBalance(Customer.CustomerId);
                            Console.WriteLine("Type Debit for withdrawl or Type Credit for deposit");
                            string ss = Console.ReadLine();
                            savbal = obj_bbl.SavingsTransact(Customer.CustomerId,ss, Transaction.transAmount);
                        }
                        else if (x == 2)
                        {
                            //Console.WriteLine("Please mention your previous balance");
                            Checking.Balance = Bank_Business_Layer.ChkBalance(Customer.CustomerId);
                            Console.WriteLine("Type Debit for withdrawl or Type Credit for deposit");
                            string ss = Console.ReadLine();
                            chkbal = obj_bbl.CheckingTransact(Customer.CustomerId,ss, Transaction.transAmount);
                        }
                        if (x == 1)
                        {
                            //Console.WriteLine("Enter the customer ID");
                            //string custId = Console.ReadLine();
                            if(savbal>double.MinValue)
                            {
                                if (savbal > int.MinValue)
                                {
                                    var savup = obj_bbl.UpdateSavingsDetails(Customer.CustomerId, savbal);
                                    if (savup == "")
                                    {
                                        Console.WriteLine("Updation Successfull");
                                    }
                                    else
                                    {
                                        Console.WriteLine(savup);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Transaction not possible due to insufficient balance");
                                }
                            }
                            else
                            {
                                Console.WriteLine("The Customer does not have savings account");
                            }
                            
                           
                        }
                        else if (x == 2)
                        {
                            //Console.WriteLine("Enter the customer ID");
                            //string custoId = Console.ReadLine();
                            if(chkbal>double.MinValue)
                            {
                                if (chkbal > int.MinValue)
                                {
                                    var chkup = obj_bbl.UpdateCheckingDetails(Customer.CustomerId, chkbal);
                                    if (chkup == "")
                                    {
                                        Console.WriteLine("Updation Successfull");
                                    }
                                    else
                                    {
                                        Console.WriteLine(chkup);
                                    }
                                }
                                else

                                {
                                    Console.WriteLine("Transaction not possible due to insufficient balance");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Customer does not have checking account");
                            }

                        }
                    }
                    else if (o==2)
                    {
                        Console.WriteLine("Enter the customer ID");
                        string CustoId = Console.ReadLine();
                        Console.WriteLine("Press Savings for savings account OR Press Checking for checking account");
                        string type = Console.ReadLine();
                        ArrayList arracc = new ArrayList();
                        arracc = obj_bbl.FetchAccount(CustoId, type);
                        if (arracc.Count > 1)
                        {
                            Console.WriteLine("Customer Id ------- " + arracc[0]);
                            Console.WriteLine("Account Number ------- " + arracc[1]);
                            Console.WriteLine("Account Date ------- " + arracc[2]);
                            Console.WriteLine("Interest Rate ------- " + arracc[3]);
                            Console.WriteLine("Initial Amount Deposited ------- " + arracc[4]);
                            Console.WriteLine("Balance ------- " + arracc[5]);
                        }
                        else
                        {
                            Console.WriteLine(arracc[0]);
                        }

                    }
                 
                    else if(o==3)
                    {
                        Console.WriteLine("Enter the customer ID");
                        string CustomId = Console.ReadLine();
                        ArrayList arrtransac = new ArrayList();
                        arrtransac = obj_bbl.FetchTransaction(CustomId);
                        if (arrtransac.Count > 1)
                        {
                            Console.WriteLine("Customer Id ------- " + arrtransac[0]);
                            Console.WriteLine("Transaction ID ------- " + arrtransac[1]);
                            Console.WriteLine("Transaction Date ------- " + arrtransac[2]);
                            Console.WriteLine("Transaction Amount ------- " + arrtransac[3]);

                        }
                        else

                        {
                            Console.WriteLine(arrtransac[0]);
                        }


                    }



                    break;
                default:
                    Console.WriteLine("Invalid Choice, Please press the correct option");
                    break;
            }
        }
    }
}
