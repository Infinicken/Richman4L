using System;
using System . Collections . Generic;
using System . IO;
using System . Linq;
using System . Runtime . InteropServices . WindowsRuntime;
using System . Threading . Tasks;
using Windows . Foundation;
using Windows . Foundation . Collections;
using Windows . UI . Xaml;
using Windows . UI . Xaml . Controls;
using Windows . UI . Xaml . Controls . Primitives;
using Windows . UI . Xaml . Data;
using Windows . UI . Xaml . Input;
using Windows . UI . Xaml . Media;
using Windows . UI . Xaml . Navigation;

using WenceyWang . Richman4L . App . Logic;
using WenceyWang . Richman4L . App . Pages . Controls;

namespace WenceyWang . Richman4L . App . Pages
{
	/// <summary>
	/// 提供加载动画的页
	/// </summary>
	public sealed partial class LoadingPage : Page
	{

		public LoadingPageArgument Argument { get; private set; }

		public LoadingPage ( )
		{
			InitializeComponent ( );
			Loaded += LoadingPage_Loaded;
		}

		protected override void OnNavigatedTo ( NavigationEventArgs e )
		{
			LoadingPageArgument argument = e . Parameter as LoadingPageArgument ;
			if ( argument != null )
			{
				Argument = argument;
			}
			else
			{
				throw new ArgumentException ( "Invalid Loading Parameter" );
			}

			base . OnNavigatedTo ( e );
		}

		private void LoadingPage_Loaded ( object sender , RoutedEventArgs e )
		{

		}

		SayingPresenter currentPrenster;



	}
}
