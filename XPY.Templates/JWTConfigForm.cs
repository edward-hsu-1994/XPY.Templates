using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XPY.Templates {
    public partial class JWTConfigForm : Form {
        public JWTConfigForm() {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void JWTConfigForm_Activated(object sender, EventArgs e) {
            Issuer.Focus();
            Issuer.SelectAll();
        }

        private void JWTConfigForm_Load(object sender, EventArgs e) {
            
        }

        private void Expires_TextChanged(object sender, EventArgs e) {

        }
    }
}
