using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace cs_r_editor
{
    public class RScriptRunner
    {

        public static void RunFromCmd(string rCodeFilePath, string rScriptExecutablePath, string args, EventHandler<ProgressChangedEventArgs> doWorkHandler, EventHandler<RunWorkerCompletedEventArgs> completed_handler)
        {
            string file = rCodeFilePath;

            BackgroundWorker worker = new BackgroundWorker();
            BackgroundWorker worker2 = new BackgroundWorker();
            worker2.WorkerSupportsCancellation = true;
            worker2.WorkerReportsProgress = true;

            worker2.DoWork += (sender, e) =>
                {
                    BackgroundWorker w = sender as BackgroundWorker;
                    int counter = 0;
                    while (!w.CancellationPending)
                    {
                        Thread.Sleep(200);
                        w.ReportProgress(0, ++counter);
                    }
                    e.Cancel = w.CancellationPending;
                };
            worker2.ProgressChanged += (sender, e) =>
                {
                    int index = (int)e.UserState;
                    if (index % 10 == 0)
                    {
                        doWorkHandler(sender, new ProgressChangedEventArgs(0, index / 10));
                    }
                };
            worker2.RunWorkerCompleted += (sender, e) =>
                {

                };

            worker.DoWork += (sender, e) =>
              {

                  var info = new ProcessStartInfo();
                  info.FileName = string.Format("\"{0}\"", rScriptExecutablePath);
                  info.WorkingDirectory = Path.GetDirectoryName(rScriptExecutablePath);
                  info.Arguments = rCodeFilePath + " " + args;

                  info.RedirectStandardInput = false;
                  info.RedirectStandardOutput = true;
                  info.UseShellExecute = false;
                  info.CreateNoWindow = true;


                  using (var proc = new Process())
                  {
                      proc.StartInfo = info;
                      proc.Start();
                      e.Result = proc.StandardOutput.ReadToEnd();
                  }
                  worker2.CancelAsync();
                  Thread.Sleep(300);
              };
            worker.RunWorkerCompleted += (sender, e) =>
            {

                completed_handler(sender, e);
            };

            worker.RunWorkerAsync();
            worker2.RunWorkerAsync();
        }
    }
}
