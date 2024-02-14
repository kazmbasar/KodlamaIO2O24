﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class CourseDetailDto : IDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string InstruductorName { get; set; }

    }
}
