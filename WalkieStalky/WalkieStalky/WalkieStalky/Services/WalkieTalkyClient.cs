using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using unirest_net.http;
using unirest_net.request;
using WalkieStalky.Model;

namespace WalkieStalky.Services
{
    public class raduboc
    {
        public string personId { get; set; }
    }
    public class WalkieTalkyClient
    {
        private const string URLSERVER = "https://walkiestalky.verspult.com/test";
        public PersonRecord CreateGetRequest()
        {
            HttpResponse<string> jsonResponse = Unirest.get("http://pastebin.com/raw/45SvuMGc")
                .header("accept", "application/json").asString();
            var personRecord = JsonConvert.DeserializeObject<PersonRecord>(jsonResponse.Body);

            return personRecord;
        }

      
        public ClosePersonList CreatePostRequest()
        {

            var dummyPerson = GetDummyPersonRecord();
            HttpResponse < string > jsonResponse = Unirest.put(URLSERVER)
                 .header("accept", "application/json")
                .field("personid", dummyPerson.PersonId)
                .field("authtoken", "dummyTokenUntilfacebookToken")
                .field("personrecord", dummyPerson)
                .asString();

            var closePersonsList = JsonConvert.DeserializeObject<ClosePersonList>(jsonResponse.Body);

            return closePersonsList;
        }

        private PersonRecord GetDummyPersonRecord()
        {
            PersonRecord dummyPersonRecordPerson = new PersonRecord
            {
                Name = "Elias Weingaertner",
                Phonenumber = "+49 179 4969645",
                Coordinates = new GeoCoordinates
                {
                    Longitude = 45.7537200,
                    Latitude = 21.2257100
                },
                Topics = new List<string>
                {
                    "Pizza",
                    "PHP",
                    "Romania"
                }
            };

            return dummyPersonRecordPerson;

        }
        
    }

    //    {
    //  "personId": "0de77c08b76406e9eb6703c0663061e9f3445054d17fc1de490ff4b2da0f8ef7",
    //  "name": "Elias Weingaertner",
    //  "phonenumber": "+49 179 4969645",
    //  "topics": [
    //    "Pizza",
    //    "Hydraulic Press Channel",
    //    "Coffee"
    //  ],
    //  "coordinates": {
    //    "longitude" : 21.2257100,
    //    "latitude" : 45.7537200 
    //  }
    //}








}
