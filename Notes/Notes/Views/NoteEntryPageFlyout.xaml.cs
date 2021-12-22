using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPageFlyout : ContentPage
    {
        public ListView ListView;

        public NoteEntryPageFlyout()
        {
            InitializeComponent();

            BindingContext = new NoteEntryPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class NoteEntryPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NoteEntryPageFlyoutMenuItem> MenuItems { get; set; }

            public NoteEntryPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<NoteEntryPageFlyoutMenuItem>(new[]
                {
                    new NoteEntryPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new NoteEntryPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new NoteEntryPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new NoteEntryPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new NoteEntryPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}