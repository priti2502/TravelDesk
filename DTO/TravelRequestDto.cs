namespace TravelDesk.DTO
{
    public class TravelRequestDto
    {
        public int TravelRequestId { get; set; }
     
        public UserDto User { get; set; }
        public ProjectDto Project { get; set; }
       
    }
}
