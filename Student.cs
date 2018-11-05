﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.Models
{
    public class Student
    {
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name="Index Number")]
        public string IndexNo { get; set; }
        [Display(Name="Register Date")]
        public DateTime? RegisterDate { get; set; }
        public AcademicType AcademicType { get; set; }
        public byte AcademicTypeId { get; set; }
    }
}