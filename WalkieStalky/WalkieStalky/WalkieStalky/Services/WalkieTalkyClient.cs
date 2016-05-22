using System;
using System.Collections.Generic;
using System.Json;
using Newtonsoft.Json;
using unirest_net.http;
using WalkieStalky.Model;

namespace WalkieStalky.Services
{
    public class WalkieTalkyClient
    {
        private const string URLSERVER = "https://walkiestalky.verspult.com/persons/";
        public PersonRecord CreateGetRequest(string token)
        {
            string url = String.Concat(URLSERVER, "id?authtoken=" + token);
            HttpResponse<string> jsonResponse = Unirest.get(url)
                .header("accept", "application/json")
                .asString();
            var personRecord = JsonConvert.DeserializeObject<PersonRecord>(jsonResponse.Body);

            return personRecord;
        }


        // .header("Content-Type", "application/json")
        public ClosePersonList CreatePutRequest(string personId,PersonRecord personToUpdate,string fbToken)
        {
            string url = String.Concat(URLSERVER, personId + "?authtoken="+ fbToken);

            HttpResponse<string> jsonResponse = Unirest.put(url)
                 .header("Content-Type", "application/json")
             .body(personToUpdate.ToJson())
                .asString();

            var closePersonsList = JsonConvert.DeserializeObject<ClosePersonList>(jsonResponse.Body);


            return closePersonsList;
        }

        private PersonRecord GetDummyPersonRecord()
        {
            PersonRecord dummyPersonRecordPerson = new PersonRecord
            {
                Name = "Elias Weingaertner",
                PersonId = "0de77c08b76406e9eb6703c0663061e9f3445054d17fc1de490ff4b2da0f8ef7",
                Phonenumber = "+49 179 4969645",
                Coordinates = new GeoCoordinates
                {
                    Longitude = 21.2257100,
                    Latitude = 45.7537200
                },
                Topics = new List<string>
                {
                     "Pizza",
    "Hydraulic Press Channel",
    "Coffee"
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
