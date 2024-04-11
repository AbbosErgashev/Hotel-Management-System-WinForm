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
                    cmd.Parameters.AddWithValue("@RT", RTypeCb.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@RS", StatusTb.SelectedItem.ToString());
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
                    cmd.Parameters.AddWithValue("@RT", RTypeCb.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@RS", StatusTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Rnum", int.Parse(RId.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Updated");
                    Con.Close();
                    Populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void DeleteRooms()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete  from RoomTbl where Rnum = @Rnum", Con);
                cmd.Parameters.AddWithValue("@Rnum", int.Parse(RId.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Deleted");
                Con.Close();
                Populate();
            }
            catch
            {
                MessageBox.Show("Please. Select a Room!!!");
                Con.Close();
            }
        }

        private void Populate()
        {
            Con.Open();
            string Query = "select * from RoomTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            RoomsDGV.DataSource = ds.Tables[0];
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

        private void RoomsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RId.Text = RoomsDGV.SelectedRows[0].Cells[0].Value.ToString();
            RnameTb.Text = RoomsDGV.SelectedRows[0].Cells[1].Value.ToString();
            RTypeCb.Text = RoomsDGV.SelectedRows[0].Cells[2].Value.ToString();
            StatusTb.Text = RoomsDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (RId.Text == "")
            {
                RId.Text = "here value is null";
            }
            else
            {
                RId.Text = Convert.ToInt32(RoomsDGV.SelectedRows[0].Cells[0].Value).ToString();
            }
        }
    }
}