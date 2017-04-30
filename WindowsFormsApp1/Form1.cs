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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Helvi\Documents\DATAENTRY.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Helvi\Documents\DATAENTRY.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* con.Open();
             SqlCommand cmd = con.CreateCommand();
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "insert into Registration values ('"+textBox1.Text+ "','" + textBox2.Text + "','" +comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox5.Text + "')";
             cmd.ExecuteNonQuery();
             con.Close();
                 MessageBox.Show("Saved Successfully");*/

            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("insert into Registration values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox5.Text + "')",con);
            sd.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved Successfully");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select * from Registration", con);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            sd.SelectCommand.ExecuteNonQuery();
            con.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select * from Registration",con);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            sd.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Displayed Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("Update  Registration set Name='" + textBox2.Text + "', Gender='" +comboBox1.Text + "',Age= '" + textBox5.Text + "', Salary='" + textBox6.Text + "',Tax= '" + textBox6.Text +"' where Id='"+textBox1.Text+"'",con);
            sd.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("Delete from Registration where Id='"+textBox1.Text+"'",con);
            sd.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
  
    }

