using System.Data;
using System.Data.SqlClient;

namespace HotelManagmentSystem
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
            Populate();
            GetCategories();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=ACER;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=False");

        private void InsertRooms()
        {
            if (RnameTb.Text == "" || RTypeCb.SelectedIndex == -1 || StatusTb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into RoomTbl(RName, RType, RStatus) values(@RN, @RT, @RS)", Con);
                    cmd.Parameters.AddWithValue("@RN", RnameTb.Text);
                    cmd.Parameters.AddWithValue("@RT", RTypeCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@RS", StatusTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Added");
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

        private void EditRooms()
        {
            if (RnameTb.Text == "" || RTypeCb.SelectedIndex == -1 || StatusTb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update RoomTbl set RName=@RN, RType=@RT, RStatus=@RS where RNum=@Rnum", Con);
                    cmd.Parameters.AddWithValue("@RN", RnameTb.Text);
                    cmd.Parameters.AddWithValue("@RT", RTypeCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@RS", StatusTb.Text);
                    cmd.Parameters.AddWithValue("@Rnum", int.Parse(RId.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Updated");
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

        private void DeleteRooms()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from RoomTbl where Rnum = @Rnum", Con);
                cmd.Parameters.AddWithValue("@Rnum", int.Parse(RId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Deleted");
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

        private void ClearRooms()
        {
            RId.Text = "";
            RnameTb.Text = "";
            RTypeCb.SelectedIndex = -1;
            StatusTb.Text = "Status";
        }

        private void Populate()
        {
            try
            {
                Con.Open();
                string Query = "select * from RoomTbl";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                RoomsDGV.DataSource = ds.Tables[0];
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

        private void GetCategories()
        {
            try
            {

                Con.Open();
                SqlCommand cmd = new SqlCommand("select * from TypeTbl", Con);
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("TypeNum", typeof(int));
                dt.Load(rdr);
                RTypeCb.ValueMember = "TypeNum";
                RTypeCb.DataSource = dt;
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

        private void IdSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select RNum, RName, RType, RStatus from RoomTbl where RNum LIKE '%" + IdSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            RoomsDGV.DataSource = dt;
            Con.Close();
        }

        private void NameSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select RNum, RName, RType, RStatus from RoomTbl where RName LIKE '%" + NameSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            RoomsDGV.DataSource = dt;
            Con.Close();
        }

        private void TypeSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select RNum, RName, RType, RStatus from RoomTbl where RType LIKE '%" + TypeSearchCb.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            RoomsDGV.DataSource = dt;
            Con.Close();
        }

        private void StatusSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select RNum, RName, RType, RStatus from RoomTbl where RStatus LIKE '%" + StatusSearchCb.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            RoomsDGV.DataSource = dt;
            Con.Close();
        }

        private void ResetRoomsFilter()
        {
            IdSearchTbl.Text = "";
            NameSearchTbl.Text = "";
            TypeSearchCb.SelectedIndex = -1;
            TypeSearchCb.Text = "";
            StatusSearchCb.SelectedIndex = -1;
            StatusSearchCb.Text = "Filter by Status";
            Populate();
            Con.Close();
        }

        private void FilterByType()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from RoomTbl where RType='" + TypeSearchCb.SelectedIndex + "'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            var dt = new DataSet();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            RoomsDGV.DataSource = dt.Tables[0];
            Con.Close();
        }

        private void FilterStatus()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from RoomTbl where RStatus='" + StatusSearchCb.SelectedIndex + "'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            var dt = new DataSet();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            RoomsDGV.DataSource = dt.Tables[0];
            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertRooms();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditRooms();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteRooms();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Types types = new Types();
            types.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Bookings bookings = new Bookings();
            bookings.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void IdSearchTbl_TextChanged(object sender, EventArgs e)
        {
            IdSearch();
        }

        private void NameSearchTbl_TextChanged(object sender, EventArgs e)
        {
            NameSearch();
        }

        private void TypeSearchTbl_TextChanged(object sender, EventArgs e)
        {
            TypeSearch();
        }

        private void StatusSearchTbl_TextChanged(object sender, EventArgs e)
        {
            StatusSearch();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearRooms();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetRoomsFilter();
        }

        private void TypeSearchCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByType();
        }

        private void StatusSearchCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStatus();
        }
    }
}