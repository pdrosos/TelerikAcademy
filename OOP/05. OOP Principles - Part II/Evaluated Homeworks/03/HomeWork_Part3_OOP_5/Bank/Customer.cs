﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Customer
    {
        private string name;

        public string Name 
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Customer() 
        {
            this.name = null;
        }
        public Customer(string name) 
        {
            this.name = name;
        }
    }
}