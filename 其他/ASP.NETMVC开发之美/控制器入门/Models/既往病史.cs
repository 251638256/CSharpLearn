using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace 控制器入门.Models {
    public class 既往病史 : IValidatableObject {
        public int Id { get; set; }
        public string SickName { get; set; }
        public string Long { get; set; }
        public string SickResult { get; set; }
        public int 基本信息ID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (string.IsNullOrWhiteSpace(SickName)) {
                yield return new ValidationResult("疾病名称不能为空", new string[] { "SickName" });
            }

        }
    }
}