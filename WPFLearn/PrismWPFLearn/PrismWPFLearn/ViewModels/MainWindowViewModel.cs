using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismWPFLearn.Views;

namespace PrismWPFLearn.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IRegionManager _RegionManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand swithRegion1;    
        public DelegateCommand SwithRegion1
        {
            get { return swithRegion1; }
            set { SetProperty(ref swithRegion1, value); }
        }
        private DelegateCommand swithRegion2;
        public DelegateCommand SwithRegion2
        {
            get { return swithRegion2; }
            set { SetProperty(ref swithRegion2, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _RegionManager = regionManager;
            _RegionManager.RegisterViewWithRegion<PrismUserControl1>("ContentRegion");
            SwithRegion1 = new DelegateCommand(() =>
            {
                _RegionManager.Regions["ContentRegion"].RequestNavigate(nameof(PrismUserControl1));
            });
            SwithRegion2 = new DelegateCommand(() =>
            {
                _RegionManager.Regions["ContentRegion"].RequestNavigate(nameof(PrismUserControl2));
            });

        }
    }
}
