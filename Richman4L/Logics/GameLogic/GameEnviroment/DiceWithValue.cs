using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . GameEnviroment
{

	/// <summary>
	///     骰子和它的值
	/// </summary>
	public struct DiceWithValue
	{

		public DiceType DiceType { get ; }

		public int Value { get ; }

		public DiceWithValue ( DiceType diceType , int value )
		{
			if ( ! Enum . IsDefined ( typeof ( DiceType ) , diceType ) )
			{
				throw new ArgumentOutOfRangeException ( nameof(diceType) , "Value should be defined in the DiceType enum." ) ;
			}
			if ( value <= 0
				|| value > ( int ) diceType )
			{
				throw new ArgumentOutOfRangeException ( nameof(value) ) ;
			}

			DiceType = diceType ;
			Value = value ;
		}

		public override string ToString ( ) { return $"{nameof(DiceType)}: {DiceType}, {nameof(Value)}: {Value}" ; }

	}

}
