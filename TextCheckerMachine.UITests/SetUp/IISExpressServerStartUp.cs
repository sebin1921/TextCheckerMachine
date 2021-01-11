using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace TextCheckerMachine.UITests.SetUp
{
    public abstract class IisExpressServerStartUp
    {
        private static int IisPort
        {
            get
            {
                if (int.TryParse(ConfigurationManager.AppSettings["webSitePort"], out var value))
                {
                    return value;
                }
                throw new InvalidOperationException("Wrong port number");
            }
        }

        private readonly string _applicationName;
        private static Process _iisProcess;

        protected IisExpressServerStartUp(string applicationName)
        {
            _applicationName = applicationName;
        }

        protected void TestInitialize()
        {
            StartIisApplication();
        }

        protected void TestCleanup()
        {
            if (_iisProcess.HasExited == false)
            {
                _iisProcess.Kill();
            }
        }

        public abstract void Initialize();

        public abstract void Cleanup();

        private void StartIisApplication()
        {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            _iisProcess = new Process
            {
                StartInfo =
                {
                    FileName = programFiles + @"\IIS Express\iisexpress.exe",
                    Arguments = $"/path:\"{applicationPath}\" /port:{IisPort}"
                }
            };
            _iisProcess.Start();
        }

        private static string GetApplicationPath(string applicationName)
        {
            var projectFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            var parent = Directory.GetParent(projectFolder);
            return Path.Combine(parent.FullName, applicationName);
        }
    }
}
