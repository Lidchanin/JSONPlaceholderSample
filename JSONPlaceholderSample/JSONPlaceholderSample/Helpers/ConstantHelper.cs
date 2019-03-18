using System;

namespace JSONPlaceholderSample.Helpers
{
    public static class ConstantHelper
    {
        public const string ServiceUrl = "https://jsonplaceholder.typicode.com/";

        public static readonly TimeSpan ServiceTimeout = new TimeSpan(0,0,1,0);

        public const string UsersPageTitle = "Users";

        public const string Loading = "Please, wait...";
        public const string Error = "Error";
        public const string Reload = "Reload";
        public const string Ok = "OK";

        public const string Albums = "Albums";
        public const string Todos = "Todos";
        public const string Posts = "Posts";
        public const string Name = "Name";
        public const string Website = "Website";
        public const string Email = "Email";
        public const string Address = "Address";
        public const string Phone = "Phone";
        public const string Company = "Company";
        public const string FullInformation = "Full information";
        public const string More = "More";

        #region Files names

        public const string DefaultUserIcon = "default_user_icon.png";
        public const string CurvedMaskImage = "curved_image_mask.png";
        public const string DefaultProfileBackgroundImage = "default_profile_background.png";
        public const string CompanyIcon = "company_icon.png";
        public const string EmailIcon = "email_icon.png";
        public const string LocationIcon = "location_icon.png";
        public const string NameIcon = "name_icon.png";
        public const string PhoneIcon = "phone_icon.png";
        public const string WebsiteIcon = "website_icon.png";

        #endregion
    }
}