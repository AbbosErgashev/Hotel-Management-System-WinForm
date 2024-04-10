using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace HotelManagmentSystem
{
    public partial class Types : Form
    {
        public Types()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=ACER;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=False");
        private void InsertCategories()
        {
            if (TypeNameTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TypeTbl(TypeName, TypeCost) values(@TN, @TC)", Con);
                    cmd.Parameters.AddWithValue("@TN", TypeNameTb.Text);
                    cmd.Parameters.AddWithValue(@"TC", CostTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categories Added");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void populate()
        {
            Con.Open();
            string Query = "select * from TypeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TypesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertCategories();
        }
        int Key = 0;
        private void TypesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TypeNameTb.Text = TypesDGV.SelectedRows[0].Cells[1].Value.ToString();
            CostTb.Text = TypesDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (TypesDGV.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TypesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
