using ChatAppUI.Core;
using ChatAppUI.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppUI.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */

        public RelayCommand SendCommand { get; set; }

        public ContactModel SelectedContact { get; set; }

        private string _message;

        public string Message
        {
            get { return  _message; }
            set { _message = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel { FirstMessage=false, Message= Message});
                Message = "";
            });

            Messages.Add( new MessageModel { FirstMessage = true, ImageSource = "https://static.remove.bg/remove-bg-web/8fb1a6ef22fefc0b0866661b4c9b922515be4ae9/assets/start_remove-c851bdf8d3127a24e2d137a55b1b427378cd17385b01aec6e59d5d4b5f39d2ec.png",
            IsNativeOrigin = true, Message = "Merhaba",Time = DateTime.Now, Username = "Mehmet Emin Zeğerek", UsernameColor = "#AEA9BD"});


        }
    }
}
