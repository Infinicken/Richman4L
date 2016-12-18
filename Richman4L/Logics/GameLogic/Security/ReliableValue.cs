//using System ;
//using System . Collections ;
//using System . Collections . Generic ;
//using System . Linq ;
//using System . Runtime . InteropServices ;

//using PCLCrypto ;

//namespace WenceyWang . Richman4L .Security
//{

//	public sealed class ReliableValue <T>
//	{

//		private readonly IHashAlgorithmProvider _hashprovider =
//			WinRTCrypto . HashAlgorithmProvider . OpenAlgorithm ( HashAlgorithm . Sha512 ) ;

//		private readonly Random _ran = new Random ( ) ;

//		private byte [ ] _hashCode ;

//		private byte [ ] _salt ;

//		private byte [ ] _saltHashCode ;

//		private T _value ;

//		public T Value
//		{
//			get
//			{
//				CheckValue ( ) ;
//				return _value ;
//			}
//			set
//			{
//				_salt = new byte[ _ran . Next ( 5 , 10 ) ] ;

//				NetFxCrypto . RandomNumberGenerator . GetBytes ( _salt ) ;

//				_saltHashCode = _hashprovider . HashData ( _salt ) ;

//				_value = value ;

//				byte [ ] valueByteArray = ToByteArray ( _value ) ;

//				List <byte> saltedValue = new List <byte> ( ) ;

//				saltedValue . AddRange ( valueByteArray ) ;
//				saltedValue . AddRange ( _salt ) ;

//				_hashCode = _hashprovider . HashData ( saltedValue . ToArray ( ) ) ;
//			}
//		}

//		private byte [ ] ToByteArray ( object value )
//		{
//			int rawsize = Marshal . SizeOf ( value ) ;
//			byte [ ] rawdata = new byte[ rawsize ] ;
//			GCHandle handle = GCHandle . Alloc ( rawdata , GCHandleType . Pinned ) ;
//			Marshal . StructureToPtr ( value , handle . AddrOfPinnedObject ( ) , false ) ;
//			handle . Free ( ) ;
//			return rawdata ;
//		}

//		private void CheckValue ( )
//		{
//			//验证盐
//			if ( ! _hashprovider . HashData ( _salt ) . SequenceEqual ( _saltHashCode ) )
//			{
//				throw new ValueCheckFailedException ( _saltHashCode , _salt ) ;
//			}


//			//验证值
//			byte [ ] valueByteArray = ToByteArray ( _value ) ;

//			List <byte> saltedValue = new List <byte> ( ) ;

//			saltedValue . AddRange ( valueByteArray ) ;
//			saltedValue . AddRange ( _salt ) ;

//			if ( ! _hashprovider . HashData ( _salt ) . SequenceEqual ( _hashCode ) )
//			{
//				throw new ValueCheckFailedException ( _saltHashCode , valueByteArray ) ;
//			}
//		}

//		public static implicit operator ReliableValue <T> ( T value )
//		{
//			ReliableValue <T> temp = new ReliableValue <T> { Value = value } ;
//			return temp ;
//		}

//		public static implicit operator T ( ReliableValue <T> value ) { return value . Value ; }

//	}

//}

using System ;
using System . Collections ;
using System . Linq ;
