using System.Text;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Windows.Forms;

namespace BillingProvider.WinForms
{
    public class NLogConfig
    {
        public LoggingConfiguration Instance { get; }

        public NLogConfig()
        {
            Instance = new LoggingConfiguration();

            var logfile = new FileTarget("logfile")
            {
                Name = "logfile",
                Encoding = Encoding.UTF8,
                Layout = @"${date:format=HH\:mm\:ss.fff}|${Level} ${callsite} - ${message}",
                FileName = "${basedir}/log/${date:format=yyyy-MM-dd}.log",
                ArchiveAboveSize = 2097151,
                ConcurrentWrites = true,
                ArchiveFileName = "${basedir}/log/arch/${date:format=yyyy-MM-dd}.log",
                ArchiveNumbering = ArchiveNumberingMode.Sequence,
                KeepFileOpen = true,
                OpenFileCacheTimeout = 10,
                MaxArchiveFiles = 30,
            };

            var rtxtLog = new RichTextBoxTarget()
            {
                Name = "rtxtLog",
                Layout =
                    @"${date:format=HH\:mm\:ss.fff}${pad:padding=7:inner=${level:uppercase=true}} ${message} ${onexception:${newline}  ${exception:format=ToString}}",
                AutoScroll = true,
                MaxLines = 300,
                ControlName = "rtxtLog",
                FormName = "MainWindow",
                UseDefaultRowColoringRules = true
            };

            Instance.AddTarget(logfile);
            Instance.AddTarget(rtxtLog);

            Instance.AddRuleForOneLevel(LogLevel.Trace, logfile);
            Instance.AddRuleForOneLevel(LogLevel.Info, rtxtLog);
        }
    }
}