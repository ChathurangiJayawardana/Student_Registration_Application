﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.Models
{
    public class AcademicType
    {
        public byte Id { get; set; }
        public int NoOfCourses { get; set; }
        public int TotalCredits { get; set; }
        public byte year { get; set; }

    }
}