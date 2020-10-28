using HoatDongTraiNghiem.Models.DAO.HCM_EDU_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Services
{
    public class T_DM_LopService : IDisposable
    {
        public void Dispose()
        {
            
        }
        public List<T_DM_Lop> GetT_DM_LopsBySchoolId(string schoolId)
        {
            using (var _db = new HCM_EDU_DATA())
            {
                List<T_DM_Lop> t_DM_Lops = _db.T_DM_Lop.SqlQuery($"SELECT [LopID] ,[SchoolID] ,[NamHocID],[ClientLopID],[Khoi],[TenLop],[PGDID], [LopHoc2Buoi],[CreateBy],[CreateTime],[ModifyTime],[STT],[LogID],[SiSoHS] FROM [Server_VS].[CSDL].[dbo].[T_DM_Lop] WHERE SCHOOLID = '{schoolId}' AND NAMHOCID = {DateTime.Now.Year}").ToList();
                return t_DM_Lops;
            }
            
        }
        public T_DM_Lop GetT_DM_LopsByClassId(string classId)
        {
            using (var _db = new HCM_EDU_DATA())
            {
                T_DM_Lop t_DM_Lops = _db.T_DM_Lop.SqlQuery($"SELECT * FROM [Server_VS].[CSDL].[dbo].[T_DM_Lop] WHERE LopId = '{classId}'").SingleOrDefault();
                return t_DM_Lops;
            }

        }
    }
}