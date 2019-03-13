using JSONPlaceholderSample.Controls.ViewCells;
using JSONPlaceholderSample.Models;
using Xamarin.Forms;

namespace JSONPlaceholderSample.DataTemplateSelectors
{
    public class UsersIdTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _evenUserIdDateTemplate;
        private readonly DataTemplate _unevenUserIdDateTemplate;

        public UsersIdTemplateSelector()
        {
            _evenUserIdDateTemplate = new DataTemplate(typeof(EvenUserIdViewCell));
            _unevenUserIdDateTemplate = new DataTemplate(typeof(UnevenUserIdViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (!(item is User user)) return null;

            return user.Id % 2 == 0
                ? _evenUserIdDateTemplate
                : _unevenUserIdDateTemplate;
        }
    }
}