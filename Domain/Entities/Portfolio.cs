﻿using System;

namespace Domain.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Crypto Crypto { get; set; }
        public User User { get; set; }
    }
}