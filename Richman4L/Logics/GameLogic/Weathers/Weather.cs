using System ;

using WenceyWang . Richman4L . Calendars ;
using WenceyWang . Richman4L . Seasons ;

namespace WenceyWang . Richman4L .Weathers
{

	//Todo:完成天气模型
	/// <summary>
	///     表示天气，它会影响场景的样式，建造，玩家的移动，随机事件等。
	/// </summary>
	public class Weather
	{

		public bool BlockMoving => Wind . Strength >= 950 ;

		public bool BlockBuilding => Wind . Strength >= 900 ;

		public double BlockBuildBuildingPersent { get ; }

		/// <summary>
		///     指示降水类型
		/// </summary>
		public PrecipitationType PrecipitationType { get ; private set ; }

		/// <summary>
		///     指示阳光的强度,取值[0,1000]
		/// </summary>
		public int SunshineStrength { get ; private set ; }

		/// <summary>
		///     指示降水量
		/// </summary>
		public int Precipitation { get ; private set ; }


		public Wind Wind { get ; private set ; }

		/// <summary>
		///     代表温度（℃）(非常冷(-10~0)，冷(0，10)，舒适(10~25)，温暖(25~30)，热(30-35)，非常热(35-40))
		/// </summary>
		public double Temperature { get ; set ; }

		public int MoveReduceDistance ( int moveCount )
		{
			if ( Wind . Strength > 600 )
			{
				return Convert . ToInt32 ( Math . Floor ( moveCount * ( Convert . ToDouble ( Wind . Strength - 600 ) / 350d ) ) ) ;
			}

			return 0 ;
		}

		public long BuildAddMoney ( long price )
		{
			if ( Wind . Strength > 600 )
			{
				return Convert . ToInt64 ( Convert . ToDouble ( price ) * Convert . ToDouble ( Wind . Strength - 600 ) / 300d ) ;
			}

			return 0 ;
		}

		public Weather Clone ( )
		{
			return new Weather
					{
						Precipitation = Precipitation ,
						PrecipitationType = PrecipitationType ,
						SunshineStrength = SunshineStrength ,
						Temperature = Temperature ,
						Wind = Wind
					} ;
		}

		public static Weather Random ( GameDate date )
		{
			Weather weather = new Weather ( ) ;

			double seasonProcessNet = Convert . ToDouble ( date . SeasonProcess ) / Convert . ToDouble ( date . SeasonLenth ) ;

			double windAngle = 0 ;
			int windStrength = 0 ;


			switch ( date . Season )
			{
				case Season . Spring :
				{
					if ( GameRandom . Current . Next ( 2 ) == 1 ) //和煦的，南风，升温
					{
						weather . Temperature = seasonProcessNet * seasonProcessNet * 9 * 1.25 - 4.8 +
												GameRandom . Current . NextNormalDouble ( 0 , 4 , 0 , 10 ) ;

						windAngle = GameRandom . Current . NextNormalDouble ( 180 , 100 , 90 , 270 ) ;
						windStrength = GameRandom . Current . NextNormal ( 350 , 200 , 0 , 600 ) ;

						if ( weather . Wind . Strength <= 450 )
						{
							int rain = GameRandom . Current . Next ( 1 , 11 ) ;

							if ( rain == 1 ) //下雨
							{
								weather . Precipitation = GameRandom . Current . NextNormal ( 100 , 50 , 20 , 200 ) ;
								weather . SunshineStrength = GameRandom . Current . NextNormal ( 100 , 50 , 20 , 200 ) ;
								if ( weather . Temperature >= 5 )
								{
									weather . PrecipitationType = PrecipitationType . Rainy ;
								}
								else
								{
									if ( weather . Temperature >= 0 )
									{
										weather . PrecipitationType = PrecipitationType . Sleet ;
									}
									else
									{
										weather . PrecipitationType = PrecipitationType . Snowy ;
									}
								}
							}
							else
							{
								weather . Precipitation = 0 ;
								weather . SunshineStrength = GameRandom . Current . NextNormal ( 150 , 50 , 20 , 300 ) ;
							}
						}
						else
						{
							weather . Precipitation = 0 ;
							weather . SunshineStrength = GameRandom . Current . NextNormal ( 175 , 60 , 50 , 400 ) ;
						}
					}
					else //犀利的，北风，降温
					{
						weather . Temperature = seasonProcessNet * seasonProcessNet * 9 * 1.25 - 4.8 +
												GameRandom . Current . NextNormalDouble ( 0 , 4 , - 10 , 0 ) ;
						windAngle = GameRandom . Current . NextNormalDouble ( 0 , 100 , - 90 , 90 ) ;
						if ( weather . Wind . Angle < 0 )
						{
							windAngle += 360 ;
						}
						windStrength = GameRandom . Current . NextNormal ( 350 , 200 , 200 , 1000 ) ;

						if ( weather . Wind . Strength <= 450 )
						{
							int rain = GameRandom . Current . Next ( 1 , 21 ) ;
							if ( rain == 1 ) //下雨
							{
								weather . Precipitation = GameRandom . Current . NextNormal ( 300 , 50 , 20 , 500 ) ;
								weather . Precipitation = GameRandom . Current . NextNormal ( 300 , 50 , 20 , 500 ) ;
								weather . SunshineStrength =
									GameRandom . Current . NextNormal ( 100 , 50 , 20 , 200 ) ;
								if ( weather . Temperature >= 5 )
								{
									weather . PrecipitationType = PrecipitationType . Rainy ;
								}
								else
								{
									if ( weather . Temperature >= 0 )
									{
										weather . PrecipitationType = PrecipitationType . Sleet ;
									}
									else
									{
										weather . PrecipitationType = PrecipitationType . Snowy ;
									}
								}
							}
							else
							{
								weather . Precipitation = 0 ;
								weather . SunshineStrength = GameRandom . Current . NextNormal ( 200 , 50 , 20 , 400 ) ;
							}
						}
						else
						{
							weather . Precipitation = 0 ;
							weather . SunshineStrength = GameRandom . Current . NextNormal ( 250 , 60 , 50 , 500 ) ;
						}
					}

					break ;
				}
				case Season . Summer :
				{
					if ( GameRandom . Current . Next ( 2 ) == 1 )
					{
					}
					break ;
				}
				case Season . Autumn :
				{
					break ;
				}
				case Season . Winter :
				{
					break ;
				}
				default :
				{
					throw new NotImplementedException ( ) ;
				}
			}

			weather . Wind = new Wind { Angle = windAngle , Strength = windStrength } ;
			return weather ;
		}


		public static Weather GetWeather ( GameDate date )
		{
			return Game . Current . Calendar . WeatherList [ date . Date ] ;
		}

	}

}
