using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

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
                IncomeByCustomerLbl.Text = "$  " + dt.Rows[0][0].ToString();
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

        private void LinkedInLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "https://www.linkedin.com/in/eaxusniddinovich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void EmailLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "mailto:eaxusniddinovich@gmail.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void TelegramLinkUser()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "https://t.me/eaxusniddinovich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void GitHubLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "https://github.com/AbbosErgashev");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void GitLab()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "https://gitlab.com/eaxusniddinovich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void InstagramLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "https://www.instagram.com/eaxusniddinovich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void FacebookLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "https://www.facebook.com/eaxusniddinovich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void VKLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "https://vk.com/eaxusniddinovich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void YouTubeChannelLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "https://youtube.com/@eaxusniddinovich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void MailRuLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "mailto:eaxusniddinovich@mail.ru");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }

        private void XMailRuLink()
        {
            try
            {
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, "mailto:eaxusniddinovich@xmail.ru");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkedInLink();
        }

        private void EmailLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EmailLink();
        }

        private void TelegramLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TelegramLinkUser();
        }

        private void GitHubLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GitHubLink();
        }

        private void GitLabLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GitLab();
        }

        private void InstagramLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InstagramLink();
        }

        private void FacebookLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FacebookLink();
        }

        private void VKLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VKLink();
        }

        private void YouTubeChannelLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            YouTubeChannelLink();
        }

        private void MailRuLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MailRuLink();
        }

        private void XMailRuLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XMailRuLink();
        }
    }
}
