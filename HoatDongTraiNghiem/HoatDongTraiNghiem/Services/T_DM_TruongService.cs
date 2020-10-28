using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class T_DM_TruongService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<T_DM_Truong> GetT_DM_TruongsByPGDId(int id)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var schools = _db.Database.SqlQuery<T_DM_Truong>(@"SELECT [ID]
      ,[SchoolID]
      ,[TenTruong]               
      ,[PGDID]
      ,[PGDID_C12]
      ,[Cap1]
      ,[Cap2]
      ,[Cap3]
      ,[IsTestOnly]
  FROM [Server_VS].[CSDL].[dbo].[T_DM_Truong]
  WHERE [PGDID] = @PGDID AND [IsTestOnly] = 0
  ORDER BY [TenTruong]
", new SqlParameter("@PGDID", id)).ToList();
                return schools;
            }
           
        }

        public T_DM_Truong GetTruongBySchoolId(string schoolId)
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var school = _db.Database.SqlQuery<T_DM_Truong>($"SELECT * FROM [Server_VS].[CSDL].[dbo].[T_DM_Truong] WHERE [SchoolID] = '${schoolId}'").SingleOrDefault();
                return school;
            }
        }
    }
}