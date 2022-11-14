﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntitiyLayer.Concrete
{
    public class ToDoList
    {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}
