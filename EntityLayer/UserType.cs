using System.Collections.Generic;

namespace EntityLayer
{
    public class UserType:IEntity
    {
        public UserType()
        {
            if(Users==null) 
                Users = new List<User>();
        }
        public int UserTypeId { get; set; }
        public string TypeName { get; set; }
        public List<User> Users { get; set; } 


    }
}
