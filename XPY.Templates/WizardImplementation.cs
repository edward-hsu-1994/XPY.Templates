using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace XPY.Templates.Web.Wizard {
    public class WizardImplementation : IWizard {
        public void BeforeOpeningFile(ProjectItem projectItem) {
        }

        public void ProjectFinishedGenerating(Project project) {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem) {
        }

        public void RunFinished() {

        }

        public void RunStarted(
            object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind,
            object[] customParams) {
            if (replacementsDictionary.ContainsKey("$ext_safeprojectname$")) {
                replacementsDictionary["$lastnamespace$"] = replacementsDictionary["$ext_safeprojectname$"].Split('.').Last();
                replacementsDictionary["$safeclassname$"] = replacementsDictionary["$ext_safeprojectname$"].Replace(".", "");
            } else {
                replacementsDictionary["$lastnamespace$"] = replacementsDictionary["$safeprojectname$"].Split('.').Last();
                replacementsDictionary["$safeclassname$"] = replacementsDictionary["$safeprojectname$"].Replace(".", "");
            }

            if (
                replacementsDictionary.ContainsKey("$ext_safeprojectname$") &&
                replacementsDictionary["$ext_safeprojectname$"] == replacementsDictionary["$safeprojectname$"]) {
                var jwtConfigForm = new JWTConfigForm();
                jwtConfigForm.ShowDialog();

                replacementsDictionary["$issuer$"] = jwtConfigForm.Issuer.Text;
                replacementsDictionary["$audience$"] = jwtConfigForm.Audience.Text;
                replacementsDictionary["$securekey$"] = jwtConfigForm.SecureKey.Text;
            }

            switch (runKind) {
                case WizardRunKind.AsMultiProject:

                    break;
                case WizardRunKind.AsNewProject:
                    break;
            }
        }

        public bool ShouldAddProjectItem(string filePath) {
            return true;
        }
    }
}
