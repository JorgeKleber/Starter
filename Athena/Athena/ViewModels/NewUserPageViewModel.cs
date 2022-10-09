using Akavache;
using Athena.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Athena.ViewModels
{
	public class NewUserPageViewModel : ViewModelBase
	{
		private string _UserName;

		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				_UserName = value;
				Notify("UserInfo");

			}
		}

		private string _Password;
		public string Password
		{
			get { return _Password; }
			set
			{
				_Password = value; 
				Notify("Password");
			}
		}

		public ICommand SaveUserAccountCommand { get; set; }

		public NewUserPageViewModel()
		{
			SaveUserAccountCommand = new Command(SaveUserAccountEvent);
		}

		private void SaveUserAccountEvent(object obj)
		{
			User userInfo = new User()
			{
				Name = UserName,
				Password = this.Password
			};

			var teste = BlobCache.UserAccount.InsertObject("UserInfo", userInfo);

			App.Current.MainPage.DisplayAlert("Teste", "Nome: "+UserName+" pass: "+Password, "Ok");


		}
	}
}
