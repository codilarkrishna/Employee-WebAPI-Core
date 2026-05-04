namespace EmployeePortal.Entities.DTO
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
