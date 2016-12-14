using System ;
using System . Collections ;
using System . Linq ;

using CommandLine ;

namespace WenceyWang . Richman4L . Apps .Console
{

	/// <summary>
	///     指示启动时的命令行参数
	/// </summary>
	public class ConsoleArguments
	{

		[Option ( DefaultValue = false , Required = false )]
		public bool NoLogo { get ; set ; }

		[Option ( DefaultValue = false , Required = false )]
		public bool Setup { get ; set ; }

		//public bool ShowLicense { get; set; }


		//[Option ( DefaultValue = false , Required = false )]
	}

}
