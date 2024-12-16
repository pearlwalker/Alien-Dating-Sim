using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Collections;
using System.Dynamic;
using System.IO;

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
        {  
            
            /* alien 0 */
            new LoveData(new string[]{"100" , "A many-eyed creature who likes the heat." }, new string[] { "../../Resources/alien_100.png"}, new string[] { "Mercury" },
                new string[] { 
                    "bleh bleh i have a hundred eyes",
                    "Waaaahhhh you hate my eyes Dont You!!!!",
                    "Aww how sweet~ ",
                    "i hate YOOOOUUUUUU" ,
                    "who knew someone with so few eyes could still peer into my heart~ <3 " 
                },
                 new string[]
                {
                    "urk! i think im gonna Throw Up",
                    "hey there cutie, love the dress?????",
                    "jk, ur ugly",
                    "not as sweet as your heart"
                  
                }
                )
            /*alien 1*/,
                       new LoveData(new string[]{"AAAAAA" , "Actively on Fire. " }, new string[] {"../../Resources/alien_AAAAAA.png"}, new string[] { "The Sun" },
                new string[] {
                    "I’m literally on fire—hot, dangerous, and impossible to ignore.", 
                    "Ugh, your lack of enthusiasm is like a bucket of water on my flames.",
                    "But I’ll admit, you’ve got a spark that’s hard to resist. ",
                    "Seriously though, are you even capable of keeping up with this heat?",
                    "Maybe you’re not so bad—you might just be fuel for my fire"

                } , 
                new string[]
                {
                    "Literally on fire? Sounds like a safety hazard",
                    "Hot, dangerous, and impossible to ignore? That’s exactly my type.",
                     "Fuel for your fire? Sorry, I don’t want to get burned."
                    ,"Fuel for your fire? I’ll keep you blazing brighter than ever"

                }
                )

            /*alien 2*/,
                       new LoveData(new string[]{"Bear" , "The best option," }, new string[] {"../../Resources/alien_Bear.png"}, new string[] { "The Sun", "Mercury", "Mars" , "Saturn" },
                   new string[] {
                    "I’m cuddly, reliable, and undeniably the best option here.",
                    "But if you don’t appreciate me, I might just hibernate forever.",
                    "Still, you seem like someone who knows a good thing when they see it.",
                    "Although, you could stand to show a little more gratitude.",
                    "Fine, I’ll stick around—you’re worth a little extra effort."


                } ,

                new string[]
                {
                "The best option? That’s a bold claim.",
                "Cuddly and reliable? You’ve convinced me already.",
                "Show gratitude? You’re lucky I’m still here.",
                "Show gratitude? You’re right—I’m grateful for you."
                }
                )

            /*alien 3*/,
                       new LoveData(new string[]{"Frederick" , "Is probably negging you." }, new string[] {"../../Resources/alien_Frederick.png"}, new string[] { "The Sun" },
                new string[] {
                "You’re tolerable, I guess. I’ve seen worse.",
                "But honestly, you could try harder to impress me.",
                "I’ll admit, though, you’ve got a certain charm.",
                "Still, don’t let it go to your head—it’s not that great.",
                "Okay, fine, you’re growing on me. Don’t make me regret saying that."

                } ,
                new string[]
                {
                    "Tolerable? Wow, way to make someone feel special.",
                    "Tolerable? Coming from you, that’s high praise.",
                    "Not that great? Maybe I’ll find someone who appreciates me.",
                    "Not that great? You’re lucky I’m into your honesty."


                }
                )

            /*alien 4*/,
                       new LoveData(new string[]{"Jern" , "Low gravity grey humanoid." }, new string[] {"../../Resources/alien_Jern.png"}, new string[] { "Mercury", "Mars" },
                new string[] {
                "I’m light on my feet, easygoing, and low-maintenance—what’s not to love?",
                  "Though I can’t help but notice you’re not exactly grounded.",
                    "Still, you’ve got a way of keeping me intrigued.",
                "But are you sure you’re ready for a partner who’s truly out of this world?",
            	"Alright, I’m in—let’s see if you can keep up with my orbit"

               
                } ,
                new string[]
                {
                    "Low-maintenance? Sounds boring.",
	                "Light on your feet? You’re floating right into my heart.",
	                "Keep up with your orbit? I’m not signing up for space drama.",
	                "Keep up with your orbit? I’m ready for the ride."

                }
                )

            /*alien 5*/,
                       new LoveData(new string[]{"MarpMarp" , "A green friend who likes the cold." }, new string[] {"../../Resources/alien_MarpMarp.png"}, new string[] { "Mars" },
                new string[] {
		            "I’m cool, calm, and collected—just like the icy planets I call home.",
		            "But honestly, you’re coming off a bit… lukewarm.",
		            "Still, there’s something refreshing about you—like a crisp winter breeze.",
		            "Although I’m not sure you can handle my frosty side.",
		            "Alright, I’ll let you stick around—you might just warm me up."
                } ,
                new string[]
                {
                    "Cool and collected? More like cold and distant.",
             	    "Cool, calm, and collected? You’re chill in the best way.",
		            "Your frosty side? Sounds like too much work.",
		            "Your frosty side? I’ll bring the heat to balance us out."
                }
                )

            /*alien 6*/,
                       new LoveData(new string[]{"Olgakar" , "Some part squid, some part snake. Definitely blue, likes the cold." }, new string[] {"../../Resources/alien_Olgakar.png"}, new string[] { "Mars", "Saturn" },
                new string[] {
	            "I’m a perfect blend of elegance and mystery—part squid, part snake, and all charm.",
	            "But honestly, your warm-blooded energy is kind of off-putting.",
	            "Still, I can’t deny that there’s something oddly captivating about you.",
	            "Although I doubt you’d survive a dip in my icy waters.",
	            "Alright, you’ve earned a spot in my tentacled heart—don’t let me down."

                } ,
                new string[]
                {
	            "Part squid, part snake? Sounds like a nightmare.",
                 "Part squid, part snake? That’s the coolest thing I’ve ever heard.",
	            "Your icy waters? Sorry, I prefer warmer vibes.",
	            "Your icy waters? I’ll dive in headfirst if it means staying close to you."

                }
                )

            /*alien 7*/,
                       new LoveData(new string[]{"SolsticeBlaze" , "Likes hot planets, hates being called a furry." }, new string[] {"../../Resources/alien_SolsticeBlaze.png"}, new string[] { "Mercury"},
                new string[] {
            	"I thrive on heat and passion—no cold feet or hesitation allowed.",
	            "But seriously, if you even think about calling me a furry, we’re done.",
            	"That said, you’ve got a certain spark that I can’t ignore.",
            	"Although I doubt you can handle the intensity of my fiery personality.",
	            "Fine, I’ll give you a chance—just don’t make me regret it."

             
                } ,
                new string[]
                {
                "Heat and passion? Sounds exhausting.",
                "Heat and passion? I’m already feeling the burn—in the best way.",
                "Fiery personality? I’m not trying to get scorched.",
                "Fiery personality? I’ll match your flames and raise you a wildfire."

                }
                )

        };//end of lovedata   //tally  mercury:4 , mars:4 , Saturn:2 , The Sun:3 

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
            // Root node with 5 data points  for the images, if we want to simply leave whatever is already in their then simply input "". 
            root = new TreeNode("Root Node", "Name Data", "Character Image Data", "Planet Image Data", "TextBox Data", "Button Text Data");
            //root = new TreeNode("Root Node", "Name Data", "Character Image Data", "Planet Image Data", "TextBox Data", "Button Text Data");

            // Branches for the root node, each with its own data points                         
            root.Path1 = new TreeNode("Node 1", "", "", "../../Resources/planet_mercury.png", "Now choose your Date!", "Mercury \n Mercury is an oft misunderstood terrestrial planet. Maybe by moving here you can see its true colors.");
            root.Path2 = new TreeNode("Node 2", "", "", "../../Resources/planet_mars.png", "Now choose your Date!", "Mars \n Maybe you’re intimidated by the “Red Planet” named after the Roman god of war, but what is red if not the color of love? And blood? And rust? (hopefully you got that tetanus shot!).\r\n");
            root.Path3 = new TreeNode("Node 3", "", "", "../../Resources/planet_saturn.png", "Now choose your Date!", "Saturn \n Saturn’s most iconic feature is its dazzling system of rings…talk about “putting a ring on it”! With 146 moons in its orbit, Saturn’s “wealth” of culture truly lives up to its namesake.\r\n");
            root.Path4 = new TreeNode("Node 4", "", "", "../../Resources/planet_sun.png", "Now choose your Date!", "The Sun \n Call yourself Icarus, because what future is brighter than one on a star. The locals here are FLAMING HOT, so why not take a chance being the center of the solar system.");


            //MERCURY (1)
            // Define further branching from Path1/ mercury, each with its own data points
            root.Path1.Path1 = new TreeNode("Node 1.1", loveDataArray[0].Name[0], loveDataArray[0].CharacterImageLinks[0], ""/*<--mercury background goes there*/, loveDataArray[0].Dialouges[0], loveDataArray[0].Name[0] + "\n"+ loveDataArray[0].Name[1]);
            root.Path1.Path2 = new TreeNode("Node 1.2", loveDataArray[2].Name[0], loveDataArray[2].CharacterImageLinks[0], ""/*<--mercury background goes there*/, loveDataArray[2].Dialouges[0], loveDataArray[2].Name[0] + "\n" + loveDataArray[2].Name[1]);
            root.Path1.Path3 = new TreeNode("Node 1.3", loveDataArray[4].Name[0], loveDataArray[4].CharacterImageLinks[0], ""/*<--mercury background goes there*/, loveDataArray[4].Dialouges[0], loveDataArray[4].Name[0] + "\n" + loveDataArray[4].Name[1]);
            root.Path1.Path4 = new TreeNode("Node 1.4", loveDataArray[7].Name[0], loveDataArray[7].CharacterImageLinks[0], ""/*<--mercury background goes there*/, loveDataArray[7].Dialouges[0], loveDataArray[7].Name[0] + "\n" + loveDataArray[7].Name[1]);

                //alien 0 dialogue  (Mercury only)
                root.Path1.Path1.Path1 = new TreeNode("Node 1.1.1", loveDataArray[0].Name[0], "", "", loveDataArray[0].Dialouges[1], loveDataArray[0].ButtonText[0]);
                root.Path1.Path1.Path4 = new TreeNode("Node 1.1.4", loveDataArray[0].Name[0], "", "", loveDataArray[0].Dialouges[2], loveDataArray[0].ButtonText[1]);
            
                root.Path1.Path1.Path4.Path1 = new TreeNode("Node 1.1.4.1", loveDataArray[0].Name[0], "", "", loveDataArray[0].Dialouges[3], loveDataArray[0].ButtonText[2]);
                root.Path1.Path1.Path4.Path4 = new TreeNode("Node 1.1.4.4", loveDataArray[0].Name[0], "", "", loveDataArray[0].Dialouges[4], loveDataArray[0].ButtonText[3]);
                
            
                //alien 2 dialogue  (All planets)    
                root.Path1.Path2.Path1 = new TreeNode("Node 1.2.1", loveDataArray[2].Name[0], "","", loveDataArray[2].Dialouges[1], loveDataArray[2].ButtonText[0]);
                root.Path1.Path2.Path4 = new TreeNode("Node 1.2.4", loveDataArray[2].Name[0], "","", loveDataArray[2].Dialouges[2], loveDataArray[2].ButtonText[1]);
               
                root.Path1.Path2.Path4.Path1 = new TreeNode("Node 1.2.4.1", loveDataArray[2].Name[0],"","", loveDataArray[2].Dialouges[3], loveDataArray[2].ButtonText[2]);
                root.Path1.Path2.Path4.Path4 = new TreeNode("Node 1.2.4.4", loveDataArray[2].Name[0],"","", loveDataArray[2].Dialouges[4], loveDataArray[2].ButtonText[3]);

                //alien 4 dialogue (mercury and mars)
                root.Path1.Path3.Path1 = new TreeNode("Node 1.3.1", loveDataArray[4].Name[0], "","", loveDataArray[4].Dialouges[1], loveDataArray[4].ButtonText[0]);
                root.Path1.Path3.Path4 = new TreeNode("Node 1.3.4", loveDataArray[4].Name[0], "","", loveDataArray[4].Dialouges[2], loveDataArray[4].ButtonText[1]);
                
                root.Path1.Path3.Path4.Path1 = new TreeNode("Node 1.3.4.1", loveDataArray[4].Name[0],"","", loveDataArray[4].Dialouges[3], loveDataArray[4].ButtonText[2]);
                root.Path1.Path3.Path4.Path4 = new TreeNode("Node 1.3.4.4", loveDataArray[4].Name[0],"","", loveDataArray[4].Dialouges[4], loveDataArray[4].ButtonText[3]);

                //alien 7 dialogue (Mercury only)
                root.Path1.Path4.Path1 = new TreeNode("Node 1.4.1", loveDataArray[7].Name[0],"","", loveDataArray[7].Dialouges[1], loveDataArray[7].ButtonText[0]);
                root.Path1.Path4.Path4 = new TreeNode("Node 1.4.4", loveDataArray[7].Name[0],"","", loveDataArray[7].Dialouges[2], loveDataArray[7].ButtonText[1]);
                
                root.Path1.Path4.Path4.Path1 = new TreeNode("Node 1.4.4.1", loveDataArray[7].Name[0],"","", loveDataArray[7].Dialouges[3], loveDataArray[7].ButtonText[2]);
                root.Path1.Path4.Path4.Path4 = new TreeNode("Node 1.4.4.4", loveDataArray[7].Name[0],"","", loveDataArray[7].Dialouges[4], loveDataArray[7].ButtonText[3]);
        

                //MARS (2)
                // Further branching for Aliens from Mars
                root.Path2.Path1 = new TreeNode("Node 2.1", loveDataArray[2].Name[0], loveDataArray[2].CharacterImageLinks[0], "../../Resources/bg_mars.png", loveDataArray[2].Dialouges[0], loveDataArray[2].Name[0] + "\n" + loveDataArray[2].Name[1]);
                root.Path2.Path2 = new TreeNode("Node 2.2", loveDataArray[4].Name[0], loveDataArray[4].CharacterImageLinks[0], "../../Resources/bg_mars.png", loveDataArray[4].Dialouges[0], loveDataArray[4].Name[0] + "\n" + loveDataArray[4].Name[1]);
                root.Path2.Path3 = new TreeNode("Node 2.3", loveDataArray[5].Name[0], loveDataArray[5].CharacterImageLinks[0], "../../Resources/bg_mars.png", loveDataArray[5].Dialouges[0], loveDataArray[5].Name[0] + "\n" + loveDataArray[5].Name[1]);
                root.Path2.Path4 = new TreeNode("Node 2.4", loveDataArray[6].Name[0], loveDataArray[6].CharacterImageLinks[0], "../../Resources/bg_mars.png", loveDataArray[6].Dialouges[0], loveDataArray[6].Name[0] + "\n" + loveDataArray[6].Name[1]);

                 //alien 2 dialogue (ALL planets)
                 root.Path2.Path1.Path1 = new TreeNode("Node 2.1.1", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[1], loveDataArray[2].ButtonText[0]);
                 root.Path2.Path1.Path4 = new TreeNode("Node 2.1.4", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[2], loveDataArray[2].ButtonText[1]);

                 root.Path2.Path1.Path4.Path1 = new TreeNode("Node 2.1.4.1", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[3], loveDataArray[2].ButtonText[2]);
                 root.Path2.Path1.Path4.Path4 = new TreeNode("Node 2.1.4.4", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[4], loveDataArray[2].ButtonText[3]);

                //alien 4 dialogue (mercury and MARS)
                root.Path2.Path2.Path1 = new TreeNode("Node 2.2.1", loveDataArray[4].Name[0], "", "", loveDataArray[4].Dialouges[1], loveDataArray[4].ButtonText[0]);
                root.Path2.Path2.Path4 = new TreeNode("Node 2.2.4", loveDataArray[4].Name[0], "", "", loveDataArray[4].Dialouges[2], loveDataArray[4].ButtonText[1]);

                root.Path2.Path2.Path4.Path1 = new TreeNode("Node 2.2.4.1", loveDataArray[4].Name[0], "", "", loveDataArray[4].Dialouges[3], loveDataArray[4].ButtonText[2]);
                root.Path2.Path2.Path4.Path4 = new TreeNode("Node 2.2.4.4", loveDataArray[4].Name[0], "", "", loveDataArray[4].Dialouges[4], loveDataArray[4].ButtonText[3]);

                //alien 5 dialogue (Mars ONLY)
                root.Path2.Path3.Path1 = new TreeNode("Node 2.3.1", loveDataArray[5].Name[0], "", "", loveDataArray[5].Dialouges[1], loveDataArray[5].ButtonText[0]);
                root.Path2.Path3.Path4 = new TreeNode("Node 2.3.4", loveDataArray[5].Name[0], "", "", loveDataArray[5].Dialouges[2], loveDataArray[5].ButtonText[1]);

                root.Path2.Path3.Path4.Path1 = new TreeNode("Node 2.3.4.1", loveDataArray[5].Name[0], "", "", loveDataArray[5].Dialouges[3], loveDataArray[5].ButtonText[2]);
                root.Path2.Path3.Path4.Path4 = new TreeNode("Node 2.3.4.4", loveDataArray[5].Name[0], "", "", loveDataArray[5].Dialouges[4], loveDataArray[5].ButtonText[3]);

                //alien 6 dialogue (Mars and Saturn)
                root.Path2.Path4.Path1 = new TreeNode("Node 2.4.1", loveDataArray[6].Name[0], "", "", loveDataArray[6].Dialouges[1], loveDataArray[6].ButtonText[0]);
                root.Path2.Path4.Path4 = new TreeNode("Node 2.4.4", loveDataArray[6].Name[0], "", "", loveDataArray[6].Dialouges[2], loveDataArray[6].ButtonText[1]);
    
                root.Path2.Path4.Path4.Path1 = new TreeNode("Node 2.4.4.1", loveDataArray[6].Name[0], "", "", loveDataArray[6].Dialouges[3], loveDataArray[6].ButtonText[2]);
                root.Path2.Path4.Path4.Path4 = new TreeNode("Node 2.4.4.4", loveDataArray[6].Name[0], "", "", loveDataArray[6].Dialouges[4], loveDataArray[6].ButtonText[3]);


            //SATURN (3)
            // Further branching for Aliens from Saturn
            root.Path3.Path1 = new TreeNode("Node 3.1", loveDataArray[2].Name[0], loveDataArray[2].CharacterImageLinks[0], ""/*<--Saturn background goes there*/, loveDataArray[2].Dialouges[0], loveDataArray[2].Name[0] + "\n" + loveDataArray[2].Name[1]);
            root.Path3.Path4 = new TreeNode("Node 3.4", loveDataArray[6].Name[0], loveDataArray[6].CharacterImageLinks[0], ""/*<--Saturn background goes there*/, loveDataArray[6].Dialouges[0], loveDataArray[6].Name[0] + "\n" + loveDataArray[6].Name[1]);



                //alien 2 dialogue (ALL planets)
                root.Path3.Path1.Path1 = new TreeNode("Node 3.1.1", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[1], loveDataArray[2].ButtonText[0]);
                root.Path3.Path1.Path4 = new TreeNode("Node 3.1.4", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[2], loveDataArray[2].ButtonText[1]);

                root.Path3.Path1.Path4.Path1 = new TreeNode("Node 3.1.4.1", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[3], loveDataArray[2].ButtonText[2]);
                root.Path3.Path1.Path4.Path4 = new TreeNode("Node 3.1.4.4", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[4], loveDataArray[2].ButtonText[3]);

                //alien 6 dialogue (Mars and Saturn)
                root.Path3.Path4.Path1 = new TreeNode("Node 3.4.1", loveDataArray[6].Name[0], "", "", loveDataArray[6].Dialouges[1], loveDataArray[6].ButtonText[0]);
                root.Path3.Path4.Path4 = new TreeNode("Node 3.4.4", loveDataArray[6].Name[0], "", "", loveDataArray[6].Dialouges[2], loveDataArray[6].ButtonText[1]);

                root.Path3.Path4.Path4.Path1 = new TreeNode("Node 3.4.4.1", loveDataArray[6].Name[0], "", "", loveDataArray[6].Dialouges[3], loveDataArray[6].ButtonText[2]);
                root.Path3.Path4.Path4.Path4 = new TreeNode("Node 3.4.4.4", loveDataArray[6].Name[0], "", "", loveDataArray[6].Dialouges[4], loveDataArray[6].ButtonText[3]); 


            //SUN (4)
            // Further branching for Aliens from the SUN
            root.Path4.Path1 = new TreeNode("Node 4.1", loveDataArray[1].Name[0], loveDataArray[1].CharacterImageLinks[0], "../../Resources/bg_sun.png", loveDataArray[1].Dialouges[0], loveDataArray[1].Name[0] + "\n" + loveDataArray[1].Name[1]);
            root.Path4.Path2 = new TreeNode("Node 4.2", loveDataArray[2].Name[0], loveDataArray[2].CharacterImageLinks[0], "../../Resources/bg_sun.png", loveDataArray[2].Dialouges[0], loveDataArray[2].Name[0] + "\n" + loveDataArray[2].Name[1]);
            root.Path4.Path4 = new TreeNode("Node 4.3", loveDataArray[3].Name[0], loveDataArray[3].CharacterImageLinks[0], "../../Resources/bg_sun.png", loveDataArray[3].Dialouges[0], loveDataArray[3].Name[0] + "\n" + loveDataArray[3].Name[1]);

                 //alien 1 dialogue (SUN only)
                 root.Path4.Path1.Path1 = new TreeNode("Node 4.1.1", loveDataArray[1].Name[0], "", "", loveDataArray[1].Dialouges[1], loveDataArray[1].ButtonText[0]);
                 root.Path4.Path1.Path4 = new TreeNode("Node 4.1.4", loveDataArray[1].Name[0], "", "", loveDataArray[1].Dialouges[2], loveDataArray[1].ButtonText[1]);

                 root.Path4.Path1.Path4.Path1 = new TreeNode("Node 4.1.4.1", loveDataArray[1].Name[0], "", "", loveDataArray[1].Dialouges[3], loveDataArray[1].ButtonText[2]);
                 root.Path4.Path1.Path4.Path4 = new TreeNode("Node 4.1.4.4", loveDataArray[1].Name[0], "", "", loveDataArray[1].Dialouges[4], loveDataArray[1].ButtonText[3]);

                 //alien 2 dialogue (ALL planets)
                 root.Path4.Path2.Path1 = new TreeNode("Node 4.2.1", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[1], loveDataArray[2].ButtonText[0]);
                 root.Path4.Path2.Path4 = new TreeNode("Node 4.2.4", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[2], loveDataArray[2].ButtonText[1]);

                 root.Path4.Path2.Path4.Path1 = new TreeNode("Node 4.2.4.1", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[3], loveDataArray[2].ButtonText[2]);
                 root.Path4.Path2.Path4.Path4 = new TreeNode("Node 4.2.4.4", loveDataArray[2].Name[0], "", "", loveDataArray[2].Dialouges[4], loveDataArray[2].ButtonText[3]);

                 //alien 3 dialogue (SUN only)
                 root.Path4.Path4.Path1 = new TreeNode("Node 4.4.1", loveDataArray[3].Name[0], "", "", loveDataArray[3].Dialouges[1], loveDataArray[3].ButtonText[0]);
                 root.Path4.Path4.Path4 = new TreeNode("Node 4.4.4", loveDataArray[3].Name[0], "", "", loveDataArray[3].Dialouges[2], loveDataArray[3].ButtonText[1]);

                 root.Path4.Path4.Path4.Path1 = new TreeNode("Node 4.4.4.1", loveDataArray[3].Name[0], "", "", loveDataArray[3].Dialouges[3], loveDataArray[3].ButtonText[2]);
                 root.Path4.Path4.Path4.Path4 = new TreeNode("Node 4.4.4.4", loveDataArray[3].Name[0], "", "", loveDataArray[3].Dialouges[4], loveDataArray[3].ButtonText[3]);






        }

        // Button click event to start a new game
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            currentNode = root; // Always start from the root
            isEndGame = false; // Reset the end game flag

            btnStartGame.Visible = false; // Hide start button
            lblTextBox.Text = "Choose A Planet!"; // Show the first node
            pictureBox1.ImageLocation = "../../Resources/solarSystem.jpg";
            pictureBox1.Load();

            pictureBox2.Image = null ;
            

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
            
            btnOption1.Text = currentNode.Path1?.GivenData[5] ?? "No Path";
            btnOption2.Text = currentNode.Path2?.GivenData[5] ?? "No Path";
            btnOption3.Text = currentNode.Path3?.GivenData[5] ?? "No Path";
            btnOption4.Text = currentNode.Path4?.GivenData[5] ?? "No Path";
            
            /*
            btnOption1.Text = (currentNode.Path1?.GivenData[0]) + "\n" + (currentNode.Path1?.GivenData[5]) ?? "No Path";
            btnOption2.Text = (currentNode.Path2?.GivenData[0]) + "\n" + (currentNode.Path2?.GivenData[5]) ?? "No Path";
            btnOption3.Text = (currentNode.Path3?.GivenData[0]) + "\n" + (currentNode.Path3?.GivenData[5]) ?? "No Path";
            btnOption4.Text = (currentNode.Path4?.GivenData[0]) + "\n" + (currentNode.Path4?.GivenData[5]) ?? "No Path";
            */

            if (currentNode.Path1 == null) { btnOption1.Visible = false; }
            if (currentNode.Path2 == null) { btnOption2.Visible = false; }
            if (currentNode.Path3 == null) { btnOption3.Visible = false; }
            if (currentNode.Path4 == null) { btnOption4.Visible = false; }
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

                    //EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
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
                    //EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
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
                    //EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
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
                    //EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
                    isEndGame = true; // Set the game to end
                }
            }
        }

        // Handle the final end game response (no more "correct/incorrect" prompts)
        private void HandleEndGame()
        {
            //lblTextBox.Text = $"Game Over! You reached: {currentNode.GivenData[0]}";

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

            
            // location Image
            if (currentNode.GivenData[3] != "") {
                string imagePath = currentNode.GivenData[3];
                //pictureBox1.Image = Properties.Resources.imagePath;
                //pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.ImageLocation = imagePath ;
                pictureBox1.Load();
            }

            // character Image 
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
                //EndGame($"You reached: {currentNode.GivenData[0]}. Game Over!");
                isEndGame = true; // Set the game to end
                HandleEndGame();
                
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
        public string[] Name { get; set; }
        public string[] Dialouges { get; set; }

        public string[] ButtonText { get; set; }
        public string[] CharacterImageLinks { get; set; }
        public string[] PlanetImageLinks { get; set; }

        //public int Value { get; set; }

        public LoveData(string[] name, string[] characterImageLinks, string[] planetImageLinks, string[] dialouges, string[] buttonText)
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