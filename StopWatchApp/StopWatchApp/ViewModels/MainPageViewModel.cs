using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace StopWatchApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand TimerButton_Clicked { get; private set; }
        public DelegateCommand LapButton_Clicked { get; private set; }

        private string _TimerLabel;
        public string TimerLabel
        {
            get { return _TimerLabel; }
            set { SetProperty(ref _TimerLabel, value); }
        }

        private string _LapLabel1;
        public string LapLabel1
        {
            get { return _LapLabel1; }
            set { SetProperty(ref _LapLabel1, value); }
        }

        private string _LapLabel2;
        public string LapLabel2
        {
            get { return _LapLabel2; }
            set { SetProperty(ref _LapLabel2, value); }
        }

        private string _LapLabel3;
        public string LapLabel3
        {
            get { return _LapLabel3; }
            set { SetProperty(ref _LapLabel3, value); }
        }

        private string _TimerButtonText;
        public string TimerButtonText
        {
            get { return _TimerButtonText; }
            set { SetProperty(ref _TimerButtonText, value); }
        }

        private bool _IsRunning;
        public bool IsRunning
        {
            get { return _IsRunning; }
            set { SetProperty(ref _IsRunning, value); }
        }

        private int seconds;
        private int Lap;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            string st = "00:00:00";

            Title = "ストップウォッチ";
            TimerLabel = st;
            LapLabel1 = st;
            LapLabel2 = st;
            LapLabel3 = st;
            TimerButtonText = "スタート";
            IsRunning = false;
            seconds = 0;
            Lap = 1;
            TimerButton_Clicked = new DelegateCommand(() => TimerAction());
            LapButton_Clicked = new DelegateCommand(() => LapTimeAction());
        }

        private void TimerAction()
        {
            if (IsRunning)
            {
                TimerButtonTextChange();
                IsRunning = false;
            }
            else
            {
                TimerButtonTextChange();
                IsRunning = true;
                Device.StartTimer(new TimeSpan(0, 0, 0, 1), () => { Timeadd(); return IsRunning; });
            }
            
        }

        private void Timeadd()
        {
            seconds += 1;
            var ts = new TimeSpan(0,0,seconds);
            TimerLabel = ts.ToString(@"hh\:mm\:ss");
        }

        private void TimerButtonTextChange()
        {
            if(IsRunning)
            {
                TimerButtonText = "スタート";
            }
            else
            {
                TimerButtonText = "ストップ";
            }
            
        }

        private void LapTimeAction()
        {
            switch(Lap)
            {
                case 1:
                    LapLabel1 = TimerLabel;
                    Lap += 1;
                    break;
                case 2:
                    LapLabel2 = TimerLabel;
                    Lap += 1;
                    break;
                case 3:
                    LapLabel3 = TimerLabel;
                    Lap = 1;
                    break;
                default:
                    break;
            }
        }
    }
}
