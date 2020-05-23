using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibraryMerge
{
	class ID3ExtendedHeader
	{
		int _length;
		int _padding;
		bool _flagcrc;
		byte[] _flags;
		byte[] _crc;
		ID3Class _parent;
		public ID3ExtendedHeader()
		{

		}
		public ID3ExtendedHeader(ID3Class lclparent)
		{
			_parent = lclparent;
		}
		~ID3ExtendedHeader()
		{

		}
		public bool FlagCRC
		{
			get { return _flagcrc; }
			set { _flagcrc = value; }
		}
		public byte[] Flags
		{
			get { return (byte[])_flags.Clone(); }
			set { _flags = (byte[])value.Clone(); }
		}
		public byte[] CRC
		{
			get { return (byte[])_crc.Clone(); }
			set { _crc = (byte[])value.Clone(); }
		}
		public int Length
		{
			get { return _length; }
			set { _length = value; }
		}
		public int Padding
		{
			get { return _padding; }
			set { _padding = value; }
		}
		public void CheckExtendedHeaderFlags(byte[] headerflags)
		{
			_flagcrc = false;
			_flags = (byte[])headerflags.Clone();
			if (_parent.IsBitSet(headerflags[0], 7))
			{
				_flagcrc = true;
				//a - CRC appended
				//Bit 7 in the flags[0] byte indicates whether or not a CRC is appended at the end of the
				//extended header
			}
		}

	}
}
