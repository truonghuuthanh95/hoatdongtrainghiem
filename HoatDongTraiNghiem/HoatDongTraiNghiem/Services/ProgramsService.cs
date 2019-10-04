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
                var programs = _db.Programs.AsNoTracking().Where(s => s.IsActive == true).ToList();
                return programs;
            }
        }
        public List<Program> GetProgramsAll()
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var programs = _db.Programs.AsNoTracking().ToList();
                return programs;
            }
        }
        public List<Program> GetProgramsByAccountId(int accountId)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var listProgramPermission = _db.ProgramPermissions.AsNoTracking().Where(s => s.AccountId == accountId && s.Program.IsActive == true).Select(s => s.ProgramId).ToList();
                var listProgarm = _db.Programs.Where(s => listProgramPermission.Contains(s.Id)).ToList();
                return listProgarm;
            }
        }

    }
}