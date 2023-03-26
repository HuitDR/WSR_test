namespace Web_service.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportData { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Passport { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string EmployeeCode { get; set; }
    }

    public class VisitingIndividual
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public Guest Guest { get; set; }
        public Employee Employee { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class VisitingGroup
    {
        public int Id { get; set; } // первичный ключ
        public string Name { get; set; }
        public string Purpose { get; set; }
        public Guest Guest { get; set; }
        public Employee Employee { get; set; }
        public DateTime EndDate { get; set; }
    }
}
