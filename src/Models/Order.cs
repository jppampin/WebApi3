using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Order
    {
    
        public virtual Guid Id { get; set; }
        public IEnumerable<String> ItemsIds {get; set;}
        public string Currency { get; set; }
    }
}