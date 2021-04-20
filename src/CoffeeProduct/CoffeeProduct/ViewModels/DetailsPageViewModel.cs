using CoffeeProduct.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Prism.Commands;

namespace CoffeeProduct.ViewModels
{
    public class DetailsPageViewModel : BindableBase, IInitialize
    {
        private int quantity;

        private Coffee selectedItem;
        public Coffee SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
            }
        }

        public int Quantity
        {
            get => quantity;

            set
            {
                SetProperty(ref quantity, value);
            }
        }

        public DetailsPageViewModel()
        {

        }

        public void Initialize(INavigationParameters parameters)
        {
            SelectedItem = parameters.GetValue<Coffee>("SelectedItem");
        }

        private ICommand minusCommand;

        public ICommand MinusCommand
        {
            get
            {
                if (minusCommand == null)
                {
                    minusCommand = new DelegateCommand(Minus);
                }

                return minusCommand;
            }
        }

        private void Minus()
        {
            if (Quantity > 1)
            {
                --Quantity;
            }
        }

        private ICommand plusCommand;

        public ICommand PlusCommand
        {
            get
            {
                if (plusCommand == null)
                {
                    plusCommand = new DelegateCommand(Plus);
                }

                return plusCommand;
            }
        }

        private void Plus()
        {
            Quantity++;
        }
    }
}
