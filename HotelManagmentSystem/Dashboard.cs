using System.Data;
using System.Data.SqlClient;

namespace HotelManagmentSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountRooms();
            CountCustomers();
            SumAmount();
            GetCustomors();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=ACER;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=False");

        private void CountRooms()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from RoomTbl", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                RoomsLbl.Text = dt.Rows[0][0].ToString() + "  Rooms";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void CountCustomers()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CustomerTbl", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                CustomersLbl.Text = dt.Rows[0][0].ToString() + "  Customers";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void SumAmount()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select sum(Cost) from BookingTbl", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BookingsLbl.Text = "$  " + dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void SumDaily()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(Cost) FROM BookingTbl WHERE BookDate = @BookDate", Con);
                cmd.Parameters.AddWithValue("@BookDate", BDateTime.Value.Date);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    DailyIncomeLbl.Text = "$  " + result.ToString();
                }
                else
                {
                    DailyIncomeLbl.Text = "$  0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void SumByCustomer()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select sum(Cost) from BookingTbl where Customer=" + CustomerCb.SelectedValue.ToString() + "", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                IncomeByCustomerLbl.Text = "Rs  " + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void GetCustomors()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("select * from CustomerTbl", Con);
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("CustNum", typeof(int));
                dt.Load(rdr);
                CustomerCb.ValueMember = "CustNum";
                CustomerCb.DataSource = dt;
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void BDateTime_ValueChanged(object sender, EventArgs e)
        {
            SumDaily();
        }

        private void CustomerCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SumByCustomer();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Hide();
        }

        private void categoriesClick_Click(object sender, EventArgs e)
        {
            Types types = new Types();
            types.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Users types = new Users();
            types.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Customers types = new Customers();
            types.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Bookings types = new Bookings();
            types.Show();
            this.Hide();
        }

        private void panelLogOut_MouseClick(object sender, MouseEventArgs e)
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
