using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics
{

	[AttributeUsage ( AttributeTargets . Property )]
	public sealed class OwnAttribute : PropertySerializationAttributeBase
	{

		public override SerializationMode Rule => SerializationMode . Full ;


		public OwnAttribute ( PropertyVisability visability = PropertyVisability . Everyone ) { Visability = visability ; }

	}

	[AttributeUsage ( AttributeTargets . Property )]
	public sealed class ReferenceAttribute : PropertySerializationAttributeBase
	{

		public override SerializationMode Rule => SerializationMode . Reference ;

		public ReferenceAttribute ( PropertyVisability visability = PropertyVisability . Everyone )
		{
			Visability = visability ;
		}

	}

	public abstract class PropertySerializationAttributeBase : Attribute
	{

		public PropertyVisability Visability { get ; set ; }

		public abstract SerializationMode Rule { get ; }

	}

	public enum SerializationMode
	{

		Full ,

		Reference

	}

	public enum PropertyVisability
	{

		Everyone ,

		Owner ,

		God

	}

	public enum ConsoleVision
	{

		Normal ,

		Owner ,

		God

	}

	public enum PlayerVision
	{

		Normal ,

		God

	}


	/// <summary>
	///     玩家具有的权限
	/// </summary>
	[Flags]
	public enum PlayerPermission
	{

		GetData ,


		/// <summary>
		///     发消息
		/// </summary>
		SendMessage = 0b0001 ,

		/// <summary>
		///     参与游戏
		/// </summary>
		Play = 0b0010 ,

		/// <summary>
		///     执行普通的命令
		/// </summary>
		ExcuteNormalCommand = 0b0100 ,

		/// <summary>
		///     控制游戏
		/// </summary>
		Control = 0b1000

	}

}
