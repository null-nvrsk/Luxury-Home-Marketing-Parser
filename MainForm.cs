using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuxuryHomeMarketing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button1.Enabled = false;
            LuxuryHomeMarketing.StartQueueProcessing();
            button1.Enabled = true;

            //richTextBox1.Text = LuxuryHomeMarketing.GetSearchResult("https://www.luxuryhomemarketing.com/real-estate-agents/advanced_search.html");

            //string pageStr = LuxuryHomeMarketing.GetMemberPage("23f08");
            //LuxuryHomeMarketing.ParseMember(pageStr);
        }
    }
}
