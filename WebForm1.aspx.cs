using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Ticket_booking
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-LKPCK8O\SQLEXPRESS;Initial Catalog=vaibhav;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            DropDownList1.Enabled=true;
            DropDownList2.Enabled = true;
            Button3.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;

            Random r = new Random();
            int num = r.Next();
            TextBox1.Text = num.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != DropDownList2.SelectedValue)
            {
                string s = "insert into Ticket_booking values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList1.SelectedValue + "','" + DropDownList2.SelectedValue + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')";

                cn.Open();
                SqlCommand cmd = new SqlCommand(s, cn);
                cmd.ExecuteNonQuery();

                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                cn.Close();
            }
            else
            {
                Response.Write("Please select valid data");
            }
           

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = "select * from Ticket_booking where PNR_Number=" + TextBox1.Text;
           // SqlConnection cn = new SqlConnection(@"Data Source = DESKTOP - LKPCK8O\SQLEXPRESS; Initial Catalog = vaibhav; Integrated Security = True"); //1764492596
            SqlDataAdapter da = new SqlDataAdapter(s,cn);
            DataSet ds=new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}