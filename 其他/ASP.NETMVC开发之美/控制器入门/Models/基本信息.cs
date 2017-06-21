using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace 控制器入门.Models {

    [CustomValidation(typeof(Validator), "JibenXinxiYanzheng")]
    public class 基本信息 {
        public int Id { get; set; }

        //[Required]
        //[StringLength(15, ErrorMessage = "{0}的长度必须介于{2}和{1}之间", MinimumLength = 4)]
        public string 姓名 { get; set; }

        /// <summary>
        /// 自定义验证规则
        /// </summary>
        [CustomValidation(typeof(Validator), "Number")]
        public string 性别 { get; set; }
        public string 年龄 { get; set; }

        public HashSet<受检者个人信息> 受检者个人信息集 { get; set; }
        public HashSet<既往病史> 既往病史 { get; set; }
        public HashSet<职业史> 职业史 { get; set; }

        public 基本信息() {
            受检者个人信息集 = new HashSet<受检者个人信息>();
            既往病史 = new HashSet<Models.既往病史>();
            职业史 = new HashSet<Models.职业史>();
        }
    }

    
}