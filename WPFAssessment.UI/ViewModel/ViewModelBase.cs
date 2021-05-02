using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFAssessment.UI.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // CallerMemberName attribute helps the event so that we don't need a parameter set, compiler will automatically pass in the member name of whoever is the caller. 
        // Making this method virtual to allow any class to override it 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // needed to create a helper method to help raise the event
            // sender is going to be mainviewmodel
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
