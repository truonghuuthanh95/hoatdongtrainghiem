using HoatDongTraiNghiem.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class ProgramsService : IDisposable
    {
        public void Dispose()
        {
           
        }

        public List<Program> GetPrograms()
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var programs = _db.Programs.Where(s => s.IsActive == true).ToList();
                return programs;
            }
        }

    }
}