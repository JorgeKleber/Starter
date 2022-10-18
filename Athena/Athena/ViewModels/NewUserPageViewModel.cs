using Athena.Data;
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

		private async void SaveUserAccountEvent(object obj)
		{
			if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
			{
				await App.Current.MainPage.DisplayAlert("Atenção!!!", "Preencha todos os campos!", "Ok");
			}
			else
			{
				User userInfo = new User()
				{
					Name = UserName,
					Password = this.Password
				};

				AthenaDb athenaDb = await AthenaDb.Instance;
				int result = await athenaDb.SaveItemAsync(userInfo);

				if (result != 0)
				{
					await App.Current.MainPage.DisplayAlert("Atenção!!!", "Usuário cadastrado com sucesso!", "Ok"); 
					await App.Current.MainPage.Navigation.PopModalAsync();
				}
			}
		}
	}
}
