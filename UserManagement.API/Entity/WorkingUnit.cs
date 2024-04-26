namespace UserManagement.API.Entity
{
    public class WorkingUnit
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
