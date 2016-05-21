using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace WalkieStalky.Model
{/// <summary>
 /// 
 /// </summary>
    [DataContract]
    public partial class PersonRecord : IEquatable<PersonRecord>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRecord" /> class.
        /// Initializes a new instance of the <see cref="PersonRecord" />class.
        /// </summary>
        /// <param name="PersonId">A public technical id we can use to connect to the user.</param>
        /// <param name="Name">The name to display on other people&#39;s phones.</param>
        /// <param name="Phonenumber">The phone number of the user.</param>
        /// <param name="Topics">Topics.</param>
        /// <param name="Coordinates">Coordinates.</param>

        public PersonRecord(string PersonId = null, string Name = null, string Phonenumber = null, List<string> Topics = null, GeoCoordinates Coordinates = null)
        {
            this.PersonId = PersonId;
            this.Name = Name;
            this.Phonenumber = Phonenumber;
            this.Topics = Topics;
            this.Coordinates = Coordinates;

        }


        /// <summary>
        /// A public technical id we can use to connect to the user
        /// </summary>
        /// <value>A public technical id we can use to connect to the user</value>
        [DataMember(Name = "personId", EmitDefaultValue = false)]
        public string PersonId { get; set; }

        /// <summary>
        /// The name to display on other people&#39;s phones
        /// </summary>
        /// <value>The name to display on other people&#39;s phones</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The phone number of the user
        /// </summary>
        /// <value>The phone number of the user</value>
        [DataMember(Name = "phonenumber", EmitDefaultValue = false)]
        public string Phonenumber { get; set; }

        /// <summary>
        /// Gets or Sets Topics
        /// </summary>
        [DataMember(Name = "topics", EmitDefaultValue = false)]
        public List<string> Topics { get; set; }

        /// <summary>
        /// Gets or Sets Coordinates
        /// </summary>
        [DataMember(Name = "coordinates", EmitDefaultValue = false)]
        public GeoCoordinates Coordinates { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PersonRecord {\n");
            sb.Append("  PersonId: ").Append(PersonId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Phonenumber: ").Append(Phonenumber).Append("\n");
            sb.Append("  Topics: ").Append(Topics).Append("\n");
            sb.Append("  Coordinates: ").Append(Coordinates).Append("\n");

            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as PersonRecord);
        }

        /// <summary>
        /// Returns true if PersonRecord instances are equal
        /// </summary>
        /// <param name="other">Instance of PersonRecord to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PersonRecord other)
        {
            if (other == null)
                return false;

            return
                (
                    this.PersonId == other.PersonId ||
                    this.PersonId != null &&
                    this.PersonId.Equals(other.PersonId)
                ) &&
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) &&
                (
                    this.Phonenumber == other.Phonenumber ||
                    this.Phonenumber != null &&
                    this.Phonenumber.Equals(other.Phonenumber)
                ) &&
                (
                    this.Topics == other.Topics ||
                    this.Topics != null &&
                    this.Topics.SequenceEqual(other.Topics)
                ) &&
                (
                    this.Coordinates == other.Coordinates ||
                    this.Coordinates != null &&
                    this.Coordinates.Equals(other.Coordinates)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)

                if (this.PersonId != null)
                    hash = hash * 59 + this.PersonId.GetHashCode();

                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();

                if (this.Phonenumber != null)
                    hash = hash * 59 + this.Phonenumber.GetHashCode();

                if (this.Topics != null)
                    hash = hash * 59 + this.Topics.GetHashCode();

                if (this.Coordinates != null)
                    hash = hash * 59 + this.Coordinates.GetHashCode();

                return hash;
            }
        }

    }
}
