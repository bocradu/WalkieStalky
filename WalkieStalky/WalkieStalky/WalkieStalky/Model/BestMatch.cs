using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace WalkieStalky.Model
{
    [DataContract]
    public class BestMatch : IEquatable<BestMatch>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BestMatch" /> class.
        /// Initializes a new instance of the <see cref="BestMatch" />class.
        /// </summary>
        /// <param name="MatchedTopic">MatchedTopic.</param>
        /// <param name="BestMatchedPerson">BestMatchedPerson.</param>

        public BestMatch(string MatchedTopic = null, PersonRecord BestMatchedPerson = null)
        {
            this.MatchedTopic = MatchedTopic;
            this.BestMatchedPerson = BestMatchedPerson;

        }


        /// <summary>
        /// Gets or Sets MatchedTopic
        /// </summary>
        [DataMember(Name = "matchedTopic", EmitDefaultValue = false)]
        public string MatchedTopic { get; set; }

        /// <summary>
        /// Gets or Sets BestMatchedPerson
        /// </summary>
        [DataMember(Name = "bestMatchedPerson", EmitDefaultValue = false)]
        public PersonRecord BestMatchedPerson { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BestMatch {\n");
            sb.Append("  MatchedTopic: ").Append(MatchedTopic).Append("\n");
            sb.Append("  BestMatchedPerson: ").Append(BestMatchedPerson).Append("\n");

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
            return this.Equals(obj as BestMatch);
        }

        /// <summary>
        /// Returns true if BestMatch instances are equal
        /// </summary>
        /// <param name="other">Instance of BestMatch to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BestMatch other)
        {
            if (other == null)
                return false;

            return
                (
                    MatchedTopic == other.MatchedTopic ||
                    MatchedTopic != null &&
                    MatchedTopic.Equals(other.MatchedTopic)
                ) &&
                (
                    this.BestMatchedPerson == other.BestMatchedPerson ||
                    this.BestMatchedPerson != null &&
                    this.BestMatchedPerson.Equals(other.BestMatchedPerson)
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

                if (this.MatchedTopic != null)
                    hash = hash * 59 + this.MatchedTopic.GetHashCode();

                if (this.BestMatchedPerson != null)
                    hash = hash * 59 + this.BestMatchedPerson.GetHashCode();

                return hash;
            }
        }

    }
}
