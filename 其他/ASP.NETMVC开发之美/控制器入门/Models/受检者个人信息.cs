using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 控制器入门.Models {
    public class 受检者个人信息 {
        public int Id { get; set; }

        [MinLength(5)]
        public string Chind { get; set; }
        public string Smoke { get; set; }
        public string Drink { get; set; }
        public int 基本信息ID { get; set; }
    }
}