using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace MW5.Plugins.AdvancedSnapping.ViewModels
{
    internal class DoubleInputBoxViewModel : ViewModelBase
    {

        private bool closeOnEnter = false;
        public bool CloseOnEnter
        {
            get => closeOnEnter;
            set
            {
                if (this.closeOnEnter != value)
                {
                    this.closeOnEnter = value;
                    OnPropertyChanged();
                }
            }
        }

        private string stringValue;
        public string StringValue
        {
            get => stringValue;
            set
            {
                if (this.stringValue != value)
                {
                    this.stringValue = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Value");
                }
            }
        }

        double lastValue;
        public double Value
        {
            get
            {
                if (double.TryParse(StringValue, NumberStyles.Float, CultureInfo.CurrentCulture, out double result))
                    lastValue = result;
                return lastValue;
            }
        }

        private bool hasFocus;
        public bool HasFocus
        {
            get => hasFocus;
            set
            {
                if (this.hasFocus != value)
                {
                    this.hasFocus = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand valueChangedCommand;
        public ICommand ValueChangedCommand
        {
            get => valueChangedCommand;
            set
            {
                if (this.valueChangedCommand != value)
                {
                    this.valueChangedCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand valueEnteredCommand;
        public ICommand ValueEnteredCommand
        {
            get => valueEnteredCommand;
            set
            {
                if (this.valueEnteredCommand != value)
                {
                    this.valueEnteredCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        private string inputRegex = "[0-9.-]+";
        public string InputRegex
        {
            get => inputRegex;
            set
            {
                if (this.inputRegex != value)
                {
                    this.inputRegex = value;
                    OnPropertyChanged();
                }
            }
        }

        private string label = "Value:";
        public string Label
        {
            get => label;
            set
            {
                if (this.label != value)
                {
                    this.label = value;
                    OnPropertyChanged();
                }
            }
        }

        public DoubleInputBoxViewModel(string label, double value, ICommand valueChangedCommand, ICommand valueEnteredCommand)
        {
            StringValue = value.ToString();
            Label = label;
            ValueEnteredCommand = new RelayCommand((o) => {
                if (valueEnteredCommand.CanExecute(o)) valueEnteredCommand.Execute(o);
                if (CloseOnEnter)
                {
                    Window.GetWindow(o as DependencyObject).Hide();
                }
            });
            ValueChangedCommand = valueChangedCommand;

            PropertyChanged += ValueChanged;
        }

        private void ValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                ValueChangedCommand.Execute(sender);
            }
        }
    }
}
