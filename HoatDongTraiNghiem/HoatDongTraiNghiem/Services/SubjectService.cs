using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class SubjectService
    {
        public IQueryable<Subject> GetSubjects()
        {
            using (HoatDongTraiNghiemDB _db = new HoatDongTraiNghiemDB())
            {
                var subjects = _db.Subjects.Where(s => s.IsActive == true);
                return subjects;
            }
           
        }
    }
}