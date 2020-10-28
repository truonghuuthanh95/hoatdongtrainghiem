using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoatDongTraiNghiem.Models.DTO
{
    public class HoatDongNgoaiKhoaDTO
    {
        public int Id { get; set; }

        [StringLength(2000)]
        public string ActivityName { get; set; }

        public int ProvinceId { get; set; }
       
        public DateTime DateRegisted { get; set; }

        public int StudentQuantity { get; set; }

        public string Summary { get; set; }       

        [StringLength(50)]
        public string SchoolId { get; set; }

        [StringLength(200)]
        public string SchoolName { get; set; }

        [StringLength(200)]
        public string Creator { get; set; }      

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public int JobTitileId { get; set; }
        public int ClassId { get; set; }
    }
}