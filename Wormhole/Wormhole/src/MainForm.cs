using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Wormhole.src
{
    public partial class frmMainForm : Form
    {
        public static string currentUser = "";

        // Container Objects
        private CustomPanel plGamePage, plMobPlane;

        // Control Objects
        private PictureBox[] pbWormholes;
        private ListView lvTopScores, lvPlayerScores;
        private Label lblGameHeader, lblScoreInfo, lblInfo, lblPause, lblEasy, lblNormal, lblHard, lblInsane, lblPlayerLocation, lblPlayerScore, lblPlayerHealth, lblTimeLimit, lblGameSpeed;
        private ComboBox cbScoreList;

        // Game Utility Objects
        private Thread mobThread;
        private Random random;
        private Thread subThread, playerThread, bulletThread, gameTimerThread, guideThread;
        private StringFormat defaultAlign;

        // Game Variables
        private string[,] gameQuestion;

        private string[] gameDirection = new string[] { "_Up", "_Down", "_Left", "_Right" }, gameChoices = new string[] { "A", "B", "C", "D" }, gameGuideLines;
        private int[] randomQuestionIndex, gameTimeLimit, mobSwitcher, guideBorder;
        private bool[] playerKey, mobExistence, mobNotChangeDirection, xBound, yBound, continueGuide;

        private string gameDifficulty = "";
        private int gamePageIndex = 0, until1 = 0, until2 = 0, directionId = 0, guideProgress = 1;

        private bool isDemo = false, isLevelCleared = false, isTimeUp = true, isPause = false, isHomeInstance = false, isGameInstance = false, isGameOver = false;

        private const int questionWidth = 800, questionHeight = 350;

        private bool? playerBlink = null;

        // Entity Objects
        private Image[] playerSpriteSheet, bulletSpriteSheet;
        private volatile Rectangle[] rectMobs, rectWormholes;
        private Image imgHome, imgInGame, imgPortal, imgGameBox, imgPlayer, imgBullet, imgMob, imgWormhole, imgAsteroid;
        private Rectangle rectGameBox, rectPlayer, rectPlayerSafeBox, rectBullet, rectQuestion;

        // Entity Variables
        private string playerSprite = "", bulletSprite = "", mobSprite = "", bulletDirection = "";
        private string playerAnswer = "";
        private int playerStage = 0, playerStageChosen = 0, playerKills = 0, playerLevel = 0, playerScore = 0, playerGameLevelPeak = 0,
                    playerHealth = 0, playerMaxHealth = 0;
        private int mobSpawnNumber = 0, mobId = 0, perMobScore = 0, wormholeScore = 0;
        private bool bulletFired = false, playerDamaged = false, containsWormhole = false, mobExplode = false, enableBullet = false, showWormholeScore = false, blinkChoice = false;

        private volatile int playerX = 0, playerY = 0, playerWidth = 0, playerHeight = 0;
        private const int wormholeSize = 70, mobSize = 25;

        /// <summary>
        /// Main Program
        /// </summary>
        public frmMainForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            imgInGame = Image.FromFile(Utilities.getDefGameImgPath + "Milky2.jpg");
            imgPortal = Image.FromFile(Utilities.getDefGameImgPath + "HyperSpace.gif");
            imgHome = Image.FromFile(Utilities.getDefGameImgPath + "Moving.gif");
            imgWormhole = Image.FromFile(Utilities.getDefGameImgPath + "Wormhole4.gif");
            imgAsteroid = Image.FromFile(Utilities.getDefGameImgPath + "Asteroid.png");

            plGamePage = new CustomPanel();
            plMobPlane = new CustomPanel();
            random = new Random();

            InitialScreen();
        }

        /// <summary>
        /// Home Screen Stuff
        /// </summary>
        private void InitialScreen()
        {
            HomeGameScreen();
            HomeGameComponents();

            pbBackGround.Controls.Add(plGamePage);
        }

        private void HomeGameScreen()
        {
            pbBackGround.Image = imgHome;

            isDemo = false;
            Controls.Remove(lblBack);
            Controls.Remove(lblSignout);

            plGamePage.Controls.Add(lblUserHeader);
            plGamePage.Controls.Add(lblTitle);
            plGamePage.Controls.Add(lblQuickDemo);
            plGamePage.Controls.Add(lblStartGame);
            plGamePage.Controls.Add(lblScores);
            plGamePage.Controls.Add(lblInstruction);
            plGamePage.Controls.Add(lblOption);
            plGamePage.Controls.Add(lblAbout);
            if (frmLoginForm.accActive) { plGamePage.Controls.Add(lblSignout); plGamePage.Controls.Remove(lblQuickDemo); }

            gameQuestion = null;
            randomQuestionIndex = null; gameTimeLimit = null; mobSwitcher = null;
            playerKey = null; mobExistence = null; mobNotChangeDirection = null; xBound = null; yBound = null; guideBorder = null;
            playerSpriteSheet = null; bulletSpriteSheet = null;
            rectMobs = null; rectWormholes = null;
            imgGameBox = null; imgPlayer = null; imgBullet = null; imgMob = null;
            rectWormholes = null;
            rectGameBox = Rectangle.Empty; rectPlayer = Rectangle.Empty; rectPlayerSafeBox = Rectangle.Empty; rectBullet = Rectangle.Empty; rectQuestion = Rectangle.Empty;
            lblOption.Enabled = false;
        }

        private void HomeGameComponents()
        {
            if (!isHomeInstance)
            {
                isHomeInstance = true;
                lvTopScores = Utilities.AddListView(ref lvTopScores, new Rectangle(150, 100, 1000, 410));
                lvPlayerScores = Utilities.AddListView(ref lvPlayerScores, new Rectangle(150, 100, 1000, 410));
                lblGameHeader = Utilities.AddLabel(ref lblGameHeader, new Point(0, 15), new Size(0, 0), 12, false, ContentAlignment.MiddleCenter);
                lblScoreInfo = Utilities.AddLabel(ref lblScoreInfo, new Point(Size.Width / 2 - 200, 60), new Size(400, 30), 14, false, ContentAlignment.MiddleCenter);
                lblPause = Utilities.AddLabel(ref lblPause, new Point(15, 15), new Size(0, 0), 7, false, ContentAlignment.MiddleCenter);
                lblEasy = Utilities.AddLabel(ref lblEasy, new Point(0, 110), new Size(0, 0), 16, false, ContentAlignment.MiddleCenter);
                lblNormal = Utilities.AddLabel(ref lblNormal, new Point(0, 230), new Size(0, 0), 16, false, ContentAlignment.MiddleCenter);
                lblHard = Utilities.AddLabel(ref lblHard, new Point(0, 350), new Size(0, 0), 16, false, ContentAlignment.MiddleCenter);
                lblInsane = Utilities.AddLabel(ref lblInsane, new Point(0, 470), new Size(0, 0), 16, false, ContentAlignment.MiddleCenter);
                cbScoreList = Utilities.AddComboBox(ref cbScoreList, new Point(990, 520), new Size(160, 25));
                lblInfo = Utilities.AddLabel(ref lblInfo, new Point(150, 100), new Size(1000, 400), 13, false, ContentAlignment.TopCenter);
                defaultAlign = new StringFormat();

                lblGameHeader.Size = new Size(Width, 20);
                lblPause.Size = new Size(20, 25);
                lblEasy.Size = new Size(Width, 50);
                lblNormal.Size = new Size(Width, 50);
                lblHard.Size = new Size(Width, 50);
                lblInsane.Size = new Size(Width, 50);
                
                defaultAlign.LineAlignment = StringAlignment.Center;
                defaultAlign.Alignment = StringAlignment.Center;

                lblPause.BorderStyle = BorderStyle.FixedSingle;
                cbScoreList.Items.Add("Easy");
                cbScoreList.Items.Add("Normal");
                cbScoreList.Items.Add("Hard");
                cbScoreList.Items.Add("Insane");

                lblEasy.Click += lblEasy_Click;
                lblEasy.MouseEnter += lblEasy_MouseEnter;
                lblEasy.MouseLeave += lblEasy_MouseLeave;
                lblNormal.Click += lblNormal_Click;
                lblNormal.MouseEnter += lblNormal_MouseEnter;
                lblNormal.MouseLeave += lblNormal_MouseLeave;
                lblHard.Click += lblHard_Click;
                lblHard.MouseEnter += lblHard_MouseEnter;
                lblHard.MouseLeave += lblHard_MouseLeave;
                lblInsane.Click += lblInsane_Click;
                lblInsane.MouseEnter += lblInsane_MouseEnter;
                lblInsane.MouseLeave += lblInsane_MouseLeave;
                lblPause.Click += lblPause_Click;
                lblPause.MouseEnter += lblPause_MouseEnter;
                lblPause.MouseLeave += lblPause_MouseLeave;
                lvTopScores.ColumnWidthChanging += lvTopScores_ColumnWidthChanging;
                lvPlayerScores.ColumnWidthChanging += lvPlayerScores_ColumnWidthChanging;
                cbScoreList.SelectedIndexChanged += cbScoreList_SelectedIndexChanged;
            }
            lblPause.Text = "||";
            lblEasy.Text = "Easy";
            lblNormal.Text = "Normal";
            lblHard.Text = "Hard";
            lblInsane.Text = "Insane";
            cbScoreList.Text = "Easy";
            lblScoreInfo.Text = "Top Scorers In [" + cbScoreList.Text + "] Game Mode:";
        }

        /// <summary>
        /// Game Stage Stuff
        /// </summary>
        private void GameStageComponents()
        {
            Utilities.query = "SELECT ProgressNumber FROM tbgameusers WHERE Username = '" + currentUser + "'";
            playerStage = isDemo ? 1 : Convert.ToInt16(Utilities.DBRead());
            playerStageChosen = 0;
            playerKills = 0;
            playerLevel = 0;
            playerScore = 0;
            directionId = 0;
            mobId = 0;
            perMobScore = 0;
            wormholeScore = 0;
            guideProgress = 1;

            gameGuideLines = (isDemo || playerStage == 1) ? File.ReadAllLines(Utilities.getDefPath + "/res/txt/guide.txt") : null;
            if (isDemo || playerStage == 1)
            {
                guideBorder = new int[4];
                string[] temp = gameGuideLines[0].Split(',');
                for (int i = 0; i < temp.Length; i++)
                {
                    guideBorder[i] = Convert.ToInt32(temp[i]);
                }
            }

            bool[] isUnlock = new bool[4];

            for (int i = 4; i > playerStage; i--)
            {
                isUnlock[i - 1] = true;
            }

            lblEasy.Enabled = !isUnlock[0];
            lblNormal.Enabled = !isUnlock[1];
            lblHard.Enabled = !isUnlock[2];
            lblInsane.Enabled = !isUnlock[3];

            lblGameHeader.Text = "Hey" + lblUserHeader.Text.Remove(0, isDemo ? 14 : 13) + "!, Please Choose A Stage You Have Unlocked And Click It!";

            plGamePage.Controls.Add(lblGameHeader);
            plGamePage.Controls.Add(lblEasy);
            plGamePage.Controls.Add(lblNormal);
            plGamePage.Controls.Add(lblHard);
            plGamePage.Controls.Add(lblInsane);
        }

        private bool GameStageChosen()
        {
            playerSprite = "Player1";
            bulletSprite = "Bullet1";
            mobSprite = "Mob1";

            if (Utilities.CountQuestion(gameDifficulty) == 0)
            {
                MessageBox.Show("Insufficient Game Resources..", "Load Game Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gamePageIndex = 0;
                CleanAndUpdate();
                return false;
            }

            playerGameLevelPeak = playerGameLevelPeak < Utilities.CountQuestion(gameDifficulty) ? playerGameLevelPeak : Utilities.CountQuestion(gameDifficulty);
            randomQuestionIndex = Utilities.GetRandomIndex(ref randomQuestionIndex, playerGameLevelPeak, gameDifficulty);
            gameQuestion = Utilities.GetGameQuestion(ref gameQuestion, gameDifficulty);
            gameTimeLimit = new int[2];

            switch (gameDifficulty)
            {
                case "Easy":
                    playerMaxHealth = 3;
                    gameTimeLimit[0] = 30;
                    gameTimeLimit[1] = 2;
                    playerStageChosen = 1;
                    break;
                case "Normal":
                    playerMaxHealth = 4;
                    gameTimeLimit[0] = 0;
                    gameTimeLimit[1] = 4;
                    playerStageChosen = 2;
                    break;
                case "Hard":
                    playerMaxHealth = 5;
                    gameTimeLimit[0] = 30;
                    gameTimeLimit[1] = 5;
                    playerStageChosen = 3;
                    break;
                case "Insane":
                    playerMaxHealth = 6;
                    gameTimeLimit[0] = 0;
                    gameTimeLimit[1] = 7;
                    playerStageChosen = 4;
                    break;
            }

            playerHealth = playerMaxHealth;
            playerX = random.Next(20, 180) * 5;
            playerY = random.Next(20, 100) * 5;
            playerWidth = 60;
            playerHeight = 40;
            playerSpriteSheet = Utilities.GetEntitySpriteSheet(playerSprite, gameDirection, ".png");
            bulletSpriteSheet = Utilities.GetEntitySpriteSheet(bulletSprite, gameDirection, ".png");

            imgGameBox = Image.FromFile(Utilities.getDefGameImgPath + "GameBox.png");
            imgPlayer = playerSpriteSheet[0];
            imgMob = Image.FromFile(Utilities.getDefGameImgPath + mobSprite + ".png");

            rectWormholes = new Rectangle[4];

            rectGameBox = new Rectangle(50, 75, Size.Width - 100, Size.Height - 100);
            rectQuestion = new Rectangle((rectGameBox.Size.Width / 2 - questionWidth / 2) + rectGameBox.Location.X, (rectGameBox.Size.Height / 2 - questionHeight / 2) + rectGameBox.Location.Y, questionWidth, questionHeight);

            for (int i = 0; i < rectWormholes.Length; i++)
            {
                rectWormholes[i] = new Rectangle(i % 2 == 0 ? rectQuestion.Location.X - wormholeSize - 20 : (rectQuestion.Location.X + rectQuestion.Size.Width) + 20, i > 1 ? rectQuestion.Location.Y + rectQuestion.Size.Height - (wormholeSize / 2) : rectQuestion.Location.Y - (wormholeSize / 2), wormholeSize, wormholeSize);
            }
            for (int i = 0; i < rectWormholes.Length; i++)
            {
                if (rectWormholes[i].IntersectsWith(new Rectangle(playerX, playerY, playerWidth, playerHeight)))
                {
                    playerX = random.Next(20, 180) * 5;
                    playerY = random.Next(20, 100) * 5;
                    i = -1;
                }
            }
            rectPlayer = new Rectangle(playerX, playerY, playerWidth, playerHeight);
            rectPlayerSafeBox = new Rectangle(playerX - 100, playerY - 100, playerWidth + 200, playerHeight + 200);

            if (!isGameInstance)
            {
                lblPlayerLocation = Utilities.AddLabel(ref lblPlayerLocation, new Point(1100, 30), new Size(200, 30), 12, false, ContentAlignment.MiddleLeft);
                lblPlayerScore = Utilities.AddLabel(ref lblPlayerScore, new Point(300, 30), new Size(200, 30), 12, false, ContentAlignment.MiddleLeft);
                lblPlayerHealth = Utilities.AddLabel(ref lblPlayerHealth, new Point(50, 30), new Size(150, 30), 12, false, ContentAlignment.MiddleLeft);
                lblTimeLimit = Utilities.AddLabel(ref lblTimeLimit, new Point(575, 30), new Size(150, 30), 12, false, ContentAlignment.MiddleLeft);
                lblGameSpeed = Utilities.AddLabel(ref lblGameSpeed, new Point(850, 30), new Size(150, 30), 12, false, ContentAlignment.MiddleLeft);
                isGameInstance = true;
            }

            lblPlayerHealth.Text = "Health : " + playerHealth + " / " + playerMaxHealth;
            lblPlayerScore.Text = "Your Score: " + playerScore;
            lblPlayerLocation.Text = "X: " + playerX + " | Y: " + playerY;

            if (!isDemo && playerStage != 1) playerKey = new bool[300];
            GetMobs();

            playerBlink = null;
            bulletFired = false;
            isLevelCleared = false;
            isPause = false;
            enableBullet = false;
            isGameOver = false;
            plGamePage.Paint += plGamePage_Paint;
            plMobPlane.Paint += plMobPlane_Paint;
            pbBackGround.Image = imgInGame;
            return true;
        }

        /// <summary>
        /// Main Game Stuff
        /// </summary>
        private void MainGameScreen()
        {
            isTimeUp = true;
            playerDamaged = false;
            mobExplode = false;
            blinkChoice = false;

            gamePageIndex = 6;
            CleanAndUpdate();

            if (playerLevel > 0)
            {
                GetDelay("DelayScore");
            }

            if (playerLevel == playerGameLevelPeak)
            {
                isTimeUp = true;
                playerScore += (gameTimeLimit[1] * 60) + gameTimeLimit[0];
                MessageBox.Show("Congratulations! You Have Found The Earth! \n\nTotal Score: " + playerScore);
                if (playerStageChosen == playerStage) playerStage++;
                playerStage = playerStage > 4 ? 4 : playerStage;
                if (!isDemo) MainGameEnded();
                gamePageIndex = 0;
                CleanAndUpdate();
                return;
            }

            plGamePage.Controls.Add(plMobPlane);
            plMobPlane.SendToBack();

            pbBackGround.Controls.Add(lblPause);
            pbBackGround.Controls.Add(lblPlayerLocation);
            pbBackGround.Controls.Add(lblPlayerScore);
            pbBackGround.Controls.Add(lblPlayerHealth);
            pbBackGround.Controls.Add(lblTimeLimit);
            pbBackGround.Controls.Add(lblGameSpeed);

            lblPause.BringToFront();
            lblPlayerLocation.BringToFront();
            lblPlayerScore.BringToFront();
            lblPlayerHealth.BringToFront();
            lblTimeLimit.BringToFront();
            lblGameSpeed.BringToFront();

            subThread = new Thread(CallAllThread);
            subThread.IsBackground = true;
            subThread.Start();

            if (containsWormhole) GetDelay("DelayWormhole");

            plGamePage.Invalidate();
            plMobPlane.Invalidate();
        }

        private void MainGameEnded()
        {
            Utilities.query = "INSERT INTO tbgamerecords VALUES ('" + Utilities.GeneratePK("R-", "tbgamerecords", 5) + "',";
            Utilities.query += "'" + currentUser + "',";
            Utilities.query += "'" + playerScore + "',";
            Utilities.query += "'" + gameDifficulty + "',";
            Utilities.query += "'" + DateTime.Now.ToLongDateString() + "')";

            Utilities.DBCreate();

            Utilities.query = "UPDATE tbgameusers SET ProgressNumber = " + playerStage + " WHERE Username = '" + currentUser + "'";
            Utilities.DBUpdate();

            SetHighScore();
        }

        private void SetHighScore()
        {
            Utilities.query = "SELECT COUNT(*) FROM tbgamehighscores INNER JOIN tbgameusers ON tbgamehighscores.Username = tbgameusers.Username INNER JOIN tbgamerecords ON tbgamehighscores.RecordID = tbgamerecords.RecordID WHERE tbgamehighscores.Username = '" + currentUser + "' AND tbgamerecords.Difficulty = '" + gameDifficulty + "'";
            bool ifHighScoreExists = Convert.ToInt16(Utilities.DBRead()) == 0 ? false : true;
            Utilities.query = "SELECT tbgamerecords.RecordID FROM tbgamerecords INNER JOIN tbgameusers ON tbgameusers.Username = tbgamerecords.Username WHERE tbgamerecords.Username = '" + currentUser + "' AND tbgamerecords.Difficulty = '" + gameDifficulty + "' ORDER BY tbgamerecords.Score DESC";
            string highestID = Utilities.DBRead();

            if (ifHighScoreExists)
            {
                MessageBox.Show("UPDATE: " + highestID);
                Utilities.query = "UPDATE tbgamehighscores SET RecordID = '" + highestID + "' WHERE Username = '" + currentUser + "'";
                Utilities.DBUpdate();
            }
            else if (!ifHighScoreExists)
            {
                MessageBox.Show("INSERT: " + highestID);
                Utilities.query = "INSERT INTO tbgamehighscores VALUES ('" + Utilities.GeneratePK("H-", "tbgamehighscores", 5) + "', '" + currentUser + "', '" + highestID + "')";
                Utilities.DBCreate();
            }
        }

        /// <summary>
        /// Entity Stuffs
        /// </summary>
        private void UpdatePlayer()
        {
            if (playerKey == null) return;

            GetPlayerCollisionToMob();
            if (!isLevelCleared) GetPlayerCollisionToAsteroid();
            if (isGameOver) return;

            if (playerKey[Convert.ToInt16(Keys.W)]) { playerY -= 5; directionId = 0; rectPlayer.Size = new Size(playerWidth, playerHeight); }
            else if (playerKey[Convert.ToInt16(Keys.S)]) { playerY += 5; directionId = 1; rectPlayer.Size = new Size(playerWidth, playerHeight); }
            else if (playerKey[Convert.ToInt16(Keys.A)]) { playerX -= 5; directionId = 2; rectPlayer.Size = new Size(playerHeight, playerWidth); }
            else if (playerKey[Convert.ToInt16(Keys.D)]) { playerX += 5; directionId = 3; rectPlayer.Size = new Size(playerHeight, playerWidth); }

            if (playerY < rectGameBox.Y + 15) playerY = rectGameBox.Y + 15;
            else if (playerY > (rectGameBox.Y + rectGameBox.Height - 15) - rectPlayer.Height) playerY = (rectGameBox.Y + rectGameBox.Height - 15) - rectPlayer.Height;

            if (playerX < rectGameBox.X + 20) playerX = rectGameBox.X + 20;
            else if (playerX > (rectGameBox.X + rectGameBox.Width - 20) - rectPlayer.Width) playerX = (rectGameBox.X + rectGameBox.Width- 20) - rectPlayer.Width;

            imgPlayer = playerSpriteSheet[directionId];
            rectPlayer.Location = new Point(playerX, playerY);

            lblPlayerHealth.Text = "Health : " + playerHealth + " / " + playerMaxHealth;
            lblPlayerLocation.Text = "X: " + playerX + " | Y: " + playerY;

            if (playerKills == mobSpawnNumber) GetPlayerCollisionToWormhole();
            if (!bulletFired && playerBlink == null) plGamePage.Invalidate(false);
        }

        private void UpdateBullet()
        {
            if (!bulletFired) return;

            switch (bulletDirection)
            {
                case "_Up":
                    if (rectBullet.Y > rectGameBox.Y) rectBullet.Y -= 5; else { bulletFired = false; bulletThread.Abort(); }
                    break;
                case "_Down":
                    if (rectBullet.Y < (rectGameBox.Y + rectGameBox.Height) - rectBullet.Height) rectBullet.Y += 5; else { bulletFired = false; bulletThread.Abort(); }
                    break;
                case "_Left":
                    if (rectBullet.X > rectGameBox.X) rectBullet.X -= 5; else { bulletFired = false; bulletThread.Abort(); }
                    break;
                case "_Right":
                    if (rectBullet.X < (rectGameBox.X + rectGameBox.Width) - rectBullet.Width) rectBullet.X += 5; else { bulletFired = false; bulletThread.Abort(); }
                    break;
            }
            GetBulletCollisionToMob();
            if (playerBlink == null) plGamePage.Invalidate(false);
        }

        private void UpdateMob(int mobId)
        {
            int mobX = rectMobs[mobId].Location.X, mobY = rectMobs[mobId].Location.Y;

            if (!mobExistence[mobId]) return;
            
            switch (Math.Abs(mobSwitcher[mobId] % 4))
            {
                case 0:
                    if (mobY > rectGameBox.Location.Y + 20 && !yBound[mobId]) { mobY -= 10; }
                    else if (mobY <= rectGameBox.Location.Y + 20 && !yBound[mobId]) { yBound[mobId] = true; mobY += 10; }

                    if (mobY < (rectGameBox.Location.Y + rectGameBox.Size.Height) - rectMobs[mobId].Size.Height - 20 && yBound[mobId]) { mobY += 10; }
                    else if (mobY >= rectGameBox.Size.Height - rectMobs[mobId].Size.Height - 20 && yBound[mobId]) { yBound[mobId] = false; mobY -= 10; }
                    break;
                case 3:
                    if (mobY < (rectGameBox.Location.Y + rectGameBox.Size.Height) - rectMobs[mobId].Size.Height - 20 && !yBound[mobId]) { mobY += 10; }
                    else if (mobY >= rectGameBox.Size.Height - rectMobs[mobId].Size.Height - 20 && !yBound[mobId]) { yBound[mobId] = true; mobY -= 10; }

                    if (mobY > rectGameBox.Location.Y + 20 && yBound[mobId]) { mobY -= 10; }
                    else if (mobY <= rectGameBox.Location.Y + 20 && yBound[mobId]) { yBound[mobId] = false; mobY += 10; }
                    break;
                case 2:
                    if (mobX > rectGameBox.Location.X + 20 && !xBound[mobId]) { mobX -= 10; }
                    else if (mobX <= rectGameBox.Location.X + 20 && !xBound[mobId]) { xBound[mobId] = true; mobX += 10; }

                    if (mobX < (rectGameBox.Location.X + rectGameBox.Size.Width) - rectMobs[mobId].Size.Width - 20 && xBound[mobId]) { mobX += 10; }
                    else if (mobX >= rectGameBox.Size.Width - rectMobs[mobId].Size.Width - 20 && xBound[mobId]) { xBound[mobId] = false; mobX -= 10; }
                    break;
                case 1:
                    if (mobX < (rectGameBox.Location.X + rectGameBox.Size.Width) - rectMobs[mobId].Size.Width - 20 && !xBound[mobId]) { mobX += 10; }
                    else if (mobX >= rectGameBox.Size.Width - rectMobs[mobId].Size.Width - 20 && !xBound[mobId]) { xBound[mobId] = true; mobX -= 10; }

                    if (mobX > rectGameBox.Location.X + 20 && xBound[mobId]) { mobX -= 10; }
                    else if (mobX <= rectGameBox.Location.X + 20 && xBound[mobId]) { xBound[mobId] = false; mobX += 10; }
                    break;
            }
            rectMobs[mobId].Location = new Point(mobX, mobY);
            plMobPlane.Invalidate();
        }

        /// <summary>
        /// Getter Stuffs
        /// </summary>
        private void GetMobs()
        {
            rectMobs = null;
            mobExistence = null;

            playerKills = 0;

            rectMobs = new Rectangle[mobSpawnNumber];
            mobExistence = new bool[rectMobs.Length];

            for (int i = 0; i < rectMobs.Length; i++)
            {
                int mobX = (random.Next((rectGameBox.X + 50) / 5, (rectGameBox.Width - 50) / 5) * 5 + rectGameBox.X) - mobSize, mobY = (random.Next((rectGameBox.Y + 20) / 5, (rectGameBox.Height - 20) / 5) * 5 + rectGameBox.Y) - mobSize;
                for (int j = 0; j < i; j++)
                {
                    Rectangle rectTemp = new Rectangle(mobX, mobY, mobSize, mobSize);
                    if (rectMobs[j].IntersectsWith(rectTemp) || rectTemp.IntersectsWith(rectPlayerSafeBox))
                    {
                        mobX = (random.Next(rectGameBox.X / 5, rectGameBox.Width / 5) * 5 + rectGameBox.X) - mobSize;
                        mobY = (random.Next(rectGameBox.Y / 5, rectGameBox.Height / 5) * 5 + rectGameBox.Y) - mobSize;
                        j = -1;
                    }
                }
                rectMobs[i] = new Rectangle(mobX, mobY, mobSize, mobSize);
                mobExistence[i] = true;
            }
        }

        private void GetWormholes()
        {
            pbWormholes = null;
            
            pbWormholes = new PictureBox[4];

            for (int i = 0; i < rectWormholes.Length; i++)
            {
                pbWormholes[i] = Utilities.AddPictureBox(ref pbWormholes[i], rectWormholes[i].Location, rectWormholes[i].Size);
                pbWormholes[i].Image = imgWormhole;
                pbWormholes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Controls.Add(pbWormholes[i]);
                pbWormholes[i].BringToFront();
            }
            containsWormhole = true;
            GetDelay("DelayWormhole");
        }
        
        private void GetScore(string scoreType)
        {
            if (scoreType == "Mobs")
            {
                switch (gameDifficulty)
                {
                    case "Easy":
                        playerScore += (perMobScore = 4);
                        break;
                    case "Normal":
                        playerScore += (perMobScore = 6);
                        break;
                    case "Hard":
                        playerScore += (perMobScore = 8);
                        break;
                    case "Insane":
                        playerScore += (perMobScore = 10);
                        break;
                }
            }
            else if (scoreType == "Wormhole")
            {
                switch (gameDifficulty)
                {
                    case "Easy":
                        CompareAnswer(10);
                        break;
                    case "Normal":
                        CompareAnswer(20);
                        break;
                    case "Hard":
                        CompareAnswer(30);
                        break;
                    case "Insane":
                        CompareAnswer(40);
                        break;
                }
                playerAnswer = "";
            }
            lblPlayerScore.Text = "Your Score: " + (playerScore = playerScore < 0 ? 0 : playerScore);
        }

        private void GetBulletCollisionToMob()
        {
            for (int i = 0; i < mobExistence.Length; i++)
            {
                if (rectBullet.IntersectsWith(rectMobs[i]) && mobExistence[i])
                {
                    if ((isDemo || playerStage == 1) && playerKills == 0) { continueGuide[guideBorder[3]] = bulletFired; guideProgress++; }
                    mobExistence[i] = false;
                    bulletFired = false;
                    playerKills++;
                    bulletThread.Abort();
                    GetScore("Mobs");
                    mobId = i;
                    mobExplode = true;
                    GetDelay("DelayScorePoints");
                    plGamePage.Invalidate();
                    if (playerStage == 1 && !gameTimerThread.IsAlive)
                    {
                        gameTimerThread = new Thread(ActivateGameTimer);
                        gameTimerThread.IsBackground = true; gameTimerThread.Name = "Timer";
                        gameTimerThread.Start();
                    }
                }
            }
            if (playerKills == mobSpawnNumber && !containsWormhole)
            {
                isLevelCleared = true;
                GetWormholes();
            }
        }

        private void GetPlayerCollisionToAsteroid()
        {
            if (!isGameOver)
            {
                for (int i = 0; i < rectWormholes.Length; i++)
                {
                    if (rectPlayer.IntersectsWith(rectWormholes[i]) && !playerDamaged && playerBlink == null)
                    {
                        playerHealth--;
                        playerDamaged = true;
                        playerBlink = !playerDamaged;
                        GetDelay("DelayPlayerHealth");
                        break;
                    }
                }
            }
        }

        private void GetPlayerCollisionToWormhole()
        {
            if (isLevelCleared || isTimeUp)
            {
                if (!isTimeUp)
                {
                    for (int i = 0; i < pbWormholes.Length; i++)
                    {
                        if (rectPlayer.IntersectsWith(pbWormholes[i].Bounds))
                        {
                            playerKills = 0;
                            for (int j = 0; j < rectWormholes.Length; j++)
                            {
                                playerX = random.Next(20, 180) * 5; playerY = random.Next(20, 100) * 5;
                                if (rectWormholes[j].IntersectsWith(new Rectangle(playerX, playerY, playerWidth, playerHeight)))
                                {
                                    playerX = random.Next(20, 180) * 5; playerY = random.Next(20, 100) * 5;
                                    j = -1;
                                }
                            }
                            rectPlayer.Location = new Point(playerX, playerY);
                            gamePageIndex = 7;
                            CleanAndUpdate();
                            pbBackGround.Image = imgPortal;
                            playerAnswer = gameChoices[i];
                            isLevelCleared = false;
                            containsWormhole = false;
                            isTimeUp = true;
                            for (int j = 0; j < pbWormholes.Length; j++)
                            {
                                pbWormholes[j].Image = null;
                                pbWormholes[j].Dispose();
                            }
                            GetScore("Wormhole");
                            mobSpawnNumber += playerLevel % 2 == 0 ? 1 : 0;
                            subThread.Abort();
                            playerThread.Abort();
                            if (bulletThread.IsAlive) bulletThread.Abort();
                            gameTimerThread.Abort();
                            if (!isDemo && playerStage != 1) mobThread.Abort();
                            if (isDemo || playerStage == 1) guideThread.Abort();
                            playerLevel++;
                            GetDelay("DelayWormholeAnimationAndScore");
                            plGamePage.Invalidate();
                            break;
                        }
                    }
                }
                else
                {
                    gamePageIndex = 7;
                    CleanAndUpdate();

                    subThread.Abort();
                    playerThread.Abort();
                    if (bulletThread.IsAlive) bulletThread.Abort();
                    gameTimerThread.Abort();
                    if (!isDemo || playerStage != 1) mobThread.Abort();
                    if (isDemo || playerStage == 1) guideThread.Abort();
                }
            }
        }

        private void GetPlayerCollisionToMob()
        {
            if (!isGameOver)
            {
                for (int i = 0; i < rectMobs.Length; i++)
                {
                    if (rectMobs[i].IntersectsWith(rectPlayer) && mobExistence[i] && !playerDamaged && playerBlink == null)
                    {
                        playerHealth--;
                        playerDamaged = true;
                        playerBlink = !playerDamaged;
                        GetDelay("DelayPlayerHealth");
                        break;
                    }
                }
                if (playerHealth == 0)
                {
                    isGameOver = true;
                    subThread.Abort();
                    playerThread.Abort();
                    if (bulletThread.IsAlive) bulletThread.Abort();
                    gameTimerThread.Abort();
                    if (!isDemo && playerStage != 1) mobThread.Abort();
                    if (isDemo || playerStage == 1) guideThread.Abort();

                    MessageBox.Show("Game Over.., Your Total Score : " + playerScore);

                    for (int j = 0; j < mobExistence.Length; j++)
                    {
                        mobExistence[j] = false;
                    }
                    MainGameEnded();
                    gamePageIndex = 7;
                    CleanAndUpdate();
                    gamePageIndex = 0;
                    CleanAndUpdate();
                    return;
                }
            }
        }

        private bool GetConfirm()
        {
            var message = MessageBox.Show("Are you sure you want to select this level?", "Level Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.No) return false;
            return true;
        }

        private long GetNanoTime()
        {
            return DateTime.Now.ToFileTime() * 50;
        }

        private void GetBulletDirection()
        {
            int bulletSize = 20;

            switch (bulletDirection)
            {
                case "_Up":
                    rectBullet = new Rectangle(rectPlayer.X + ((rectPlayer.Width / 2) - bulletSize / 2), rectPlayer.Y - bulletSize, bulletSize, bulletSize);
                    break;
                case "_Down":
                    rectBullet = new Rectangle(rectPlayer.X + ((rectPlayer.Width / 2) - bulletSize / 2), rectPlayer.Y + rectPlayer.Height + bulletSize, bulletSize, bulletSize);
                    break;
                case "_Left":
                    rectBullet = new Rectangle(rectPlayer.X - bulletSize, rectPlayer.Y + ((rectPlayer.Height / 2) - bulletSize / 2), bulletSize, bulletSize);
                    break;
                case "_Right":
                    rectBullet = new Rectangle(rectPlayer.X + rectPlayer.Width, rectPlayer.Y + ((rectPlayer.Height / 2) - bulletSize / 2), bulletSize, bulletSize);
                    break;
            }
            imgBullet = bulletSpriteSheet[directionId];
        }

        private void GetDelay(string whatDelay)
        {
            if (isLevelCleared && whatDelay == "DelayWormhole")
            {
                new Thread(() =>
                {
                    long lastTime = GetNanoTime(), now, delay = 0;

                    while (Controls.Contains(pbWormholes[0]))
                    {
                        do
                        {
                            now = GetNanoTime();
                            delay += now - lastTime;
                            lastTime = now;
                        } while (delay < 300000000);
                        blinkChoice = !blinkChoice;
                        delay = 0;
                        Console.WriteLine("Blinking Number!");
                    }
                }).Start();
            }
            else if (whatDelay == "DelayScore")
            {
                new Thread(() =>
                {
                    lblPlayerScore.ForeColor = wormholeScore > 0 ? Color.Lime : Color.Red;
                    Thread.Sleep(2000);
                    lblPlayerScore.ForeColor = lblPlayerLocation.ForeColor;
                }).Start();
            }
            else if (whatDelay == "DelayScorePoints")
            {
                new Thread(() =>
                {
                    lblPlayerScore.ForeColor = Color.Lime;
                    Thread.Sleep(1000);
                    mobExplode = false; lblPlayerScore.ForeColor = lblPlayerLocation.ForeColor;
                }).Start();
            }
            else if(whatDelay == "DelayWormholeAnimationAndScore")
            {
                new Thread(() =>
                {
                    Thread.Sleep(2500);
                    GetMobs();
                    pbBackGround.Image = null;
                    pbBackGround.Image = imgInGame;
                    Invoke(new Action(() => MainGameScreen()));
                    showWormholeScore = true;

                    Thread.Sleep(1500);
                    showWormholeScore = false;
                }).Start();
            }
            else if(whatDelay == "DelayPlayerHealth")
            {
                new Thread(() =>
                {
                    lblPlayerHealth.ForeColor = Color.Red;
                    Thread.Sleep(2000);
                    lblPlayerHealth.ForeColor = lblPlayerLocation.ForeColor;
                    playerDamaged = false;
                }).Start();
            }
        }

        /// <summary>
        /// Thread Stuffs
        /// </summary>
        private void ActivatePlayer()
        {
            int fps = 80, delay = 0;
            double timeperUpdate = 1000000000 / fps;
            double delta = 0;
            long lastTime = GetNanoTime(), now, ticker = 0;

            while (!isGameOver)
            {
                now = GetNanoTime();
                delta += (now - lastTime) / timeperUpdate;
                ticker += now - lastTime;
                lastTime = now;

                if (delta >= 1)
                {
                    Invoke(new Action(UpdatePlayer));
                    delta--;
                }
                if (ticker >= 100000000 && playerBlink != null)
                {
                    ticker = 0;
                    if (delay != 10)
                    {
                        delay++;
                        plGamePage.Invalidate();
                    }
                    else
                    {
                        delay = 0;
                        playerBlink = null;
                    }
                }
            }
        }

        private void ActivateBullet()
        {
            int fps = 90;
            double timeperUpdate = 1000000000 / fps;
            double delta = 0;
            long lastTime = GetNanoTime(), now;

            while (!isGameOver)
            {
                now = GetNanoTime();
                delta += (now - lastTime) / timeperUpdate;
                lastTime = now;

                if (delta >= 1)
                {
                    Invoke(new Action(UpdateBullet));
                    delta--;
                }
            }
        }

        private void ActivateMob(int ctr)
        {
            int[] otherDirection = { 1, 2, 3, 4};
            mobSwitcher = new int[mobSpawnNumber];
            mobNotChangeDirection = new bool[mobSpawnNumber];

            int fps = 0, changeDirectionDelay = 0, gameSpeed = 0;
            if (gameDifficulty == "Easy") { fps = 50; } else if (gameDifficulty == "Normal") { fps = 80; } else if (gameDifficulty == "Hard") { fps = 170; } else { fps = 230; }
            if (mobSpawnNumber >= 4 && fps == 50) { fps = 70; } else if (mobSpawnNumber > 4 && fps == 80) { fps = 90; }
            double timeperUpdate = 1000000000 / fps;
            double delta = 0;
            long lastTime = GetNanoTime(), now, ticker = 0, gameSpeedMeasurer = 0;

            while (!isGameOver)
            {
                now = GetNanoTime();
                delta += (now - lastTime) / timeperUpdate;
                ticker += now - lastTime;
                gameSpeedMeasurer += now - lastTime;
                lastTime = now;

                if (delta >= 1)
                {
                    Invoke(new Action(() => UpdateMob(ctr)));
                    delta--;
                    gameSpeed++;
                    ctr = ctr < mobSpawnNumber - 1 ? ctr + 1 : 0;
                    if (ticker >= 50000000)
                    {
                        ticker = 0;
                        if (bulletFired)
                        {
                            new Thread(() =>
                            {
                                for (int i = 0; i < mobSpawnNumber; i++)
                                {
                                    int index = i;
                                    if (!mobExistence[index]) continue;
                                    Rectangle temp = new Rectangle(rectMobs[index].Location.X - 30, rectMobs[index].Location.Y - 30, rectMobs[index].Size.Width + 60, rectMobs[index].Size.Height + 60);
                                    if (rectBullet.IntersectsWith(temp) && bulletFired)
                                    {
                                        mobNotChangeDirection[index] = true;
                                        //mobSwitcher[index] = bulletDirection == gameDirection[0] || bulletDirection == gameDirection[1] ? random.Next(2) : random.Next(2, 4);
                                        if (bulletDirection == gameDirection[2] || bulletDirection == gameDirection[3]) if (temp.Location.Y + (temp.Size.Height / 2) > rectBullet.Location.Y + (rectBullet.Size.Height / 2)) { mobSwitcher[index] = 1; otherDirection = new int[]{ 1, 2, 3}; } else { mobSwitcher[index] = 0; otherDirection = new int[] { 0, 2, 3}; }
                                        if (bulletDirection == gameDirection[0] || bulletDirection == gameDirection[1]) if (temp.Location.X + (temp.Size.Width / 2) > rectBullet.Location.X + (rectBullet.Size.Width / 2)) { mobSwitcher[index] = 3; otherDirection = new int[] { 0, 1, 3}; } else { mobSwitcher[index] = 2; otherDirection = new int[] { 1, 2, 0}; }
                                        Console.WriteLine("Mob #" + index + " Changed To : " + gameDirection[mobSwitcher[index]]);
                                    }
                                }
                            }).Start();
                        } else
                        {

                        }
                        if (changeDirectionDelay != mobSpawnNumber)
                        {
                            mobSwitcher[changeDirectionDelay] = mobNotChangeDirection[changeDirectionDelay] ? mobSwitcher[changeDirectionDelay] : otherDirection[random.Next(otherDirection.Length)];
                            mobNotChangeDirection[changeDirectionDelay] = false;
                            changeDirectionDelay++;
                        }
                        else
                        {
                            changeDirectionDelay = 0;
                        }
                    }
                }
                if (gameSpeedMeasurer >= 1000000000)
                {
                    Invoke(new Action(() => lblGameSpeed.Text = "FPS : " + gameSpeed));
                    gameSpeed = 0;
                    gameSpeedMeasurer = 0;
                }
            }
        }

        private void ActivateGameTimer()
        {
            if (isDemo || playerStage == 1) Invoke(new Action(() => lblTimeLimit.Text = "Time : N/A"));

            isTimeUp = false;

            while (gameTimeLimit[1] >= 0 && gameTimeLimit[0] <= 60 && !isTimeUp && !isDemo || (playerStage == 1 && playerLevel > 1))
            {
                if (gameTimeLimit[1] <= 9 && gameTimeLimit[0] <= 9) Invoke(new Action(() => lblTimeLimit.Text = "Time : 0" + gameTimeLimit[1] + ":0" + gameTimeLimit[0]));
                if (gameTimeLimit[1] <= 9 && gameTimeLimit[0] > 9) Invoke(new Action(() => lblTimeLimit.Text = "Time : 0" + gameTimeLimit[1] + ":" + gameTimeLimit[0]));
                Thread.Sleep(1000);

                if (gameTimeLimit[1] == 0 && gameTimeLimit[0] == 0)
                {
                    isTimeUp = true;
                }

                if (gameTimeLimit[0] == 0)
                {
                    gameTimeLimit[1]--;
                    gameTimeLimit[0] = 60;
                }
                gameTimeLimit[0]--;
            }
        }

        /// <summary>
        /// Utility Stuffs
        /// </summary>
        private void plGamePage_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (gamePageIndex == 6)
            {
                if (isLevelCleared)
                {
                    g.DrawImage(Image.FromFile(Utilities.getDefPath + "/res/img/quest/" + gameQuestion[randomQuestionIndex[playerLevel], 0]), rectQuestion);
                    if (!blinkChoice)
                    {
                        for (int i = 0; i < pbWormholes.Length; i++)
                        {
                            g.DrawString(gameChoices[i], new Font("Consolas", 35, FontStyle.Bold), Brushes.PaleGoldenrod, new Point(pbWormholes[i].Location.X + 15, i < 2 ? pbWormholes[i].Location.Y + pbWormholes[i].Size.Height : pbWormholes[i].Location.Y - 55));
                        }
                    }
                } else
                {
                    for (int i = 0; i < rectWormholes.Length; i++)
                    {
                        g.DrawImage(imgAsteroid, rectWormholes[i]);
                    }
                }
                g.DrawImage(imgGameBox, rectGameBox);
                if (playerBlink == null) { g.DrawImage(imgPlayer, rectPlayer); } else { if (playerBlink == true) { playerBlink = false; g.DrawImage(imgPlayer, rectPlayer); } else playerBlink = true; }
                if (bulletFired) g.DrawImage(imgBullet, rectBullet);
                if (playerDamaged) g.DrawString("-1!", new Font("Consolas", 20, FontStyle.Regular), Brushes.Red, new Point(rectPlayer.Location.X, rectPlayer.Location.Y - 20));
                
                if (showWormholeScore) { g.DrawString(wormholeScore > 0 ? "+" + wormholeScore + "!" : wormholeScore + "!", new Font("Consolas", 20, FontStyle.Regular), wormholeScore > 0 ? Brushes.Lime : Brushes.Red, new Point(rectPlayer.Location.X, rectPlayer.Location.Y - 20)); }
            }
        }

        private void plMobPlane_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (gamePageIndex == 6)
            {
                RenderMobs(g);
                if ((isDemo || playerStage == 1) && !continueGuide[gameGuideLines.Length - 1] && playerLevel == 0)
                {
                    Rectangle rectGuide = new Rectangle(rectGameBox.Location.X + 200, rectGameBox.Location.Y + 15, 800, 100);
                    g.DrawRectangle(new Pen(Brushes.PaleGoldenrod, 2), rectGuide);
                    g.DrawString((guideProgress == 1 || guideProgress == gameGuideLines.Length - 1 ? "" : "~ GameMaster ~\n\n-> ") + gameGuideLines[guideProgress], new Font("Consolas", 13, FontStyle.Bold), Brushes.PaleGoldenrod, rectGuide, defaultAlign);
                    plMobPlane.Invalidate();
                }
            }
        }

        private void RenderMobs(Graphics g)
        {
            if (!isLevelCleared)
            {
                for (int i = 0; i < rectMobs.Length; i++)
                {
                    int temp = i;
                    //Rectangle index = new Rectangle(rectMobs[temp].Location.X - 30, rectMobs[temp].Location.Y - 30, rectMobs[temp].Size.Width + 60, rectMobs[temp].Size.Height + 60);
                    if (mobExistence[temp])
                    {
                        //g.DrawRectangle(new Pen(Brushes.DarkBlue, 2), index);
                        g.DrawImage(imgMob, rectMobs[temp]);
                        //g.DrawString(temp.ToString(), new Font("Consolas", 20, FontStyle.Regular), Brushes.White, rectMobs[temp].Location);
                    }
                }
                if (mobExplode) g.DrawString("+" + perMobScore + "!", new Font("Consolas", 20, FontStyle.Regular), Brushes.Lime, rectMobs[mobId].Location);
            }
        }

        private void CompareAnswer(int answerScore)
        {
            playerScore = playerAnswer.Equals(gameQuestion[randomQuestionIndex[playerLevel], 1], StringComparison.OrdinalIgnoreCase) ? playerScore += (wormholeScore = answerScore) : playerScore += (wormholeScore = -answerScore);
        }

        private void CallAllThread()
        {
            playerThread = new Thread(ActivatePlayer);
            playerThread.IsBackground = true; playerThread.Name = "Player";

            bulletThread = new Thread(ActivateBullet);
            if (bulletFired)
            {
                bulletThread.IsBackground = true; bulletThread.Name = "Bullet";
                bulletThread.Start();
            }
            if (isTimeUp)
            {
                gameTimerThread = new Thread(ActivateGameTimer);
                gameTimerThread.IsBackground = true; gameTimerThread.Name = "Timer";
                gameTimerThread.Start();
            }

            if (!isDemo && playerStage != 1)
            {
                xBound = new bool[mobSpawnNumber];
                yBound = new bool[mobSpawnNumber];

                mobThread = new Thread(() => ActivateMob(0));
                mobThread.IsBackground = true;
                mobThread.Start();
            }
            playerThread.Start();
            if ((isDemo || playerStage == 1) && guideProgress != gameGuideLines.Length - 1)
            {
                continueGuide = new bool[gameGuideLines.Length];
                guideThread = new Thread(() => 
                {
                    for (int i = guideProgress; i < gameGuideLines.Length; i++)
                    {
                        if (playerKills != mobSpawnNumber && i < guideBorder[0])
                        {
                            long lastTime = GetNanoTime(), now, delay = 0;

                            guideProgress = i;
                            if (guideProgress == guideBorder[3]) { enableBullet = true; }
                            do
                            {
                                now = GetNanoTime();
                                delay += now - lastTime;
                                lastTime = now;
                            } while ((delay < (i < guideBorder[2] ? 1300000000 : 2300000000) && (!continueGuide[guideProgress + 1] || guideProgress == guideBorder[2])));
                            continueGuide[guideProgress + 1] = true;
                            if (guideProgress + 1 == guideBorder[2]) { continueGuide[guideProgress + 1] = true; playerKey = new bool[300]; }
                            continue;
                        }
                        if (playerKills == mobSpawnNumber)
                        {
                            i = i < guideBorder[0] ? guideBorder[0] : i;
                            long lastTime = GetNanoTime(), now, delay = 0;

                            guideProgress = i;
                            do
                            {
                                now = GetNanoTime();
                                delay += now - lastTime;
                                lastTime = now;
                            } while ((delay < (i > guideBorder[1] ? 1300000000 : 2300000000)));
                            continueGuide[guideProgress] = true;
                        }
                        else
                        {
                            i--;
                        }
                    }
                    guideThread.Abort();
                });
                guideThread.IsBackground = true;
                guideThread.Start();
            }
        }

        private void CleanAndUpdate()
        {
            plGamePage.Controls.Clear();
            
            switch (gamePageIndex)
            {
                case 0:
                    plGamePage.Paint -= plGamePage_Paint; plMobPlane.Paint -= plMobPlane_Paint;
                    HomeGameScreen();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    break;
                case 1:
                    plGamePage.Controls.Add(lblBack);
                    break;
                case 2:
                    plGamePage.Controls.Add(lblBack);
                    break;
                case 3:
                    plGamePage.Controls.Add(lblBack);
                    break;
                case 4:
                    plGamePage.Controls.Add(lblBack);
                    break;
                case 5:
                    plGamePage.Controls.Add(lblBack);
                    break;
                case 6:
                    plGamePage.Controls.Add(lblPause);
                    if (!isPause && playerKills == mobSpawnNumber)
                    {
                        for (int i = 0; i < pbWormholes.Length; i++)
                        {
                            int temp = i;
                            Console.WriteLine("Add");
                            //pbWormholes[temp].Image = imgWormhole;
                            Controls.Add(pbWormholes[temp]);
                            pbWormholes[temp].BringToFront();
                        }
                    }
                    break;
                case 7:
                    pbBackGround.Controls.Remove(lblPause);
                    pbBackGround.Controls.Remove(lblPlayerLocation);
                    pbBackGround.Controls.Remove(lblPlayerScore);
                    pbBackGround.Controls.Remove(lblPlayerHealth);
                    pbBackGround.Controls.Remove(lblTimeLimit);
                    pbBackGround.Controls.Remove(lblGameSpeed);
                    pbBackGround.Invalidate();
                    if (isPause && playerKills == mobSpawnNumber)
                    {
                        for (int i = 0; i < pbWormholes.Length; i++)
                        {
                            int temp = i;
                            Console.WriteLine("Removed");
                            //pbWormholes[temp].Image = null;
                            Controls.Remove(pbWormholes[temp]);
                        }
                        Console.WriteLine(pbWormholes.Length);
                    }
                    break;
            }
            
        }

        /// <summary>
        /// Clicks
        /// </summary>
        private void lblQuickDemo_Click(object sender, EventArgs e)
        {
            isDemo = true;
            gamePageIndex = 5;
            CleanAndUpdate();
            GameStageComponents();
        }

        private void lblStartGame_Click(object sender, EventArgs e)
        {
            if (!frmLoginForm.accActive)
            {
                frmLoginForm frmLogin = new frmLoginForm();
                frmLogin.ShowDialog();
            }
            if (frmLoginForm.accActive)
            {
                gamePageIndex = 5;
                if (plGamePage.Controls.Contains(lblSignout))
                {
                    CleanAndUpdate();
                    GameStageComponents();
                }
                else
                {
                    lblUserHeader.Text += currentUser;
                    lblStartGame.Text = "Play       ";
                    lblScores.Text = "Your Scores       ";
                    plGamePage.Controls.Add(lblSignout);
                    plGamePage.Controls.Remove(lblQuickDemo);
                }
            }
        }

        private void lblSignout_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Do you want to logout from your account?", "Logout Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.No) return;
            
            frmLoginForm.accActive = false;
            lblUserHeader.Text = "Current User: ";
            lblStartGame.Text = "Login       ";
            lblScores.Text = "Ranking Board       ";
            currentUser = "";
            plGamePage.Controls.Remove(lblSignout);
            plGamePage.Controls.Add(lblQuickDemo);
        }

        private void lblScores_Click(object sender, EventArgs e)
        {
            gamePageIndex = 1;
            CleanAndUpdate();

            if (frmLoginForm.accActive)
            {
                Utilities.query = "SELECT * FROM tbgamerecords WHERE Username = '" + currentUser + "'";
                Utilities.DBReadScore(ref lvPlayerScores, false, until2);
                plGamePage.Controls.Add(lvPlayerScores);
                until2 = until2 < 2 ? until2 + 1 : until2 = 1;
            }
            else
            {
                cbScoreList.Text = "Easy";
                plGamePage.Controls.Add(lblScoreInfo);
                plGamePage.Controls.Add(cbScoreList);
                Utilities.query = "SELECT tbgamehighscores.Username, tbgamerecords.Score, tbgamerecords.Difficulty, tbgameusers.ProgressNumber, tbgamerecords.DateRecorded FROM tbgamehighscores INNER JOIN tbgamerecords ON tbgamehighscores.RecordID = tbgamerecords.RecordID INNER JOIN tbgameusers ON tbgamehighscores.Username = tbgameusers.Username WHERE tbgamerecords.Difficulty = '" + cbScoreList.Text + "' ORDER BY tbgamerecords.Score DESC";
                Utilities.DBReadScore(ref lvTopScores, true, until1);
                plGamePage.Controls.Add(lvTopScores);
                until1 = until1 < 2 ? until1 + 1 : until1 = 1;
            }
        }

        private void lblInstruction_Click(object sender, EventArgs e)
        {
            gamePageIndex = 2;
            CleanAndUpdate();
            lblInfo.Text = Utilities.ReadTextFile("ins.txt");
            plGamePage.Controls.Add(lblInfo);
        }

        private void lblOption_Click(object sender, EventArgs e)
        {
            gamePageIndex = 3;
            CleanAndUpdate();
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            gamePageIndex = 4;
            CleanAndUpdate();
            lblInfo.Text = Utilities.ReadTextFile("abt.txt");
            plGamePage.Controls.Add(lblInfo);
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            gamePageIndex = 0;
            CleanAndUpdate();
        }

        private void lblEasy_Click(object sender, EventArgs e)
        {
            if (!GetConfirm()) return;
            gameDifficulty = "Easy";
            playerGameLevelPeak = 4;
            mobSpawnNumber = 3;
            if (!GameStageChosen()) return;
            MainGameScreen();
        }

        private void lblNormal_Click(object sender, EventArgs e)
        {
            if (!GetConfirm()) return;
            gameDifficulty = "Normal";
            playerGameLevelPeak = 4;
            mobSpawnNumber = 4;
            if (!GameStageChosen()) return;
            MainGameScreen();
        }

        private void lblHard_Click(object sender, EventArgs e)
        {
            if (!GetConfirm()) return;
            gameDifficulty = "Hard";
            playerGameLevelPeak = 4;
            mobSpawnNumber = 6;
            if (!GameStageChosen()) return;
            MainGameScreen();
        }

        private void lblInsane_Click(object sender, EventArgs e)
        {
            if (!GetConfirm()) return;
            gameDifficulty = "Insane";
            playerGameLevelPeak = 4;
            mobSpawnNumber = 7;
            if (!GameStageChosen()) return;
            MainGameScreen();
        }

        private void lblPause_Click(object sender, EventArgs e)
        {
            isPause = true;
            subThread.Abort();
            playerThread.Abort();
            if (bulletThread.IsAlive) bulletThread.Abort();
            gameTimerThread.Abort();
            if (!isDemo && playerStage != 1) mobThread.Abort();
            if (isDemo || playerStage == 1) guideThread.Abort();

            isTimeUp = true;
            gamePageIndex = 7;
            CleanAndUpdate();

            var message = MessageBox.Show("Are you sure you want to go back to home screen? ", "User Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes) { gamePageIndex = 0; CleanAndUpdate(); lblBack_Click(sender, e); isLevelCleared = true; }
            else { isPause = false; MainGameScreen();}
        }

        /// <summary>
        /// Effects
        /// </summary>
        private void lblClose_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.No) return;
            Dispose();
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Maroon;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lblMin_MouseEnter(object sender, EventArgs e)
        {
            lblMin.BackColor = Color.Maroon;
        }

        private void lblMin_MouseLeave(object sender, EventArgs e)
        {
            lblMin.BackColor = Color.Transparent;
        }

        private void lblQuickDemo_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblQuickDemo, true);
        }

        private void lblQuickDemo_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblQuickDemo, false);
        }

        private void lblStartGame_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblStartGame, true);
        }

        private void lblStartGame_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblStartGame, false);
        }

        private void lblScores_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblScores, true);
        }

        private void lblScores_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblScores, false);
        }

        private void lblInstruction_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblInstruction, true);
        }

        private void lblInstruction_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblInstruction, false);
        }

        private void lblOption_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblOption, true);
        }

        private void lblOption_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblOption, false);
        }

        private void lblAbout_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblAbout, true);
        }

        private void lblAbout_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblAbout, false);
        }

        private void lblBack_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblBack, true);
        }

        private void lblBack_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblBack, false);
        }

        private void lblSignout_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblSignout, true);
        }

        private void lblSignout_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblSignout, false);
        }

        private void lblEasy_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblEasy, true);
        }

        private void lblEasy_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblEasy, false);
        }

        private void lblNormal_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblNormal, true);
        }

        private void lblNormal_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblNormal, false);
        }

        private void lblHard_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblHard, true);
        }

        private void lblHard_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblHard, false);
        }

        private void lblInsane_MouseEnter(object sender, EventArgs e)
        {
            ChangeLabelColor(lblInsane, true);
        }

        private void lblInsane_MouseLeave(object sender, EventArgs e)
        {
            ChangeLabelColor(lblInsane, false);
        }

        private void lblPause_MouseEnter(object sender, EventArgs e)
        {
            lblPause.BackColor = Color.Maroon;
        }

        private void lblPause_MouseLeave(object sender, EventArgs e)
        {
            lblPause.BackColor = Color.Transparent;
        }

        private void cbScoreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.query = "SELECT tbgamehighscores.Username, tbgamerecords.Score, tbgamerecords.Difficulty, tbgameusers.ProgressNumber, tbgamerecords.DateRecorded FROM tbgamehighscores INNER JOIN tbgamerecords ON tbgamehighscores.RecordID = tbgamerecords.RecordID INNER JOIN tbgameusers ON tbgamehighscores.Username = tbgameusers.Username WHERE tbgamerecords.Difficulty = '" + cbScoreList.Text + "' ORDER BY tbgamerecords.Score DESC";

            Utilities.DBReadScore(ref lvTopScores, true, until1);
            
            lblScoreInfo.Text = "Top Scorers In [" + cbScoreList.Text + "] Game Mode:";
        }

        private void frmMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (gamePageIndex < 6 || playerKey == null) return;

            playerKey[Convert.ToInt16(e.KeyCode)] = true;

            if (playerKey[Convert.ToInt16(Keys.M)])
            {

            }
            if ((playerKey[Convert.ToInt16(Keys.Enter)] || playerKey[Convert.ToInt16(Keys.Space)]) && !((isDemo || playerStage == 1) && !enableBullet) && playerBlink == null)
            {
                if (bulletFired) return;
                bulletFired = true;
                bulletDirection = gameDirection[directionId];
                GetBulletDirection();

                if (bulletThread.ThreadState.ToString() != "Aborted" && bulletThread.ThreadState.ToString() != "Unstarted") return;
                bulletThread = new Thread(ActivateBullet);
                bulletThread.IsBackground = true; bulletThread.Name = "Bullet";
                bulletThread.Start();
            }
        }

        private void frmMainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (playerKey != null) playerKey[Convert.ToInt16(e.KeyCode)] = false;
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            if (subThread.IsAlive) subThread.Abort();
            if (playerThread.IsAlive) playerThread.Abort();
            if (bulletThread.IsAlive) bulletThread.Abort();
            if (gameTimerThread.IsAlive) gameTimerThread.Abort();
            if ((gameDifficulty == "Insane" || gameDifficulty == "Hard") && mobThread.IsAlive) mobThread.Abort();
        }

        private void lvTopScores_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvTopScores.Columns[e.ColumnIndex].Width;
        }

        private void lvPlayerScores_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvPlayerScores.Columns[e.ColumnIndex].Width;
        }

        private void ChangeLabelColor(Label label, bool active)
        {
            if (active)
            {
                label.Font = new Font("Consolas", 19, FontStyle.Regular);
                label.BackColor = Color.DarkGoldenrod;
                label.ForeColor = Color.Black;
            }
            else
            {
                label.Font = new Font("Consolas", 14, FontStyle.Regular);
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.PaleGoldenrod;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}