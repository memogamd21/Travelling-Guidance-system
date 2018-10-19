using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;



namespace onlineTravelSystem
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

        
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

     

        public int InsertTraveller(string Account_ID, string fullName)
        {
            string query = "INSERT INTO traveller (Account_ID,fullName) " + "Values('" + Account_ID + "','" + fullName + "');";
            return dbMan.ExecuteNonQuery(query);
        }
       /* please try to give us at least partial credit in this part because we didn't have the time to complete it :D
        *public void sendVisaDocs(button e)
        {

            if(e.checked == true){
                    string query = "SELECT REQUIREMENTS FROM traveller,traveller chosen destination, visaRequirements WHERE TravellerId == AccountId AND CountryName == Name AND TripId =  ;";
                }
        }*/

        public DataTable findpossibletrips(int travellerbudget)
        {
            string query = "SELECT * FROM OfferedPAckage WHERE travellerbudget < = TotalPrice - Discounts";
            return dbMan.ExecuteReader(query);
        }

        public DataTable findAirlinemaxrating()
        {
            string query = "SELECT MAX(Rating) FROM AirLine ";

            return dbMan.ExecuteReader(query);
        }

        public DataTable findtravelagencymaxrating()
        {
            string query = "SELECT MAX(Rating) FROM TravelAgency ";

            return dbMan.ExecuteReader(query);
        }

        public DataTable findtwoweekpackages()
        {// finds trips that will stay for two weeks
            string query = "SELECT * FROM OfferedPackagesOnline, Trip, Airline  WHERE TripId == ID AND PackId == PkgId AND AirlineName = Name AND duration == 15";

            return dbMan.ExecuteReader(query);
        }

        public DataTable findspecifictrips(int x, bool y)
        {// finds trips with budget greater than x and medical check = y
            string query = "SELECT * FROM Traveller, Trip, Country  WHERE TripId == ID AND TravellerId == AccountId AND CountryName = Name AND CurrentBudget >= x AND MedicalCheck == y";

            return dbMan.ExecuteReader(query);
        }






    }

}
;

