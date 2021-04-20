using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CoffeeProduct.Utils
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate OddTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var collection = (ObservableCollection<CoffeeProduct.Models.Coffee>)((CollectionView)container).ItemsSource;

            int index = collection.IndexOf((Models.Coffee)item);

            return (index + 1) % 2 == 0 ? EvenTemplate : OddTemplate;
        }
    }
}
