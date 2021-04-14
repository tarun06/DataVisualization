using DatabaseLayer;
using DataVisualization.Commands;
using DataVisualization.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfControlLibrary;

namespace DataVisualization.ViewModel
{
    public class EmployeeViewModel : NotifyPropertyBase
    {
        private ObservableCollection<Employee> _employeeCollection = new ObservableCollection<Employee>();
        private EmployeeModel _employeeModel;
        private Command _loadEmployeeCommand;
        private IProgress _progress;
        private Command _stopCommand;

        public EmployeeViewModel(IProgress progress)
        {
            _employeeModel = new EmployeeModel();
            _progress = progress;
        }

        public ObservableCollection<Employee> EmployeeCollection
        {
            get
            {
                return _employeeCollection;
            }
            set
            {
                _employeeCollection = value;
                OnPropertyChanged(nameof(EmployeeCollection));
            }
        }

        public Command LoadEmployeeCommand => _loadEmployeeCommand ??
                  (_loadEmployeeCommand = new Command(StartLoadingData, () => true));

        public Command StopCommand => _stopCommand ??
                  (_stopCommand = new Command(StopLoadingData, () => true));

        private void StartLoadingData()
        {
            _employeeCollection.Clear();

            var dispatcher = Application.Current.Dispatcher;
            Task.Factory.StartNew(async () =>
            {
                var employeeData = await _employeeModel.GetEmployeeDataAsync();
                var numberOfEmployee = employeeData.Count();
                for (int i = 0; i < numberOfEmployee; i++)
                {
                    Thread.Sleep(1);
                    var progress = i * 100 / numberOfEmployee;
                    dispatcher.Invoke(() =>
                    {
                        _progress.Report(progress);
                        EmployeeCollection.Add(employeeData.ElementAt(i));
                    });
                }
                dispatcher.Invoke(() => _progress.TryClose());
            });
            _progress.TryShow();
        }

        private void StopLoadingData()
        {
            _progress.TryClose();
        }
    }
}
