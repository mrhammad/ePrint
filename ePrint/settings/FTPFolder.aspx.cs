using FluentFTP;
using nmsCommon;
using nmsLanguage;
using Printcenter.UI.Setting;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.settings
{
    public class FtpSettingsModel
    {
        public string FtpAddress { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public int Port { get; set; }
        public string RootFolder { get; set; }

        public string FileTransferProtocol { get; set; }

    }
    public partial class FTPFolder : BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        private BaseClass objbase = new BaseClass();

        public int CompanyID;

        public int UserID;

        protected void btnRefreshFolders_Click(object sender, EventArgs e)
        {
            try
            {
                string ftpAddress = txtFtpAddress.Text;
                string username = txtFtpUsername.Text;
                string password = txtFtpPassword.Text;
                string port = txtFtpPort.Text;
                string rootFolder = txtFtpRootFolder.Text;
                hdnPassword.Value = password;
                string protocol = ddlProtocol.SelectedValue; // "SFTP" or "FTPS"
                txtFtpPassword.Attributes["value"] = password;
                if (!string.IsNullOrEmpty(protocol))
                {
                    var savedFolders = SettingsBasePage.GetSavedFtpFolders(this.CompanyID);

                    var folders = GetSftpFolders(ftpAddress, Convert.ToInt32(port), username, password, rootFolder, protocol);

                    var folderData = folders.Select(folder => new
                    {
                        Name = folder.Trim('/'),
                        IsSelected = savedFolders.Values.Contains(folder.Trim('/'))
                    }).OrderBy(f => f.Name).ToList();

                    rptFolderList.DataSource = folderData;
                    rptFolderList.DataBind();

                    lblMessage.Visible = false;
                    btnRefreshFolders.Enabled = true;
                    btnSaveFtpSettings.Enabled = true;
                }
                else
                {
                    lblMessage.Text = "Please select a protocol.";
                    lblMessage.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Failed to connect or retrieve folders: " + ex.Message;
                lblMessage.Visible = true;
            }
        }


        public List<string> GetSftpFolders(string ip, int port, string username, string password,string rootfolder,string protocol)
        {
            var folderList = new List<string>();
            if (protocol.Equals("SFTP", StringComparison.OrdinalIgnoreCase))
            {
                using (var sftp = new SftpClient(ip, port, username, password))
                {
                    try
                    {
                        sftp.Connect();

                        //var files = sftp.ListDirectory(".");
                        var rootDirs = sftp.ListDirectory(".");
                        //var mainFolder = rootDirs
                        //    .FirstOrDefault(f => f.IsDirectory && f.Name != "." && f.Name != "..");
                        var mainFolder = rootDirs
                            .FirstOrDefault(f => f.IsDirectory
                             && f.Name.Equals(rootfolder, StringComparison.OrdinalIgnoreCase));

                        if (mainFolder == null)
                            throw new Exception($"The specified main folder '{rootfolder}' was not found in the root directory.");

                        // Step 2: Go into that main folder (e.g., FTP) and list its directories
                        var files = sftp.ListDirectory(mainFolder.FullName);

                        foreach (var file in files)
                        {
                            if (file.IsDirectory && file.Name != "." && file.Name != "..")
                            {
                                //folderList.Add(file.FullName);
                                //folderList.Add(file.FullName.TrimStart('/')); // Remove leading slash
                                folderList.Add(file.Name);
                            }
                        }

                        sftp.Disconnect();
                    }
                    catch (Exception ex)
                    {
                        // Handle login failure or connection issues
                        throw new ApplicationException("SFTP connection failed: " + ex.Message);
                    }
                }

            }
            else if (protocol.Equals("FTPS", StringComparison.OrdinalIgnoreCase))
            {
                // --- FTPS via FluentFTP ---
                using (var client = new FtpClient(ip, new NetworkCredential(username, password)))
                {
                    client.Port = port; // 21 (explicit) or 990 (implicit)
                    //  Decide encryption mode based on port
                    client.Config.EncryptionMode = (port == 990)
                        ? FtpEncryptionMode.Implicit
                        : FtpEncryptionMode.Explicit;

                    // Use Passive mode (most servers require this)
                    client.Config.DataConnectionType = FtpDataConnectionType.PASV;

                    client.ValidateCertificate += (control, e) => { e.Accept = true; };

                    client.Connect();

                    var targetPath = string.IsNullOrEmpty(rootfolder) ? "/" : "/" + rootfolder;

                    if (!client.DirectoryExists(targetPath))
                        throw new Exception($"The specified main folder '{rootfolder}' was not found in the root directory.");

                    foreach (var item in client.GetListing(targetPath))
                    {
                        if (item.Type == FtpObjectType.Directory)
                            folderList.Add(item.Name);
                    }

                    client.Disconnect();
                }
            }
            else
            {
                throw new NotSupportedException($"Protocol '{protocol}' is not supported. Use 'SFTP' or 'FTPS'.");
            }

            return folderList;
        }

        protected void btnSaveFtpSettings_Click(object sender, EventArgs e)
        {
            string ftpAddress = txtFtpAddress.Text.Trim();
            string username = txtFtpUsername.Text.Trim();
            string password = txtFtpPassword.Text;
            string port = txtFtpPort.Text;
            string rootFolder = txtFtpRootFolder.Text;
            string fileTransferProtocol = ddlProtocol.SelectedValue;
            if (string.IsNullOrEmpty(password))
            {
                password= hdnPassword.Value;
            }
            txtFtpPassword.Attributes["value"] = password;

            if (string.IsNullOrWhiteSpace(ftpAddress) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "FTP Address, Username, and Password are required.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            //var selectedFolders = chkFolderList.Items.Cast<ListItem>()
            //                        .Where(i => i.Selected)
            //                        .Select(i => i.Text)
            //                        .ToList();
            List<string> selectedFolders = new List<string>();
            foreach (RepeaterItem item in rptFolderList.Items)
            {
                CheckBox chkFolder = (CheckBox)item.FindControl("chkFolder");
                if (chkFolder != null && chkFolder.Checked)
                {
                    selectedFolders.Add(chkFolder.Text);
                }
            }

            if (!selectedFolders.Any())
            {
                lblMessage.Text = "Please select at least one folder.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            string encryptedPassword = commonClass.Encrypt(password);

            // Save FTP settings and get the Id
            int ftpSettingsId = SettingsBasePage.SaveFtpSettings(ftpAddress, username, encryptedPassword, this.CompanyID, Convert.ToInt32(port),rootFolder,fileTransferProtocol);

            // Save selected folders
            //SettingsBasePage.SaveSelectedFolders(ftpSettingsId, selectedFolders);

            // ✅ Get already saved folders for this FTP setting
            List<string> existingFolders = SettingsBasePage.GetSavedFtpFoldersByFtpId(ftpSettingsId);

            // ✅ Insert only folders that are not already saved
            foreach (string folder in selectedFolders)
            {
                if (!existingFolders.Contains(folder, StringComparer.OrdinalIgnoreCase))
                {
                    SettingsBasePage.SaveSelectedFolder(ftpSettingsId, folder);
                }
            }
            // Delete folders that were previously selected but now unselected
            foreach (string folder in existingFolders)
            {
                if (!selectedFolders.Contains(folder, StringComparer.OrdinalIgnoreCase))
                {
                    SettingsBasePage.DeleteSelectedFolder(ftpSettingsId, folder);
                }
            }
            //YourDAL.SaveFtpSettings(ftpAddress, username, encryptedPassword, enableHexihub, selectedFolders);

            //lblMessage1.Text = "✅ Settings saved successfully.";
            //lblMessage1.ForeColor = System.Drawing.Color.Green;
            //lblMessage1.Visible = true;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "hideSuccessMsg", "hideSuccessMessage();", true); 
            base.Message_Display(this.objLanguage.GetLanguageConversion("Your_Update_Was_Successful"), "msg-success", this.plhMessage);
        }
        private void LoadSavedFtpSettings()
        {
            var settings = SettingsBasePage.GetFtpSettings(this.CompanyID); // Assume it returns an object with FTPAddress, Username, etc.
            var selectedFolders = SettingsBasePage.GetSavedFtpFolders(this.CompanyID); 

            if (settings != null)
            {
                txtFtpAddress.Text = settings.FtpAddress;
                txtFtpUsername.Text = settings.Username;
                txtFtpPort.Text = settings.Port.ToString();
                txtFtpRootFolder.Text = settings.RootFolder;
                ddlProtocol.SelectedValue = settings.FileTransferProtocol;
                string decrypted = commonClass.Decrypt(settings.EncryptedPassword);
                txtFtpPassword.Attributes["value"] = decrypted;
                hdnPassword.Value = decrypted;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("FTP_Folders");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.GetLanguageConversion("FTP_Folders");
            base.Session["pagename"] = "setting";
            if (!IsPostBack)
            {
                btnRefreshFolders.Enabled = true;
                LoadSavedFtpSettings();
            }
        }
    }
}