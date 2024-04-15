﻿using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class PredictedEffect
    {
        [Key]
        public int PredictedEffectID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
