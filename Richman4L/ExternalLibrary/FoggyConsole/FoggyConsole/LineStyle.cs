/*
This file is part of FoggyConsole.

FoggyConsole is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as
published by the Free Software Foundation, either version 3 of
the License, or (at your option) any later version.

FoogyConsole is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with FoggyConsole.  If not, see <http://www.gnu.org/licenses/lgpl.html>.
*/

namespace FoggyConsole
{

	/// <summary>
	///     A set of characters which can be used to draw a box or complex lines
	/// </summary>
	public class LineStyle
	{

		/// <summary>
		///     A character representing the top left corner of an rectangle
		/// </summary>
		public char TopLeftCorner { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing the top right corner of an rectangle
		/// </summary>
		public char TopRightCorner { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing the bottom left corner of an rectangle
		/// </summary>
		public char BottomLeftCorner { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing the bottom right corner of an rectangle
		/// </summary>
		public char BottomRightCorner { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing the a left or right edge of an rectangle
		/// </summary>
		public char VerticalEdge { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing the a top or bottom edge of an rectangle
		/// </summary>
		public char HorizontalEdge { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing a connection between a <code>HorizontalEdge</code> and a <code>VerticalEdge</code>,
		///     in which the <code>VerticalEdge</code> is above the <code>HorizontalEdge</code>
		/// </summary>
		public char ConnectionHorizontalUp { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing a connection between a <code>HorizontalEdge</code> and a <code>VerticalEdge</code>,
		///     in which the <code>VerticalEdge</code> is below the <code>HorizontalEdge</code>
		/// </summary>
		public char ConnectionHorizontalDown { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing a connection between a <code>VerticalEdge</code> and a <code>HorizontalEdge</code>,
		///     in which the <code>HorizontalEdge</code> is on the left side of the <code>VerticalEdge</code>
		/// </summary>
		public char ConnectionVerticalRight { get ; set ; } = ' ' ;

		/// <summary>
		///     A character representing a connection between a <code>VerticalEdge</code> and a <code>HorizontalEdge</code>,
		///     in which the <code>HorizontalEdge</code> is on the right side of the <code>VerticalEdge</code>
		/// </summary>
		public char ConnectionVerticalLeft { get ; set ; } = ' ' ;

		/// <summary>
		///     A characer representing a connection between two <code>VerticalEdge</code> and two <code>HorizontalEdge</code>
		/// </summary>
		public char ConnectionCross { get ; set ; } = ' ' ;

		/// <summary>
		///     A empty character which can be used to fill boxes
		/// </summary>
		public char EmptyChar { get ; set ; } = ' ' ;

		/// <summary>
		///     A <code>LineStyle</code> which uses single-lined box-drawing-characters
		/// </summary>
		/// <returns></returns>
		public static LineStyle Empty => new LineStyle
										{
											TopLeftCorner = ' ' ,
											TopRightCorner = ' ' ,
											BottomLeftCorner = ' ' ,
											BottomRightCorner = ' ' ,
											VerticalEdge = ' ' ,
											HorizontalEdge = ' ' ,
											ConnectionHorizontalUp = ' ' ,
											ConnectionHorizontalDown = ' ' ,
											ConnectionVerticalRight = ' ' ,
											ConnectionVerticalLeft = ' ' ,
											ConnectionCross = ' ' ,
											EmptyChar = ' '
										} ;


		/// <summary>
		///     A very simple <code>LineStyle</code>.
		/// </summary>
		public static LineStyle GetSimpleSet { get ; } = new LineStyle
														{
															TopLeftCorner = '.' ,
															TopRightCorner = '.' ,
															BottomLeftCorner = '`' ,
															BottomRightCorner = '´' ,
															VerticalEdge = '|' ,
															HorizontalEdge = '-' ,
															ConnectionHorizontalUp = '+' ,
															ConnectionHorizontalDown = '+' ,
															ConnectionVerticalRight = '+' ,
															ConnectionVerticalLeft = '+' ,
															ConnectionCross = '+' ,
															EmptyChar = ' '
														} ;

		/// <summary>
		///     A <code>LineStyle</code> which uses single-lined box-drawing-characters
		/// </summary>
		/// <returns></returns>
		public static LineStyle SingleLinesSet => new LineStyle
												{
													TopLeftCorner = '\u250C' , // ┌
													TopRightCorner = '\u2510' , // ┐
													BottomLeftCorner = '\u2514' , // └
													BottomRightCorner = '\u2518' , // ┘
													VerticalEdge = '\u2502' , // │
													HorizontalEdge = '\u2500' , // ─
													ConnectionHorizontalUp = '\u2534' , // ┴
													ConnectionHorizontalDown = '\u252C' , // ┬
													ConnectionVerticalRight = '\u251C' , // ├
													ConnectionVerticalLeft = '\u2524' , // ┤
													ConnectionCross = '\u253C' , // ┼
													EmptyChar = ' '
												} ;

		/// <summary>
		///     A <code>LineStyle</code> which uses double-lined box-drawing-characters
		/// </summary>
		public static LineStyle DoubleLinesSet => new LineStyle
												{
													TopLeftCorner = '\u2554' , // ╔
													TopRightCorner = '\u2557' , // ╗
													BottomLeftCorner = '\u255A' , // ╚
													BottomRightCorner = '\u255D' , // ╝
													VerticalEdge = '\u2551' , // ║
													HorizontalEdge = '\u2550' , // ═
													ConnectionHorizontalUp = '\u2569' , // ╩
													ConnectionHorizontalDown = '\u2566' , // ╦
													ConnectionVerticalRight = '\u2560' , // ╠
													ConnectionVerticalLeft = '\u2563' , // ╣
													ConnectionCross = '\u256C' , // ╬
													EmptyChar = ' '
												} ;

	}

}
