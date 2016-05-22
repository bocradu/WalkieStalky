using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace WalkieStalky.Model
{
    /// <summary>
    /// This datatype models a list of persons that are close to the user&#39;s geo coordinate specified in the person record of the request. In essence, this is a response type that models a list of persons, with additional information if the person was matched.
    /// </summary>
    [DataContract]
    public class ClosePersonList : IEquatable<ClosePersonList>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClosePersonList" /> class.
        /// Initializes a new instance of the <see cref="ClosePersonList" />class.
        /// </summary>
        /// <param name="ClosePersons">ClosePersons.</param>
        /// <param name="Match">Match.</param>

        public ClosePersonList(List<PersonRecord> ClosePersons = null, PersonRecord Match = null)
        {
            this.ClosePersons = ClosePersons;
            this.Match = Match;

        }


        /// <summary>
        /// Gets or Sets ClosePersons
        /// </summary>
        [DataMember(Name = "ClosePersons", EmitDefaultValue = false)]
        public List<PersonRecord> ClosePersons { get; set; }

        /// <summary>
        /// Gets or Sets Match
        /// </summary>
        [DataMember(Name = "match", EmitDefaultValue = false)]
        public PersonRecord Match { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ClosePersonList {\n");
            sb.Append("  ClosePersons: ").Append(ClosePersons).Append("\n");
            sb.Append("  match: ").Append(Match).Append("\n");

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
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as ClosePersonList);
        }

        /// <summary>
        /// Returns true if ClosePersonList instances are equal
        /// </summary>
        /// <param name="other">Instance of ClosePersonList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ClosePersonList other)
        {
            if (other == null)
                return false;

            return
                (
                    this.ClosePersons == other.ClosePersons ||
                    this.ClosePersons != null &&
                    this.ClosePersons.SequenceEqual(other.ClosePersons)
                ) &&
                (
                    this.Match == other.Match ||
                    this.Match != null &&
                    this.Match.Equals(other.Match)
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

                if (this.ClosePersons != null)
                    hash = hash * 59 + this.ClosePersons.GetHashCode();

                if (this.Match != null)
                    hash = hash * 59 + this.Match.GetHashCode();

                return hash;
            }
        }

    }
}
