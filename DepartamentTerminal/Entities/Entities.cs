using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Entities
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

        public static string GetHashedPassword(string _password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(_password));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; } = 0;
        public string FullName { get; set; }
        public int? DepartamentId { get; set; }
        public Departament? Departament { get; set; }
        public int? DivisionId { get; set; }
        public Division? Division { get; set; }
        public string EmployeeCode { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Job Job { get; set; }
        public string MnemonicWord { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Job
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }

    public class Departament
    {
        public int DepartamentId { get; set; }
        public string Name { get; set; }

    }

    public class Division
    {
        public int DivisionId { get; set; }
        public string Name { get; set; }
    }

    public class VisitingIndividual
    {
        public int VisitingIndividualId { get; set; }
        public string Reason { get; set; }
        public Guest Guest { get; set; }
        public Employee Employee { get; set; }
        public Status Status { get; set; }
        public string StatusReason { get; set; }

    }

    public class VisitingGroup
    {
        public int VisitingGroupId { get; set; }
        public string Reason { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public ICollection<Guest> Guests { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public string StatusReason { get; set; }
    }

    public class GuestVisitingGroup
    {
        public int GuestsId { get; set; }
        public int VisitingGroupId { get; set; }
    }

    public class BlackList
    {
        public int BlackListId { get; set; }
        public Guest Guest { get; set; }
        public string Reason { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }


}
