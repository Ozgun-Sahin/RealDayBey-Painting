﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }
        public string ClientName { get; set; }
        public string ClientUserName { get; set; }
        public string? Company { get; set; }
        public string Comment { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; }
        public bool IsComfirmed { get; set; }
    }
}
