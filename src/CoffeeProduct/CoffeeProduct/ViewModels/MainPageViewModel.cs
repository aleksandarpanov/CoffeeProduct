using CoffeeProduct.Models;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CoffeeProduct.ViewModels
{
    /// <summary>
    /// MainPage ViewModel
    /// </summary>
    /// <seealso cref="CoffeeProduct.ViewModels.ViewModelBase" />
    public class MainPageViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<Coffee> mainCoffees;
        private ObservableCollection<Coffee> otherCoffees;
        private Coffee selectedItem;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
            LoadCoffees();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the main coffees.
        /// </summary>
        /// <value>
        /// The main coffees.
        /// </value>
        public ObservableCollection<Coffee> MainCoffees
        {
            get { return mainCoffees; }
            set { SetProperty(ref mainCoffees, value); }
        }

        /// <summary>
        /// Gets or sets the other coffees.
        /// </summary>
        /// <value>
        /// The other coffees.
        /// </value>
        public ObservableCollection<Coffee> OtherCoffees
        {
            get { return otherCoffees; }
            set { SetProperty(ref otherCoffees, value); }
        }

        public Coffee SelectedItem
        {
            get => selectedItem;

            set
            {
                if (selectedItem != value)
                {
                    SetProperty(ref selectedItem, value);
                    if (value != null)
                    {
                        _ = NavigateToDetailsPageAsync(value).ContinueWith(task => SelectedItem = null);
                    }
                }
            }
        }

        private Task NavigateToDetailsPageAsync(Coffee selectedItem)
        {
            var navParameters = new NavigationParameters 
            {
                { "SelectedItem", selectedItem }
            };

            return NavigationService.NavigateAsync("DetailsPage", navParameters);
        }

        #endregion

        #region Private Methods

        private void LoadCoffees()
        {
            MainCoffees = new ObservableCollection<Coffee>
            {
                new Coffee { 
                    Id = 1,
                    Title = "Coffee Robusta", 
                    SubTitle = "The two most popular & special taste", 
                    Description="A coffee bean is a seed of the Coffea plant and the source for coffee. It is the pit inside the red or purple fruit.", 
                    LongDescription="A coffee bean is a seed of the Coffea plant and the source for coffee. It is the pit inside the red or purple fruit. Just like ordinary cherries.",
                    Price = 134.00m,
                    Image = "CoffeeRobusta.png"
                },
                new Coffee {
                    Id = 2,
                    Title = "Coffee Arabica",
                    SubTitle = "The two most popular & special taste",
                    Description="A coffee bean is a seed of the Coffea plant and the source for coffee. It is the pit inside the red or purple fruit.",
                    LongDescription="A coffee bean is a seed of the Coffea plant and the source for coffee. It is the pit inside the red or purple fruit. Just like ordinary cherries.",
                    Price = 134.00m,
                    Image = "CoffeeArabica.png"
                },
                new Coffee {
                    Id = 3,
                    Title = "Coffee Robusta",
                    SubTitle = "The two most popular & special taste",
                    Description="A coffee bean is a seed of the Coffea plant and the source for coffee. It is the pit inside the red or purple fruit.",
                    LongDescription="A coffee bean is a seed of the Coffea plant and the source for coffee. It is the pit inside the red or purple fruit. Just like ordinary cherries.",
                    Price = 134.00m,
                    Image = "CoffeeRobusta.png"
                }
            };

            OtherCoffees = new ObservableCollection<Coffee>
            {
                new Coffee {
                    Title = "Coffee Arabica",
                    Price = 449.00m,
                    Image = "MoreProductCoffeeArabica.png"
                },
                new Coffee {
                    Title = "Coffee Robusta",
                    Price = 449.00m,
                    Image = "MoreProductCoffeeRobusta.png"
                },
                new Coffee {
                    Title = "Coffee Arabica",
                    Price = 449.00m,
                    Image = "MoreProductCoffeeArabica.png"
                },
            };
        }

        #endregion
    }
}
