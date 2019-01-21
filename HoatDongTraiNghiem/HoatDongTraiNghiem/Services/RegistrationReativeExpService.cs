using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class RegistrationReativeExpService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public int CheckValidQuantityStudent(int programId, int sesstionAdayId, DateTime time)
        {
            int studentJoinedAllDayNumb = 0;
            int studentJoinedHaftDaynumb = 0;
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var maxStudent = _db.Programs.Where(x => x.Id == programId).Select(x => x.MaxAudience).First();
                List<RegistrationCreativeExp> studentJoinedAllDay = _db.RegistrationCreativeExps
                    .Where(x => x.DateRegisted == time)
                    .Where(x => x.DaySessionId == 3).Where(s => s.ProgramId == programId).ToList();

                foreach (RegistrationCreativeExp registration in studentJoinedAllDay)
                {
                    studentJoinedAllDayNumb += Convert.ToInt16(registration.StudentQuantity);
                }

                if (sesstionAdayId == 1 || sesstionAdayId == 2)
                {
                    List<RegistrationCreativeExp> studentJoinedHaftDay = _db.RegistrationCreativeExps
                    .Where(x => x.DateRegisted == time)
                    .Where(x => x.DaySessionId == sesstionAdayId).Where(s => s.ProgramId == programId).ToList();
                    foreach (RegistrationCreativeExp registration in studentJoinedHaftDay)
                    {
                        studentJoinedHaftDaynumb += Convert.ToInt16(registration.StudentQuantity);
                    }
                }
                else
                {
                    int studentJoinedEvenningNumb = 0;
                    int studentJoinedMorningNumb = 0;
                    List<RegistrationCreativeExp> studentJoinedMorning = _db.RegistrationCreativeExps
                    .Where(x => x.DateRegisted == time)
                    .Where(x => x.DaySessionId == 1).Where(s => s.ProgramId == programId).ToList();

                    List<RegistrationCreativeExp> studentJoinedEvenning = _db.RegistrationCreativeExps
                    .Where(x => x.DateRegisted == time)
                    .Where(x => x.DaySessionId == 2).Where(s => s.ProgramId == programId).ToList();

                    foreach (RegistrationCreativeExp registration in studentJoinedEvenning)
                    {
                        studentJoinedEvenningNumb += Convert.ToInt16(registration.StudentQuantity);
                    }
                    foreach (RegistrationCreativeExp registration in studentJoinedMorning)
                    {
                        studentJoinedMorningNumb += Convert.ToInt16(registration.StudentQuantity);
                    }

                    if (studentJoinedMorningNumb >= studentJoinedEvenningNumb)
                    {
                        studentJoinedHaftDaynumb = studentJoinedMorningNumb;
                    }
                    else
                    {
                        studentJoinedHaftDaynumb = studentJoinedEvenningNumb;
                    }

                }

                return Convert.ToInt16(maxStudent) - (studentJoinedAllDayNumb + studentJoinedHaftDaynumb);
            }
        }
        public RegistrationCreativeExp SaveRegistrationCreativeExp(RegistrationCreativeExp registrationCreativeExp)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                _db.RegistrationCreativeExps.Add(registrationCreativeExp);
                _db.SaveChanges();
                return registrationCreativeExp;
            }           
        }

        public List<RegistrationCreativeExp> GetRegistrationCreativeExpsBySchoolIdAndProgramId(string schoolId, int programId)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var list = _db.RegistrationCreativeExps
                    .Include("SessionADay")
                    .Include("Program")
                    .Include("Jobtitle").Where(s => s.SchoolId == schoolId && s.ProgramId == programId).OrderBy(s => s.DateRegisted).ToList();
                return list;
            }
            
        }
        public List<RegistrationCreativeExp> GetRegistrationCreativeExpsByProgramIdAndDateRange(int programId, DateTime dateFrom, DateTime dateTo)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var list = _db.RegistrationCreativeExps             
               .Include("SessionADay")
               .Include("Program")
               .Include("Jobtitle")
               .Where(s => s.DateRegisted >= dateFrom && s.DateRegisted <= dateTo).Where(s => s.ProgramId == programId)
               .OrderBy(s => s.DateRegisted)
               .ToList();
                return list;
            }
        }
        public RegistrationCreativeExp GetRegistrationCreativeExpById(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var registrationCreativeExp = _db.RegistrationCreativeExps
               .Include("SessionADay")
               .Include("Program")
               .Include("Jobtitle")
               .Where(s => s.Id == id)
               .SingleOrDefault();
                return registrationCreativeExp;
            }
        }


    }
}