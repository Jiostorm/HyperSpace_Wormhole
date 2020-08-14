using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Wormhole.src
{
    public static class Utilities
    {
        private static string cnnStr = "server=localhost;user id=root;passowrd=;database=dbgamefest;sslmode=none";
        public static string getDefPath = Application.LocalUserAppDataPath;
        public static string getDefGameImgPath = getDefPath + "/res/img/game/";

        private static MySqlConnection myCnn;
        private static MySqlCommand myCmd;

        public static string query = "";
        public static string user = "";
        public static string pass = "";

        public static void AddTextBoxFeature(ref TextBox textbox)
        {
            textbox.Controls.Add(new Label()
            {
                BackColor = Color.DimGray,
                Dock = DockStyle.Bottom,
                Height = 1
            });
        }

        public static bool VerifyLogin(string user, string pass, string accessType)
        {
            DBConnect();

            query = "SELECT * FROM tbgameusers WHERE AccessType = '" + accessType + "'";

            myCmd = new MySqlCommand(query, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (user.Equals(reader.GetString(0)) && !pass.Equals(reader.GetString(1)) && accessType == "Player")
                    {
                        MessageBox.Show("Password Incorrect!!", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DBClose();
                        return false;
                    }
                    else if (user.Equals(reader.GetString(0)) && pass.Equals(reader.GetString(1)) && accessType == "Player")
                    {
                        MessageBox.Show("Welcome To The Game! " + reader.GetString(2) + " " + reader.GetString(3), "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DBClose();
                        return true;
                    }
                    else if (user.Equals(reader.GetString(0)) && pass.Equals(reader.GetString(1)) && accessType == "Admin")
                    {
                        MessageBox.Show("Game System Database Unlocked!, \n\nWelcome! Master " + reader.GetString(2) + " " + reader.GetString(3), "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DBClose();
                        return true;
                    }
                }
            }

            MessageBox.Show("Account Information Does Not Exist.", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DBClose();
            return false;

            void DBClose()
            {
                myCnn.Close();
                myCmd.Dispose();
            }
        }

        public static bool VerifySignup(ref TextBox[] signinfo, string squery)
        {
            if (signinfo[0].Text == "") { DisplayMessage("First Name is blank!", signinfo[0]); return false; }
            else if (ContainsNumeric(signinfo[0].Text)) { DisplayMessage("Numerics are not allowed!", signinfo[0]); return false; }

            if (signinfo[1].Text == "") { DisplayMessage("Last Name is blank!", signinfo[1]); return false; }
            else if (ContainsNumeric(signinfo[1].Text)) { DisplayMessage("Numerics are not allowed!", signinfo[1]); return false; }

            if (signinfo[2].Text == "") { DisplayMessage("School Code Name is blank!", signinfo[2]); return false; }

            if (signinfo[3].Text == "") { DisplayMessage("Username is blank!", signinfo[3]); return false; }
            else if (UsernameCheck(signinfo[3].Text)) { DisplayMessage("Username already exists!", signinfo[3]); return false; }
            else if (signinfo[3].Text.Contains(" ")) { DisplayMessage("Spaces in Username are not allowed!", signinfo[3]); return false; }
            else if (signinfo[3].Text.Length >= 15) { DisplayMessage("Only below 15 characters in Username are allowed!", signinfo[3]); return false; }

            if (signinfo[4].Text == "") { DisplayMessage("Password is blank!", signinfo[4]); return false; }
            else if (signinfo[4].Text.Length < 4) { DisplayMessage("Your Password is weak!", signinfo[4]); return false; }

            if (signinfo[5].Text == "") { DisplayMessage("Re-type Password is blank!", signinfo[5]); return false; }
            else if (!signinfo[5].Text.Equals(signinfo[4].Text)) { DisplayMessage("Password did not match!", signinfo[5]); return false; }

            query = squery;

            if (MessageBox.Show("Do You want to register the information above?", "Register Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return false;

            DBCreate();
            MessageBox.Show("Your Account have been registered!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            user = signinfo[3].Text;
            pass = signinfo[4].Text;

            return true;
        }

        private static void DisplayMessage(string message, TextBox textbox)
        {
            MessageBox.Show(message, "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textbox.Text = textbox.Text;
            textbox.Focus();
        }

        private static bool UsernameCheck(string username)
        {
            Utilities.DBConnect();

            query = "SELECT Username FROM tbgameusers";

            myCmd = new MySqlCommand(query, Utilities.myCnn);

            MySqlDataReader Reader = myCmd.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    if (username == Reader.GetString(0))
                    {
                        Utilities.myCnn.Close();
                        myCmd.Dispose();
                        query = "";
                        return true;
                    }
                }
            }
            Utilities.myCnn.Close();
            myCmd.Dispose();
            query = "";

            return false;
        }

        public static bool ContainsNumeric(string text)
        {
            return text.Any(char.IsDigit);
        }

        public static string GeneratePK(string prefix, string db, int length)
        {
            DBConnect();

            string pkQuery = "SELECT * FROM " + db + " ORDER BY 1 DESC";

            myCmd = new MySqlCommand(pkQuery, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();

            int curRecord = GenerateLostPK(db);

            if (reader.HasRows)
            {
                reader.Read();

                int pktemp = curRecord == 0 ? Convert.ToInt16(reader.GetString(0).Remove(0, 2)) : curRecord;
                pktemp += curRecord == 0 ? 1 : 0;
                string prefixtemp = "";

                for (int i = 0; i < length + i; i++)
                {
                    if (pktemp.ToString().Length == length - 1)
                    {
                        for (int j = length + i; j > pktemp.ToString().Length; j--)
                        {
                            prefixtemp += "0";
                        }
                        break;
                    }
                    length--;
                }
                return prefix + prefixtemp + pktemp;
            }

            string pkstemp = "";

            for (int i = 0; i < length - 1; i++)
            {
                pkstemp += "0";
            }

            myCnn.Close();
            myCmd.Dispose();
            return prefix + pkstemp + 1;
        }

        public static int GenerateLostPK(string db)
        {
            DBConnect();

            query = "SELECT * FROM " + db;

            myCmd = new MySqlCommand(query, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();

            int[] ids = new int[CountQuestion("")];

            if (reader.HasRows)
            {
                for (int ctr = 0; reader.Read(); ctr++)
                {
                    ids[ctr] = Convert.ToInt32(reader.GetString(0).Remove(0, 2));
                    if ((ctr + 1) != ids[ctr])
                    {
                        return ctr + 1;
                    }
                }
            }

            myCnn.Close();
            myCmd.Dispose();
            return 0;
        }

        public static string ReadTextFile(string filename)
        {
            return File.ReadAllText(getDefPath + "\\res\\txt\\" + filename);
        }

        public static TextBox AddTextBox(ref TextBox temp, int x, int y, int width, int height, bool isreadonly)
        {
            temp = new TextBox();
            temp.BackColor = Color.Black;
            temp.ForeColor = Color.PaleGoldenrod;
            temp.SetBounds(x, y, width, height);
            temp.Font = new Font("Consolas", 12, FontStyle.Regular);
            temp.Multiline = true;
            temp.BorderStyle = BorderStyle.None;
            temp.ReadOnly = isreadonly;
            temp.Visible = true;
            return temp;
        }

        public static Label AddLabel(ref Label temp, Point point, Size size, int fsize, bool autoresize, ContentAlignment content)
        {
            temp = new Label();
            temp.AutoSize = autoresize;
            temp.BackColor = Color.Transparent;
            temp.ForeColor = Color.PaleGoldenrod;
            temp.Location = point;
            if (!autoresize) temp.Size = size;
            temp.Font = new Font("Consolas", fsize, FontStyle.Regular);
            temp.TextAlign = content;
            temp.Visible = true;
            return temp;
        }

        public static ComboBox AddComboBox(ref ComboBox temp, Point point, Size size)
        {
            temp = new ComboBox();
            temp.BackColor = Color.Black;
            temp.ForeColor = Color.PaleGoldenrod;
            temp.Font = new Font("Consolas", 12, FontStyle.Regular);
            temp.FlatStyle = FlatStyle.Flat;
            temp.DropDownStyle = ComboBoxStyle.DropDownList;
            temp.Location = point;
            temp.Size = size;
            temp.TabStop = false;
            temp.Visible = true;
            return temp;
        }

        public static PictureBox AddPictureBox(ref PictureBox temp, Point point, Size size)
        {
            temp = new PictureBox();
            temp.BackColor = Color.Transparent;
            temp.Location = point;
            temp.Size = size;
            temp.Visible = true;
            return temp;
        }
        
        public static ListView AddListView(ref ListView temp, Rectangle rect)
        {
            temp = new ListView();
            temp.BackColor = Color.Black;
            temp.ForeColor = Color.PaleGoldenrod;
            temp.FullRowSelect = true;
            temp.GridLines = true;
            temp.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            temp.LabelEdit = false;
            temp.MultiSelect = false;
            temp.Bounds = rect;
            temp.View = View.Details;
            temp.Visible = true;
            return temp;
        }
        
        /// <summary>
        /// Database Related
        /// </summary>
        public static void DBConnect()
        {
            myCnn = new MySqlConnection(cnnStr);
            try { myCnn.Open(); } catch (Exception e) { MessageBox.Show("Server Error : " + e); }
        }

        public static void DBCreate()
        {
            DBConnect();

            myCmd = new MySqlCommand(query, myCnn);

            myCmd.ExecuteNonQuery();

            myCnn.Close();
            myCmd.Dispose();
            query = "";
        }

        public static string DBRead()
        {
            DBConnect();

            myCmd = new MySqlCommand(query, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();

            if (!reader.HasRows)
            {
                return "0";
            }
            reader.Read();
            
            return reader.GetString(0);
        }

        public static void DBReadGameQuest(ref string[,] temp)
        {
            DBConnect();

            myCmd = new MySqlCommand(query, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                int ctr = 0;
                while (reader.Read())
                {
                    temp[ctr, 0] = reader["QuestionFile"].ToString();
                    temp[ctr, 1] = reader["CorrectAnswer"].ToString();
                    ctr++;
                }
            }

            myCnn.Close();
            myCmd.Dispose();
        }

        public static void DBReadQuestion(ref ListView temp)
        {
            DBConnect();

            myCmd = new MySqlCommand(query, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();

            temp.Items.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ListViewItem lvi = new ListViewItem(reader.GetString(0));
                    for (int i = 1; i < reader.FieldCount; i++)
                    {
                        lvi.SubItems.Add(reader.GetString(i));
                    }
                    temp.Items.Add(lvi);
                }
            }

            myCnn.Close();
            myCmd.Dispose();
        }

        public static void DBReadScore(ref ListView temp, bool score, int until)
        {
            DBConnect();

            myCmd = new MySqlCommand(query, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();

            temp.Items.Clear();

            if (score && until == 0)
            {
                temp.Clear();
                temp.Columns.Add("Rank", 50, HorizontalAlignment.Center);
                temp.Columns[0].TextAlign = HorizontalAlignment.Center;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    int size = i == 0 ? 205 : 167;
                    size = i == reader.FieldCount - 1 ? 241 : size;
                    temp.Columns.Add(reader.GetName(i), size, HorizontalAlignment.Center);
                }
            } else if (!score && until == 0)
            {
                temp.Clear();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    temp.Columns.Add(reader.GetName(i), i == 0 ? 70 : 235, HorizontalAlignment.Center);
                }
            }
            if (reader.HasRows)
            {
                int ctr = 0;

                while (reader.Read())
                {
                    string ctrtemp = "";

                    ctr++;
                    if (score)
                    {
                        switch (ctr.ToString().Length)
                        {
                            case 1:
                                ctrtemp = "0000" + ctr;
                                break;
                            case 2:
                                ctrtemp = "000" + ctr;
                                break;
                            case 3:
                                ctrtemp = "00" + ctr;
                                break;
                            case 4:
                                ctrtemp = "0" + ctr;
                                break;
                            case 5:
                                ctrtemp = "" + ctr;
                                break;
                        }
                        ListViewItem lvi = new ListViewItem(ctrtemp);
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            lvi.SubItems.Add(reader.GetString(i));
                        }
                        temp.Items.Add(lvi);
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem(reader.GetString(0));
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            lvi.SubItems.Add(reader.GetString(i));
                        }
                        temp.Items.Add(lvi);
                    }
                }
            }
            else
            {
                string placeholder = "--------";

                if (score)
                {
                    ListViewItem lvi = new ListViewItem(placeholder);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lvi.SubItems.Add(placeholder);
                    }
                    temp.Items.Add(lvi);
                }
                else
                {
                    ListViewItem lvi = new ListViewItem(placeholder);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lvi.SubItems.Add(placeholder);
                    }
                    temp.Items.Add(lvi);
                }
            }

            myCnn.Close();
            myCmd.Dispose();
            query = "";

        }
        
        public static void DBUpdate()
        {
            DBConnect();

            myCmd = new MySqlCommand(query, myCnn);

            myCmd.ExecuteNonQuery();

            myCnn.Close();
            myCmd.Dispose();
            query = "";
        }

        public static void DBDelete()
        {
            DBConnect();

            myCmd = new MySqlCommand(query, myCnn);

            myCmd.ExecuteNonQuery();

            myCnn.Close();
            myCmd.Dispose();
            query = "";
        }

        /// <summary>
        /// Game Related
        /// </summary>
        public static int CountQuestion(string diff)
        {
            DBConnect();

            if(diff.Length != 0) query = "SELECT COUNT(*) FROM tbgamequestions WHERE Difficulty = '" + diff + "'";
            else query = "SELECT COUNT(*) FROM tbgamequestions";

            myCmd = new MySqlCommand(query, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return reader.GetInt16(0);
            }

            myCnn.Close();
            myCmd.Dispose();
            query = "";
            return 0;
        }

        public static int[] GetRandomIndex(ref int[] randIndex, int size, string diff)
        {
            randIndex = new int[size];

            Random rand = new Random();

            int numOfQuest = CountQuestion(diff);
            bool[] state = new bool[numOfQuest];

            for (int i = 0; i < size; i++)
            {
                int temp = 0;

                do
                {
                    temp = rand.Next(numOfQuest);
                } while (state[temp]);
                state[temp] = true;
                randIndex[i] = temp;
            }
            return randIndex;
        }

        public static string[,] GetGameQuestion(ref string[,] gameQuestion, string gameDifficulty)
        {
            gameQuestion = new string[CountQuestion(gameDifficulty), 2];
            query = "SELECT * FROM tbgamequestions WHERE Difficulty = '" + gameDifficulty + "'";
            DBReadGameQuest(ref gameQuestion);
            return gameQuestion;
        }

        public static int GetUserScores(string name)
        {
            DBConnect();

            query = "SELECT Score FROM tbgamerecords WHERE Username = '" + name + "'";

            myCmd = new MySqlCommand(query, myCnn);

            MySqlDataReader reader = myCmd.ExecuteReader();

            int score = 0;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    score += reader.GetInt32(0);
                }
            }

            myCnn.Close();
            myCmd.Dispose();
            query = "";
            return score;
        }

        public static Image[] GetEntitySpriteSheet(string spriteName, string[] direction, string imgType)
        {
            Image[] sprites = new Image[direction.Length];
            for (int i = 0; i < direction.Length; i++)
            {
                sprites[i] = Image.FromFile(getDefGameImgPath + spriteName + direction[i] + imgType);
            }

            return sprites;
        }
    }
}
