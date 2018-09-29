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
            replacementsDictionary["$lastnamespace$"] = replacementsDictionary["$ext_safeprojectname$"].Split('.').Last();
            replacementsDictionary["$safeclassname$"] = replacementsDictionary["$ext_safeprojectname$"].Replace(".", "");
        }

        public bool ShouldAddProjectItem(string filePath) {
            return true;
        }
    }
}
