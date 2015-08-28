using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pikabot4
{
    class clsCatch
    {
        #region Variables
        public string htmlblock;

        public string catchString;
        public string resultType;
        public string methodType;

        public string catchCompanion;
        public string mouseName;
        public string mouseWeight;
        public string mouseGold;
        public string mousePoints;
        public string mouseImage;
        public string mouseLoot;
        public string mousePillage;
        public string catchTime;
        public string rewardContents;

        public string itemTransacted;
        public string goldTransacted;
        public string hunterTransacted;
        public string transactionAction;

        public string toLocationTravelled;
        public string goldUsedTravelled;

        public string cheeseCrafted;
        public string cheeseUsed;
        public string potionsUsed;
        public string goldSpent;

        public string titleReceived;
        public string badgeReceived;
        public string numOfMiceForBadge;

        public string ballotsPurchased;

        #endregion

        public clsCatch(string html)
        {
            htmlblock = html;
        }

        public void parseData()
        {
            try
            {
                catchString = htmlblock.Substring(htmlblock.IndexOf("<div class=\"entry") + 18, (htmlblock.IndexOf("\"><div class=\"")) - (htmlblock.IndexOf("<div class=\"entry") + 18));

                #region catchsuccess
                if (catchString.Contains("catchsuccess"))
                {
                    resultType = "catchsuccess";
                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    #region Active / Linked / Passive
                    if (catchString.Contains("active"))
                    {
                        methodType = "active";
                    }
                    else if (catchString.Contains("linked"))
                    {
                        catchCompanion = htmlblock.Substring(htmlblock.IndexOf("+ Math.random();return true;\">") + 30, (htmlblock.IndexOf("</a> where I was successful in my hunt!")) - (htmlblock.IndexOf("+ Math.random();return true;\">") + 30));
                        htmlblock = htmlblock.Substring(htmlblock.IndexOf("where I was successful in my hunt! ") + 34);
                        methodType = "linked";
                    }
                    else
                    {
                        methodType = "passive";
                    }
                    #endregion

                    #region Mouse Image String
                    mouseImage = htmlblock.Substring(htmlblock.IndexOf("oz. <a href=\"http://apps.facebook.com/mousehunt/adversaries.php?mouse=") + 70, (htmlblock.IndexOf("\" onclick=\"(new Image()).src =")) - (htmlblock.IndexOf("oz. <a href=\"http://apps.facebook.com/mousehunt/adversaries.php?mouse=") + 70));
                    #endregion

                    #region Mouse Name
                    mouseName = htmlblock.Substring(htmlblock.IndexOf("+ Math.random();return true;\">") + 30, (htmlblock.IndexOf("</a> worth ")) - (htmlblock.IndexOf("+ Math.random();return true;\">") + 30));
                    #endregion

                    #region Mouse Weight
                    if (mouseName[0].Equals('A') || mouseName[0].Equals('E') || mouseName[0].Equals('I') || mouseName[0].Equals('O') || mouseName[0].Equals('U'))
                    {
                        mouseWeight = htmlblock.Substring(htmlblock.IndexOf("I caught an ") + 12, (htmlblock.IndexOf(" oz. ") + 4) - (htmlblock.IndexOf("I caught an ") + 12));
                    }
                    else
                    {
                        mouseWeight = htmlblock.Substring(htmlblock.IndexOf("I caught a ") + 11, (htmlblock.IndexOf(" oz. ") + 4) - (htmlblock.IndexOf("I caught a ") + 11));
                    }
                    #endregion

                    #region Mouse Gold
                    mouseGold = htmlblock.Substring(htmlblock.IndexOf("points and ") + 11, (htmlblock.IndexOf(" gold.")) - (htmlblock.IndexOf("points and ") + 11));
                    #endregion

                    #region Mouse Points
                    mousePoints = htmlblock.Substring(htmlblock.IndexOf("</a> worth ") + 11, (htmlblock.IndexOf(" points ")) - (htmlblock.IndexOf("</a> worth ") + 11));
                    #endregion

                    #region Mouse Loot
                    mouseLoot = "nothing";
                    #endregion
                }
                #endregion

                #region catchuccessloot
                else if (catchString.Contains("catchuccessloot"))
                {
                    resultType = "catchuccessloot";
                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    #region Active / Linked / Passive
                    if (catchString.Contains("active"))
                    {
                        methodType = "active";
                    }
                    else if (catchString.Contains("linked"))
                    {
                        catchCompanion = htmlblock.Substring(htmlblock.IndexOf("+ Math.random();return true;\">") + 30, (htmlblock.IndexOf("</a> where I was successful in my hunt!")) - (htmlblock.IndexOf("+ Math.random();return true;\">") + 30));
                        htmlblock = htmlblock.Substring(htmlblock.IndexOf("where I was successful in my hunt! ") + 34);
                        methodType = "linked";
                    }
                    else
                    {
                        htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));
                        methodType = "passive";
                    }
                    #endregion

                    #region Mouse Image String
                    mouseImage = htmlblock.Substring(htmlblock.IndexOf("oz. <a href=\"http://apps.facebook.com/mousehunt/adversaries.php?mouse=") + 70, (htmlblock.IndexOf("\" onclick=\"(new Image()).src =")) - (htmlblock.IndexOf("oz. <a href=\"http://apps.facebook.com/mousehunt/adversaries.php?mouse=") + 70));
                    #endregion

                    #region Mouse Name
                    mouseName = htmlblock.Substring(htmlblock.IndexOf("+ Math.random();return true;\">") + 30, (htmlblock.IndexOf("</a> worth ")) - (htmlblock.IndexOf("+ Math.random();return true;\">") + 30));
                    #endregion

                    #region Mouse Weight
                    if (mouseName[0].Equals('A') || mouseName[0].Equals('E') || mouseName[0].Equals('I') || mouseName[0].Equals('O') || mouseName[0].Equals('U'))
                    {
                        mouseWeight = htmlblock.Substring(htmlblock.IndexOf("I caught an ") + 12, (htmlblock.IndexOf(" oz. ") + 4) - (htmlblock.IndexOf("I caught an ") + 12));
                    }
                    else
                    {
                        mouseWeight = htmlblock.Substring(htmlblock.IndexOf("I caught a ") + 11, (htmlblock.IndexOf(" oz. ") + 4) - (htmlblock.IndexOf("I caught a ") + 11));
                    }
                    #endregion

                    #region Mouse Gold
                    mouseGold = htmlblock.Substring(htmlblock.IndexOf("points and ") + 11, (htmlblock.IndexOf(" gold.")) - (htmlblock.IndexOf("points and ") + 11));
                    #endregion

                    #region Mouse Points
                    mousePoints = htmlblock.Substring(htmlblock.IndexOf("</a> worth ") + 11, (htmlblock.IndexOf(" points ")) - (htmlblock.IndexOf("</a> worth ") + 11));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf(" points "));

                    #region Mouse Loot
                    mouseLoot = htmlblock.Substring(htmlblock.IndexOf("+ Math.random();return true;\">") + 30, (htmlblock.IndexOf("</a></div></div>")) - (htmlblock.IndexOf("+ Math.random();return true;\">") + 30));
                    #endregion

                    //MessageBox.Show(catchTime + "\n" + catchCompanion + "\n" + mouseImage + "\n" + mouseName + "\n" + mouseWeight + "\n" + mouseGold + " gold\n" + mousePoints + " points\n" + mouseLoot);
                }
                #endregion

                #region catchfailuredamage
                else if (catchString.Contains("catchfailuredamage"))
                {
                    resultType = "catchfailuredamage";
                    mouseImage = "log_catchfailuredamage";
                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    #region Active / Linked / Passive
                    if (catchString.Contains("active"))
                    {
                        methodType = "active";
                    }
                    else if (catchString.Contains("linked"))
                    {
                        methodType = "linked";
                    }
                    else
                    {
                        methodType = "passive";
                    }
                    #endregion

                    #region Mouse Name
                    if (methodType.Equals("linked"))
                    {
                        htmlblock = htmlblock.Substring(htmlblock.IndexOf("but my efforts were fruitless."));
                    }
                    mouseName = htmlblock.Substring(htmlblock.IndexOf(" + Math.random();return true;\">") + 31, (htmlblock.IndexOf("</a> ate a piece of cheese without setting off my trap.")) - (htmlblock.IndexOf(" + Math.random();return true;\">") + 31));
                    #endregion

                    #region Pillaged Contents
                    if (htmlblock.Contains("the fiend pillaged "))
                    {
                        mousePillage = "Pillaged: " + htmlblock.Substring(htmlblock.IndexOf("the fiend pillaged ") + 19, (htmlblock.IndexOf(" from me!")) - (htmlblock.IndexOf("the fiend pillaged ") + 19));
                    }
                    else if (htmlblock.Contains("Additionally, the power of this mouse crippled my courage, setting me back"))
                    {
                        mousePillage = "Crippled: " + htmlblock.Substring(htmlblock.IndexOf("Additionally, the power of this mouse crippled my courage, setting me back") + 75, (htmlblock.IndexOf(" points!") + 7) - (htmlblock.IndexOf("Additionally, the power of this mouse crippled my courage, setting me back") + 75));
                    }
                    else
                    {
                        mousePillage = "Stole: " + htmlblock.Substring(htmlblock.IndexOf("Additionally, the crafty mouse managed to steal an additional ") + 61, (htmlblock.IndexOf(" of my bait!") + 11) - (htmlblock.IndexOf("Additionally, the crafty mouse managed to steal an additional ") + 61));
                    }
                    #endregion

                }
                #endregion

                #region catchfailure
                else if (catchString.Contains("catchfailure"))
                {
                    resultType = "catchfailure";
                    mouseImage = "log_catchfailure";
                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    #region Active / Linked / Passive
                    if (catchString.Contains("active"))
                    {
                        methodType = "active";
                    }
                    else if (catchString.Contains("linked"))
                    {
                        methodType = "linked";
                    }
                    else
                    {
                        methodType = "passive";
                    }
                    #endregion

                    #region Mouse Name
                    if (methodType.Equals("passive"))
                    {
                        mouseName = htmlblock.Substring(htmlblock.IndexOf(" + Math.random();return true;\">") + 31, (htmlblock.IndexOf("</a> had eaten a piece of cheese without setting it off.")) - (htmlblock.IndexOf(" + Math.random();return true;\">") + 31));
                    }
                    else if (methodType.Equals("linked"))
                    {
                        htmlblock = htmlblock.Substring(htmlblock.IndexOf("but my efforts were fruitless."));
                        mouseName = htmlblock.Substring(htmlblock.IndexOf(" + Math.random();return true;\">") + 31, (htmlblock.IndexOf("</a> ate a piece of cheese without setting off my trap.")) - (htmlblock.IndexOf(" + Math.random();return true;\">") + 31));
                    }
                    else
                    {
                        mouseName = htmlblock.Substring(htmlblock.IndexOf(" + Math.random();return true;\">") + 31, (htmlblock.IndexOf("</a> ate a piece of cheese without setting off my trap.")) - (htmlblock.IndexOf(" + Math.random();return true;\">") + 31));
                    }
                    #endregion
                }
                #endregion

                #region attractionfailurestale
                else if (catchString.Contains("attractionfailurestale"))
                {
                    resultType = "attractionfailurestale";
                    mouseImage = "log_attractionfailurestale";
                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    #region Active / Linked / Passive
                    if (catchString.Contains("active"))
                    {
                        methodType = "active";
                    }
                    else if (catchString.Contains("linked"))
                    {
                        methodType = "linked";
                    }
                    else
                    {
                        methodType = "passive";
                    }
                    #endregion
                }
                #endregion

                #region attractionfailure
                else if (catchString.Contains("attractionfailure"))
                {
                    resultType = "attractionfailure";
                    mouseImage = "log_attractionfailure";
                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    #region Active / Linked / Passive
                    if (catchString.Contains("active"))
                    {
                        methodType = "active";
                    }
                    else if (catchString.Contains("linked"))
                    {
                        methodType = "linked";
                    }
                    else
                    {
                        methodType = "passive";
                    }
                    #endregion
                }
                #endregion

                #region captchasolved
                else if (catchString.Contains("captchasolved"))
                {
                    resultType = "captchasolved";
                    mouseImage = "log_captchasolved";
                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    #region Reward Contents
                    rewardContents = htmlblock.Substring(htmlblock.IndexOf("I claimed a King's Reward worth ") + 32, (htmlblock.IndexOf(".</div></div>")) - (htmlblock.IndexOf("I claimed a King's Reward worth ") + 32));
                    #endregion
                }
                #endregion

                #region itemtransaction
                else if (catchString.Contains("itemtransaction"))
                {
                    resultType = "itemtransaction";
                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Transaction Contents
                    if (htmlblock.Contains("I purchased"))
                    {
                        itemTransacted = htmlblock.Substring(htmlblock.IndexOf("I purchased") + 12, (htmlblock.IndexOf(" for")) - (htmlblock.IndexOf("I purchased") + 12));
                        goldTransacted = htmlblock.Substring(htmlblock.IndexOf("for ") + 4, (htmlblock.IndexOf(" gold.")) - (htmlblock.IndexOf("for ") + 4));
                        transactionAction = "Purchased ";
                        mouseImage = "log_itemplus";
                    }
                    else if (htmlblock.Contains("I sold"))
                    {
                        itemTransacted = htmlblock.Substring(htmlblock.IndexOf("I sold") + 7, (htmlblock.IndexOf(" for")) - (htmlblock.IndexOf("I sold") + 7));
                        goldTransacted = htmlblock.Substring(htmlblock.IndexOf("for ") + 4, (htmlblock.IndexOf(" gold.")) - (htmlblock.IndexOf("for ") + 4));
                        transactionAction = "Sold ";
                        mouseImage = "log_goldplus";
                    }
                    #endregion
                }
                #endregion

                #region supplytransferitem
                else if (catchString.Contains("supplytransferitem"))
                {
                    resultType = "supplytransferitem";
                    mouseImage = "log_itemplus";

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Transfer Contents
                    if (htmlblock.Contains("I sent "))
                    {
                        transactionAction = "Sent ";
                        itemTransacted = htmlblock.Substring(htmlblock.IndexOf("I sent ") + 7, (htmlblock.IndexOf(" to <a href=\"http://apps.facebook.com/mousehunt/hunterprofile.php?")) - (htmlblock.IndexOf("I sent ") + 7));
                        hunterTransacted = htmlblock.Substring(htmlblock.IndexOf("Math.random();return true;\">") + 28, (htmlblock.IndexOf("</a>.</div></div>")) - (htmlblock.IndexOf("Math.random();return true;\">") + 28));
                    }
                    else if (htmlblock.Contains("I received "))
                    {
                        transactionAction = "Received ";
                        itemTransacted = htmlblock.Substring(htmlblock.IndexOf("I received ") + 11, (htmlblock.IndexOf(" from <a href=\"http://apps.facebook.com/mousehunt/hunterprofile.php?")) - (htmlblock.IndexOf("I received ") + 11));
                        hunterTransacted = htmlblock.Substring(htmlblock.IndexOf("Math.random();return true;\">") + 28, (htmlblock.IndexOf("</a>.</div></div>")) - (htmlblock.IndexOf("Math.random();return true;\">") + 28));
                    }
                    #endregion
                }
                #endregion

                #region supplytransfergold
                else if (catchString.Contains("supplytransfergold"))
                {
                    resultType = "supplytransfergold";
                    mouseImage = "log_goldplus";

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Transfer Contents
                    if (htmlblock.Contains("I sent "))
                    {
                        transactionAction = "Sent ";
                        goldTransacted = htmlblock.Substring(htmlblock.IndexOf("I sent ") + 7, (htmlblock.IndexOf(" to <a href=\"http://apps.facebook.com/mousehunt/hunterprofile.php?")) - (htmlblock.IndexOf("I sent ") + 7));
                        hunterTransacted = htmlblock.Substring(htmlblock.IndexOf("Math.random();return true;\">") + 28, (htmlblock.IndexOf("</a> from which the King deducted")) - (htmlblock.IndexOf("Math.random();return true;\">") + 28));
                    }
                    else if (htmlblock.Contains("I received "))
                    {
                        transactionAction = "Received ";
                        goldTransacted = htmlblock.Substring(htmlblock.IndexOf("I received ") + 11, (htmlblock.IndexOf(" from <a href=\"http://apps.facebook.com/mousehunt/hunterprofile.php?")) - (htmlblock.IndexOf("I received ") + 11));
                        hunterTransacted = htmlblock.Substring(htmlblock.IndexOf("Math.random();return true;\">") + 28, (htmlblock.IndexOf("</a>.</div></div>")) - (htmlblock.IndexOf("Math.random();return true;\">") + 28));
                    }
                    #endregion
                }
                #endregion

                #region travel
                else if (catchString.Contains("travel"))
                {
                    resultType = "travel";
                    mouseImage = "log_travel";

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Travel Details
                    if (htmlblock.Contains("I was guided by Larry"))
                    {
                        toLocationTravelled = htmlblock.Substring(htmlblock.IndexOf("I was guided by Larry back to the ") + 34, (htmlblock.IndexOf(" free of charge.")) - (htmlblock.IndexOf("I was guided by Larry back to the ") + 34));
                        goldUsedTravelled = "0";
                    }
                    else if (htmlblock.Contains("I traveled to "))
                    {
                        toLocationTravelled = htmlblock.Substring(htmlblock.IndexOf("I traveled to ") + 14, (htmlblock.IndexOf(" for the cost of")) - (htmlblock.IndexOf("I traveled to ") + 14));
                        goldUsedTravelled = htmlblock.Substring(htmlblock.IndexOf("for the cost of ") + 16, (htmlblock.IndexOf(" gold.")) - (htmlblock.IndexOf("for the cost of ") + 16));
                    }
                    else
                    {
                        toLocationTravelled = "";
                        goldUsedTravelled = "";
                    }
                    #endregion;
                }
                #endregion

                #region marketplacepurchase
                else if (catchString.Contains("marketplacepurchase"))
                {
                    resultType = "marketplacepurchase";
                    mouseImage = "log_itemplus";

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Item Transaction
                    itemTransacted = htmlblock.Substring(htmlblock.IndexOf("I purchased ") + 12, (htmlblock.IndexOf(" for ")) - (htmlblock.IndexOf("I purchased ") + 12));
                    #endregion

                    #region Gold Transaction
                    goldTransacted = htmlblock.Substring(htmlblock.IndexOf(" for ") + 5, (htmlblock.IndexOf(" gold at the Marketplace.")) - (htmlblock.IndexOf(" for ") + 5));
                    #endregion
                }
                #endregion

                #region marketplacesale
                else if (catchString.Contains("marketplacesale"))
                {
                    resultType = "marketplacesale";
                    mouseImage = "log_goldplus";

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Item Transaction
                    itemTransacted = htmlblock.Substring(htmlblock.IndexOf("I sold ") + 7, (htmlblock.IndexOf(" for ")) - (htmlblock.IndexOf("I sold ") + 7));
                    #endregion

                    #region Gold Transaction
                    goldTransacted = htmlblock.Substring(htmlblock.IndexOf(" for ") + 5, (htmlblock.IndexOf(" gold each at the Marketplace.")) - (htmlblock.IndexOf(" for ") + 5));
                    #endregion
                }
                #endregion

                #region potionuse
                else if (catchString.Contains("potionuse"))
                {
                    resultType = "potionuse";
                    mouseImage = "log_cheesecraft";

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Cheese Crafted
                    cheeseCrafted = htmlblock.Substring(htmlblock.IndexOf("I created ") + 10, (htmlblock.IndexOf(" which used ")) - (htmlblock.IndexOf("I created ") + 10));
                    #endregion

                    #region Cheese Used
                    cheeseUsed = htmlblock.Substring(htmlblock.IndexOf("which used <span class=\"token\">") + 31, (htmlblock.IndexOf("</span>")) - (htmlblock.IndexOf("which used <span class=\"token\">") + 31));
                    #endregion

                    if (htmlblock.Contains("gold"))
                    {
                        #region Potions Used
                        htmlblock = htmlblock.Substring(htmlblock.IndexOf("</span>") + 7);
                        potionsUsed = htmlblock.Substring(htmlblock.IndexOf("<span class=\"token\">") + 20, (htmlblock.IndexOf("</span> and ")) - (htmlblock.IndexOf("<span class=\"token\">") + 20));
                        #endregion

                        #region Gold Used
                        htmlblock = htmlblock.Substring(htmlblock.IndexOf("</span> and ") + 12);
                        goldSpent = htmlblock.Substring(htmlblock.IndexOf("<span class=\"token\">") + 20, (htmlblock.IndexOf("</span>.")) - (htmlblock.IndexOf("<span class=\"token\">") + 20));
                        #endregion
                    }
                    else
                    {
                        #region Potions Used
                        htmlblock = htmlblock.Substring(htmlblock.IndexOf("</span>") + 7);
                        potionsUsed = htmlblock.Substring(htmlblock.IndexOf("<span class=\"token\">") + 20, (htmlblock.IndexOf("</span>.</div>")) - (htmlblock.IndexOf("<span class=\"token\">") + 20));
                        #endregion

                        #region Gold Used
                        goldSpent = "0 gold";
                        #endregion
                    }

                }
                #endregion

                #region craft
                else if (catchString.Contains("craft"))
                {
                    resultType = "craft";
                    mouseImage = "log_cheesecraft";

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Cheese Crafted
                    cheeseCrafted = htmlblock.Substring(htmlblock.IndexOf("I crafted ") + 10, (htmlblock.IndexOf(".</div></div>")) - (htmlblock.IndexOf("I crafted ") + 10));
                    #endregion
                }
                #endregion

                #region titlechange
                else if (catchString.Contains("titlechange"))
                {
                    resultType = "titlechange";
                    mouseImage = "log_titlechange";

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region Title Changed To
                    titleReceived = htmlblock.Substring(htmlblock.IndexOf("I received the title of ") + 24, (htmlblock.IndexOf("!<br /><br /></div>")) - (htmlblock.IndexOf("I received the title of ") + 24));
                    #endregion
                }
                #endregion

                #region badge
                else if (catchString.Contains("badge"))
                {
                    resultType = "badge";

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    #region numOfMiceForBadge
                    numOfMiceForBadge = htmlblock.Substring(htmlblock.IndexOf("I caught my ") + 12, htmlblock.IndexOf("th ") - (htmlblock.IndexOf("I caught my ") + 12));
                    #endregion

                    #region Mouse Type
                    mouseName = htmlblock.Substring(htmlblock.IndexOf("I caught my " + numOfMiceForBadge + "th ") + 15 + numOfMiceForBadge.Length, htmlblock.IndexOf(" Mouse and earned a") - (htmlblock.IndexOf("I caught my " + numOfMiceForBadge + "th ") + 15 + numOfMiceForBadge.Length));
                    #endregion

                    #region Badge Received
                    badgeReceived = htmlblock.Substring(htmlblock.IndexOf("Mouse and earned a ") + 19, (htmlblock.IndexOf("!<br /><br />I can view my trophy crowns on my")) - (htmlblock.IndexOf("Mouse and earned a ") + 19));
                    #endregion

                    if (badgeReceived.Contains("Bronze"))
                        mouseImage = "log_bronze";
                    else if (badgeReceived.Contains("Silver"))
                        mouseImage = "log_silver";
                    else if (badgeReceived.Contains("Gold"))
                        mouseImage = "log_gold";
                    else
                        mouseImage = "no_img";
                }
                #endregion

                #region misc
                else if (catchString.Contains("misc"))
                {
                    resultType = "misc";

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    if (htmlblock.Contains("The tide suddenly rose and the entire cove was flooded with water! I was quickly washed up on the shore of the Jungle of Dread."))
                    {
                        toLocationTravelled = "Jungle Of Dread";
                        mouseImage = "log_travel";
                    }
                    else
                    {
                        toLocationTravelled = "";
                        mouseImage = "no_img";
                    }

                }
                #endregion

                #region drawballotpurchase
                else if (catchString.Contains("drawballotpurchase"))
                {
                    resultType = "drawballotpurchase";

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">"));

                    #region Time Of Catch
                    catchTime = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaldate\">") + 25, (htmlblock.IndexOf(" - ")) - (htmlblock.IndexOf("<div class=\"journaldate\">") + 25));
                    #endregion

                    htmlblock = htmlblock.Substring(htmlblock.IndexOf("<div class=\"journaltext\">"));

                    ballotsPurchased = htmlblock.Substring(htmlblock.IndexOf("I purchased ") + 12, (htmlblock.IndexOf(" ballot(s) to try and win")) - (htmlblock.IndexOf("I purchased ") + 12));
                    mouseImage = "log_ballot";
                }
                #endregion

                #region other
                else
                {
                    resultType = "other";
                    methodType = "other";
                    mouseImage = "other";
                }
                #endregion
            }
            catch (Exception ex)
            {
                string debugContents;
                debugContents = DateTime.Now.ToString() + "\n\n";
                debugContents += "=====\nERROR\n=====\n\n";
                debugContents += ex + "\n\n\n";
                debugContents += "=========\nHTMLBLOCK\n=========\n\n";
                debugContents += htmlblock + "\n\n\n";
                debugContents += "===========\nCATCHSTRING\n===========\n\n";
                debugContents += catchString;

                clsFunctions.writeToFile(debugContents, Application.StartupPath.ToString() + @"\errorlog.log");
            }
        }
    }
}
