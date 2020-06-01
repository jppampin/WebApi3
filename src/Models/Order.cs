using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Order
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public IEnumerable<String> ItemsIds {get; set;}
    }
}