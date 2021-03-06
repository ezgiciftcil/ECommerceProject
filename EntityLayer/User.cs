using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    public class User:IEntity
    {
        public User()
        {
            if (Addresses == null)
                Addresses = new List<Address>();
            if (Carts == null)
                Carts = new List<Cart>();
            if (WishingLists == null)
                WishingLists = new List<WishingList>();
            if (Orders == null)
                Orders = new List<Order>();
        }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Cart> Carts { get; set; }
        public List<WishingList> WishingLists { get; set; }
        public List<Order> Orders { get; set; }
    }
}
