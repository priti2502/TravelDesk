﻿namespace TravelDesk.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }

        

        public string FirstName { get; set; }
        public string LastName { get; set; } 
        
        public DepartmentDto Department { get; set; }
    }
}
