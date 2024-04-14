using System.Data;
using System.Data.SqlClient;

namespace HotelManagmentSystem
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            Populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=ACER;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=False");

        private void InsertCustomers()
        {
            if (CnameTb.Text == "" || GenderCb.SelectedIndex == -1 || CPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTbl(CustName, CustPhone, CustGender) values(@CustN, @CustP, @CustG)", Con);
                    cmd.Parameters.AddWithValue("@CustN", CnameTb.Text);
                    cmd.Parameters.AddWithValue("@CustP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CustG", GenderCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added");
                    Con.Close();
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    Con.Close();
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        private void EditCustomers()
        {
            if (CId.Text == "" || CnameTb.Text == "" || GenderCb.SelectedIndex == -1 || CPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update CustomerTbl set CustName=@CustN, CustPhone=@CustP, CustGender=@CustG where CustNum=@CustNum", Con);
                    cmd.Parameters.AddWithValue("@CustN", CnameTb.Text);
                    cmd.Parameters.AddWithValue("@CustP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CustG", GenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CustNum", int.Parse(CId.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated");
                    Con.Close();
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    Con.Close();
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        private void DeleteCustomers()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from CustomerTbl where CustNum=@CustNum", Con);
                cmd.Parameters.AddWithValue("@CustNum", int.Parse(CId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Deleted");
                Con.Close();
                Populate();
            }
            catch
            {
                MessageBox.Show("Select a Customer!!!");
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void Populate()
        {
            try
            {
                Con.Open();
                string Query = "select * from CustomerTbl";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                CustomerDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditCustomers();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertCustomers();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCustomers();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Types types = new Types();
            types.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Bookings bookings = new Bookings();
            bookings.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
