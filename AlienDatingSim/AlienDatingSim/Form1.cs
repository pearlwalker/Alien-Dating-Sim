using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlienDatingSim
{

    public partial class Form1 : Form
    {
        // Define the root of the decision tree
        private TreeNode root;
        private TreeNode currentNode;
        private bool isEndGame; // Flag to track when the game is at the end

        // Array of LoveData objects
        private LoveData[] loveDataArray = new LoveData[]
        {   //just a mockUp
            /*
            new LoveData("Mars", new string[] { "Zorblatt", "Xanthe" }, new string[] { "ZorblattImageLink", "XantheImageLink", "MarsImageLink" }, 1),
            new LoveData("Venus", new string[] { "Gravlox", "Glaxor" }, new string[] { "GravloxImageLink", "GlaxorImageLink", "VenusImageLink" }, 2),
            new LoveData("Earth", new string[] { "Luna", "Klara" }, new string[] { "LunaImageLink", "KlaraImageLink", "EarthImageLink" }, 3),
            new LoveData("Jupiter", new string[] { "Ogar", "Zelda" }, new string[] { "OgarImageLink", "ZeldaImageLink", "JupiterImageLink" }, 4)
            */
            /* alien 0 */
            new LoveData("100", new string[] { "alien_100.png"}, new string[] { "Mercury", "Venus" },
                new string[] { 
                    "bleh bleh i have a hundred eyes",
                    "grrr.. go away you stink",
                    "do you think im funny?",
                    "who knew someone with so few eyes could still into my heart~ <3 " , 
                "i hate YOOOOUUUUUU" ,
                },
                 new string[]
                {
                    "responce 1",
                    "responce 2",
                    "responce 3",
                    "responce 4"
                }
                )/*alien 1*/,
                       new LoveData("placeholder", new string[] {"alien_bear.png"}, new string[] { "Mercury", "Venus" },
                new string[] {
                    "dialouge 1",
                    "dialouge 2",
                    "dialouge 3",
                    "dialouge 4 "} , 
                new string[]
                {
                    "responce 1",
                    "responce 2",
                    "responce 3",
                    "responce 4"
                }
                )/*alien 2*/
        };

        // Constructor for the Form
        //  -- Dont touch vvvvvvv
        public Form1()
        {
            InitializeComponent();
            InitializeTree(); // Initialize the tree once
        }//  -- Dont touch ^^^^^^

        // TreeNode class to represent the structure of the game
        class TreeNode
        {
            public string[] GivenData { get; set; }
            public TreeNode Path1 { get; set; }
            public TreeNode Path2 { get; set; }
            public TreeNode Path3 { get; set; }
            public TreeNode Path4 { get; set; }

            public TreeNode(string data1, string data2, string data3, string data4, string data5, string data6)
            {
                GivenData = new string[] { data1, data2, data3, data4, data5, data6 };
                Path1 = null;
                Path2 = null;
                Path3 = null;
                Path4 = null;
            }
        }

        // Initialize the game tree with generic questions and answers
        private void InitializeTree()
        {
            // Root node with 5 data points    -- i may have a system in which if there is something we dont wanna change, then input "" or "n/a"
            root = new TreeNode("Root Node", "Name Data", "Character Image Data", "Planet Image Data", "TextBox Data", "Button Text Data");

            // Branches for the root node, each with its own data points                         /*"solarSystem"*/ /*@"C:\Users\Magic\Downloads\WorkForCollege\IGME.201\Project-3\media"*/
            root.Path1 = new TreeNode("Node 1", "", "", "planet_mercury.png", "Now choose your Date!", "Mercury");
            root.Path2 = new TreeNode("Node 2", "", "", "planet_mars.png"   , "Now choose your Date!", "Mars");
            root.Path3 = new TreeNode("Node 3", "", "", "planet_saturn.png" , "Now choose your Date!", "Saturn");
            root.Path4 = new TreeNode("Node 4", "", "", "planet_sun.png"    , "Now choose your Date!", "The Sun");

            // Define further branching from Path1, each with its own data points
            root.Path1.Path1 = new TreeNode("Node 1.1", loveDataArray[0].Name, loveDataArray[0].CharacterImageLinks[0]  , ""/*mercury background goes here*/, loveDataArray[0].Dialouges[0], loveDataArray[0].Name);
            root.Path1.Path2 = new TreeNode("Node 1.2", loveDataArray[1].Name, loveDataArray[1].CharacterImageLinks[0]  , ""/*mercury background goes here*/, loveDataArray[0].Dialouges[1], loveDataArray[1].Name);
            root.Path1.Path3 = new TreeNode("Node 1.3", loveDataArray[0].Name, loveDataArray[0].CharacterImageLinks[0]  , ""/*mercury background goes here*/, "Node 1.3 Data 4", "Node 1.3 Data 5");
            root.Path1.Path4 = new TreeNode("Node 1.4", loveDataArray[0].Name, loveDataArray[0].CharacterImageLinks[0]  , ""/*mercury background goes here*/, "Node 1.4 Data 4", "Node 1.4 Data 5");

            // Further branching from Node 1.1
            root.Path1.Path1.Path1 = new TreeNode("Node 1.1.1", "Node 1.1.1 Data 1", "Node 1.1.1 Data 2", "Node 1.1.1 Data 3", "Node 1.1.1 Data 4", "Node 1.1.1 Data 5");
            root.Path1.Path1.Path2 = new TreeNode("Node 1.1.2", "Node 1.1.2 Data 1", "Node 1.1.2 Data 2", "Node 1.1.2 Data 3", "Node 1.1.2 Data 4", "Node 1.1.2 Data 5");
            root.Path1.Path1.Path3 = new TreeNode("Node 1.1.3", "Node 1.1.3 Data 1", "Node 1.1.3 Data 2", "Node 1.1.3 Data 3", "Node 1.1.3 Data 4", "Node 1.1.3 Data 5");
            root.Path1.Path1.Path4 = new TreeNode("Node 1.1.4", "Node 1.1.4 Data 1", "Node 1.1.4 Data 2", "Node 1.1.4 Data 3", "Node 1.1.4 Data 4", "Node 1.1.4 Data 5");

            // Further branching from Node 1.2
            root.Path1.Path2.Path1 = new TreeNode("Node 1.2.1", "Node 1.2.1 Data 1", "Node 1.2.1 Data 2", "Node 1.2.1 Data 3", "Node 1.2.1 Data 4", "Node 1.2.1 Data 5");
            root.Path1.Path2.Path2 = new TreeNode("Node 1.2.2", "Node 1.2.2 Data 1", "Node 1.2.2 Data 2", "Node 1.2.2 Data 3", "Node 1.2.2 Data 4", "Node 1.2.2 Data 5");
            root.Path1.Path2.Path3 = new TreeNode("Node 1.2.3", "Node 1.2.3 Data 1", "Node 1.2.3 Data 2", "Node 1.2.3 Data 3", "Node 1.2.3 Data 4", "Node 1.2.3 Data 5");
            root.Path1.Path2.Path4 = new TreeNode("Node 1.2.4", "Node 1.2.4 Data 1", "Node 1.2.4 Data 2", "Node 1.2.4 Data 3", "Node 1.2.4 Data 4", "Node 1.2.4 Data 5");

            // Further branching from Node 1.3
            root.Path1.Path3.Path1 = new TreeNode("Node 1.3.1", "Node 1.3.1 Data 1", "Node 1.3.1 Data 2", "Node 1.3.1 Data 3", "Node 1.3.1 Data 4", "Node 1.3.1 Data 5");
            root.Path1.Path3.Path2 = new TreeNode("Node 1.3.2", "Node 1.3.2 Data 1", "Node 1.3.2 Data 2", "Node 1.3.2 Data 3", "Node 1.3.2 Data 4", "Node 1.3.2 Data 5");
            root.Path1.Path3.Path3 = new TreeNode("Node 1.3.3", "Node 1.3.3 Data 1", "Node 1.3.3 Data 2", "Node 1.3.3 Data 3", "Node 1.3.3 Data 4", "Node 1.3.3 Data 5");
            root.Path1.Path3.Path4 = new TreeNode("Node 1.3.4", "Node 1.3.4 Data 1", "Node 1.3.4 Data 2", "Node 1.3.4 Data 3", "Node 1.3.4 Data 4", "Node 1.3.4 Data 5");

            // Further branching from Node 1.4
            root.Path1.Path4.Path1 = new TreeNode("Node 1.4.1", "Node 1.4.1 Data 1", "Node 1.4.1 Data 2", "Node 1.4.1 Data 3", "Node 1.4.1 Data 4", "Node 1.4.1 Data 5");
            root.Path1.Path4.Path2 = new TreeNode("Node 1.4.2", "Node 1.4.2 Data 1", "Node 1.4.2 Data 2", "Node 1.4.2 Data 3", "Node 1.4.2 Data 4", "Node 1.4.2 Data 5");
            root.Path1.Path4.Path3 = new TreeNode("Node 1.4.3", "Node 1.4.3 Data 1", "Node 1.4.3 Data 2", "Node 1.4.3 Data 3", "Node 1.4.3 Data 4", "Node 1.4.3 Data 5");
            root.Path1.Path4.Path4 = new TreeNode("Node 1.4.4", "Node 1.4.4 Data 1", "Node 1.4.4 Data 2", "Node 1.4.4 Data 3", "Node 1.4.4 Data 4", "Node 1.4.4 Data 5");

            // Continue with Path2, Path3, Path4 branching as needed...
        }

        // Button click event to start a new game
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            currentNode = root; // Always start from the root
            isEndGame = false; // Reset the end game flag

            btnStartGame.Visible = false; // Hide start button
            lblTextBox.Text = $"Node: {currentNode.GivenData[0]}"; // Show the first node

            // Show the options (buttons)
            UpdateButtonText();

            btnOption1.Visible = true;
            btnOption2.Visible = true;
            btnOption3.Visible = true;
            btnOption4.Visible = true;

            // Reset event handlers for buttons
            ResetButtonEvents();
        }

        // Update button text based on current node
        private void UpdateButtonText()
        {
            /*
            btnOption1.Text = currentNode.Path1?.GivenData[0] ?? "No Path";
            btnOption2.Text = currentNode.Path2?.GivenData[0] ?? "No Path";
            btnOption3.Text = currentNode.Path3?.GivenData[0] ?? "No Path";
            btnOption4.Text = currentNode.Path4?.GivenData[0] ?? "No Path";
            */
            btnOption1.Text = (currentNode.Path1?.GivenData[0]) + "\n" + (currentNode.Path1?.GivenData[5]) ?? "No Path";
            btnOption2.Text = (currentNode.Path2?.GivenData[0]) + "\n" + (currentNode.Path2?.GivenData[5]) ?? "No Path";
            btnOption3.Text = (currentNode.Path3?.GivenData[0]) + "\n" + (currentNode.Path3?.GivenData[5]) ?? "No Path";
            btnOption4.Text = (currentNode.Path4?.GivenData[0]) + "\n" + (currentNode.Path4?.GivenData[5]) ?? "No Path";
        }

        // Button click event for Path 1 response
        private void btnOption1_Click(object sender, EventArgs e)
        {
            if (isEndGame)
            {
                HandleEndGame();
            }
            else
            {
                if (currentNode.Path1 != null)
                {
                    currentNode = currentNode.Path1; // Move to Path1 branch
                    PlayGame();
                }
                else
                {

                    EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
                    isEndGame = true; // Set the game to end
                }
            }
        }

        // Button click event for Path 2 response
        private void btnOption2_Click(object sender, EventArgs e)
        {
            if (isEndGame)
            {
                HandleEndGame();
            }
            else
            {
                if (currentNode.Path2 != null)
                {
                    currentNode = currentNode.Path2; // Move to Path2 branch
                    PlayGame();
                }
                else
                {
                    EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
                    isEndGame = true; // Set the game to end
                }
            }
        }

        // Button click event for Path 3 response
        private void btnOption3_Click(object sender, EventArgs e)
        {
            if (isEndGame)
            {
                HandleEndGame();
            }
            else
            {
                if (currentNode.Path3 != null)
                {
                    currentNode = currentNode.Path3; // Move to Path3 branch
                    PlayGame();
                }
                else
                {
                    EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
                    isEndGame = true; // Set the game to end
                }
            }
        }

        // Button click event for Path 4 response
        private void btnOption4_Click(object sender, EventArgs e)
        {
            if (isEndGame)
            {
                HandleEndGame();
            }
            else
            {
                if (currentNode.Path4 != null)
                {
                    currentNode = currentNode.Path4; // Move to Path4 branch
                    PlayGame();
                }
                else
                {
                    EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
                    isEndGame = true; // Set the game to end
                }
            }
        }

        // Handle the final end game response (no more "correct/incorrect" prompts)
        private void HandleEndGame()
        {
            lblTextBox.Text = $"Game Over! You reached: {currentNode.GivenData[0]}";

            // Hide the option buttons at the end of the game
            ShowAnswerButtons(false);

            // Show the "Start Game" button to allow restarting
            btnStartGame.Visible = true;
        }

        // Show or hide the answer buttons
        private void ShowAnswerButtons(bool visible)
        {
            btnOption1.Visible = visible;
            btnOption2.Visible = visible;
            btnOption3.Visible = visible;
            btnOption4.Visible = visible;
        }

        // Play the game (ask questions)
        private void PlayGame()
        {
            // Show the current node's position and text
            lblTextBox.Text =  currentNode.GivenData[4];
            if (currentNode.GivenData[3] != "") {
                string imagePath = currentNode.GivenData[3];
                //pictureBox1.Image = Properties.Resources.imagePath;
                //pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.ImageLocation = imagePath ;
                pictureBox1.Load();
            }

            if (currentNode.GivenData[2] != "")
            {
                string imagePath = currentNode.GivenData[2];
                //pictureBox2.Image = Properties.Resources.imagePath;
                //pictureBox2.Image = Image.FromFile(imagePath);
                pictureBox2.ImageLocation = imagePath;
                pictureBox2.Load();
            }


            // Update the button text to reflect the next node choices
            UpdateButtonText();

            if (currentNode.Path1 == null && currentNode.Path2 == null && currentNode.Path3 == null && currentNode.Path4 == null)
            {
                // If at a leaf node, game ends
                EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
                isEndGame = true; // Set the game to end
            }
        }

        // End the game and show the final message
        private void EndGame(string message)
        {
            lblTextBox.Text = message;
        }

        // Reset button event handlers to prevent duplicates
        private void ResetButtonEvents()
        {
            btnOption1.Click -= btnOption1_Click; // Remove previous event handlers
            btnOption2.Click -= btnOption2_Click;
            btnOption3.Click -= btnOption3_Click;
            btnOption4.Click -= btnOption4_Click;

            // Add new event handlers
            btnOption1.Click += btnOption1_Click;
            btnOption2.Click += btnOption2_Click;
            btnOption3.Click += btnOption3_Click;
            btnOption4.Click += btnOption4_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }//end public partial class Form 1 : Form

    // LoveData class with the specified properties
    public class LoveData
    {
        public string Name { get; set; }
        public string[] Dialouges { get; set; }

        public string[] ButtonText { get; set; }
        public string[] CharacterImageLinks { get; set; }
        public string[] PlanetImageLinks { get; set; }

        //public int Value { get; set; }

        public LoveData(string name, string[] characterImageLinks, string[] planetImageLinks, string[] dialouges, string[] buttonText)
        {
            /* Planet = planet;
             Aliens = aliens;
             ImageLinks = imageLinks;
             Value = value;*/
            Name = name;
            CharacterImageLinks = characterImageLinks;
            PlanetImageLinks = planetImageLinks;
            Dialouges = dialouges;
            ButtonText = buttonText;

        }
    }//end of Public class  LoveData

}