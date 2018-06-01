using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaOrder
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void purchaseButton_Click(object sender, EventArgs e)
        {
            //Reset Total Label
            resultLabel.Text = "Total: $0.00";
            string specialDeal = "";
            double totalPrice = 0;


            //Check size value and add store to total
            switch (sizeList.SelectedIndex)
            {
                case 0:
                    {
                        totalPrice = 10;
                        break;
                    }
                case 1:
                    {
                        totalPrice = 13;
                        break;
                    }
                case 2:
                    {
                        totalPrice = 16;
                        break;
                    }
            }
            //check for crust options
            if (crustList.SelectedIndex == 1)
            {
                        totalPrice += 2;                                      
            }

            //Cycle through checkbox list and add the value to totalPrice
            for(int i = 0; i<toppingCheckList.Items.Count; i++)
            {
                if (toppingCheckList.Items[i].Selected == true){
                    totalPrice = totalPrice + double.Parse(toppingCheckList.Items[i].Value);
                }
            }
            //Check for Special Deal Criteria
            if((toppingCheckList.Items[0].Selected == true &&
                toppingCheckList.Items[2].Selected == true &&
                toppingCheckList.Items[4].Selected == true) ||

                (toppingCheckList.Items[0].Selected == true &&
                toppingCheckList.Items[1].Selected == true &&
                toppingCheckList.Items[3].Selected == true))
                {
                totalPrice -= 2;
               specialDeal = " $2 Discount for Papa bob's Deal";

            }

            resultLabel.Text = ("Total: " + totalPrice.ToString() + specialDeal);
        }
    }
}