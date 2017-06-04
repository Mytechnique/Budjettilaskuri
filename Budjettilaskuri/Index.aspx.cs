using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace Budjettilaskuri
{
    public partial class Index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Only do these on the first time user comest to the page
            if (!Page.IsPostBack)
            {

                newBudgetFields.Visible = false;
               
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            string filename = Server.MapPath("~/App_Data/Budgets.xml");
            string MonthlyBal = CalculateBudget(txtIncome.Text, txtExpenses.Text).ToString();
            string Taxes = CalculatePaidTaxes(txtIncome.Text, txtTaxPercent.Text).ToString();

            //Checking if any of the fields are null
            if (txtExpenses.Text == "" || txtIncome.Text == "" || txtTaxPercent.Text == "" || datepickerInput.Value.ToString() == "")
            {
                //Return and don't do an xml entry with null fields
                return;
            }
            else if(File.Exists(filename) == true)
            {

                //Add New Record
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(Server.MapPath("~/App_Data/Budgets.xml"));

                XmlElement Budget = xdoc.CreateElement("Budget");

                XmlElement Expenses = xdoc.CreateElement("Expenses");
                XmlText xmlExpenses = xdoc.CreateTextNode(txtExpenses.Text);

                XmlElement Income = xdoc.CreateElement("Income");
                XmlText xmlIncome = xdoc.CreateTextNode(txtIncome.Text);

                XmlElement Balance = xdoc.CreateElement("Balance");
                XmlText xmlBalance = xdoc.CreateTextNode(MonthlyBal);

                XmlElement TaxesPaid = xdoc.CreateElement("TaxesPaid");
                XmlText xmlTaxesPaid = xdoc.CreateTextNode(Taxes);

                XmlElement TaxPercent = xdoc.CreateElement("TaxPercent");
                XmlText xmlTaxPercent = xdoc.CreateTextNode(txtTaxPercent.Text);

                XmlElement Date = xdoc.CreateElement("Date");
                XmlText xmlDate = xdoc.CreateTextNode(datepickerInput.Value.ToString());

                //Telling each Element what is their text like as under

                Expenses.AppendChild(xmlExpenses);
                Income.AppendChild(xmlIncome);
                Balance.AppendChild(xmlBalance);
                TaxesPaid.AppendChild(xmlTaxesPaid);
                TaxPercent.AppendChild(xmlTaxPercent);
                Date.AppendChild(xmlDate);

                //Appending this to Budget Element

                Budget.AppendChild(Expenses);
                Budget.AppendChild(Income);
                Budget.AppendChild(Balance);
                Budget.AppendChild(TaxesPaid);
                Budget.AppendChild(TaxPercent);
                Budget.AppendChild(Date);

                //Append the whole Budget to the xml file

                xdoc.DocumentElement.AppendChild(Budget);

                //Save file
                xdoc.Save(Server.MapPath("~/App_Data/Budgets.xml"));


            }
            else
            {
                //Create a New File and Structure
                XmlTextWriter xtw = new XmlTextWriter(filename, null);

                xtw.WriteStartDocument();

                xtw.WriteStartElement("Budgets");
                xtw.WriteStartElement("Budget");

                //This Will Create a Element and Close that Element
                xtw.WriteElementString("Expenses", txtExpenses.Text);
                xtw.WriteElementString("Income", txtIncome.Text);
                xtw.WriteElementString("Balance", MonthlyBal);
                xtw.WriteElementString("TaxesPaid", Taxes);
                xtw.WriteElementString("TaxPercent", txtTaxPercent.Text);
                xtw.WriteElementString("Date", datepickerInput.Value.ToString());

                //Closing Budgets and Budget elements
                xtw.WriteEndElement();
                xtw.WriteEndElement();
                xtw.WriteEndDocument();

                //Close stream after completed
                xtw.Close();
            }

            lblSuccess.Visible = true;
        }

        private int SumExpenses()
        {
            var doc = XDocument.Load(Server.MapPath("~/App_Data/Budgets.xml"));
            var sum = (from nd in doc.Descendants("Expenses")
                       select Int32.Parse(nd.Value)).Sum();

            return sum;
        }
        private int SumBalances()
        {
            var doc = XDocument.Load(Server.MapPath("~/App_Data/Budgets.xml"));
            var sum = (from nd in doc.Descendants("Balance")
                       select Int32.Parse(nd.Value)).Sum();

            return sum;
        }

        private double GetYearlyPaidTaxes()
        {
            var doc = XDocument.Load(Server.MapPath("~/App_Data/Budgets.xml"));
            var sum = (from nd in doc.Descendants("TaxesPaid")
                       select Double.Parse(nd.Value)).Sum();

            return sum;
        }

        private int CalculateBudget(string a, string b)
        {
            int result =  int.Parse(a) - int.Parse(b);
            return result;
        }

        private double CalculatePaidTaxes(string a, string b)
        {
           double result = int.Parse(a) * (0.01 * int.Parse(b));
           return result;
        }

        private void GetAllBudgets()
        {
            DataSet ds = new System.Data.DataSet();
            ds.ReadXml(Server.MapPath("~/App_Data/Budgets.xml"));

            gvBudgets.DataSource = ds;
            gvBudgets.DataBind();
        }

        protected void btnNewBudget_Click(object sender, EventArgs e)
        {
            newBudgetFields.Visible = true;
            btnNewBudget.Visible = false;
            gvBudgets.Visible = false;
            lblSavingsAsp.Visible = false;
            lblTaxesAsp.Visible = false;
            lblSuccess.Visible = false;
        }

        protected void btnShowBudgets_Click(object sender, EventArgs e)
        {
            GetAllBudgets();
            gvBudgets.Visible = true;
            btnNewBudget.Visible = true;
            newBudgetFields.Visible = false;
            lblSavingsAsp.Visible = true;
            lblTaxesAsp.Visible = true;
            YearlySavings();
            TaxesPaid();
            lblSuccess.Visible = false;

        }

        private void YearlySavings() {
            if(SumBalances() <= 0)
            {
                lblSavingsAsp.Text = "Ei säästöjä, olet miinuksella budjetissasi " + SumBalances().ToString() + "€";
            }
            else
            {
                lblSavingsAsp.Text = "Olet säästänyt " + SumBalances().ToString() + "€";
            }
        }

        private void TaxesPaid() {
            if(GetYearlyPaidTaxes() <= 0)
            {
                lblTaxesAsp.Text = "Et ole maksanut tänä vuonna budjettisi mukaan yhtään veroja. Lisää budjettimerkintä!";
            }else{
                lblTaxesAsp.Text = "Olet maksanut veroja yhteensä " + GetYearlyPaidTaxes().ToString() + "€";
            }
        }
    }
}