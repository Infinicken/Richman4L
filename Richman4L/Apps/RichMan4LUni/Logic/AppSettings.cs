using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel ;
using System . Linq ;
using System . Runtime . CompilerServices ;

using Windows . Storage ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{

	public class AppSettings : INotifyPropertyChanged
	{

		public static AppSettings Current { get ; } = new AppSettings ( ) ;

		/// <summary>
		///     游戏的标题
		/// </summary>
		public GameTitle GameTitle
		{
			get => ReadSettings ( nameof(GameTitle) , string . Empty ) ;
			set
			{
				SaveSettings ( nameof(GameTitle) , value . ToString ( ) ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     指示是否同意协议
		/// </summary>
		public bool AcceptLicence
		{
			get => ReadSettings ( nameof(AcceptLicence) , false ) ;
			set
			{
				SaveSettings ( nameof(AcceptLicence) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     指示强迫症模式是否开启
		/// </summary>
		public bool OcdMode
		{
			get => ReadSettings ( nameof(OcdMode) , false ) ;
			set
			{
				SaveSettings ( nameof(OcdMode) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     指示Comic Sans模式是否开启
		/// </summary>
		public bool ComicSansMode
		{
			get => ReadSettings ( nameof(ComicSansMode) , false ) ;
			set
			{
				SaveSettings ( nameof(ComicSansMode) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     春季的长度
		/// </summary>
		public int SpringLenth
		{
			get => ReadSettings ( nameof(SpringLenth) , 20 ) ;
			set
			{
				SaveSettings ( nameof(SpringLenth) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     夏季的长度
		/// </summary>
		public int SummerLenth
		{
			get => ReadSettings ( nameof(SummerLenth) , 20 ) ;
			set
			{
				SaveSettings ( nameof(SummerLenth) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     秋季的长度
		/// </summary>
		public int AutumnLenth
		{
			get => ReadSettings ( nameof(AutumnLenth) , 20 ) ;
			set
			{
				SaveSettings ( nameof(AutumnLenth) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     冬季的长度
		/// </summary>
		public int WinterLenth
		{
			get => ReadSettings ( nameof(WinterLenth) , 20 ) ;
			set
			{
				SaveSettings ( nameof(WinterLenth) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     是否允许随机生成标题
		/// </summary>
		public bool AllowRandomTitle
		{
			get => ReadSettings ( nameof(AllowRandomTitle) , false ) ;
			set
			{
				SaveSettings ( nameof(AllowRandomTitle) , value ) ;
				GameTitleManager . GenerateNewTitle ( ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     是否允许随机生成标题前半部分
		/// </summary>
		public bool AllowRandomTitleRoot
		{
			get => ReadSettings ( nameof(AllowRandomTitleRoot) , false ) ;
			set
			{
				SaveSettings ( nameof(AllowRandomTitleRoot) , value ) ;
				GameTitleManager . GenerateNewTitle ( ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		public ApplicationDataContainer RoamingSettings { get ; set ; }

		public AppSettings ( )
		{
			App . Current . TitleChanged += App_TitleChanged ;
			RoamingSettings = ApplicationData . Current . RoamingSettings ;
		}

		public event PropertyChangedEventHandler PropertyChanged ;

		private void App_TitleChanged ( object sender , EventArgs e )
		{
			PropertyChanged ? . Invoke ( this , new PropertyChangedEventArgs ( nameof(GameTitle) ) ) ;
		}

		private void SaveSettings ( string key , object value ) { RoamingSettings . Values [ key ] = value ; }

		private T ReadSettings <T> ( string key , T defaultValue )
		{
			if ( RoamingSettings . Values . ContainsKey ( key ) )
			{
				return ( T ) RoamingSettings . Values [ key ] ;
			}
			if ( null != defaultValue )
			{
				return defaultValue ;
			}

			return default ( T ) ;
		}

		protected void NotifyPropertyChanged ( [CallerMemberName] string propName = "" )
		{
			PropertyChanged ? . Invoke ( this , new PropertyChangedEventArgs ( propName ) ) ;
		}

		#region Sound

		/// <summary>
		///     指示是否播放声音
		/// </summary>
		public bool PlaySound
		{
			get => ReadSettings ( nameof(PlaySound) , false ) ;
			set
			{
				SaveSettings ( nameof(PlaySound) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     音乐音量
		/// </summary>
		public int MusicVolume
		{
			get => ReadSettings ( nameof(MusicVolume) , 60 ) ;
			set
			{
				SaveSettings ( nameof(MusicVolume) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     效果音量
		/// </summary>
		public int EffectVolume
		{
			get => ReadSettings ( nameof(EffectVolume) , 10 ) ;
			set
			{
				SaveSettings ( nameof(EffectVolume) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		/// <summary>
		///     通知音量
		/// </summary>
		public int NotificationVolume
		{
			get => ReadSettings ( nameof(NotificationVolume) , 30 ) ;
			set
			{
				SaveSettings ( nameof(NotificationVolume) , value ) ;
				NotifyPropertyChanged ( ) ;
			}
		}

		#endregion

	}

}
