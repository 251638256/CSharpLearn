using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 条件编译 {
    class Program {
        static void Main(string[] args) {

            // Release 定义 Trace
#if DEBUG
            Console.WriteLine("AA");
#elif TRACE
            Console.WriteLine("BB");
#endif
            // debug模式下两个都要显示到DebugView release下只会显示trace 
            //Trace.WriteLine("Trace.Write");
            //Debug.WriteLine("Debug.Write");

            Trace.TraceError("错误信息");
            Trace.TraceWarning("警告信息");
            Trace.TraceInformation("普通信息");
            Trace.Assert(5 < 3, "出大问题了");

            //Debug.Write("AAAAA");

            Console.Read();
        }
    }
}
