using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

using WenceyWang . Richman4L . Logics . GameEnviroment ;

namespace WenceyWang . Richman4L . Logics . Maps
{

	/// <summary>
	///     空的地块
	/// </summary>
	[MapObject]
	[Guid ( "E0AB2AC4-499B-4584-95FA-77C17E35A66E" )]
	public sealed class EmptyBlock : Block
	{

		public override MapSize Size => MapSize . Small ;

		public override GameValue CrossDifficulty { get ; }

		public override int PondingDecrease => Map . Currnet . PondingDecreaseBase ;

		//todo:转化率
		//Todo:Write a Fody Addin to finish this state.
		[GameRuleExpression ( "Convert.ToInt32((Math.Tanh((ForestCoverRate.ToInt32() - 4000d)/1200d)+1d)*4200d)" ,
			typeof ( GameValue ) )]
		public override GameValue Flammability
			=> GameRule . GetExpression <EmptyBlock , int> ( this ) .
						Invoke ( this ) ; //( GameValue ) ( ( Math . Tanh ( ( ForestCoverRate - 4000d ) / 1200d ) + 1d )

		//				* 4200d ) ;


		public override GameValue ForestCoverRate { get ; set ; }

		//todo:转化率
		[GameRuleExpression ( "ForestCoverRate" , typeof ( int ) )]
		public override int CombustibleMaterialAmount => ForestCoverRate * 1 ;

		public EmptyBlock ( [NotNull] XElement resource ) : base ( resource )
		{
			if ( resource == null )
			{
				throw new ArgumentNullException ( nameof(resource) ) ;
			}

			ForestCoverRate =
				ReadUnnecessaryValue ( resource , nameof(ForestCoverRate) , GameRandom . Current . RandomGameValue ( ) ) ;
		}

		public EmptyBlock ( MapPosition position )
		{
			Position = position ;
			ForestCoverRate = GameRandom . Current . RandomGameValue ( ) ;
		}

	}

}
