using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TemplateWizard;

namespace XPY.Templates.Web.Wizard {
    public class WizardImplementation : IWizard {
        DTE2 dte2;
        bool isSln;
        public void BeforeOpeningFile(ProjectItem projectItem) {
        }

        public void ProjectFinishedGenerating(Project project) {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem) {
        }

        public void RunFinished() {
            if (!isSln) return;
            string unexpectedDir = Path.GetDirectoryName(Path.GetDirectoryName(this.dte2.Solution.Projects.Item(1).FullName));

            List<string> projectNames = new List<string>();
            foreach (Project prj in this.dte2.Solution.Projects)
                projectNames.Add(prj.FullName);

            foreach (string prjName in projectNames)
                this.AdjustProjectLoaction(prjName);

            foreach (string prjName in projectNames) {
                Directory.Delete(Path.GetDirectoryName(prjName), true);

                if (Path.GetDirectoryName(prjName).EndsWith(".Models.EF")) {
                    string slnPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(prjName)));

                    var batPath = Path.Combine(slnPath, Path.GetDirectoryName(prjName).Split(new char[] { '/', '\\' }).Last(), "scaffold.bat");

                    if (!initEFCore) {
                        continue;
                    }
                    var proc = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() {
                        FileName = batPath,
                        WorkingDirectory = Path.GetDirectoryName(batPath)
                    });
                    proc.WaitForExit();
                    if (proc.ExitCode != 0) {
                        MessageBox.Show(
                            "EFCore Models 更新失敗",
                            "更新失敗，請檢查批次檔內的資料庫連線字串",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    // 產生控制器
                    var template = System.IO.File.ReadAllText("./Templates/Controller.txt");

                    foreach (var model in Directory.GetFiles(Path.GetDirectoryName(batPath), "*.cs", SearchOption.TopDirectoryOnly)) {
                        var filename = Path.GetFileNameWithoutExtension(model);
                        if (filename.EndsWith("Context") && filename != "Context") {
                            continue;
                        }

                        var output = template;
                        foreach (var kv in replacementsDictionary) {
                            output = output.Replace(kv.Key, kv.Value);
                        }
                        output = output.Replace("$modelName$", filename);
                        output = output.Replace("$slnName$", Path.GetFileName(slnPath));

                        File.WriteAllText(Path.Combine(slnPath, Path.GetFileName(slnPath), "Controllers", $"{filename}Controller.cs"), output);
                    }
                }
            }
        }

        private static bool initEFCore;
        private static string efProvider;
        private static string connectionString;
        private static Dictionary<string, string> replacementsDictionary;
        public void RunStarted(
            object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind,
            object[] customParams) {
            WizardImplementation.replacementsDictionary = replacementsDictionary;
            dte2 = automationObject as DTE2;

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

                var slnForm = new SlnWizard();
                slnForm.ShowDialog();

                initEFCore = slnForm.initEFCore.Checked;
                replacementsDictionary["$issuer$"] = slnForm.Issuer.Text;
                replacementsDictionary["$audience$"] = slnForm.Audience.Text;
                replacementsDictionary["$securekey$"] = slnForm.SecureKey.Text;
                replacementsDictionary["$expires$"] = slnForm.Expires.Value.ToString();

                replacementsDictionary["$swaggerName$"] = slnForm.SwaggerName.Text;
                replacementsDictionary["$swaggerDescription$"] = slnForm.SwaggerDescription.Text;

                efProvider = slnForm.dbType.SelectedItem.ToString();
                connectionString = slnForm.dbConnectionString.Text;
            }

            replacementsDictionary["$efProvider$"] = efProvider;
            replacementsDictionary["$connectionString$"] = connectionString;

            switch (runKind) {
                case WizardRunKind.AsMultiProject:
                    isSln = true;
                    break;
                case WizardRunKind.AsNewProject:
                    isSln = false;
                    break;
            }
        }

        public bool ShouldAddProjectItem(string filePath) {
            return true;
        }

        private void AdjustProjectLoaction(string projectFullName) {
            string projectName = Path.GetFileName(projectFullName);

            this.dte2.Solution.Remove(this.dte2.Solution.Projects.Item(1));

            string oldProjectDir = Path.GetDirectoryName(projectFullName);
            //go 1 Level up
            string solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(oldProjectDir));
            string newProjectDir = Path.Combine(solutionDir, Path.GetFileNameWithoutExtension(projectName));

            Directory.CreateDirectory(newProjectDir);

            this.CopyFolder(oldProjectDir, newProjectDir);

            this.dte2.Solution.AddFromFile(Path.Combine(newProjectDir, projectName));
        }

        private void CopyFolder(string sourceFolder, string destFolder) {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files) {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders) {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}
