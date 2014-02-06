﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myAppMemory.ViewModels {
  public class StudentsForList {
    [Key]
    public int StudentId { get; set; }

    [Required]
    [RegularExpression("^[0][0-9]{8}$", ErrorMessage = "0 followed by 8 digits")]
    public string StudentNumber { get; set; }
  }

  public class StudentFull : StudentsForList {
    [Required]
    [StringLength(40, MinimumLength = 3)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required]
    [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$", ErrorMessage = "nnn-nnn-nnnn")]
    public string Phone { get; set; }
  }

  public class StudentPublic {

    [Required]
    [RegularExpression("^[0][0-9]{8}$", ErrorMessage = "0 followed by 8 digits")]
    public string StudentNumber { get; set; }

    [Required]
    [StringLength(40, MinimumLength = 3)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required]
    [RegularExpression("^[2-9]\\d{2}-\\d{3}-\\d{4}$", ErrorMessage = "nnn-nnn-nnnn")]
    public string Phone { get; set; }
  }
}