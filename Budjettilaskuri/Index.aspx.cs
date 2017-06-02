using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Xml;

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

            //Checking if any of the fields are null
            if(txtExpenses.Text == "" || txtIncome.Text == "" || txtTaxPercent.Text == "" || datepickerInput.Value.ToString() == "")
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

                XmlElement TaxPercent = xdoc.CreateElement("TaxPercent");
                XmlText xmlTaxPercent = xdoc.CreateTextNode(txtTaxPercent.Text);

                XmlElement Date = xdoc.CreateElement("Date");
                XmlText xmlDate = xdoc.CreateTextNode(datepickerInput.Value.ToString());

                //Telling each Element what is their text like as under

                Expenses.AppendChild(xmlExpenses);
                Income.AppendChild(xmlIncome);
                TaxPercent.AppendChild(xmlTaxPercent);
                Date.AppendChild(xmlDate);

                //Appending this to Budget Element

                Budget.AppendChild(Expenses);
                Budget.AppendChild(Income);
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
                xtw.WriteElementString("TaxPercent", txtTaxPercent.Text);
                xtw.WriteElementString("Date", datepickerInput.Value.ToString());

                //Closing Budgets and Budget elements
                xtw.WriteEndElement();
                xtw.WriteEndElement();
                xtw.WriteEndDocument();

                //Close stream after completed
                xtw.Close();
            }

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
        }

        protected void btnShowBudgets_Click(object sender, EventArgs e)
        {
            GetAllBudgets();
            gvBudgets.Visible = true;
            btnNewBudget.Visible = true;
            newBudgetFields.Visible = false;
        }
    }
}