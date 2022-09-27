using System;
using System.Collections.Generic;
using System.Text;

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

		public LoginPageViewModel()
		{
			TitlePage = "Bem vindo ao Athenas!";
		}
	}
}
