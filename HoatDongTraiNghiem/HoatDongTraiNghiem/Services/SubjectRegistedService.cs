using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class SubjectRegistedService : IDisposable
    {
        public List<SubjectsRegisted> GetSubjectsRegistedsByRegistrationId(int id)
        {
            using (HoatDongTraiNghiemDB _db = new HoatDongTraiNghiemDB())
            {
                var subjectsRegisteds = _db.SubjectsRegisteds.Include("Subject").Where(s => s.RegistrationId == id).ToList();
                return subjectsRegisteds;
            }
            
        }

        public SubjectsRegisted CreateSubjectRegisted(SubjectsRegisted subjectsRegisted)
        {
            using (HoatDongTraiNghiemDB _db = new HoatDongTraiNghiemDB())
            {
                var subjectRegisted = _db.SubjectsRegisteds.Add(subjectsRegisted);
                _db.SaveChanges();
                return subjectsRegisted;
            }
            
        }

        public bool RemoveSunjectRegistedByRegistrationId(int id)
        {
            try
            {
                using (HoatDongTraiNghiemDB _db = new HoatDongTraiNghiemDB())
                {
                    var subjectsRegisteds = _db.SubjectsRegisteds.Where(s => s.RegistrationId == id).ToList();
                    foreach (var item in subjectsRegisteds)
                    {
                        _db.SubjectsRegisteds.Remove(item);
                        _db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            
        }
    }
}