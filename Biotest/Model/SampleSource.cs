﻿using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class SampleSource
    {
        [Key]
        public int SampleSourceID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
