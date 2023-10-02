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
namespace Hastane_Otomasyon
{
    public partial class FrmDoctorPanel : Form
    {
        public FrmDoctorPanel()
        {
            InitializeComponent();
        }
        //CONNECTION 
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmDoctorPanel_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Tbl_Doktorlar ", bgl.conn());
            da2.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Tbl_Doktorlar (doktor_ad,doktor_soyad,doktor_brans,doktor_tc,doktor_sifre) VALUES (@p1,@p2,@p3,@p4,@p5)";
            SqlCommand command = new SqlCommand(query, bgl.conn());
            command.Parameters.AddWithValue("@p1",TxtName.Text);
            command.Parameters.AddWithValue("@p2",TxtSurname.Text);
            command.Parameters.AddWithValue("@p3",CmbBranch.Text);
            command.Parameters.AddWithValue("@p4",MskdNumberTc.Text);
            command.Parameters.AddWithValue("@p5",TxtPassword.Text);
            command.ExecuteNonQuery();
            bgl.conn().Close();
            MessageBox.Show("Doctor Added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int temp = dataGridView1.SelectedCells[0].RowIndex;
            TxtName.Text = dataGridView1.Rows[temp].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[temp].Cells[2].Value.ToString();
            CmbBranch.Text = dataGridView1.Rows[temp].Cells[3].Value.ToString();
            MskdNumberTc.Text = dataGridView1.Rows[temp].Cells[4].Value.ToString();
            TxtPassword.Text = dataGridView1.Rows[temp].Cells[5].Value.ToString();
        }
    }
}
