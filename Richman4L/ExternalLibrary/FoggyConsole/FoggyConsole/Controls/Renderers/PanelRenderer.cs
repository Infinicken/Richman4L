using System;

namespace FoggyConsole . Controls . Renderers
{

    /// <summary>
    ///     Draws a <code>Canvas</code>, which has no own appearance.
    ///     All controls within the panel are drawn.
    /// </summary>
    public class PanelRenderer : ControlRenderer<Canvas>
    {

        public PanelRenderer ( Canvas control ) : base ( control ) { }

        private static readonly ConsoleColor [] DebugColors =
        {
            ConsoleColor . Blue ,
            ConsoleColor . Red ,
            ConsoleColor . Green ,
            ConsoleColor . Cyan ,
            ConsoleColor . Yellow
        };

        private static readonly LineStyle DebugCharSet = new LineStyle ( );

        private static int _debugColorCounter = 0;

        /// <summary>
        ///     Draws the <code>Canvas</code> given in the Control-Property.
        /// </summary>
        /// <exception cref="InvalidOperationException">Is thrown if the Control-Property isn't set.</exception>
        /// <exception cref="InvalidOperationException">Is thrown if the CalculateBoundary-Method hasn't been called.</exception>
        public override void Draw ( )
        {
            base . Draw ( );
            if ( Control . Width == 0 ||
                Control . Height == 0 )
            {
                return;
            }

            Rectangle boxBound = new Rectangle ( Control . RenderArea . Left ,
                                                Control . RenderArea . Top ,
                                                Control . Width ,
                                                Control . Height );
            ConsoleColor boxColor;

            //if ( Application . DebugMode )
            //{
            //	boxColor = DebugColors [ _debugColorCounter ];

            //	_debugColorCounter++;
            //	if ( _debugColorCounter == DebugColors . Length )
            //	{
            //		_debugColorCounter = 0;
            //	}
            //}
            //else
            //{
            //	boxColor = Control . BackgroundColor;
            //}

            //FogConsole . DrawBox ( boxBound , DebugCharSet , Control . RenderArea,
            //						edgeBackgroundColor: boxColor ,
            //						fillBackgroundColor: boxColor ,
            //						fill: true );

            //if ( Application . DebugMode )
            //{
            //	FogConsole . Write ( Control . RenderArea. Left ,
            //						Control . RenderArea. Top ,
            //						"{" + Control . Name + "}" ,
            //						Control . RenderArea, Control . ForegroundColor , boxColor );
            //}

            foreach ( Control control in Control . Chrildren )
            {
                control . Renderer . Draw ( );
            }
        }

    }

}
