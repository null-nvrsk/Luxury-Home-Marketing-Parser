using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuxuryHomeMarketing
{
    public partial class MainForm : Form
    {
        private static string dbCommand = "";
        private static BindingSource bindingSrc;

        private static string dbPath = $"{Application.StartupPath}\\db.sqlite3";
        private static string conString = $"Data Source={dbPath};Version=3;New=False;Compress=True;";

        private static SQLiteConnection connection = new SQLiteConnection(conString);
        private static SQLiteCommand command = new SQLiteCommand("", connection);

        private static string sql;

        public MainForm()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {

            startBbutton.Enabled = false;
            LuxuryHomeMarketing.StartQueueProcessing();
            startBbutton.Enabled = true;
        }

        //---------------------------------------------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenConnection();

            UpdateDataBinding();

            CloseConnection();
        }

        //---------------------------------------------------------------------
        private void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                string msg = "The connection is: " + connection.State.ToString();
                // MessageBox.Show(msg);
                logRichTextBox.AppendText(msg + "\r\n");
            }

        }

        //---------------------------------------------------------------------
        private void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                string msg = "The connection is: " + connection.State.ToString();
                // MessageBox.Show(msg);
                logRichTextBox.AppendText(msg + "\r\n");
            }
        }

        //---------------------------------------------------------------------
        private void DisplayInfo()
        {
            infoStatusLabel.Text = $"Members: {bindingSrc.Count.ToString()}";
        }

        //---------------------------------------------------------------------
        private void UpdateDataBinding(SQLiteCommand cmd = null)
        {
            try
            {
                dbCommand = "SELECT";
                sql = "SELECT * FROM members";

                if (cmd == null)
                {
                    command.CommandText = sql;
                }
                else
                {
                    command = cmd;
                }

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Members");

                bindingSrc = new BindingSource();
                bindingSrc.DataSource = dataSet.Tables["Members"];

                membersGridView.DataSource = bindingSrc;
                membersGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                membersGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                membersGridView.Columns[0].Width = 70;

                DisplayInfo();
            }
            catch (Exception ex)
            {
                string msg = $"Data binding error: {ex.Message.ToString()}";
                MessageBox.Show(msg);
                logRichTextBox.AppendText(msg + "\r\n");
            }
        }

    }
}
