﻿using System.Runtime.CompilerServices;
using System.Security;
using System.Transactions;

[assembly: InternalsVisibleTo("TaskerAI.Application")]
namespace TaskerAI.Domain
{
    public class Location
    {

        public int Id { get; private set; }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Floor { get; private set; }

        public string ZipCode { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        public double Lat { get; private set; }

        public double Lon { get; private set; }

        public User User { get; private set; }



        internal Location(string street, string number, string floor, string zipCode, string city, string country, User user)
        {
            this.Street = street;
            this.Number = number;
            this.Floor = floor;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
            this.User = user;

          
        }

        internal Location(string street, string number, string floor, string zipCode, string city, string country, User user, double lat, double lon) : this(street, number, floor, zipCode, city, country, user)
        {

            this.Lat = lat;
            this.Lon = lon;

        }

        internal void CalculateGeoCoordinates()
        {


            //this method will be called if the coordinates are not calculated in the client side - 

        }


    }
}