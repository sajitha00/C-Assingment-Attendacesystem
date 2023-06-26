using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;


namespace C_Assingment
{
    public partial class dashboard : Form
    {




        public dashboard()
        {
            InitializeComponent();
        }


        private void bunifuButton4_Click(object sender, EventArgs e)
        {
           
            var lineNumber = 0;
            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Yasiru Perera\\Desktop\\New folder (3)\\C#Assingment\\C#Assingment\\DB\\Attendance_system.mdf\";Integrated Security=True;Connect Timeout=30"))
            {

                conn.Open();

                using (StreamReader reader = new StreamReader(@"C:\Users\Yasiru Perera\Desktop\C#Assingment\version 9\C#Assingment\python\Attendance.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (lineNumber != 0)
                        { 
                        var values = line.Split(',');
                        var sql = "INSERT INTO marked values('"+ values[0] + "' , '"+ values[1] + "' , '"+ values[2] +"')";
                        var cmd = new SqlCommand();
                        cmd.CommandText = sql;
                        cmd.CommandType  = System.Data.CommandType.Text;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        }
                        lineNumber++;

                    }
                }
                conn.Close();

                using (SqlConnection conn2 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Yasiru Perera\\Desktop\\New folder (3)\\C#Assingment\\C#Assingment\\DB\\Attendance_system.mdf\";Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();

                    // Construct the SQL query to retrieve the updated data
                    string sql = "SELECT * FROM marked";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn2);

                    // Create a new DataTable to hold the updated data
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the results of the SQL query
                    adapter.Fill(dataTable);

                    conn2.Close();

                    // Set the DataSource property of the DataGridView to the DataTable
                    bunifuDataGridView1.DataSource = dataTable;

                    // Refresh the view of the DataGridView
                    bunifuDataGridView1.Refresh();
                }




            }
            bunifuPages1.SetPage("marked");
          
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("dasboard");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("add");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("marking");
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("update");
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("about");
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("add");
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("marking");
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            var lineNumber = 0;
            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Yasiru Perera\\Desktop\\New folder (3)\\C#Assingment\\C#Assingment\\DB\\Attendance_system.mdf\";Integrated Security=True;Connect Timeout=30"))
            {

                conn.Open();

                using (StreamReader reader = new StreamReader(@"C:\Users\Yasiru Perera\Desktop\C#Assingment\version 9\C#Assingment\python\Attendance.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (lineNumber != 0)
                        {
                            var values = line.Split(',');
                            var sql = "INSERT INTO marked values('" + values[0] + "' , '" + values[1] + "' , '" + values[2] + "')";
                            var cmd = new SqlCommand();
                            cmd.CommandText = sql;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;

                    }
                }
                conn.Close();

                using (SqlConnection conn2 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Yasiru Perera\\Desktop\\New folder (3)\\C#Assingment\\C#Assingment\\DB\\Attendance_system.mdf\";Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();

                    // Construct the SQL query to retrieve the updated data
                    string sql = "SELECT * FROM marked";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn2);

                    // Create a new DataTable to hold the updated data
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the results of the SQL query
                    adapter.Fill(dataTable);

                    conn2.Close();

                    // Set the DataSource property of the DataGridView to the DataTable
                    bunifuDataGridView1.DataSource = dataTable;

                    // Refresh the view of the DataGridView
                    bunifuDataGridView1.Refresh();
                }




            }
            bunifuPages1.SetPage("marked");
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("update");
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("about");
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Yasiru Perera\\Desktop\\New folder (3)\\C#Assingment\\C#Assingment\\DB\\Attendance_system.mdf\";Integrated Security=True;Connect Timeout=30";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Get the user input.
            int id = Convert.ToInt32(bunifuTextBox12.Text);
            string name = bunifuTextBox1.Text;
            string email = bunifuTextBox2.Text;
            int tNumber = Convert.ToInt32(bunifuTextBox3.Text);
            string pName = bunifuTextBox4.Text;
            int pNumber = Convert.ToInt32(bunifuTextBox5.Text);

            string sql = "INSERT INTO student(Id,Name,email,tNumber,pName,pNumber)\r\nVALUES ('" + id + "' ,'" + name + "', '" + email + "', '" + tNumber + "', '" + pName + "', '" + pNumber + "')";


            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Student Inserted");

        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Yasiru Perera\\Desktop\\New folder (3)\\C#Assingment\\C#Assingment\\DB\\Attendance_system.mdf\";Integrated Security=True;Connect Timeout=30";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Get the user input.
            int sid = Convert.ToInt32(bunifuTextBox11.Text);
            string name = bunifuTextBox1.Text;
            string email = bunifuTextBox2.Text;
            int tNumber = Convert.ToInt32(bunifuTextBox3.Text);
            string pName = bunifuTextBox4.Text;
            int pNumber = Convert.ToInt32(bunifuTextBox5.Text);

            // Check the user input.
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }

            // Create the SQL query.
            string sql = "UPDATE student SET Name = @name, email = @email WHERE id = @sId ";

            // Create the command.
            SqlCommand cmd = new SqlCommand(sql, connection);

            // Bind the parameters.
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@sId", sid);

            // Execute the command.
            cmd.ExecuteNonQuery();

            // Display a message.
            MessageBox.Show("Student Profile Updated");
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuShadowPanel7_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void bunifuButton15_Click(object sender, EventArgs e)
        {
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Isuru RAjitha\\Desktop\\2.0v c#\\C#Assingment\\DB\\Attendance_system.mdf\";Integrated Security=True;Connect Timeout=30";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Get the user input.
            int sid = Convert.ToInt32(bunifuTextBox11.Text);

            // Create the SQL query.
            string sql = "delete from student WHERE id = '" + sid + "' ";

            // Create the command.
            SqlCommand cmd = new SqlCommand(sql, connection);

            // Bind the parameters.

            cmd.Parameters.AddWithValue("@sId", sid);

            // Execute the command.
            cmd.ExecuteNonQuery();

            // Display a message.
            MessageBox.Show("Student Profile Deleted");
        }

        private void bunifuButton14_Click(object sender, EventArgs e)
        {
            // Create a Process object.
            Process process = new Process();

            // Set the process start information for changing the directory.
            ProcessStartInfo startInfo1 = new ProcessStartInfo();
            startInfo1.FileName = "cmd.exe";
            startInfo1.Arguments = "/C cd C:\\Users\\Yasiru Perera\\Desktop\\Python";
            startInfo1.WindowStyle = ProcessWindowStyle.Hidden;

            // Start the process for changing the directory.
            process.StartInfo = startInfo1;
            process.Start();

            // Wait for the process to finish.
            process.WaitForExit();

            // Set the process start information for running the Python file.
            ProcessStartInfo startInfo2 = new ProcessStartInfo();
            startInfo2.FileName = "python.exe";
            startInfo2.Arguments = "main.py";
            startInfo2.WorkingDirectory = "C:\\Users\\Yasiru Perera\\Desktop\\Python";
            startInfo2.WindowStyle = ProcessWindowStyle.Hidden;

            // Start the process for running the Python file.
            process.StartInfo = startInfo2;
            process.Start();
            MessageBox.Show("Please wait , press q to exit");

            // Wait for the process to finish.
            process.WaitForExit();

            // Exit the program.
           
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string newFileName = bunifuTextBox1.Text + Path.GetExtension(filePath);
                string destinationPath = Path.Combine("C:\\Users\\Yasiru Perera\\Desktop\\C#Assingment\\C#Assingment\\python\\Training_images", newFileName); // Replace with your desired destination path

                File.Copy(filePath, destinationPath);

                MessageBox.Show("Image saved successfully!");
            }
        }
    }
}
