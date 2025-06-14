using LSEG.LogMonitoring.Core.Models;
using LSEG.LogMonitoring.Core.Modules;
using LSEG.LogMonitoring.Core.Modules.Commands;
using LSEG.LogMonitoring.Core.Modules.EventAggregator;
using LSEG.LogMonitoring.Core.Modules.Messages;
using LSEG.LogMonitoring.Core.Services;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LSEG.LogMonitoring.Modules.LogAnalyzer.ViewModels
{
    /// <summary>
    /// ViewModel responsible for handling log file loading,
    /// parsing, and job duration reporting
    /// </summary>
    public class LogAnalyzerViewModel : ViewModelBase
    {
        private ObservableCollection<JobDuration> _jobs;
        public ObservableCollection<JobDuration> Jobs
        {
            get => _jobs;
            set => SetProperty(ref _jobs, value);
        }

        public ICommand LoadCommand { get; }
        private readonly IEventAggregator _eventAggregator;
        public LogAnalyzerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Jobs = new ObservableCollection<JobDuration>();
            LoadCommand = new RelayCommand(LoadLogs);
        }

        private void LoadLogs()
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Select log file",
                Filter = "Log files (*.log;*.txt)|*.log;*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != true)
                return;

            var path = openFileDialog.FileName;

            try
            {
                var parser = new LogParser();
                var entries = parser.Parse(path);
                var durations = parser.CalculateDurations(entries);

                Jobs.Clear();
                foreach (var job in durations)
                    Jobs.Add(job);
            }
            catch (Exception ex)
            {
                // log exception
            }
            _eventAggregator.Publish(new JobCountMessage(Jobs.Count));
        }
    }
}
