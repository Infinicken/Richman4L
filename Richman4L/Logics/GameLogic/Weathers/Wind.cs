namespace WenceyWang . Richman4L .Weathers
{

	public struct Wind
	{

		/// <summary>
		///     风向，取值[0,360)，以正北作为0°，逆时针
		///     Todo:预计在较大的地图中参与区块天气的变化。
		///     会影响视觉效果。
		/// </summary>
		public double Angle { get ; set ; }

		/// <summary>
		///     风的强度,
		///     对建筑的建设造成的影响是增加建筑成本，当天的建筑成本是x*(s-600)/300*2，四舍五入取整，超过900的话，停止建筑。
		///     如果风力大于600，会减缓玩家的移动速度，玩家的移动值将变为x*(1-(s-600)/350)，向下取整,注意正负
		///     如果风力大于800，营业商店停止营业。
		///     如果风力大于950，每个被表示为“容易摧毁“的建筑会有x=(s-950)/50的可能被摧毁，摧毁后的行为Todo
		/// </summary>
		public int Strength { get ; set ; }

	}

}
