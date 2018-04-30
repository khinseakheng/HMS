using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_System
{
    
    public partial class MecCategory : UserControl
    {
        public int btclick = 2;
        public MecCategory()
        {
            InitializeComponent();
        }

        private void MecCategory_Load(object sender, EventArgs e)
        {
            listViewShow lst = new listViewShow();
            lst.ShowData("select Category from tbMecategory", "Category", lstView);
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            ClearControl cls = new ClearControl();
            cls.ClearTextBoxes(this);
            AutoID ID = new AutoID();
            int x;
            x = ID.getID("Select MeCategoryID from tbMeCategory", "MeCategoryID");
            string TID = x.ToString();
            txtcategoryID.Text = TID;
            btclick = 1;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            btclick = 2;
            txtCategoryName.Focus();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (btclick == 1)
            {
                dbConnection dbcon = new dbConnection();
                dbcon.OpenConection();
                dbcon.ExecuteQueries("INSERT INTO tbMeCategory" +
                    "(MeCategoryID,Category,Country,Usage) VALUES " +
                    "('" + txtcategoryID.Text + "'," +
                    "'" + txtCategoryName.Text + "'," +
                    "'" + cmbCountry.Text + "'," +
                    "'" + txtUsage.Text + "'" +
                    ")");
                MecCategory_Load(this, null);
                ClearControl cn = new ClearControl();
                cn.ClearTextBoxes(this);
            }
            if (btclick == 2)
            {
                dbConnection dbcon = new dbConnection();
                dbcon.OpenConection();
                dbcon.ExecuteQueries("Update tbMeCategorySet " +
                    " Category='" + txtCategoryName.Text + "'," +
                    " Country='" + cmbCountry.Text + "'," +
                    " Usage='" + txtUsage.Text + "'" +
                    " Where  MeCategoryID='" + txtcategoryID.Text + "'");
                MecCategory_Load(this, null);
                ClearControl cn = new ClearControl();
                cn.ClearTextBoxes(this);
            }
        }
        private void lstView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstView_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            int x = lstView.SelectedIndex + 1;
            txtcategoryID.Text = x.ToString();
            dbConnection conn = new dbConnection();
            SqlDataAdapter dr = new SqlDataAdapter("select * from tbMeCategory where MeCategoryID = '" + txtcategoryID.Text + "'",
                "Database=DBHospital;Server=SEAKHENG\\KSH;Integrated Security=True;connect timeout = 30");
            DataSet ds = new DataSet();
            dr.Fill(ds, "tbMeCategory");
            txtCategoryName.Text = ds.Tables["tbMeCategory"].Rows[0].ItemArray[1].ToString();
            cmbCountry.Text = ds.Tables["tbMeCategory"].Rows[0].ItemArray[2].ToString();
            txtUsage.Text = ds.Tables["tbMeCategory"].Rows[0].ItemArray[3].ToString();
        }
    }
}
