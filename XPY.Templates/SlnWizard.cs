using System;
using System.Windows.Forms;

namespace XPY.Templates {
    public partial class SlnWizard : Form {
        public SlnWizard() {
            InitializeComponent();

            this.dbType.SelectedIndex = 0;
            EFSettingPage.AllowNext = false;
        }

        private void initEFCore_CheckedChanged(object sender, EventArgs e) {
            dbType.Enabled = initEFCore.Checked;
            dbConnectionString.Enabled = initEFCore.Checked;

            if (initEFCore.Checked) {
                EFSettingPage.AllowNext = dbConnectionString.TextLength > 0;
            } else {
                dbConnectionString.Clear();
                EFSettingPage.AllowNext = true;
            }
        }

        private void dbConnectionString_TextChanged(object sender, EventArgs e) {
            EFSettingPage.AllowNext = dbConnectionString.TextLength > 0;

            if (!initEFCore.Checked) {
                EFSettingPage.AllowNext = true;
            }
        }
    }
}
