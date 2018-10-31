using System;
using System.Windows.Forms;

namespace XPY.Templates {
    public partial class SlnWizard : Form {
        public SlnWizard() {
            InitializeComponent();

            this.dbType.SelectedIndex = 0;
        }
    }
}
