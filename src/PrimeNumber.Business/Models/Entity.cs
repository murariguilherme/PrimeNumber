using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumber.Business.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
