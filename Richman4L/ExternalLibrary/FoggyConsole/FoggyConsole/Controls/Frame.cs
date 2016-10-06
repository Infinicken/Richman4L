using System;

using FoggyConsole . Controls . Renderers;

namespace FoggyConsole . Controls
{

	public class Frame : ContentControl
	{

		public override bool CanFocus => false;

		public Page CurrentPage { get; private set; }

		public override Control Content { get { return CurrentPage; } set { throw new InvalidOperationException ( ); } }

		public Frame ( IControlRenderer renderer = null ) : base ( renderer ?? new FrameRanderer ( ) ) { }

		public override void Measure ( Size availableSize ) { CurrentPage . Measure ( availableSize ); }

		public override void Arrange ( Rectangle finalRect ) { CurrentPage . Arrange ( new Rectangle ( Size ) ); }

		protected override void RequestMeasure ( ) { Measure ( Size ); }


		public void NavigateTo ( Page page )
		{
			if ( page == null )
			{
				throw new ArgumentNullException ( nameof ( page ) );
			}

			if ( CurrentPage != page )
			{
				CurrentPage = page;
				CurrentPage . Container = this;
				Measure ( Size );
			}
		}

	}

}
