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
            new LoveData("Mars", new string[] { "Zorblatt", "Xanthe" }, new string[] { "ZorblattImageLink", "XantheImageLink", "MarsImageLink" }, 1),
            new LoveData("Venus", new string[] { "Gravlox", "Glaxor" }, new string[] { "GravloxImageLink", "GlaxorImageLink", "VenusImageLink" }, 2),
            new LoveData("Earth", new string[] { "Luna", "Klara" }, new string[] { "LunaImageLink", "KlaraImageLink", "EarthImageLink" }, 3),
            new LoveData("Jupiter", new string[] { "Ogar", "Zelda" }, new string[] { "OgarImageLink", "ZeldaImageLink", "JupiterImageLink" }, 4)
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
            public string QuestionOrAnswer { get; set; }
            public TreeNode Path1 { get; set; }
            public TreeNode Path2 { get; set; }
            public TreeNode Path3 { get; set; }
            public TreeNode Path4 { get; set; }

            public TreeNode(string questionOrAnswer)
            {
                QuestionOrAnswer = questionOrAnswer;
                Path1 = null;
                Path2 = null;
                Path3 = null;
                Path4 = null;
            }
        }

        // Initialize the game tree with generic questions and answers
        private void InitializeTree()
        {
            root = new TreeNode("Root Node");

            // Branches for the root node
            root.Path1 = new TreeNode("Node 1");
            root.Path2 = new TreeNode("Node 2");
            root.Path3 = new TreeNode("Node 3");
            root.Path4 = new TreeNode("Node 4");

            // Define further branching from Path1
            root.Path1.Path1 = new TreeNode("Node 1.1");
            root.Path1.Path2 = new TreeNode("Node 1.2");
            root.Path1.Path3 = new TreeNode("Node 1.3");
            root.Path1.Path4 = new TreeNode("Node 1.4");

            // Add additional branching under Node 1.1
            root.Path1.Path1.Path1 = new TreeNode("Node 1.1.1");
            root.Path1.Path1.Path2 = new TreeNode("Node 1.1.2");
            root.Path1.Path1.Path3 = new TreeNode("Node 1.1.3");
            root.Path1.Path1.Path4 = new TreeNode("Node 1.1.4");

            // Add additional branching under Node 1.2
            root.Path1.Path2.Path1 = new TreeNode("Node 1.2.1");
            root.Path1.Path2.Path2 = new TreeNode("Node 1.2.2");
            root.Path1.Path2.Path3 = new TreeNode("Node 1.2.3");
            root.Path1.Path2.Path4 = new TreeNode("Node 1.2.4");

            // Add additional branching under Node 1.3
            root.Path1.Path3.Path1 = new TreeNode("Node 1.3.1");
            root.Path1.Path3.Path2 = new TreeNode("Node 1.3.2");
            root.Path1.Path3.Path3 = new TreeNode("Node 1.3.3");
            root.Path1.Path3.Path4 = new TreeNode("Node 1.3.4");

            // Add additional branching under Node 1.4
            root.Path1.Path4.Path1 = new TreeNode("Node 1.4.1");
            root.Path1.Path4.Path2 = new TreeNode("Node 1.4.2");
            root.Path1.Path4.Path3 = new TreeNode("Node 1.4.3");
            root.Path1.Path4.Path4 = new TreeNode("Node 1.4.4");

            // Define further branching from Path2
            root.Path2.Path1 = new TreeNode("Node 2.1");
            root.Path2.Path2 = new TreeNode("Node 2.2");
            root.Path2.Path3 = new TreeNode("Node 2.3");
            root.Path2.Path4 = new TreeNode("Node 2.4");

            // Add additional branching under Node 2.1
            root.Path2.Path1.Path1 = new TreeNode("Node 2.1.1");
            root.Path2.Path1.Path2 = new TreeNode("Node 2.1.2");
            root.Path2.Path1.Path3 = new TreeNode("Node 2.1.3");
            root.Path2.Path1.Path4 = new TreeNode("Node 2.1.4");

            // Add additional branching under Node 2.2
            root.Path2.Path2.Path1 = new TreeNode("Node 2.2.1");
            root.Path2.Path2.Path2 = new TreeNode("Node 2.2.2");
            root.Path2.Path2.Path3 = new TreeNode("Node 2.2.3");
            root.Path2.Path2.Path4 = new TreeNode("Node 2.2.4");

            // Add additional branching under Node 2.3
            root.Path2.Path3.Path1 = new TreeNode("Node 2.3.1");
            root.Path2.Path3.Path2 = new TreeNode("Node 2.3.2");
            root.Path2.Path3.Path3 = new TreeNode("Node 2.3.3");
            root.Path2.Path3.Path4 = new TreeNode("Node 2.3.4");

            // Add additional branching under Node 2.4
            root.Path2.Path4.Path1 = new TreeNode("Node 2.4.1");
            root.Path2.Path4.Path2 = new TreeNode("Node 2.4.2");
            root.Path2.Path4.Path3 = new TreeNode("Node 2.4.3");
            root.Path2.Path4.Path4 = new TreeNode("Node 2.4.4");

            // Define further branching from Path3
            root.Path3.Path1 = new TreeNode("Node 3.1");
            root.Path3.Path2 = new TreeNode("Node 3.2");
            root.Path3.Path3 = new TreeNode("Node 3.3");
            root.Path3.Path4 = new TreeNode("Node 3.4");

            // Add additional branching under Node 3.1
            root.Path3.Path1.Path1 = new TreeNode("Node 3.1.1");
            root.Path3.Path1.Path2 = new TreeNode("Node 3.1.2");
            root.Path3.Path1.Path3 = new TreeNode("Node 3.1.3");
            root.Path3.Path1.Path4 = new TreeNode("Node 3.1.4");

            // Add additional branching under Node 3.2
            root.Path3.Path2.Path1 = new TreeNode("Node 3.2.1");
            root.Path3.Path2.Path2 = new TreeNode("Node 3.2.2");
            root.Path3.Path2.Path3 = new TreeNode("Node 3.2.3");
            root.Path3.Path2.Path4 = new TreeNode("Node 3.2.4");

            // Add additional branching under Node 3.3
            root.Path3.Path3.Path1 = new TreeNode("Node 3.3.1");
            root.Path3.Path3.Path2 = new TreeNode("Node 3.3.2");
            root.Path3.Path3.Path3 = new TreeNode("Node 3.3.3");
            root.Path3.Path3.Path4 = new TreeNode("Node 3.3.4");

            // Add additional branching under Node 3.4
            root.Path3.Path4.Path1 = new TreeNode("Node 3.4.1");
            root.Path3.Path4.Path2 = new TreeNode("Node 3.4.2");
            root.Path3.Path4.Path3 = new TreeNode("Node 3.4.3");
            root.Path3.Path4.Path4 = new TreeNode("Node 3.4.4");

            // Define further branching from Path4
            root.Path4.Path1 = new TreeNode("Node 4.1");
            root.Path4.Path2 = new TreeNode("Node 4.2");
            root.Path4.Path3 = new TreeNode("Node 4.3");
            root.Path4.Path4 = new TreeNode("Node 4.4");

            // Add additional branching under Node 4.1
            root.Path4.Path1.Path1 = new TreeNode("Node 4.1.1");
            root.Path4.Path1.Path2 = new TreeNode("Node 4.1.2");
            root.Path4.Path1.Path3 = new TreeNode("Node 4.1.3");
            root.Path4.Path1.Path4 = new TreeNode("Node 4.1.4");

            // Add additional branching under Node 4.2
            root.Path4.Path2.Path1 = new TreeNode("Node 4.2.1");
            root.Path4.Path2.Path2 = new TreeNode("Node 4.2.2");
            root.Path4.Path2.Path3 = new TreeNode("Node 4.2.3");
            root.Path4.Path2.Path4 = new TreeNode("Node 4.2.4");

            // Add additional branching under Node 4.3
            root.Path4.Path3.Path1 = new TreeNode("Node 4.3.1");
            root.Path4.Path3.Path2 = new TreeNode("Node 4.3.2");
            root.Path4.Path3.Path3 = new TreeNode("Node 4.3.3");
            root.Path4.Path3.Path4 = new TreeNode("Node 4.3.4");

            // Add additional branching under Node 4.4
            root.Path4.Path4.Path1 = new TreeNode("Node 4.4.1");
            root.Path4.Path4.Path2 = new TreeNode("Node 4.4.2");
            root.Path4.Path4.Path3 = new TreeNode("Node 4.4.3");
            root.Path4.Path4.Path4 = new TreeNode("Node 4.4.4");
        }

        // Button click event to start a new game
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            currentNode = root; // Always start from the root
            isEndGame = false; // Reset the end game flag

            btnStartGame.Visible = false; // Hide start button
            lblTextBox.Text = $"Node: {currentNode.QuestionOrAnswer}"; // Show the first node

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
            btnOption1.Text = currentNode.Path1?.QuestionOrAnswer ?? "No Path";
            btnOption2.Text = currentNode.Path2?.QuestionOrAnswer ?? "No Path";
            btnOption3.Text = currentNode.Path3?.QuestionOrAnswer ?? "No Path";
            btnOption4.Text = currentNode.Path4?.QuestionOrAnswer ?? "No Path";
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
                    EndGame($"You reached: {currentNode.QuestionOrAnswer}. Game Over!");
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
                    EndGame($"You reached: {currentNode.QuestionOrAnswer}. Game Over!");
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
                    EndGame($"You reached: {currentNode.QuestionOrAnswer}. Game Over!");
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
                    EndGame($"You reached: {currentNode.QuestionOrAnswer}. Game Over!");
                    isEndGame = true; // Set the game to end
                }
            }
        }

        // Handle the final end game response (no more "correct/incorrect" prompts)
        private void HandleEndGame()
        {
            lblTextBox.Text = $"Game Over! You reached: {currentNode.QuestionOrAnswer}";

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
            lblTextBox.Text = $"Node: {currentNode.QuestionOrAnswer}";

            // Update the button text to reflect the next node choices
            UpdateButtonText();

            if (currentNode.Path1 == null && currentNode.Path2 == null && currentNode.Path3 == null && currentNode.Path4 == null)
            {
                // If at a leaf node, game ends
                EndGame($"You reached: {currentNode.QuestionOrAnswer}. Game Over!");
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
        public string Planet { get; set; }
        public string[] Aliens { get; set; }
        public string[] ImageLinks { get; set; }
        public int Value { get; set; }

        public LoveData(string planet, string[] aliens, string[] imageLinks, int value)
        {
            Planet = planet;
            Aliens = aliens;
            ImageLinks = imageLinks;
            Value = value;
        }
    }//end of Public class  LoveData

}