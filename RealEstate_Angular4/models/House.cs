using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate_Angular4.models
{
    public partial class House
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Houseid { get; set; }
        public int? PropertyTypeId { get; set; }
        public string Mls { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        public int? Bedrooms { get; set; }
        public decimal? Bathrooms { get; set; }
        public int? AgentId { get; set; }
        public string HouseUrl { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
