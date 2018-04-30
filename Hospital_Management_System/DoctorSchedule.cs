using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class DoctorSchedule : UserControl
    {
        public int btclick = 2;
        public DoctorSchedule()
        {
            InitializeComponent();
        }

        private void btNew_Click(object sender, EventArgs e)
        {

            ClearControl cls = new ClearControl();
            cls.ClearTextBoxes(this);
            AutoID ID = new AutoID();
            int x;
            x = ID.getID("Select ScheduleID from tbDocSchedule", "ScheduleID");
            string TID = x.ToString();
            txtScheduleID.Text = TID;
            btclick = 1;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            btclick = 2;
            cmbDoctorID.Focus();
        }
    }
}
