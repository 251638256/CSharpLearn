using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 控制器入门.Models {
    public class Validator {
        public static ValidationResult Number(string name, ValidationContext context) {
            if (string.IsNullOrEmpty(name)) {
                return new ValidationResult("不能为空!"); // 
            }
            bool isNumber = name.Except("123456789").Any();
            return isNumber ? new ValidationResult("{0}不能包含其他字符,只能是数字") : ValidationResult.Success;
        }

        public static ValidationResult JibenXinxiYanzheng(基本信息 基本信息, ValidationContext context) {
            return ValidationResult.Success;
        }
    }
}