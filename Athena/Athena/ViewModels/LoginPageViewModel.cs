using Athena.Models;
using Athena.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Athena.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
		private string _TitlePage;

		public string TitlePage
		{
			get
			{
				return _TitlePage;
			}
			set
			{
				_TitlePage = value;
				Notify(_TitlePage);
			}
		}

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

		public ICommand LoginCommand { get; set; }
		public ICommand NewUserCommand { get; set; }

		public ICommand ForgetPasswordCommand { get; set; }

		public LoginPageViewModel()
		{
			TitlePage = "Bem vindo ao Athenas!";
			NewUserCommand = new Command(NewUserCommandEvent);
			ForgetPasswordCommand = new Command(ForgetPasswordCommandEvent);
			LoginCommand = new Command(LoginCommandEvent);

		}

		private void LoginCommandEvent(object obj)
		{
			App.Current.MainPage = new NavigationPage(new MainPage());
		}

		private void ForgetPasswordCommandEvent(object obj)
		{
			App.Current.MainPage.DisplayAlert("Alert!!!", "Command está funcionando!!!", "Ok");
		}

		private void NewUserCommandEvent(object obj)
		{
			App.Current.MainPage.Navigation.PushModalAsync(new NewUserPage());
		}
	}
}
