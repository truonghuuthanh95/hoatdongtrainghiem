using HoatDongTraiNghiem.Models.DAO;
using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class T_DM_PGDService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<T_DM_PGD> GetT_DM_PGDs()
        {
            using (var _db = new HoatDongTraiNghiemDB())
            {
                var PGDs = _db.Database.SqlQuery<T_DM_PGD>(@"SELECT [PGDID]
      ,[STT]
      ,[TenTat]
      ,[TenPGD]
      ,[ID_Parent]
      ,[TenPGD_rep]
  FROM [Server_VS].[CSDL].[dbo].[T_DM_PGD]").ToList();
                return PGDs;
            }
        }
    }
}