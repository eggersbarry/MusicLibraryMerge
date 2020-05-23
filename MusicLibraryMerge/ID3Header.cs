using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* https://id3.org/Developer%20Information*/
namespace MusicLibraryMerge
{
	class ID3Header
	{
		private char[] _id;
		private byte[] _version;
		private int _length;
		private int _startofaudio;
		private bool _unsynchflag;
		private bool _experimentalflag;
		private bool _extendedheaderflag;
		private int _headersize = 10;
		private byte[] _flags;
		private ID3Class _parent;
		private ID3ExtendedHeader _extendedheader;

		public ID3Header(ID3Class lclparent)
		{
			_parent = lclparent;
		}
		public ID3Header()
		{

		}
		~ID3Header()
		{
			_parent = null;
			_extendedheader = null;
			return;
		}
		public int HeaderSize
		{
			get { return _headersize; }
			set { _headersize = value; }
		}
		public ID3Class Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}
		public char[] ID
		{
			get { return (char[])_id.Clone(); }
			set { _id = (char[])value.Clone(); }
		}
		public byte[] Version
		{
			get { return (byte[])_version.Clone(); }
			set { _version = (byte[])value.Clone(); }
		}
		public int Length
		{
			get { return _length; }
			set
			{
				_length = value;
				_startofaudio = _length + _headersize;
			}
		}
		public int StartOfAudio
		{
			get { return _startofaudio; }
		}
		public byte[] FlagBytes
		{
			get { return (byte[])_flags.Clone(); }
			set { _flags = (byte[])value.Clone(); }
		}
		public bool UnSynchFlag
		{
			get { return _unsynchflag; }
			set { _unsynchflag = value; }
		}
		public bool ExperimentalFlag
		{
			get { return _experimentalflag; }
			set { _experimentalflag = value; }
		}
		public bool ExtendedHeaderFlag
		{
			get { return _extendedheaderflag; }
			set { _extendedheaderflag = value; }
		}
		public ID3ExtendedHeader ExtendedHeader
		{
			get { return _extendedheader; }
			set { _extendedheader = value; }
		}
		public void CheckHeaderFlags(byte[] headerflags)
		{
			_unsynchflag = false;
			_experimentalflag = false;
			_extendedheaderflag = false;
			_flags = (byte[])headerflags.Clone();
			if (_parent.IsBitSet(_flags[0], 7))
			{
				_unsynchflag = true;
				//a - Unsynchronisation
				//	Bit 7 in the 'ID3v2 flags' indicates whether or not	unsynchronisation is used(see section 5 for details) ; 
				//	a set bit indicates usage.
			}
			if (_parent.IsBitSet(_flags[0], 6))
			{
				_extendedheaderflag = true;
				//b - Extended header
				//	The second bit(bit 6) indicates whether or not the header is followed by an extended header.

			}
			if (_parent.IsBitSet(_flags[0], 5))
			{
				_experimentalflag = true;
				//c - Experimental indicator
				//	The third bit(bit 5) should be used as an 'experimental indicator'. 
				//	This flag should always be set when the tag is in an experimental stage.
			}

		}
		public Int32 Get4ByteLength(byte[] thesebytes)
		{
			Int32 headerlength = 0;
			Int32 tempint32 = 0;
			for (int ii = 0, jj = thesebytes.GetUpperBound(0); ii <= thesebytes.GetUpperBound(0); jj--, ii++)
			{
				tempint32 = thesebytes[ii];
				tempint32 = tempint32 << (7 * jj);
				headerlength += tempint32;
			}
			return headerlength;
		}
		public byte[] Set4ByteLength(Int32 thislength)
		{
			byte[] retbytes = new byte[4];
			for (int ii = retbytes.GetUpperBound(0); ii >= 0; ii--)
			{
				retbytes[ii] = (byte)(thislength & 0x7f);
				thislength >>= 7;
			}
			return retbytes;
		}


	}
}
