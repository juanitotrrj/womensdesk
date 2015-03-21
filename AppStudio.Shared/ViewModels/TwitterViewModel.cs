using System;
using System.Windows;
using System.Windows.Input;

using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio.ViewModels
{
    public class TwitterViewModel : ViewModelBase<TwitterSchema>
    {
        private RelayCommandEx<TwitterSchema> itemClickCommand;
        public RelayCommandEx<TwitterSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<TwitterSchema>(
                        (item) =>
                        {
                            string link = item.GetValue("Link");
                            if (!string.IsNullOrEmpty(link))
                            {
                                NavigationServices.NavigateTo(new Uri(item.GetValue("Link")));
                            }
                        });
                }

                return itemClickCommand;
            }
        }


        private RelayCommandEx<string> changeFontSizeCommand;

        public RelayCommandEx<string> ChangeFontSizeCommand
        {
            get
            {
                if (changeFontSizeCommand == null)
                {
                    changeFontSizeCommand = new RelayCommandEx<string>((s) =>
                    {
                        FontSizes fontSize;
                        Enum.TryParse<FontSizes>(s, out fontSize);
                        DisplayFontSize = fontSize;
                    });
                }

                return changeFontSizeCommand;
            }
        }

        public FontSizes DisplayFontSize
        {
            get
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(LocalSettingNames.TextViewerFontSizeSetting))
                {
                    FontSizes fontSizes;
                    Enum.TryParse<FontSizes>(ApplicationData.Current.LocalSettings.Values[LocalSettingNames.TextViewerFontSizeSetting].ToString(), out fontSizes);
                    return fontSizes;
                }
                return FontSizes.Normal;
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values[LocalSettingNames.TextViewerFontSizeSetting] = value.ToString();
                this.OnPropertyChanged("DisplayFontSize");
            }
        }
        override protected DataSourceBase<TwitterSchema> CreateDataSource()
        {
            return new TwitterDataSource(); // TwitterDataSource
        }


        override public Visibility RefreshVisibility
        {
            get { return ViewType == ViewTypes.List ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("TwitterList");
        }

        override protected void NavigateToSelectedItem()
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                NavigationServices.NavigateTo(new Uri(currentItem.GetValue("Link")));
            }
        }
    }
}
