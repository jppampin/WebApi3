using System.Collections;
using System.Collections.Generic;

namespace WebApi.Dtos
{
    public class OrderRequest 
    {
        public IEnumerable<string> ItemsIds { get; set;} = new List<string>();
        public string Currency{get; set;}
    }
}