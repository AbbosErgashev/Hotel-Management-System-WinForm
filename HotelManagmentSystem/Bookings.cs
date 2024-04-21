using System.Data;
using System.Data.SqlClient;

namespace HotelManagmentSystem
{
    public partial class Bookings : Form
    {
        public Bookings()
        {
            InitializeComponent();
            Populate();
            GetRooms();
            GetCustomors();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=ACER;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=False");
        int Price = 1;

        private void GetRooms()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("select * from RoomTbl where RStatus='Aviable'", Con);
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("RNum", typeof(int));
                dt.Load(rdr);
                RoomCb.ValueMember = "RNum";
                RoomCb.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void DeleteBookings()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from BookingTbl where BookNum = @BookNum", Con);
                cmd.Parameters.AddWithValue("@BookNum", int.Parse(BId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Booking Removed");
                Con.Close();
                Populate();
            }
            catch
            {
                MessageBox.Show("Select a Room!!!");
                Con.Close();
            }
            finally
            {
                Con.Close();
            }
        }

        private void SetBooked()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update RoomTbl set RStatus=@RS where RNum=@RNum", Con);
                cmd.Parameters.AddWithValue("@RS", "Booked");
                cmd.Parameters.AddWithValue("@RNum", RoomCb.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                Con.Close();
                Populate();
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

        private void SetAviable()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update RoomTbl set RStatus=@RS where RNum=@RoomNum", Con);
                cmd.Parameters.AddWithValue("@RS", "Aviable");
                cmd.Parameters.AddWithValue("@RoomNum", RoomCb.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Updated");
                Con.Close();
                Populate();
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

        private void FetchCost()
        {
            try
            {
                Con.Open();
                string query = "select TypeCost from RoomTbl join TypeTbl on RType=TypeNum where RNum=" + RoomCb.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Price = Convert.ToInt32(dr["TypeCost"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void BookBtn_Click(object sender, EventArgs e)
        {
            if (CustomerCb.SelectedIndex == -1 || RoomCb.SelectedIndex == -1 || AmountTb.Text == "" || DurationTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BookingTbl(Room, Customer, BookDate, Duration, Cost) values(@R, @C, @BD, @Dura, @Cost)", Con);
                    cmd.Parameters.AddWithValue("@R", RoomCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@C", CustomerCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BD", BDateTime.Value.Date);
                    cmd.Parameters.AddWithValue("@Dura", DurationTb.Text);
                    cmd.Parameters.AddWithValue("@Cost", AmountTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Booked");
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

        private void Populate()
        {
            try
            {
                Con.Open();
                string Query = "select * from BookingTbl";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                BookingDGV.DataSource = ds.Tables[0];
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

        private void DurationCb_TextChanged(object sender, EventArgs e)
        {
            if (AmountTb.Text == "")
            {
                AmountTb.Text = "0";
            }
            else
            {
                try
                {
                    int total = Price * Convert.ToInt32(DurationTb.Text);
                    AmountTb.Text = "" + total;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ClearBooking()
        {
            BId.Text = "";
            RoomCb.SelectedIndex = -1;
            CustomerCb.SelectedIndex = -1;
            DurationTb.Text = "";
            AmountTb.Text = "";
        }

        private void BookNumberSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from BookingTbl where BookNum LIKE '%" + BNumSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            BookingDGV.DataSource = dt;
            Con.Close();
        }

        private void RoomNumberSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from BookingTbl where Room LIKE '%" + RNumSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            BookingDGV.DataSource = dt;
            Con.Close();
        }

        private void CustomerNumberSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from BookingTbl where Customer LIKE '%" + CNumSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            BookingDGV.DataSource = dt;
            Con.Close();
        }

        private void DurationSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from BookingTbl where Duration LIKE '%" + DurationSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            BookingDGV.DataSource = dt;
            Con.Close();
        }

        private void CostRoom()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from BookingTbl where Cost LIKE '%" + CostSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            BookingDGV.DataSource = dt;
            Con.Close();
        }

        private void ResetBooking()
        {
            BNumSearchTbl.Text = "";
            CNumSearchTbl.Text = "";
            RNumSearchTbl.Text = "";
            DurationSearchTbl.Text = "";
            CostSearchTbl.Text = "";
            Populate();
            Con.Close();
        }

        private void BookDateTimeSearchBooking()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM BookingTbl WHERE BookDate = @BookDate", Con);
            cmd.Parameters.AddWithValue("@BookDate", BookDateTimeSearch.Value.Date);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            BookingDGV.DataSource = dt;
            Con.Close();
        }


        private void RoomCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FetchCost();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DeleteBookings();
            SetAviable();
            SetBooked();
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

        private void label12_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearBooking();
        }

        private void BNumSearchTbl_TextChanged(object sender, EventArgs e)
        {
            BookNumberSearch();
        }

        private void RNumSearchTbl_TextChanged(object sender, EventArgs e)
        {
            RoomNumberSearch();
        }

        private void CNumSearchTbl_TextChanged(object sender, EventArgs e)
        {
            CustomerNumberSearch();
        }

        private void DurationSearchTbl_TextChanged(object sender, EventArgs e)
        {
            DurationSearch();
        }

        private void CostSearchTbl_TextChanged(object sender, EventArgs e)
        {
            CostRoom();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetBooking();
        }

        private void BookDateTimeSearch_ValueChanged(object sender, EventArgs e)
        {
            BookDateTimeSearchBooking();
        }
    }
}
