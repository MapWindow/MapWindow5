using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MW5.Plugins.AdvancedSnapping.ViewModels
{
    internal class DoubleInputViewModel : ViewModelBase
    {

        private DoubleInputBoxViewModel dblValue;
        public DoubleInputBoxViewModel Value
        {
            get => dblValue;
            set
            {
                if (this.dblValue != value)
                {
                    this.dblValue = value;
                    OnPropertyChanged();
                }
            }
        }

        protected Action<double> OnNewValue { get; set; }
        protected Action<double> OnTextValueChanged { get; set; }

        private Visibility _mapActionVisible;
        public Visibility MapActionVisible
        {
            get => _mapActionVisible;
            set
            {
                if (this._mapActionVisible != value)
                {
                    this._mapActionVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand _mapActionCommand;
        public ICommand MapActionCommand
        {
            get => _mapActionCommand;
            set
            {
                if (this._mapActionCommand != value)
                {
                    this._mapActionCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        public DoubleInputViewModel(string label, double dblValue, Action<double> onValueChanged, Action<double> onNewValue, Action<object> mapAction)
        {
            Value = new DoubleInputBoxViewModel(label, dblValue, new RelayCommand(OnValueChanged), new RelayCommand(OnValueEntered))
            {
                CloseOnEnter = true,
                HasFocus = true
            };

            OnNewValue = onNewValue;
            OnTextValueChanged = onValueChanged;
            MapActionCommand = new RelayCommand(mapAction ?? ((o) => { }));
            MapActionVisible = mapAction == null ? Visibility.Collapsed : Visibility.Visible;
        }

        private void OnValueEntered(object obj)
        {
            OnNewValue(Value.Value);
        }

        private void OnValueChanged(object obj)
        {
            OnTextValueChanged(Value.Value);
        }
    }
}
