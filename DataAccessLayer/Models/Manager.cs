﻿using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SoldProduct> SoldProducts { get; set; }
    }
}