﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAL;


namespace Capstone
{
    public class CampingCLI
    {

        private string connectionString;
        private string userCampChoice = "";
        private decimal sitePrice = 0.00M;//used to calculate site price per reservation with reservered days variable
        private int reservedDays = 0;


        public CampingCLI(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void RunCLI()
        {
            while (true)
            {
                ParkMenu();
            }
        }

        public void ParkMenu()
        {

            ParkDAL allParks = new ParkDAL(connectionString);
            List<ParkModel> compiledParks = allParks.GetAllParks();//creates list of parks for menu
            Console.WriteLine("Select a Park for Further Details ");

            for (int i = 0; i < compiledParks.Count; i++)//loops through the list to display each park name in database
            {
                Console.WriteLine($"{compiledParks[i].ParkId}) {compiledParks[i].ParkName}");
            }
            Console.WriteLine($"Press Q to Quit");
            Console.WriteLine();
            string parkId = Console.ReadLine();

            foreach (ParkModel item in compiledParks)//loop to check if user input matches park id
            {

                if (parkId.ToLower() == "q")
                {
                    Environment.Exit(0);
                }
                else if (parkId != item.ParkId.ToString())
                {
                    //Console.WriteLine("Please Select Valid Option");
                    //Console.ReadLine();
                    //Console.Clear();
                    //SEE IF YOU CAN FIGURE OUT HOW TO NOT WRITE THSI MESSAGE 10000 TIMES
                    //Console.WriteLine("Please make a valid selection ");
                }
                else
                {
                    Console.Clear();
                    ParkInformationMenu(parkId);

                }
            }
        }
        public void ParkInformationMenu(string parkId)
        {
            bool ifTrue = true;
            while (ifTrue)
            {
                ParkInformation(parkId);//calls the ParkInformation Method to display park info then the rest of this method builds menu
                Console.WriteLine();
                Console.WriteLine("Select a command");
                Console.WriteLine();
                Console.WriteLine("1) View CampGrounds");
                //Console.WriteLine("2) Search For Reservation"); commeneted out for redundancy
                Console.WriteLine("2) Return To Previous Screen");
                Console.WriteLine();

                string userInputParkMenu = Console.ReadLine();

                if (userInputParkMenu == "1")
                {
                    ViewCampGroundMenu(parkId);

                }
                //else if (userInput == "2")
                //{
                //    ViewCampgrounds(parkId);
                //    SearchReservationMenu();
                //}
                else if (userInputParkMenu == "2")
                {
                    Console.Clear();
                    ifTrue = false;

                }
                else
                {
                    Console.WriteLine("Please enter a valid selection");
                }

            }
        }

        public void ParkInformation(string parkId)
        {
            ParkDAL thisPark = new ParkDAL(connectionString);
            List<ParkModel> parkInfoList = thisPark.GetAllParks();

            Console.WriteLine("Park Information");

            for (int i = 0; i < parkInfoList.Count; i++)//loops through to build park information from park model
            {
                if (parkId == parkInfoList[i].ParkId.ToString())
                {
                    Console.WriteLine(parkInfoList[i].ParkName + " National Park");
                    Console.WriteLine("Location:" + parkInfoList[i].ParkLocation.PadLeft(20));
                    Console.WriteLine("Established:".PadRight(24) + parkInfoList[i].ParkEstablishDate.Date.ToShortDateString());
                    Console.WriteLine("Area:" + parkInfoList[i].Area.ToString().PadLeft(24) + " sq km");
                    Console.WriteLine("Annual Visitors:" + parkInfoList[i].Visitors.ToString().PadLeft(15));
                    Console.WriteLine();
                    WrapText(parkInfoList[i].ParkDescription);
                }
            }

           
        }

        public void ViewCampGroundMenu(string parkId)
        {
            bool ifTrue = true;
            while (ifTrue)
            {
                ViewCampgrounds(parkId);
                Console.WriteLine();
                Console.WriteLine("Select a Command");
                Console.WriteLine("  1) Search For Available Reservation");
                Console.WriteLine("  2) Return To Previous Screen");
                Console.WriteLine();

                string userSelection = Console.ReadLine();

                if (userSelection == "1")
                {
                    SearchReservationMenu();
                    
                }
                else if (userSelection == "2")
                {
                    Console.Clear();
                    ifTrue = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection");
                }
            }

        }

        public void ViewCampgrounds(string parkId)//creates and writes list of campground from the specified parkId then calls the campground menu
        {
            Console.Clear();
            CampGroundDAL campground = new CampGroundDAL(connectionString);
            List<CampgroundModel> campList = campground.CampgroundsInPark(parkId);
            Console.WriteLine("Search for Campground Reservation");
            Console.WriteLine();
            Console.WriteLine("Name".PadLeft(17) + "Open".PadLeft(29) + "Close".PadLeft(16) + "Daily Cost".PadLeft(18));
            for (int i = 0; i < campList.Count; i++)
            {
                if (parkId == campList[i].ParkId.ToString())
                {
                    Console.WriteLine(campList[i].ToString());

                }
            }

            
        }


        public void SearchReservationMenu()
        {


            Console.Write("Which campground (enter 0 to cancel)? ");
            string campgroundInput = Console.ReadLine();
            userCampChoice = campgroundInput;
            if (campgroundInput != "0")
            {
                DateTime arrivalTime = CLIHelper.GetDateTime("What Is the Arrival Date?(mm-dd-yyyy) ");
                string arrivalInput = arrivalTime.Date.ToShortDateString();
                DateTime departTime = CLIHelper.GetDateTime("What is the Departure Date?(mm-dd-yyyy) ");
                string departureInput = departTime.Date.ToShortDateString();
                TimeSpan diff = (departTime - arrivalTime);
                reservedDays = diff.Days;
                AvailableSites(campgroundInput, arrivalInput, departureInput);


            }
            else if (campgroundInput == "0") 
            {
                Console.Clear();
            }

        }

        public void AvailableSites(string campgroundID, string arrivalDate, string endDate)
        {
            Console.Clear();
            bool ifTrue = true;
            SiteDAL sites = new SiteDAL(connectionString);
            List<SiteModel> availableSiteList = sites.AvailableSiteSearch(campgroundID, arrivalDate, endDate);
            Console.WriteLine("Results Matching Your Search Criteria");
            Console.WriteLine("Site No." + "Max Occup.".PadLeft(20) + "Accessible?".PadLeft(20) + "Max RV Length".PadLeft(20) + "Utility".PadLeft(18) + "Cost".PadLeft(8));
            if (availableSiteList.Count == 0)
            {
                Console.WriteLine("No Sites Available!");
                ifTrue = false;
            }

            while (ifTrue)
            {
                CampGroundDAL campground = new CampGroundDAL(connectionString);
                List<CampgroundModel> campList = campground.CampgroundsInPark(userCampChoice);

                for (int i = 0; i < campList.Count; i++)//loops through the list of campgrounds to provide the total cost of reservation with campsite cost and reservation days
                {
                    if (campgroundID == campList[i].CampgroundId.ToString())
                    {
                        sitePrice = campList[i].DailyCost * (decimal)reservedDays;


                    }
                }

                for (int i = 0; i < availableSiteList.Count; i++)//loops through to show details of available sites
                {
                    if (campgroundID == availableSiteList[i].CampgroundId.ToString())
                    {
                        Console.WriteLine(availableSiteList[i].ToString() + sitePrice.ToString("C2"));
                    }
                }

                ReservationSiteSelection(arrivalDate, endDate);
                ifTrue = false;
            }

        }

        public void ReservationSiteSelection(string arrivalDate, string endDate)
        {
            bool ifTrue = true;
            while (ifTrue)
            {
                Console.Write("Which site should be reserved? (enter 0 to cancel) ");
                string siteToBeReserved = Console.ReadLine();
                if (siteToBeReserved != "0")
                {
                    Console.Write("What name should the reservation name be under? ");
                    string reservationName = Console.ReadLine();


                    int reservationIdNumber = 0;

                    ReservatorDAL thisreservator = new ReservatorDAL(connectionString);

                    thisreservator.MakeReservation(siteToBeReserved, reservationName, arrivalDate, endDate);
                    List<ReservationModel> reservationIdGenerator = thisreservator.IdGrabber(reservationName);

                    for (int i = 0; i < reservationIdGenerator.Count; i++)
                    {
                        reservationIdNumber = reservationIdGenerator[i].ReservationId;
                    }

                    Console.WriteLine("The reservation has been made and here is your confirmation ID " + reservationIdNumber.ToString());
                    ifTrue = false;
                }

                else if (siteToBeReserved == "0")
                {
                    ifTrue = false;
                }


            }
        }
        public void WrapText(string description)
        {

            int myLimit = 65;

            string[] words = description.Split(' ');

            StringBuilder newSentence = new StringBuilder();

            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > myLimit)
                {
                    newSentence.AppendLine(line);
                    line = "";
                }

                line += string.Format("{0} ", word);
            }
            if (line.Length > 0)
            {
                newSentence.AppendLine(line);
            }
            Console.WriteLine(newSentence.ToString());
        }

    }
}


