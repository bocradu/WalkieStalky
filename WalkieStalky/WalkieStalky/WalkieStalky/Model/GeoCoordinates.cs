using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace WalkieStalky.Model
{
    /// <summary>
    /// This datatype encodes a GPS location using decimal degrees. See &lt;a href=\&quot;https://en.wikipedia.org/wiki/Decimal_degrees\&quot; target=\&quot;_new\&quot;&gt;https://en.wikipedia.org/wiki/Decimal_degrees&lt;/a&gt; for a description of this geo format&lt;
    /// </summary>
    [DataContract]
    public class GeoCoordinates : IEquatable<GeoCoordinates>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoCoordinates" /> class.
        /// Initializes a new instance of the <see cref="GeoCoordinates" />class.
        /// </summary>
        /// <param name="Longitude">Longitude.</param>
        /// <param name="Latitude">Latitude.</param>

        public GeoCoordinates(double? Longitude = null, double? Latitude = null)
        {
            this.Longitude = Longitude;
            this.Latitude = Latitude;

        }
        /// <summary>
        /// Gets or Sets Longitude
        /// </summary>
        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or Sets Latitude
        /// </summary>
        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        public double? Latitude { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GeoCoordinates {\n");
            sb.Append("  Longitude: ").Append(Longitude).Append("\n");
            sb.Append("  Latitude: ").Append(Latitude).Append("\n");

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
            return this.Equals(obj as GeoCoordinates);
        }

        /// <summary>
        /// Returns true if GeoCoordinates instances are equal
        /// </summary>
        /// <param name="other">Instance of GeoCoordinates to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GeoCoordinates other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return
                (
                    this.Longitude == other.Longitude ||
                    this.Longitude != null &&
                    this.Longitude.Equals(other.Longitude)
                ) &&
                (
                    this.Latitude == other.Latitude ||
                    this.Latitude != null &&
                    this.Latitude.Equals(other.Latitude)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)

                if (this.Longitude != null)
                    hash = hash * 59 + this.Longitude.GetHashCode();

                if (this.Latitude != null)
                    hash = hash * 59 + this.Latitude.GetHashCode();

                return hash;
            }
        }
    }
}
