using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikabot4
{
    class clsAccount
    {
        string username;
        string password;
        string shortusername;

        bool dHasKR;
        string dRank;
        string dGender;
        double dPercentage;
        string dGold;
        string dPoints;
        bool dIsDonor;
        string dGSExpiryDate;
        string dWeapon;
        string dBase;
        string dCheese;
        int dCheeseQuantity;
        string dLocation;

        int dHornTime;

        public clsAccount(string user, string pwd)
        {
            username = user;
            password = pwd;
            shortusername = user.Substring(0, user.IndexOf("@"));
        }

        #region GetSet Functions
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Shortusername
        {
            get { return this.shortusername; }
            set { this.shortusername = value; }
        }

        public bool DHasKR
        {
            get { return this.dHasKR; }
            set { this.dHasKR = value; }
        }

        public string DRank
        {
            get { return this.dRank; }
            set { this.dRank = value; }
        }

        public string DGender
        {
            get { return this.dGender; }
            set { this.dGender = value; }
        }

        public double DPercentage
        {
            get { return this.dPercentage; }
            set { this.dPercentage = value; }
        }

        public string DGold
        {
            get { return this.dGold; }
            set { this.dGold = value; }
        }

        public string DPoints
        {
            get { return this.dPoints; }
            set { this.dPoints = value; }
        }

        public bool DIsDonor
        {
            get { return this.dIsDonor; }
            set { this.dIsDonor = value; }
        }

        public string DGSExpiryDate
        {
            get { return this.dGSExpiryDate; }
            set { this.dGSExpiryDate = value; }
        }

        public string DWeapon
        {
            get { return this.dWeapon; }
            set { this.dWeapon = value; }
        }

        public string DBase
        {
            get { return this.dBase; }
            set { this.dBase = value; }
        }

        public string DCheese
        {
            get { return this.dCheese; }
            set { this.dCheese = value; }
        }

        public int DCheeseQuantity
        {
            get { return this.dCheeseQuantity; }
            set { this.dCheeseQuantity = value; }
        }

        public string DLocation
        {
            get { return this.dLocation; }
            set { this.dLocation = value; }
        }

        public int DHornTime
        {
            get { return this.dHornTime; }
            set { this.dHornTime = value; }
        }
        #endregion
    }
}
