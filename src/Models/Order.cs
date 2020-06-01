using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public IEnumerable<String> ItemsIds {get; set;}
    }
}