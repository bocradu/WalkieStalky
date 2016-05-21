using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WalkieStalky.Model
{
    /// <summary>
    /// Describes a personId Record
    /// </summary>
    [DataContract]
    public class PersonIdRecord : IEquatable<PersonIdRecord>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonIdRecord" /> class.
        /// Initializes a new instance of the <see cref="PersonIdRecord" />class.
        /// </summary>
        /// <param name="PersonId">PersonId.</param>

        public PersonIdRecord(string PersonId = null)
        {
            this.PersonId = PersonId;

        }


        /// <summary>
        /// Gets or Sets PersonId
        /// </summary>
        [DataMember(Name = "personId", EmitDefaultValue = false)]
        public string PersonId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PersonIdRecord {\n");
            sb.Append("  PersonId: ").Append(PersonId).Append("\n");

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
            return this.Equals(obj as PersonIdRecord);
        }

        /// <summary>
        /// Returns true if PersonIdRecord instances are equal
        /// </summary>
        /// <param name="other">Instance of PersonIdRecord to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PersonIdRecord other)
        {
            if (other == null)
                return false;

            return
                (
                    this.PersonId == other.PersonId ||
                    this.PersonId != null &&
                    this.PersonId.Equals(other.PersonId)
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

                return hash;
            }
        }

    }
}
