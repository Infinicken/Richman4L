using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;

using Windows . Security . Cryptography ;
using Windows . Security . Cryptography . Core ;
using Windows . Storage . Streams ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{

	public class UniReliableValue <T> : ReliableValue <T>
	{

		private readonly CryptographicHash _hash ;

		private IBuffer _hashCode ;

		private IBuffer _salt ;

		private IBuffer _saltHashCode ;

		private T _value ;

		public override T Value
		{
			get
			{
				lock ( this )
				{
					CheckValue ( ) ;
					return _value ;
				}
			}
			set
			{
				lock ( this )
				{
					CheckValue ( ) ;
					SetValue ( value ) ;
				}
			}
		}

		static UniReliableValue ( ) { HashProvider = HashAlgorithmProvider . OpenAlgorithm ( HashAlgorithmNames . Sha512 ) ; }

		public UniReliableValue ( T value )
		{
			_hash = HashProvider . CreateHash ( ) ;
			SetValue ( value ) ;
		}

		// The hash provider will not change because the type of T
		// ReSharper disable once StaticMemberInGenericType
		private static readonly HashAlgorithmProvider HashProvider ;

		private void SetValue ( T value )
		{
			lock ( this )
			{
				_salt = CryptographicBuffer . GenerateRandom ( CryptographicBuffer . GenerateRandomNumber ( ) % 64 + 64 ) ;

				_hash . Append ( _salt ) ;

				_saltHashCode = _hash . GetValueAndReset ( ) ;

				_value = value ;

				_hash . Append ( ToIBuffer ( value ) ) ;
				_hash . Append ( _salt ) ;

				_hashCode = _hash . GetValueAndReset ( ) ;
			}
		}

		private IBuffer ToIBuffer ( T value )
		{
			lock ( value )
			{
				int rawsize = Marshal . SizeOf ( value ) ;
				byte [ ] rawdata = new byte[ rawsize ] ;
				GCHandle handle = GCHandle . Alloc ( rawdata , GCHandleType . Pinned ) ;
				Marshal . StructureToPtr ( value , handle . AddrOfPinnedObject ( ) , false ) ;
				handle . Free ( ) ;
				return CryptographicBuffer . CreateFromByteArray ( rawdata ) ;
			}
		}

		private void CheckValue ( )
		{
			lock ( this )
			{
				//验证盐
				_hash . GetValueAndReset ( ) ;

				_hash . Append ( _salt ) ;
				IBuffer saltHashCode = _hash . GetValueAndReset ( ) ;

				byte [ ] currentSaltHashCode ;
				CryptographicBuffer . CopyToByteArray ( saltHashCode , out currentSaltHashCode ) ;
				currentSaltHashCode = currentSaltHashCode ?? new byte [ ] { } ;


				byte [ ] savedSaltHashCode ;
				CryptographicBuffer . CopyToByteArray ( _saltHashCode , out savedSaltHashCode ) ;
				savedSaltHashCode = savedSaltHashCode ?? new byte [ ] { } ;


				if ( ! savedSaltHashCode . SequenceEqual ( currentSaltHashCode ) )
				{
					throw new ValueCheckFailedException ( savedSaltHashCode , currentSaltHashCode ) ;
				}


				//验证值
				_hash . Append ( ToIBuffer ( _value ) ) ;
				_hash . Append ( _salt ) ;
				IBuffer hashCode = _hash . GetValueAndReset ( ) ;

				byte [ ] currentHashCode ;
				CryptographicBuffer . CopyToByteArray ( hashCode , out currentHashCode ) ;
				currentHashCode = currentHashCode ?? new byte [ ] { } ;

				byte [ ] savedHashCode ;
				CryptographicBuffer . CopyToByteArray ( _hashCode , out savedHashCode ) ;
				savedHashCode = savedHashCode ?? new byte [ ] { } ;

				if ( ! savedHashCode . SequenceEqual ( currentHashCode ) )
				{
					throw new ValueCheckFailedException ( currentHashCode , savedHashCode ) ;
				}
			}
		}

		public static implicit operator UniReliableValue <T> ( T value ) { return new UniReliableValue <T> ( value ) ; }

		public static implicit operator T ( UniReliableValue <T> value ) { return value . Value ; }

	}

}
