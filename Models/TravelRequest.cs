using System.Security.Cryptography.X509Certificates;

namespace TravelDesk.Models
{
    public class TravelRequest
    {
        public int TravelRequestId { get; set; }
        
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string ReasonForTravel { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; } 

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }


    }
}
