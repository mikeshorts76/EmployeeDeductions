﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EmployeeDeductions.Web.Models
{
    public class DependentViewModel
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Benefit Cost")]
        public decimal BenefitCost
        {
            get
            {
                if (FirstName.StartsWith("A", true, CultureInfo.InvariantCulture))
                    return 500M - ((10M / 100M) * 500M);
                else
                    return 500M;
            }
        }        
    }

}