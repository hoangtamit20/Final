using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Server.Entities;

namespace Server.Services.CustomDataAnnotationService
{
    public class NgaySinhValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var nguoiDung = validationContext.ObjectInstance as NguoiDung;
            if (nguoiDung != null)
            {
                if (nguoiDung.NgaySinh != null)
                {
                    if (nguoiDung.NgaySinh.Value.AddYears(7) > DateOnly.FromDateTime(DateTime.Now))
                    {
                        return new ValidationResult("Bạn chưa đủ 7 tuổi để có thể đăng ký học.");
                    }
                    return ValidationResult.Success;
                }
                return new ValidationResult("NgaySinh is null");
            }
            return ValidationResult.Success;
        }
    }
}