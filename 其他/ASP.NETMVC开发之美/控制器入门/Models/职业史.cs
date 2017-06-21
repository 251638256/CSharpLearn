using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace 控制器入门.Models {
    public class 职业史 {
        public int Id { get; set; }
        public string Work { get; set; }
        public int 基本信息ID { get; set; }

    }
}