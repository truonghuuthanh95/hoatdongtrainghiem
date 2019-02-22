using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Models.DTO
{
    public class RegistrationDTO
    {
        public int Id { get; set; }       

        public int StudentQuantity { get; set; }

        [StringLength(100)]
        public string Creator { get; set; }

        public int JobTitleId { get; set; }
       
        public DateTime DateRegisted { get; set; }
              
        public int ClassId { get; set; }

        [StringLength(200)]
        public string ProgramName { get; set; }

        public int ProvinceId { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }
           
        public string ViTriKienThuc { get; set; }

        public string TomTatNoiDungCT { get; set; }     
    }
}