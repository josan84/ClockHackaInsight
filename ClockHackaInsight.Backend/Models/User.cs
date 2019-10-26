using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Models
{
    public class User
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public string GenerateId()
        {
            Id = Guid.NewGuid().ToString(); 
            return Id;
        }
    }
}
