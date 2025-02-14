﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class UserRequest
    {
        public UserRequest()
        {
        }
        public int Id { get; set; }
        [Required]
        public int RequestId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string JobTask { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EndTime { get; set; }
        [Required]
        public int StartTime { get; set; }
        
        public virtual User User { get; set; }

        public virtual Request Request { get; set; }
    }
}
