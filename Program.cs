using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIP_Felmero1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Initialize Trace logging
            string logPath = Path.Combine(Application.StartupPath, "trace.txt");
            TextWriterTraceListener traceListener = new TextWriterTraceListener(logPath);
            Trace.Listeners.Add(traceListener);
            Trace.AutoFlush = true;

            Trace.WriteLine(string.Format("=== Application Started: {0} ===", DateTime.Now));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Trace.WriteLine(string.Format("=== Application Closed: {0} ===", DateTime.Now));
            traceListener.Close();
        }
    }
}
