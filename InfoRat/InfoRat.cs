using InfoRat.InfoRatClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoRat
{
    public partial class InfoRat : Form
    {
        public InfoRat()
        {
            InitializeComponent();
        }
        ContactClass Co = new ContactClass();
        private void InfoRat_Load(object sender, EventArgs e)
        {
            DataTable dt = Co.Select();
            dgvContactList.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Co.FirstName = textBoxFirstName.Text;
            Co.LastName = textBoxLastName.Text;
            Co.Contact = textBoxContact.Text;
            bool success = Co.Insert(Co);
            if (success == true)
            {
                MessageBox.Show("new cont created ");
                Clear();
            }
            else
            {
                MessageBox.Show("new cont not created ");
            }
            DataTable dt = Co.Select();
            dgvContactList.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            textBoxFirstName.Text=" ";
            textBoxLastName.Text=" ";
            textBoxContact.Text=" ";
            textBoxID.Text=" ";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Co.FirstName = textBoxFirstName.Text;
            Co.LastName = textBoxLastName.Text;
            Co.Contact = textBoxContact.Text;
            Co.ID= int .Parse(textBoxID.Text);
            bool success = Co.Update(Co);
            if (success == true)
            {
                MessageBox.Show("cont updated");
                Clear();
            }
            else
            {
                MessageBox.Show("cont not updated");
            }
            DataTable dt = Co.Select();
            dgvContactList.DataSource = dt;
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBoxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxLastName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxContact.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxID.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Co.FirstName = textBoxFirstName.Text;
            Co.LastName = textBoxLastName.Text;
            Co.Contact = textBoxContact.Text;
            Co.ID = int.Parse(textBoxID.Text);
            bool success = Co.Delete(Co);
            if (success == true)
            {
                MessageBox.Show("cont deleted");
                Clear();
            }
            else
            {
                MessageBox.Show("cont not deleted");
            }
            DataTable dt = Co.Select();
            dgvContactList.DataSource = dt; 
        }
        static string myconnstr= ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            SqlConnection conn= new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Table_Details WHERE FirstName LIKE '%"+keyword+ "%' OR LastName LIKE '%"+keyword+ "%' ",conn);
            DataTable dt= new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource= dt;
        }
    }
}
