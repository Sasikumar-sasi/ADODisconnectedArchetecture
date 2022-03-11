using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DisconnectedArchetecture
{
    public partial class StudentInfo : Form
    {
        public StudentInfo()
        {
            InitializeComponent();
        }
        string ConnectionStr = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        private void StudentInfo_Load(object sender, EventArgs e)
        {
            ShowStudentInformation();
        }
        private void ShowStudentInformation()
        {
            SqlConnection con = new SqlConnection(ConnectionStr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from Student",con);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds, "StudentDetails");
            dataGridView1.DataSource = ds.Tables["StudentDetails"].DefaultView;
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            con.Close();

        }
    }
}
