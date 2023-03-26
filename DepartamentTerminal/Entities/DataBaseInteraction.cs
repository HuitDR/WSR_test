using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DepartamentTerminal.Entities
{
    public class DataBaseInteraction
    {
        public static List<Guest> GetGuests()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.Guests.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<Guest>();
        }
        public static List<Employee> GetEmployees()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.Employees.Include(e => e.Division).Include(e => e.Departament).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<Employee>();
        }
        public static List<VisitingIndividual> GetVisitingIndividuals()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.VisitingIndividuals.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<VisitingIndividual>();
        }
        public static List<VisitingGroup> GetVisitingGroups()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.VisitingGroups.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<VisitingGroup>();
        }
        public static List<Departament> GetDepartaments()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.Departaments.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<Departament>();
        }
        public static List<Division> GetDivisions()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.Divisions.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<Division>();
        }
        public static List<BlackList> GetBlackList()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.BlackLists.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<BlackList>();
        }
        public static List<Status> GetStatuses()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.Statuses.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<Status>();
        }
        public static List<User> GetUsers()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.Users.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<User>();
        }
        public static List<Job> GetJobs()
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                return context.Jobs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return new List<Job>();
        }

        public static bool EnterGuest(Guest guest)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.Guests.Any(e => e.Passport == guest.Passport || e.Login == guest.Login))
                {
                    context.Guests.Update(guest);
                }
                else
                {
                    context.Guests.Add(guest);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool EnterEmployee(Employee Employee)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.Employees.Any(e => e.EmployeeId == Employee.EmployeeId))
                {
                    context.Employees.Update(Employee);
                }
                else
                {
                    context.Employees.Add(Employee);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, ex.Source);
            }
            return false;
        }
        public static bool EnterVisitingIndividual(VisitingIndividual VisitingIndividual)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.VisitingIndividuals.Any(e => e.VisitingIndividualId == VisitingIndividual.VisitingIndividualId))
                {
                    context.VisitingIndividuals.Update(VisitingIndividual);
                }
                else
                {
                    context.VisitingIndividuals.Add(VisitingIndividual);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, ex.Source);
            }
            return false;
        }
        public static bool EnterVisitingGroup(VisitingGroup VisitingGroup)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.VisitingGroups.Any(e => e.VisitingGroupId == VisitingGroup.VisitingGroupId))
                {
                    context.VisitingGroups.Update(VisitingGroup);
                }
                else
                {
                    context.VisitingGroups.Add(VisitingGroup);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool EnterDepartament(Departament Departament)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.Departaments.Any(e => e.DepartamentId == Departament.DepartamentId))
                {
                    context.Departaments.Update(Departament);
                }
                else
                {
                    if (!context.Departaments.Any(e => e.Name.ToLower() == Departament.Name.ToLower()))
                        context.Departaments.Add(Departament);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, ex.Source);
            }
            return false;
        }
        public static bool EnterDivision(Division Division)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.Divisions.Any(e => e.DivisionId == Division.DivisionId))
                {
                    context.Divisions.Update(Division);
                }
                else
                {
                    try
                    {
                        if (!context.Divisions.Any(e => e.Name.ToLower() == Division.Name.ToLower()))
                            context.Divisions.Add(Division);
                    }
                    catch () { }
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, ex.Source);
            }
            return false;
        }
        public static bool EnterBlackList(BlackList BlackList)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.BlackLists.Any(e => e.BlackListId == BlackList.BlackListId))
                {
                    context.BlackLists.Update(BlackList);
                }
                else
                {
                    context.BlackLists.Add(BlackList);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool EnterStatus(Status Status)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.Statuses.Any(e => e.Id == Status.Id))
                {
                    context.Statuses.Update(Status);
                }
                else
                {
                    context.Statuses.Add(Status);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool EnterUser(User User)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.Users.Any(e => e.UserId == User.UserId))
                {
                    context.Users.Update(User);
                }
                else
                {
                    context.Users.Add(User);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool EnterJob(Job Job)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                if (context.Jobs.Any(e => e.JobId == Job.JobId))
                {
                    context.Jobs.Update(Job);
                }
                else
                {
                    context.Jobs.Add(Job);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        
        public static bool RemoveGuest(Guest guest)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.Guests.Remove(guest);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveEmployee(Employee Employee)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.Employees.Remove(Employee);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveVisitingIndividual(VisitingIndividual VisitingIndividual)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.VisitingIndividuals.Remove(VisitingIndividual);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveVisitingGroup(VisitingGroup VisitingGroup)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.VisitingGroups.Remove(VisitingGroup);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveDepartament(Departament Departament)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.Departaments.Remove(Departament);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveDivision(Division Division)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.Divisions.Remove(Division);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveBlackList(BlackList BlackList)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.BlackLists.Remove(BlackList);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveStatus(Status Status)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.Statuses.Remove(Status);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveUser(User User)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.Users.Remove(User);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
        public static bool RemoveJob(Job Job)
        {
            try
            {
                ApplicationContext context = new ApplicationContext();
                context.Jobs.Remove(Job);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            return false;
        }
    }
}
