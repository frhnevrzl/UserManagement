namespace UserManagement.API.Entity
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Nama { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string Password { get; set; }

        public WorkingUnit Unit { get; set; }
        public int UnitId { get; set; }
        public EmployeeStatus Status { get; set; }
        public int StatusId { get; set; }


    }
}
