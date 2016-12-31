using System;
using System . Collections . Generic;
using System . Linq;
using System . Runtime . InteropServices ;
using System . Text;
using System . Threading . Tasks;

using Windows . Security . Cryptography ;
using Windows . Security . Cryptography . Core ;
using Windows . Storage . Streams ;

using WenceyWang . Richman4L . Security ;

namespace WenceyWang . Richman4L . Apps . Uni . Logic
{
	public class UniReliableValue<T>:ReliableValue <T>
	{

		// ReSharper disable once StaticMemberInGenericType
		private static readonly HashAlgorithmProvider HashProvider;

		private readonly CryptographicHash _hash;

		private IBuffer _hashCode;

		private IBuffer _salt;

		private IBuffer _saltHashCode;

		private T _value;

		public UniReliableValue ( ) { _hash = HashProvider . CreateHash ( ); }

		static UniReliableValue ( )
		{
			HashProvider = HashAlgorithmProvider . OpenAlgorithm ( HashAlgorithmNames . Sha512 );
		}

		public override T Value
		{
			get
			{
				lock ( this )
				{
					CheckValue ( );
					return _value;
				}
			}
			set
			{
				lock ( this )
				{
					CheckValue ( );

					_salt = CryptographicBuffer . GenerateRandom ( ( CryptographicBuffer . GenerateRandomNumber ( ) % 64 ) + 64 );

					_hash . Append ( _salt );

					_saltHashCode = _hash . GetValueAndReset ( );

					_value = value;

					_hash . Append ( ToIBuffer ( value ) );
					_hash . Append ( _salt );

					_hashCode = _hash . GetValueAndReset ( );
				}
			}
		}

		private IBuffer ToIBuffer ( T value )
		{
			lock ( value )
			{
				int rawsize = Marshal . SizeOf ( value );
				byte [ ] rawdata = new byte [ rawsize ];
				GCHandle handle = GCHandle . Alloc ( rawdata , GCHandleType . Pinned );
				Marshal . StructureToPtr ( value , handle . AddrOfPinnedObject ( ) , false );
				handle . Free ( );
				return CryptographicBuffer . CreateFromByteArray ( rawdata );
			}
		}

		private void CheckValue ( )
		{
			lock ( this )
			{
				//验证盐
				_hash . GetValueAndReset ( );

				byte [ ] currentSaltHashCode;
				_hash . Append ( _salt );
				CryptographicBuffer . CopyToByteArray ( _hash . GetValueAndReset ( ) , out currentSaltHashCode );

				byte [ ] savedSaltHashCode;
				CryptographicBuffer . CopyToByteArray ( _saltHashCode , out savedSaltHashCode );


				if ( !savedSaltHashCode . SequenceEqual ( currentSaltHashCode ) )
				{
					throw new ValueCheckFailedException ( savedSaltHashCode , currentSaltHashCode );
				}


				//验证值

				byte [ ] currentHashCode;
				_hash . Append ( ToIBuffer ( _value ) );
				_hash . Append ( _salt );
				CryptographicBuffer . CopyToByteArray ( _saltHashCode , out currentHashCode );

				byte [ ] savedHashCode;
				CryptographicBuffer . CopyToByteArray ( _hashCode , out savedHashCode );

				if ( !savedHashCode . SequenceEqual ( currentHashCode ) )
				{

					throw new ValueCheckFailedException ( currentHashCode , savedHashCode );
				}
			}
		}

		public static implicit operator UniReliableValue<T>( T value )
		{
			return new UniReliableValue<T> { Value = value };
		}

		public static implicit operator T ( UniReliableValue<T> value ) { return value . Value; }

	}

}
