using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L
{

	[AttributeUsage ( AttributeTargets . Property )]
	public sealed class OwnAttribute : PropertySerializationAttributeBase
	{

		public override SerializationRule Rule => SerializationRule . Full ;


		public OwnAttribute ( PropertyVisability visability = PropertyVisability . Everyone ) { Visability = visability ; }

	}

	[AttributeUsage ( AttributeTargets . Property )]
	public sealed class ReferenceAttribute : PropertySerializationAttributeBase
	{

		public override SerializationRule Rule => SerializationRule . Reference ;

		public ReferenceAttribute ( PropertyVisability visability = PropertyVisability . Everyone )
		{
			Visability = visability ;
		}

	}

	public abstract class PropertySerializationAttributeBase : Attribute
	{

		public PropertyVisability Visability { get ; set ; }

		public abstract SerializationRule Rule { get ; }

	}

	public enum SerializationRule
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
