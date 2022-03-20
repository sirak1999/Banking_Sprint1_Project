using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Data;

namespace Banking_DAL_Sprint_1
{
    public class Class1
    {
        public static string connectionString = "Data Source=DESKTOP-5P4C1OM\\MSSQLSERVER2019;Initial Catalog=banking_Sprint1;integrated security=true";
        public static bool isPresentCust(string customerId)
        {
            bool Present = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Customer";
            SqlDataAdapter sdr = new SqlDataAdapter(query, connection);
            // sdr.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString() == customerId)
                {
                    Present = true;
                    break;
                }
            }
            return Present;
        }
        public static bool isPresentBank(string BranchCode)
        {
            bool Present = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Bank";
            SqlDataAdapter sdr = new SqlDataAdapter(query, connection);
            // sdr.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString() == BranchCode)
                {
                    Present = true;
                    break;
                }
            }
            return Present;
        }
        //Inserting Operation
        public static void InsertBankDetailsTODB(ArrayList arrB)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query1 = "Insert into Bank values(@BranchCode,@BankName,@BranchName,@BPhnNumber,@BAddress,@BEmail)";
            SqlCommand cmd = new SqlCommand(query1, connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@BranchCode", arrB[0]);
            cmd.Parameters.AddWithValue("@BankName", arrB[1]);
            cmd.Parameters.AddWithValue("@BranchName", arrB[2]);
            cmd.Parameters.AddWithValue("@BPhnNumber", arrB[3]);
            cmd.Parameters.AddWithValue("@BAddress", arrB[4]);
            cmd.Parameters.AddWithValue("@BEmail", arrB[5]);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertCustomerDetails(ArrayList arrC)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query1 = "Insert into Customer values(@CustomerId,@CustomerFName,@CustomerMName,@CustomerLName,@CustAddress,@CustEmail,@CustPhnNumber,@BranchCode)";
            SqlCommand cmd = new SqlCommand(query1, connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@CustomerId", arrC[0]);
            cmd.Parameters.AddWithValue("@CustomerFName", arrC[1]);
            cmd.Parameters.AddWithValue("@CustomerMName", arrC[2]);
            cmd.Parameters.AddWithValue("@CustomerLName", arrC[3]);
            cmd.Parameters.AddWithValue("@CustAddress", arrC[4]);
            cmd.Parameters.AddWithValue("@CustEmail", arrC[5]);
            cmd.Parameters.AddWithValue("@CustPhnNumber", arrC[6]);
            cmd.Parameters.AddWithValue("@BranchCode", arrC[7]);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertSavingsDetailsTODB(ArrayList arrS)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query1 = "Insert into Savings values(@CustomerId,@AccountNum,@AccDate,@InterestRate,@InitialDepoAmt,@Bal)";
            SqlCommand cmd = new SqlCommand(query1, connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@CustomerId", arrS[0]);
            cmd.Parameters.AddWithValue("@AccountNum", arrS[1]);
            cmd.Parameters.AddWithValue("@AccDate", arrS[2]);
            cmd.Parameters.AddWithValue("@InterestRate", arrS[3]);
            cmd.Parameters.AddWithValue("@InitialDepoAmt", arrS[4]);
            cmd.Parameters.AddWithValue("@Bal", arrS[5]);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertCheckingDetailsTODB(ArrayList arrCD)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query1 = "Insert into Checking values(@CustomerId,@AccountNum,@AccDate,@ServiceCharge,@InitialDepoAmt,@Bal)";
            SqlCommand cmd = new SqlCommand(query1, connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@CustomerId", arrCD[0]);
            cmd.Parameters.AddWithValue("@AccountNum", arrCD[1]);
            cmd.Parameters.AddWithValue("@AccDate", arrCD[2]);
            cmd.Parameters.AddWithValue("@ServiceCharge", arrCD[3]);
            cmd.Parameters.AddWithValue("@InitialDepoAmt", arrCD[4]);
            cmd.Parameters.AddWithValue("@Bal", arrCD[5]);

           cmd.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertTransaction(string CusID, ArrayList arrT)
        {
            //Dictionary<string, ArrayList>.ValueCollection dictTranValues = arrTransact.Values;
            SqlConnection connection = new SqlConnection(connectionString);
            string query1 = "Insert into Transactions values(@CustomerId,@TransactionId,@TransactionDate,@TransactionAmount)";
            SqlCommand cmd = new SqlCommand(query1, connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@CustomerId", CusID);
            cmd.Parameters.AddWithValue("@TransactionId", arrT[0]);
            cmd.Parameters.AddWithValue("@TransactionDate", arrT[1]);
            cmd.Parameters.AddWithValue("@TransactionAmount", arrT[2]);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Customer Updation
        public static string UpdateSavings(string CusID, double Balance)
        {
            string e = "";
            if (isPresentCust(CusID))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "update Savings set Balance = @finalbalance WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@finalbalance", Balance);
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }
            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;


        }
        public static string UpdateCheching(string CusID, double Balance)
        {
            string e = "";
            if (isPresentCust(CusID))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "update Checking set Balance = @finalbalance WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@finalbalance", Balance);
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }
            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;


        }
        public static string UpdateCustAddtoDal(string CusID, string addr)
        {
            string e = "";
            if (isPresentCust(CusID))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "update Customer set Address = @newadd WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@newadd", addr);
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }
            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;

        }
        public static string UpdateCustPhntoDal(string CusID, long phn)
        {
            string e = "";
            if (isPresentCust(CusID))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "update Customer set CustomerPhoneNumber = @newphn WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@newphn", phn);
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();

            }
            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;


        }
        public static string UpdateCustEmailtoDal(string CusID, string email)
        {
            string e = "";
            if (isPresentCust(CusID))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "update Customer set Email = @newemail WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@newemail", email);
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }

            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;

        }
        //Branch Updation
        public static string UpdateBranchAddresstoDal(string branchcode, string address)
        {
            string b = "";
            if (isPresentBank(branchcode))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "update Bank set BankAddress = @newaddress WHERE BranchCode = @brcode";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@newaddress", address);
                cmd.Parameters.AddWithValue("@brcode", branchcode);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }
            else
            {
                b = "Invalid Branch code. Please enter valid branch code";
            }
            return b;

        }
        public static string UpdateBranchPhntoDal(string branchcode, int phn)
        {
            string b = "";
            if (isPresentBank(branchcode))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "update Bank set PhoneNumber = @newphone WHERE BranchCode = @brcode";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@newphone", phn);
                cmd.Parameters.AddWithValue("@brcode", branchcode);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }
            else
            {
                b = "Invalid Branch code. Please enter valid branch code";
            }
            return b;

        }
        public static string UpdateBranchEmailAddtoDal(string branchcode, string email)
        {
            string b = "";
            if (isPresentBank(branchcode))
            {

                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "update Bank set Email = @newemail WHERE BranchCode = @brcode";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@newemail", email);
                cmd.Parameters.AddWithValue("@brcode", branchcode);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }
            else
            {
                b = "Invalid Branch code. Please enter valid branch code";
            }
            return b;


        }
        //Delete Operation ------------> Delete Cascade
        public static string DeleteCustomerDetails(string CusID)
        {
            string e = "";
            if (isPresentCust(CusID))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "delete Customer  WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }
            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;


        }
        public static string DeleteSavingsDetails(string CusID)
        {
            string e = "";
            if (isPresentCust(CusID))
            {

                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "delete Savings  WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();
            }
            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;

        }
        public static string DeleteCheckingDetails(string CusID)
        {
            string e = "";
            if (isPresentCust(CusID))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "delete Checking  WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();

            }
            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;



        }
        public static string DeleteTransactionDetails(string CusID)
        {
            string e = "";
            if (isPresentCust(CusID))
            {
                SqlConnection dConn = new SqlConnection(connectionString);
                string query1 = "delete Transactions  WHERE CustomerID = @CustomerId";
                SqlCommand cmd = new SqlCommand(query1, dConn);
                dConn.Open();
                cmd.Parameters.AddWithValue("@CustomerId", CusID);
                cmd.ExecuteNonQuery();
                dConn.Close();

            }
            else
            {
                e = "Invalid Customer ID.Please type the correct customer id";
            }
            return e;

        }
        //Fetching Operation
        public static List<string> FetchBankDetails(string branchcode)
        {
            List<string> BankDetails = new List<string>();
            if (isPresentBank(branchcode))
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query1 = "Select * from Bank WHERE BranchCode = @brcode";
                SqlDataAdapter sdr1 = new SqlDataAdapter(query1, connection);
                sdr1.SelectCommand.Parameters.AddWithValue("@brcode", branchcode);
                //sdr1.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt1 = new DataTable();
                // SqlCommandBuilder builder = new SqlCommandBuilder(sdr1);

                //DataSet ds1 = new DataSet();
                sdr1.Fill(dt1);
                foreach (DataRow row in dt1.Rows)
                {
                   
                    if (row[0].ToString() == branchcode)
                    {
                       
                       // BankDetails.Add(Convert.ToString(row));
                        BankDetails.Add(Convert.ToString(row[0]));// Branch Code
                        BankDetails.Add(Convert.ToString(row[1]));//Bank Name
                        BankDetails.Add(Convert.ToString(row[2]));//Branch Name
                        BankDetails.Add(Convert.ToString(row[3]));//Br Phone
                        BankDetails.Add(Convert.ToString(row[4]));//Branch Address
                        BankDetails.Add(Convert.ToString(row[5]));//Branch Email
                        break;
                    }
                }
            }
            else
            {
                string resu = "Invalid Branch Code Found,Please provide a valid code";
                BankDetails.Add(resu);
            }

            return BankDetails;
        }
        public static List<string> FetchCustomerDetails(string customerId)
        {

            List<string> customerDetails = new List<string>();
            if (isPresentCust(customerId))
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query1 = "Select * from Customer WHERE CustomerId = @custId ";
                SqlDataAdapter sdr1 = new SqlDataAdapter(query1, connection);
                sdr1.SelectCommand.Parameters.AddWithValue("@custId", customerId);
                // sdr1.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt1 = new DataTable();
                sdr1.Fill(dt1);
                foreach (DataRow row in dt1.Rows)
                {
                    if (row[0].ToString() == customerId)
                    {
                        customerDetails.Add(Convert.ToString(row[0]));// CustomerId
                        customerDetails.Add(Convert.ToString(row[1]));//FName
                        customerDetails.Add(Convert.ToString(row[2]));//MName
                        customerDetails.Add(Convert.ToString(row[3]));//LName
                        customerDetails.Add(Convert.ToString(row[4]));//Customer Address
                        customerDetails.Add(Convert.ToString(row[5]));//Customer Email
                        customerDetails.Add(Convert.ToString(row[6]));//Customer Phone
                        customerDetails.Add(Convert.ToString(row[7]));//Customer Branch Code
                        break;
                    }
                }
            }
            else
            {
                customerDetails.Add("Invalid Customer Id. Please type correct one");
            }

            return customerDetails;
        }
        public static ArrayList FetchAccountDetails(string CusID, string acctype)
        {
            ArrayList AccountDetails = new ArrayList();
            if (isPresentCust(CusID))
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (acctype.Equals("Savings", StringComparison.OrdinalIgnoreCase))
                {
                    string query1 = "Select * from Savings WHERE CustomerId=@custID";
                    SqlDataAdapter sdr1 = new SqlDataAdapter(query1, connection);
                    sdr1.SelectCommand.Parameters.AddWithValue("@custId", CusID);
                    //sdr1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt1 = new DataTable();
                    sdr1.Fill(dt1);
                    foreach (DataRow row in dt1.Rows)
                    {
                        if (row[0].ToString() == CusID)
                        {
                            AccountDetails.Add(row[0]);// Customer ID
                            AccountDetails.Add(row[1]);//Account Number
                            AccountDetails.Add(row[2]);//Account Date
                            AccountDetails.Add(row[3]);//Interest Rate
                            AccountDetails.Add(row[4]);//Initial Deposit Amount
                            AccountDetails.Add(row[5]);//Balance

                            break;
                        }
                    }
                }
                else if (acctype.Equals("Checking", StringComparison.OrdinalIgnoreCase))
                {
                    string query1 = "Select * from Checking WHERE CustomerId=@custId";
                    SqlDataAdapter sdr1 = new SqlDataAdapter(query1, connection);
                    sdr1.SelectCommand.Parameters.AddWithValue("@custId", CusID);
                    // sdr1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt1 = new DataTable();
                    sdr1.Fill(dt1);
                    foreach (DataRow row in dt1.Rows)
                    {
                        if (row[0].ToString() == CusID)
                        {
                            AccountDetails.Add(row[0]);// Customer ID
                            AccountDetails.Add(row[1]);//Account Number
                            AccountDetails.Add(row[2]);//Account Date
                            AccountDetails.Add(row[3]);//Service Charge
                            AccountDetails.Add(row[4]);//Initial Deposit Amount
                            AccountDetails.Add(row[5]);//Balance

                            break;
                        }
                    }

                }
                else
                {
                    string finalresults = "Invalid Input.Please Input Savings or Checking";
                    AccountDetails.Add(finalresults);
                }


            }
            else
            {
                AccountDetails.Add("Wrong Customer Id, Please provide a correct one");
            }


            return AccountDetails;
        }
        public static ArrayList FetchTransactionDetails(string cusID)
        {
            ArrayList TransactDetails = new ArrayList();
            try
            {
                if (isPresentCust(cusID))
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    string query1 = "Select * from Transactions WHERE CustomerId=@custId";
                    SqlDataAdapter sdr1 = new SqlDataAdapter(query1, connection);
                    sdr1.SelectCommand.Parameters.AddWithValue("@custId", cusID);
                    //sdr1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt1 = new DataTable();
                    sdr1.Fill(dt1);
                    foreach (DataRow row in dt1.Rows)
                    {
                        if (row[0].ToString() == cusID)
                        {
                            TransactDetails.Add(row[0]);// Customer ID
                            TransactDetails.Add(row[1]);//Transaction ID
                            TransactDetails.Add(row[2]);//Transaction Date
                            TransactDetails.Add(row[3]);//Transaction Amount

                            break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string except = ex.Message;
                TransactDetails.Add(except);

            }
            return TransactDetails;
        }

        //Checking for customer ID presence

        public static bool iSPresentCustIDSav(string custID)
        {
            bool Present = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Savings ";
            SqlDataAdapter sdr = new SqlDataAdapter(query, connection);
            //sdr.Parameters.AddWithValue("@finalbalance", Balance);
            // sdr.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString() == custID)
                {
                    Present = true;
                    break;
                }
            }
            return Present;
        }
        public static bool iSPresentCustIDChk(string custID)
        {
            bool Present = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Checking ";
            SqlDataAdapter sdr = new SqlDataAdapter(query, connection);
            //sdr.Parameters.AddWithValue("@finalbalance", Balance);
            // sdr.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString() == custID)
                {
                    Present = true;
                    break;
                }
            }
            return Present;
        }
        public static double fetchSavingsBal(string custId)
        {
            double savingsbal = 0.0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query1 = "Select * from Savings WHERE CustomerId = @custId ";
            SqlDataAdapter sdr1 = new SqlDataAdapter(query1, connection);
            sdr1.SelectCommand.Parameters.AddWithValue("@custId", custId);
            DataTable dt1 = new DataTable();
            sdr1.Fill(dt1);
            foreach (DataRow row in dt1.Rows)
            {
                if (row[0].ToString() == custId)
                {
                    savingsbal = Convert.ToDouble(row[5]);
                    
                    break;
                }
            }
            return savingsbal;

        }
        public static double fetchCheckingsBal(string custId)
        {
            double checkingbal = 0.0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query1 = "Select * from Checking WHERE CustomerId = @custId ";
            SqlDataAdapter sdr1 = new SqlDataAdapter(query1, connection);
            sdr1.SelectCommand.Parameters.AddWithValue("@custId", custId);
            DataTable dt1 = new DataTable();
            sdr1.Fill(dt1);
            foreach (DataRow row in dt1.Rows)
            {
                if (row[0].ToString() == custId)
                {
                    checkingbal = Convert.ToDouble(row[5]);

                    break;
                }
            }
            return checkingbal;

        }


    }
}
