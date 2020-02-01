using IBBSample.Mobile.Provider;
using IBBSample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IBBSample.Mobile.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ServiceManager _manager;

        private BusTermimal _terminal;
        public BusTermimal Terminal
        {
            get
            {
                return _terminal;
            }
            set
            {
                _terminal = value;
                OnPropertyChanged();
            }
        }

        private IList<BusTermimal> _terminalList;

        public IList<BusTermimal> TerminalList
        {
            get
            {
                if (_terminalList == null)
                    _terminalList = new ObservableCollection<BusTermimal>();
                return _terminalList;
            }
            set 
            {
                _terminalList = value;
            }
        }

        public MainPageViewModel()
        {
            _manager = new ServiceManager();
            GetTerminalList();
        }

        async Task GetTerminalList()
        {
            var result = await _manager.Get<IEnumerable<BusTermimal>>("https://ibbsampleapi.azurewebsites.net/api/terminal");
            foreach (var item in result)
                TerminalList.Add(item);
        }

        public ICommand LocationCommand => new Command(async () =>
        {
            var result = Regex.Match(Terminal.Coordinate, @"\d.+").Value.Replace(")", "");
            var locs = result.Split(' ');
            var lat = Convert.ToDouble(locs[0]);
            var lng = Convert.ToDouble(locs[1]);
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = Terminal.Name,
                NavigationMode = NavigationMode.Walking
            });
        });
    }
}