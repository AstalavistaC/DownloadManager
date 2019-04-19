using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Download_Manger
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tsSetting_Click(object sender, EventArgs e)
        {
            using (frmSetting frm = new frmSetting())
            {
                frm.ShowDialog();
            }
        }

        private void tsAddurl_Click(object sender, EventArgs e)
        {
            using (frmAddUrl frm = new frmAddUrl())
            {
                if(frm.ShowDialog()== DialogResult.OK)
                {
                    frmDownload frmdown = new frmDownload(this);
                    frmdown.Url = frm.Url;
                    frmdown.Show();

                }

            }

            
        }

        private void tsRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for(int i = listView1.SelectedItems.Count;i>0;i--)
                {
                    ListViewItem item = listView1.SelectedItems[i - 1];
                    App.DB.Files.Rows[item.Index].Delete();
                    listView1.Items[item.Index].Remove();
                }
                App.DB.AcceptChanges();
                App.DB.WriteXml(String.Format("{0}/data.dat", Application.StartupPath));

            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string filename = String.Format("{0}/data.dat", Application.StartupPath);
            if (File.Exists(filename))
                App.DB.ReadXml(filename);
            foreach(DataSet1.FilesRow row in App.DB.Files)
            {
                ListViewItem item = new ListViewItem(row.Id.ToString());
                item.SubItems.Add(row.Url);
                item.SubItems.Add(row.FileName);
                item.SubItems.Add(row.FileSize);
                item.SubItems.Add(row.DateTime.ToLongDateString());
                listView1.Items.Add(item);
            }
        }
    }
}
