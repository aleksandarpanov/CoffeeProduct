using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CoffeeProduct.Utils
{
    public class MoreCoffeeItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FirstTemplate { get; set; }
        public DataTemplate OthersTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var collection = (ObservableCollection<CoffeeProduct.Models.Coffee>)((CollectionView)container).ItemsSource;

            int index = collection.IndexOf((Models.Coffee)item);

            return index == 0 ? FirstTemplate : OthersTemplate;
        }
    }
}
