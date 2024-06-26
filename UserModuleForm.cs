using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace inventory_management_system
{
    public partial class UserModuleForm : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=VPL;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        public UserModuleForm()
        {
            InitializeComponent();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            try

            {
                if (MessageBox.Show(" Are you sure you want to save this record?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ){

                    cn = new SqlCommand("INSERT INTO tbuser1(username,fullname,password,phone) VALUES(@username,@fullname,@password,@phone) ", con);
                    cn.Parameters.AddWithValue("@username", txtUserName.Text);
                    cn.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cn.Parameters.AddWithValue("@password", txtPass.Text);
                    cn.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cn.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully saved");
                    Clear();
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


        }




      


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        public void Clear()
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPass.Clear();
            txtPhone.Clear();


        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try

            {
                if (MessageBox.Show(" Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cn = new SqlCommand("UPDATE tbuser1 SET fullname = @fullname, password=@password, phone=@phone WHERE username LIKE '" + txtUserName.Text + "' ", con);
                    cn.Parameters.AddWithValue("@username", txtUserName.Text);
                    cn.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cn.Parameters.AddWithValue("@password", txtPass.Text);
                    cn.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cn.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully updated");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
