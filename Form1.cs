using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DbConnectionDemo
{
    public partial class Form1 : Form
    {
        internal DemoContext _longLivedContext = default;

        public Form1()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .MinimumLevel.Debug()
                .CreateLogger();
            DemoContext._loggerFactory = new LoggerFactory().AddSerilog();

            _longLivedContext = new DemoContext();
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            Log.Debug("Query using long lived context");
            var fromLongLivedContext = _longLivedContext.EntityOne.ToList();

            Thread.Sleep(5000);

            Log.Debug("");
            Log.Debug("Query using transient context");
            using (var transientContext = new DemoContext())
            {
                var fromTransientContext = transientContext.EntityOne.ToList();
            }
        }
    }
}
