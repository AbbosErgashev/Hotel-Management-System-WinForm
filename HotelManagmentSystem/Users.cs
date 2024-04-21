using System.Data;
using System.Data.SqlClient;

namespace HotelManagmentSystem
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            Populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=ACER;Initial Catalog=HotelDB;Integrated Security=True;Encrypt=False");

        private void InsertUsers()
        {
            if (UnameTb.Text == "" || GenderCb.SelectedIndex == -1 || UphoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl(UName, UPhone, UGender, UPassword) values(@UN, @UPh, @UG, @UP)", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UPh", UphoneTb.Text);
                    cmd.Parameters.AddWithValue("@UG", GenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UP", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added");
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

        private void EditUsers()
        {
            if (UnameTb.Text == "" || GenderCb.SelectedIndex == -1 || UphoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update UserTbl set UName=@UN, UPhone=@UPh, UGender=@UG, UPassword=@UP where UNum=@UNum", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UPh", UphoneTb.Text);
                    cmd.Parameters.AddWithValue("@UG", GenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UP", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@UNum", int.Parse(UId.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated");
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

        private void DeleteUsers()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from UserTbl where UNum = @UNum", Con);
                cmd.Parameters.AddWithValue("@Unum", int.Parse(UId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Deleted");
                Con.Close();
                Populate();
            }
            catch
            {
                MessageBox.Show("Select a User!!!");
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
                string Query = "select * from UserTbl";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                UserDGV.DataSource = ds.Tables[0];
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

        private void ClearUsers()
        {
            UId.Text = "";
            UnameTb.Text = "";
            PasswordTb.Text = "";
            UphoneTb.Text = "";
            GenderCb.SelectedIndex = -1;
            GenderCb.Text = "Gender";
        }

        private void IdSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from UserTbl where UNum LIKE '%" + IdSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            UserDGV.DataSource = dt;
            Con.Close();
        }

        private void NameSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from UserTbl where UName LIKE '%" + NameSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            UserDGV.DataSource = dt;
            Con.Close();
        }

        private void PhoneSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from UserTbl where UPhone LIKE '%" + PhoneSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            UserDGV.DataSource = dt;
            Con.Close();
        }

        private void PasswordSearch()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from UserTbl where UPassword LIKE '%" + PasswordSearchTbl.Text + "%'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            UserDGV.DataSource = dt;
            Con.Close();
        }

        private void GenderSearchUser()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();

            SqlCommand cmd = new SqlCommand("select * from UserTbl where UGender='" + GenderSearchCb.Text.ToString() + "'", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            var dt = new DataSet();
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            UserDGV.DataSource = dt.Tables[0];
            Con.Close();
        }

        private void ResetFilter()
        {
            IdSearchTbl.Text = "";
            NameSearchTbl.Text = "";
            PhoneSearchTbl.Text = "";
            PasswordSearchTbl.Text = "";
            GenderSearchCb.SelectedIndex = -1;
            GenderSearchCb.Text = "Gender";
            Populate();
            Con.Close();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditUsers();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertUsers();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteUsers();
        }

        private void panelLogOut_MouseClick(object sender, MouseEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
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

        private void label12_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
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

        private void label2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearUsers();
        }

        private void IdSearchTbl_TextChanged(object sender, EventArgs e)
        {
            IdSearch();
        }

        private void NameSearchTbl_TextChanged(object sender, EventArgs e)
        {
            NameSearch();
        }

        private void PhoneSearchTbl_TextChanged(object sender, EventArgs e)
        {
            PhoneSearch();
        }

        private void PasswordSearchTbl_TextChanged(object sender, EventArgs e)
        {
            PasswordSearch();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetFilter();
        }

        private void GenderSearchCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenderSearchUser();
        }
    }
}
