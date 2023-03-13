using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.Module
{
    public class Customer
    {
        public string ID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int TotalOrders { get; set; }
        public Customer()
        { 
        }
        public Customer(string id, string company, string name, string address, string phone)
        {
            this.ID = id;
            this.CompanyName = company;
            this.ContactName = name;
            this.Address = address;
            this.Phone = phone;
        }
    }
}