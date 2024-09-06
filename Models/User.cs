﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TravelDesk.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [Required]
    [StringLength(100)]
    public string Address { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string MobileNum { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    [Required]
    public int RoleId { get; set; }
    public Role? Role { get; set; }

    [Required]
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    
    public int? ManagerId { get; set; } // Make this nullable
    public User? Manager { get; set; }
    [JsonIgnore]
    public ICollection<TravelRequest> TravelRequests { get; set; } = new List<TravelRequest>();
    public int CreatedBy { get; set; } = 1;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public bool IsActive { get; set; } = true;
}
