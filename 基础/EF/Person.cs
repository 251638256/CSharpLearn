using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础 {


    public class Person {
        public int ID { get; set; }
        public int Sex { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Height { get; set;  }
        public Score Scores { get; set; }
        public int Children { get; set; }
        public int? Girls { get; set; }
        public int? Boys { get; set; }
        public int? GodBoys { get; set; }
        public DateTime? Born { get; set; }
        public State State { get; set; }
    }

    public enum State {
        Active,
        Deleted
    }
}
