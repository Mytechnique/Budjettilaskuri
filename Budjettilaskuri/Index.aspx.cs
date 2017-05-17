﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            Budjetti b = new Budjetti
            {
                menot = Int32.Parse(txtMenot.Text),
                tulot = Int32.Parse(txtTulot.Text),
                veroprosentti = float.Parse(txtVeroProsentti.Text),
                date = datepickerInput.ToString()
            };
            string json = JsonConvert.SerializeObject(b, Formatting.Indented);
            lblTest.Text = json;
        }
      
        protected void btnNewBudget_Click(object sender, EventArgs e)
        {
            newBudgetFields.Visible = true;
            btnNewBudget.Visible = false;
        }

        protected void btnShowBudgets_Click(object sender, EventArgs e)
        {

        }
    }
}