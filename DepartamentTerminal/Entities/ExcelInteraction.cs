
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace DepartamentTerminal.Entities
{
    public class ExcelInteraction
    {
        public static void ImportIndividualVisits(string FileName)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(FileName);
            Excel.Worksheet worksheet = workbook.Worksheets[1];
            Excel.Range range = worksheet.UsedRange;

            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;
            MessageBox.Show(range.Cells[2, 4].Value2.ToString());
            for (int i = 2; i <= rowCount; i++)
            {
                Guest guest = new Guest()
                {
                    FullName = range.Cells[i, 1].Value2,
                    PhoneNumber = range.Cells[i, 2].Value2,
                    Email = range.Cells[i, 3].Value2,
                    DateOfBirth = DateTime.FromOADate((double)range.Cells[i, 4].Value2),
                    PassportData = range.Cells[i, 5].Value2,
                    Login = range.Cells[i, 6].Value2,
                    Password = range.Cells[i, 7].Value2
                };
                DataBaseInteraction.EnterGuest(guest);
                VisitingIndividual visitingIndividual = new VisitingIndividual()
                {
                    Guest = guest,
                    Status = DataBaseInteraction.GetStatuses().First(ent => ent.Id == 3),
                    Employee = DataBaseInteraction.GetEmployees().First(ent => ent.EmployeeCode == ((string)range.Cells[i, 8].Value2).Split('_')[1]),
                    Reason = ((string)range.Cells[i, 8].Value2).Split('_')[0]
                };
                DataBaseInteraction.EnterVisitingIndividual(visitingIndividual);
            }

            workbook.Close();
            application.Quit();
        }
        public static void ImportGroupVisits(string FileName)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(FileName);
            Excel.Worksheet worksheet = workbook.Worksheets[2];
            Excel.Range range = worksheet.UsedRange;

            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                Guest guest = new Guest()
                {
                    FullName = range.Cells[i, 1].Value2,
                    PhoneNumber = range.Cells[i, 2].Value2,
                    Email = range.Cells[i, 3].Value2,
                    DateOfBirth = DateTime.FromOADate(range.Cells[i, 4].Value2),
                    PassportData = range.Cells[i, 5].Value2,
                    Login = range.Cells[i, 6].Value2,
                    Passport = range.Cells[i, 7].Value2
                };
                DataBaseInteraction.EnterGuest(guest);
                VisitingGroup visitingGroup = new VisitingGroup()
                {
                    StartDate = DateTime.Parse(((string)range.Cells[i, 8].Value2).Split('_')[0]),
                    Purpose = ((string)range.Cells[i, 8].Value2).Split('_')[1],
                    Name = ((string)range.Cells[i, 8].Value2).Split('_')[4],
                    Status = DataBaseInteraction.GetStatuses().First(ent => ent.Id == 3),
                    Employee = DataBaseInteraction.GetEmployees().First(ent => ent.EmployeeCode == ((string)range.Cells[i, 8].Value2).Split('_')[3]),
                    Reason = ((string)range.Cells[i, 8].Value2).Split('_')[1]
                };
                DataBaseInteraction.EnterVisitingGroup(visitingGroup);
            }

            workbook.Close();
            application.Quit();
        }

        public static void ImportEmployee(string FileName)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(FileName);
            Excel.Worksheet worksheet = workbook.Worksheets[3];
            Excel.Range range = worksheet.UsedRange;

            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                Departament departament = null;
                if (DataBaseInteraction.GetDepartaments().Any(e => e.Name == range.Cells[i, 2].Value2))
                {
                    departament = DataBaseInteraction.GetDepartaments().First(e => e.Name == range.Cells[i, 2].Value2);
                }
                else 
                { 
                    departament =  new Departament() { Name = range.Cells[i, 2].Value2 }; DataBaseInteraction.EnterDepartament(departament);
                }

                Division division = null;
                if (DataBaseInteraction.GetDivisions().Any(e => e.Name == range.Cells[i, 3].Value2))
                {
                    division = DataBaseInteraction.GetDivisions().First(e => e.Name == range.Cells[i, 3].Value2);
                }
                else
                {
                    division = new Division() { Name = range.Cells[i, 3].Value2 }; DataBaseInteraction.EnterDivision(division);
                }


                DataBaseInteraction.EnterDivision(division);
                try
                {
                    Employee employee = new Employee()
                    {
                        FullName = worksheet.Cells[i, 1].Value2,
                        EmployeeCode = worksheet.Cells[i, 4].Value2 == null ? Random.Shared.Next(900000,999999).ToString() : worksheet.Cells[i, 4].Value2.ToString(),
                        DepartamentId = departament.DepartamentId,
                        DivisionId = division.DivisionId

                    };
                    DataBaseInteraction.EnterEmployee(employee);
                }
                catch(Exception ex) { break; }
            }

            workbook.Close();
            application.Quit();
        } 
    }
}
