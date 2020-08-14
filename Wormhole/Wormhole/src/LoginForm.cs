using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Wormhole.src;

namespace Wormhole
{
    public partial class frmLoginForm : Form
    {
        private OpenFileDialog opfSearch;

        private TextBox[] textBoxes;
        private bool[] keys;
        private string accessType = "Player", action = "", filename = "", imageLoc = "";
        private int v = 0;

        public static bool accActive = false;

        public frmLoginForm()
        {
            InitializeComponent();
        }

        private void frmLoginForm_Load(object sender, EventArgs e)
        {
            keys = new bool[1000];
            textBoxes = new TextBox[] { txtFirstName, txtLastName, txtSchool, txtUser, txtPass, txtRetype, txtUsername, txtPassword, txtCorAns, txtQuestionMode, txtSearchBox };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                Utilities.AddTextBoxFeature(ref textBoxes[i]);
            }
            HideShow(true);
            //Utilities.query = "SELECT * FROM tbgamequestions";
            //Utilities.DBReadQuestion(ref lvQuestionList);
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            bool[] field = new bool[2];

            if ((field[0] = (txtUsername.Text == "")) || (field[1] = (txtPassword.Text == "")))
            {
                MessageBox.Show("Please fill-up the blank field.", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (field[0]) txtUsername.Focus();
                if (field[1]) txtPassword.Focus();
                return;
            }
            if (Utilities.VerifyLogin(txtUsername.Text, txtPassword.Text, accessType))
            {
                if (accessType == "Player")
                {
                    accActive = true;
                    frmMainForm.currentUser = txtUsername.Text;
                    Dispose();
                }
                else
                {
                    HideShow(null);
                    txtCorAns.Focus();
                    Utilities.query = "SELECT * FROM tbgamequestions";
                    Utilities.DBReadQuestion(ref lvQuestionList);
                    return;
                }
            }
            HideShow(true);
            txtUsername.Focus();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            int priv = accessType == "Player" ? 1 : 0;

            string query = "INSERT INTO tbgameusers VALUES ('";
            query += txtUser.Text + "','";
            query += txtPass.Text + "','";
            query += txtFirstName.Text != "" ? txtFirstName.Text.First().ToString().ToUpper() + txtFirstName.Text.Substring(1) + "','" : "";
            query += txtLastName.Text != "" ? txtLastName.Text.First().ToString().ToUpper() + txtLastName.Text.Substring(1) + "','" : "";
            query += txtSchool.Text.ToUpper() + "','" + accessType + "'," + priv + ")";

            if (Utilities.VerifySignup(ref textBoxes, query))
            {
                HideShow(true);
                txtUsername.Text = Utilities.user;
                txtPassword.Text = Utilities.pass;
                lblLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>

        private void btnAdd_Click(object sender, EventArgs e)
        {
            action = "Save";
            ValidateControls();
            ButtonState(false, true, true, false, false);
            LockControls(true);
            txtCorAns.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReviewTextBox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ValidateListView(false);
            ButtonState(false, true, true, false, false);
            LockControls(true);
            txtCorAns.Focus();
            action = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            action = "Delete";
            var Confirm = MessageBox.Show("Are You Sure You Want to Delete the Row of Data?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Confirm == DialogResult.No) return;
            Utilities.query = "DELETE FROM tbgamequestions WHERE QuestionID = '" + lblID.Text.Remove(0, 4) + "'";
            Utilities.DBDelete();
            Utilities.query = "SELECT * FROM tbgamequestions";
            Utilities.DBReadQuestion(ref lvQuestionList);
            ValidateControls();
            ButtonState(true, false, false, false, false);
            LockControls(false);
            DeletePicture(Utilities.getDefPath + "\\res\\img\\quest\\" + imageLoc);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ValidateListView(false);
            ValidateControls();
            ButtonState(true, false, false, false, false);
            LockControls(false);
            btnAdd.Focus();
            imageLoc = "";
        }

        private void HideShow(bool? dec)
        {
            if (dec == true) { plLogin.BringToFront(); plSignup.SendToBack(); lblHeader.Text = "Login"; txtUsername.Focus(); lblClose.Visible = true; }
            else if (dec == false) { plLogin.SendToBack(); plSignup.BringToFront(); lblHeader.Text = "Signup"; txtFirstName.Focus(); lblClose.Visible = false; }
            else if (dec == null) { plAdmin.BringToFront(); lblHeader.Text = "Game Database Admin"; lblClose.Visible = false; cbDifficulty.Text = "----------"; }

            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Clear();
            }
        }

        private void ValidateListView(bool selectOnly)
        {
            if (!selectOnly)
            {
                lvQuestionList.Items[v].Selected = false;
            }
            for (int i = 0; i < lvQuestionList.Items.Count; i++)
            {
                if (lvQuestionList.Items[i].Selected)
                {
                    pbQuestion.BackgroundImage = Image.FromFile(Utilities.getDefPath + "\\res\\img\\quest\\" + (imageLoc = lvQuestionList.Items[i].SubItems[1].Text));
                    lblID.Text = "ID: " + lvQuestionList.Items[i].SubItems[0].Text;
                    filename = lvQuestionList.Items[i].SubItems[1].Text;
                    txtCorAns.Text = lvQuestionList.Items[i].SubItems[2].Text;
                    cbDifficulty.Text = lvQuestionList.Items[i].SubItems[3].Text;
                    txtQuestionMode.Text = lvQuestionList.Items[i].SubItems[4].Text;
                    v = i;
                    action = "Cancel";
                    break;
                }
            }
            ButtonState(false, true, false, true, true);
        }

        private void ValidateControls()
        {
            lblID.Text = "ID: ";
            txtCorAns.Clear();
            cbDifficulty.Text = "----------";
            txtQuestionMode.Clear();
            pbQuestion.BackgroundImage = null;
        }

        private void ButtonState(bool Add, bool Cancel, bool Save, bool Edit, bool Delete)
        {
            btnAdd.Enabled = Add;
            btnCancel.Enabled = Cancel;
            btnSave.Enabled = Save;
            btnEdit.Enabled = Edit;
            btnDelete.Enabled = Delete;
        }

        private void LockControls(bool isLock)
        {
            txtCorAns.Enabled = isLock;
            cbDifficulty.Enabled = isLock;
            txtQuestionMode.Enabled = isLock;
            lvQuestionList.Enabled = !isLock;
            lblImageOpen.Enabled = isLock;
        }

        private void ReviewTextBox()
        {
            bool toPermit = false;

            if (txtCorAns.Text == "" && !IsAValidNumeric(txtCorAns.Text))
            {
                PromptError(ref txtCorAns, "Correct Answer", ref toPermit);
                return;
            }
            else if (cbDifficulty.Text == cbDifficulty.Items[0].ToString() && !IsAValidNumeric(cbDifficulty.Text))
            {
                toPermit = true;
                MessageBox.Show("The Difficulty is Invalid!", "Error Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbDifficulty.Focus();
                return;
            }
            else if (txtQuestionMode.Text == "" && !IsAValidNumeric(txtQuestionMode.Text))
            {
                PromptError(ref txtQuestionMode, "Question Mode", ref toPermit);
                return;
            }
            else if (pbQuestion.BackgroundImage == null)
            {
                toPermit = true;
                MessageBox.Show("There is no Image Imported!", "Error Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (action.Equals("Save"))
            {
                var Confirm = MessageBox.Show("Are You Sure You Want to Save the Inputted Data?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Confirm == DialogResult.No) return;

                SavePicture();
                Utilities.query = "INSERT INTO tbgamequestions VALUES ('";
                Utilities.query += Utilities.GeneratePK("Q-", "tbgamequestions", 5) + "','";
                Utilities.query += filename + "','";
                Utilities.query += txtCorAns.Text + "','";
                Utilities.query += cbDifficulty.Text + "','";
                Utilities.query += txtQuestionMode.Text + "')";
                Utilities.DBCreate();
            }
            else if (action.Equals("Update"))
            {
                var Confirm = MessageBox.Show("Are You Sure You Want to Update the Inputted Data?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Confirm == DialogResult.No) return;

                if (imageLoc != lvQuestionList.Items[v].SubItems[1].Text) SavePicture();

                imageLoc = "";
                Utilities.query = "UPDATE tbgamequestions SET QuestionFile = '" + filename + "',";
                Utilities.query += "CorrectAnswer = '" + txtCorAns.Text + "',";
                Utilities.query += "Difficulty = '" + cbDifficulty.Text + "',";
                Utilities.query += "QuestionMode = '" + txtQuestionMode.Text + "' WHERE QuestionID = '" + lblID.Text.Remove(0, 4) + "'";
                Utilities.DBUpdate();
            }
            Utilities.query = "SELECT * FROM tbgamequestions";
            Utilities.DBReadQuestion(ref lvQuestionList);
            ValidateControls();
            LockControls(toPermit);
            ButtonState(!toPermit, toPermit, toPermit, false, false);
            
        }

        private void PromptError(ref TextBox text, string name, ref bool toPermit)
        {
            toPermit = true;
            MessageBox.Show("The Inputted " + name + " is Invalid!", "Error Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            text.Focus();
        }

        private bool IsAValidNumeric(string text)
        {
            int temp;
            return int.TryParse(text, out temp) && temp > 0;
        }

        private void SavePicture()
        {
            if (opfSearch.FileName != "")
            {
                string filenametemp, curFileName = "";
                if (action != "") filenametemp = PictureUsed("Dir") ? opfSearch.SafeFileName : PictureUsed("List") ? opfSearch.SafeFileName : "dasdgdsafafdfsfca";
                else filenametemp = opfSearch.SafeFileName;
                
                string fileTemp = opfSearch.FileName == "" ? Utilities.getDefPath + "\\res\\img\\quest\\" + filenametemp : opfSearch.FileName.Remove(opfSearch.FileName.IndexOf(opfSearch.SafeFileName), opfSearch.SafeFileName.Length) + filenametemp;
                
                if (!File.Exists(fileTemp) && opfSearch.FileName != "") File.Copy(opfSearch.FileName, fileTemp);
                else filenametemp = opfSearch.SafeFileName;

                if (!File.Exists(Utilities.getDefPath + "\\res\\img\\quest\\" + (Utilities.CountQuestion("") + 1) + Path.GetExtension(opfSearch.FileName)) && !File.Exists(Utilities.getDefPath + "\\res\\img\\quest\\" + filenametemp))
                {
                    curFileName = (Utilities.CountQuestion("") + 1) + Path.GetExtension(opfSearch.FileName);
                    File.Copy(fileTemp, Utilities.getDefPath + "\\res\\img\\quest\\" + curFileName);
                }
                filename = curFileName == "" ? filenametemp : curFileName;
                if (!PictureUsed("Dir")) DeletePicture(fileTemp);
            }
        }

        private void DeletePicture(string path)
        {
            pbQuestion.BackgroundImage = null;

            if (PictureUsed("List")) return;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete(path);
        }

        private bool PictureUsed(string what)
        {
            Utilities.DBConnect();

            string defPath = Utilities.getDefPath + "\\res\\img\\quest\\";

            if (what == "Dir")
            {
                string[] files = Directory.GetFiles(defPath, "*", SearchOption.TopDirectoryOnly);

                for (int i = 0; i < Directory.GetFiles(defPath, "*", SearchOption.TopDirectoryOnly).Length; i++)
                {
                    if (imageLoc.Equals(files[i].Remove(files[i].IndexOf(defPath), defPath.Length), StringComparison.OrdinalIgnoreCase)) return true;
                }
            }
            if (what == "List")
            {
                for (int i = 0; i < lvQuestionList.Items.Count; i++)
                {
                    if (imageLoc.Equals(lvQuestionList.Items[i].SubItems[1].Text, StringComparison.OrdinalIgnoreCase)) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Effectsssssss
        /// </summary>

        private void lblClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Maroon;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
        }

        private void lblLogin_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblLogin, true);
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblLogin, false);
        }

        private void lblSign_Click(object sender, EventArgs e)
        {
            HideShow(false);
        }

        private void lblSign_MouseEnter(object sender, EventArgs e)
        {
            lblSign.ForeColor = Color.SteelBlue;
        }

        private void lblSign_MouseLeave(object sender, EventArgs e)
        {
            lblSign.ForeColor = Color.White;
        }

        private void lblRegister_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblRegister, true);
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblRegister, false);
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            HideShow(true);
        }

        private void lblBack_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblBack, true);
        }

        private void lblBack_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblBack, false);
        }

        private void frmLoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            keys[Convert.ToInt32(e.KeyCode)] = true;

            if (keys[Convert.ToInt32(Keys.ControlKey)] && keys[Convert.ToInt32(Keys.M)] && keys[Convert.ToInt32(Keys.A)])
            {
                accessType = "Admin";
            }
            else
            {
                accessType = "Player";
            }
        }

        private void frmLoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            keys[Convert.ToInt32(e.KeyCode)] = false;
        }

        private void lblAdminLogout_Click(object sender, EventArgs e)
        {
            var Confirm = MessageBox.Show("Are You Sure You Want to Logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Confirm == DialogResult.No) return;
            HideShow(true);
        }

        private void lblAdminLogout_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblAdminLogout, true);
        }

        private void lblAdminLogout_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblAdminLogout, false);
        }
        
        private void lblImageOpen_Click(object sender, EventArgs e)
        {
            opfSearch = new OpenFileDialog();
            opfSearch.Filter = "Find Image(*.png; *.jpg)|*.png; *.jpg";
            if (opfSearch.ShowDialog() == DialogResult.OK)
            {
                pbQuestion.BackgroundImage = Image.FromFile(opfSearch.FileName);
                imageLoc = opfSearch.SafeFileName != "" ? opfSearch.SafeFileName : imageLoc;
            }
        }

        private void lvQuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateListView(true);
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == "")
            {
                Utilities.query = "SELECT * FROM tbgamequestions";
                Utilities.DBReadQuestion(ref lvQuestionList);
                return;
            }
            Utilities.query = "SELECT * FROM tbgamequestions WHERE QuestionID LIKE '%" + txtSearchBox.Text + "%' OR QuestionFile LIKE '%" + txtSearchBox.Text + "%' OR Difficulty LIKE '%" + txtSearchBox.Text + "%'";
            Utilities.DBReadQuestion(ref lvQuestionList);
        }

        private void ChangeLabelColor(Label label, bool active)
        {
            if (active)
            {
                label.Font = new Font("Consolas", 11, FontStyle.Regular);
                label.BackColor = Color.DarkGoldenrod;
                label.ForeColor = Color.Black;
            }
            else
            {
                label.Font = Font;
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
            }
        }
    }
}
