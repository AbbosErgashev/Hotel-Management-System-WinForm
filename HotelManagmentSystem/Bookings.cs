using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

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
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from RoomTbl where RStatus='Aviable'", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RNum", typeof(int));
            dt.Load(rdr);
            RoomCb.ValueMember = "RNum";
            RoomCb.DataSource = dt;
            Con.Close();
        }

        private void GetCustomors()
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

        private void FetchCost()
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
            Con.Close();
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
            }
        }

        private void Populate()
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

        private void DeleteBookings()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from BookingTbl where BookNum = @BookNum", Con);
                cmd.Parameters.AddWithValue("@BookNum", int.Parse(BId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Booking Cancelled");
                Con.Close();
                Populate();
            }
            catch
            {
                MessageBox.Show("Select a Room!!!");
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
                MessageBox.Show("Room Booked");
                Con.Close();
                Populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                catch
                {

                }
            }
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
    }
}
