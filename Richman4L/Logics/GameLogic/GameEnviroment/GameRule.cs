using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Linq . Dynamic . Core ;
using System . Linq . Expressions ;
using System . Reflection ;
using System . Runtime . CompilerServices ;
using System . Xml . Linq ;

using WenceyWang . Richman4L . Annotations ;

namespace WenceyWang . Richman4L . GameEnviroment
{

	/// <summary>
	///     提供各种设置，比如说各种常数，如何产生随机数之类的
	/// </summary>
	public sealed class GameRule
	{

		public Func <DiceType , int , ReadOnlyCollection <int>> GetDice { get ; set ; }

		public static GameRule Current => Game . Current . GameRule ;

		public Dictionary <string , object> Values { get ; } = new Dictionary <string , object> ( ) ;

		public Dictionary <string , string> Expressions { get ; } = new Dictionary <string , string> ( ) ;

		//public Dictionary<string,Lazy<>>

		public static List <GameRuleItem> GameRules { get ; } = new List <GameRuleItem> ( ) ;

		private static bool Loaded { get ; set ; }

		private static object Locker { get ; } = new object ( ) ;

		public static Func <T , TResult> GetExpression <T , TResult> ( T @this , [CallerMemberName] string name = null )
		{
			ParameterExpression parameter = Expression . Parameter ( typeof ( T ) , nameof(T) . ToLower ( ) ) ;
			LambdaExpression expression = DynamicExpressionParser . ParseLambda ( true ,
																				new [ ] { parameter } ,
																				typeof ( TResult ) ,
																				Current . Expressions [ $"{typeof ( T ) . FullName}.{name}" ] ,
																				@this ) ;
			return expression . Compile ( ) as Func <T , TResult> ?? throw new InvalidOperationException ( ) ;
		}

		[Startup]
		public static void Load ( )
		{
			lock ( Locker )
			{
				if ( ! Loaded )
				{
					//Read All prop
					List <PropertyInfo> properties = typeof ( Game ) . GetTypeInfo ( ) . Assembly . GetTypes ( ) .
																		SelectMany ( type => type . GetTypeInfo ( ) . DeclaredProperties ) . ToList ( ) ;


					//Select Value Item
					List <PropertyInfo> valueRuleProperties =
						properties . Where ( property => property . GetCustomAttribute <GameRuleValueAttribute> ( ) != null ) .
									ToList ( ) ;

					foreach ( PropertyInfo propertyInfo in valueRuleProperties )
					{
						GameRuleValueAttribute attribute = propertyInfo . GetCustomAttribute <GameRuleValueAttribute> ( ) ;
						GameRuleItem item = new GameRuleValueItem ( $"{propertyInfo . DeclaringType . FullName}.{propertyInfo . Name}" ,
																	attribute . Introduction ,
																	attribute . Type ,
																	attribute . DefaultValue ) ;
						GameRules . Add ( item ) ;
					}


					//Select Expression Item
					List <PropertyInfo> expreesionRuleProperties =
						properties . Where ( property => property . GetCustomAttribute <GameRuleExpressionAttribute> ( ) != null ) .
									ToList ( ) ;
					foreach ( PropertyInfo propertyInfo in expreesionRuleProperties )
					{
						GameRuleExpressionAttribute attribute = propertyInfo . GetCustomAttribute <GameRuleExpressionAttribute> ( ) ;
						GameRuleItem item =
							new GameRuleExpressionItem ( $"{propertyInfo . DeclaringType . FullName}.{propertyInfo . Name}" ,
														attribute . Introduction ,
														attribute . Type ,
														attribute . DefaultExpression ) ;
						GameRules . Add ( item ) ;
					}

					Loaded = true ;
				}
			}
		}

		[PublicAPI]
		public static GameRule GenerateEmpty ( )
		{
			lock ( Locker )
			{
				GameRule result = new GameRule ( ) ;

				foreach ( GameRuleItem ruleItem in GameRules )
				{
					if ( ruleItem is GameRuleValueItem valueItem )
					{
						result . Values . Add ( valueItem . Name , valueItem . DefaultValue ) ;
					}
					else if ( ruleItem is GameRuleExpressionItem expressionItem )
					{
						result . Expressions . Add ( expressionItem . Name , expressionItem . DefaultExpression ) ;
					}
				}

				return result ;
			}
		}

		[PublicAPI]
		public XElement ToXElement ( )
		{
			XElement root = new XElement ( nameof(GameRule) ) ;

			XElement valueContainer = new XElement ( nameof(Values) ) ;
			foreach ( KeyValuePair <string , object> value in Values )
			{
				XElement valueElement = new XElement ( "Value" ) ;
				valueElement . SetAttributeValue ( "Name" , value . Key ) ;
				valueElement . SetAttributeValue ( "Value" , value . Value ) ;
				valueContainer . Add ( valueElement ) ;
			}

			root . Add ( valueContainer ) ;

			XElement expreessionContainer = new XElement ( nameof(Expressions) ) ;
			foreach ( KeyValuePair <string , string> expression in Expressions )
			{
				XElement expressionElement = new XElement ( "Expression" ) ;
				expressionElement . SetAttributeValue ( "Name" , expression . Key ) ;
				expressionElement . SetAttributeValue ( "Expression" , expression . Value ) ;
				expreessionContainer . Add ( expressionElement ) ;
			}

			root . Add ( expreessionContainer ) ;

			return root ;
		}

		public static T GetResult <T> ( Type type , [CallerMemberName] string name = null )
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof(name) ) ;
			}

			return ( T ) Current . Values [ $"{typeof ( T ) . FullName}.{name}" ] ;
		}

		public sealed class GameRuleValueItem : GameRuleItem
		{

			public object DefaultValue { get ; }


			public GameRuleValueItem ( string name , string introduction , Type resultType , object defaultValue ) :
				base ( name , introduction , resultType )
			{
				if ( ! resultType . IsInstanceOfType ( defaultValue ) )
				{
					//todo:
					throw new ArgumentException ( "" , nameof(defaultValue) ) ;
				}

				DefaultValue = defaultValue ;
			}

		}

		public sealed class GameRuleExpressionItem : GameRuleItem
		{

			public string DefaultExpression { get ; }

			public GameRuleExpressionItem ( string name , string introduction , Type resultType , string defaultExpression ) :
				base ( name , introduction , resultType )
			{
				DefaultExpression = defaultExpression ;
			}

		}

		public abstract class GameRuleItem
		{

			public string Name { get ; }

			public string Introduction { get ; }

			public Type ResultType { get ; }

			public GameRuleItem ( string name , string introduction , Type resultType )
			{
				Name = name ;
				Introduction = introduction ;
				ResultType = resultType ;
			}

		}

	}

}
