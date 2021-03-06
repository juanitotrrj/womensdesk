using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private FastAccessViewModel _fastAccessModel;
       private SocialMediaViewModel _socialMediaModel;
       private VAWHotlinesViewModel _vAWHotlinesModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = FastAccessModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public FastAccessViewModel FastAccessModel
        {
            get { return _fastAccessModel ?? (_fastAccessModel = new FastAccessViewModel()); }
        }
 
        public SocialMediaViewModel SocialMediaModel
        {
            get { return _socialMediaModel ?? (_socialMediaModel = new SocialMediaViewModel()); }
        }
 
        public VAWHotlinesViewModel VAWHotlinesModel
        {
            get { return _vAWHotlinesModel ?? (_vAWHotlinesModel = new VAWHotlinesViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            FastAccessModel.ViewType = viewType;
            SocialMediaModel.ViewType = viewType;
            VAWHotlinesModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

      get { return Visibility.Collapsed; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadDataAsync(bool forceRefresh = false)
        {
            var loadTasks = new Task[]
            { 
                FastAccessModel.LoadItemsAsync(forceRefresh),
                SocialMediaModel.LoadItemsAsync(forceRefresh),
                VAWHotlinesModel.LoadItemsAsync(forceRefresh),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadDataAsync(true);
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
