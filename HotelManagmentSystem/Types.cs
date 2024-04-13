using System.Data;
using System.Data.SqlClient;

namespace HotelManagmentSystem
{
    public partial class Types : Form
    {
        public Types()
        {
            InitializeComponent();
            Populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=ACER;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=False");

        private void Populate()
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
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditCategories()
        {
            if (TId.Text == "" || TypeNameTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update TypeTbl set TypeName=@TN, TypeCost=@TC where TypeNum=@TypeNum", Con);
                    cmd.Parameters.AddWithValue("@TN", TypeNameTb.Text);
                    cmd.Parameters.AddWithValue(@"TC", CostTb.Text);
                    cmd.Parameters.AddWithValue(@"TypeNum", int.Parse(TId.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Updated");
                    Con.Close();
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteCategories()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from TypeTbl where TypeNum=@TypeNum", Con);
                cmd.Parameters.AddWithValue("@TypeNum", int.Parse(TId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Deleted");
                Con.Close();
                Populate();
            }
            catch
            {
                MessageBox.Show("Select a Category!!!");
                Con.Close();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertCategories();
        }

        private void EditBtn_Click_1(object sender, EventArgs e)
        {
            EditCategories();
        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            DeleteCategories();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Rooms obj = new Rooms();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bookings bookings = new Bookings();
            bookings.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
