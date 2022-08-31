using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PrismWPFLearn.ViewModels
{
    public class PrismUserControl1ViewModel : BindableBase
    {
        private DelegateCommand onClick;
        public DelegateCommand OnClick
        {
            get { return onClick; }
            set { SetProperty(ref onClick, value); }
        }

        public PrismUserControl1ViewModel()
        {
            OnClick = new DelegateCommand(() =>
            {
                MessageBox.Show("Hello");
            });
        }
    }
}
