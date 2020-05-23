using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
/* https://id3.org/Developer%20Information*/
namespace MusicLibraryMerge
{
	class ID3Frame
	{
		bool _flaga;
		bool _flagb;
		bool _flagc;
		bool _flagi;
		bool _flagj;
		bool _flagk;
		byte[] _flags;
		bool _textflag;
		bool _v24flag;
		bool _v23flag;
		bool _unicodeflag;
		bool _validtagflag;
		bool _standardtagflag;
		string _strcontent;
		char[] _charcontent;
		byte[] _bytecontent;
		string _name;
		byte[] _namebytes;
		Int32 _length;
		ID3Class _parent;

		public ID3Frame(ID3Class lclparent)
		{
			_parent = lclparent;
		}
		public ID3Frame()
		{
			return;
		}
		public ID3Class Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}
		~ID3Frame()
		{
			_parent = null;
			return;
		}
		public bool FlagA
		{
			get { return _flaga; }
			set { _flaga = value; }
		}
		public bool FlagB
		{
			get { return _flagb; }
			set { _flagb = value; }
		}
		public bool FlagC
		{
			get { return _flagc; }
			set { _flagc = value; }
		}
		public bool FlagI
		{
			get { return _flagi; }
			set { _flagi = value; }
		}
		public bool FlagJ
		{
			get { return _flagj; }
			set { _flagj = value; }
		}
		public bool FlagK
		{
			get { return _flagk; }
			set { _flagk = value; }
		}
		public bool IsText
		{
			get { return _textflag; }
		}
		public bool V23Tag
		{
			get { return _v23flag; }
		}
		public bool V24Tag
		{
			get { return _v24flag; }
		}
		public byte[] Flags
		{
			get { return (byte[])_flags.Clone(); }
			set { _flags = (byte[])value.Clone(); }
		}
		private void CheckTagFlag(string framename)
		{
			_textflag = false;
			ID3Tag id3t = new ID3Tag();
			_textflag = id3t.IsTextTag(framename);
			_v23flag = false;
			_v23flag = id3t.IsV23Tag(framename);
			_v24flag = false;
			_v24flag = id3t.IsV24Tag(framename);
			_standardtagflag = (_v23flag | _v24flag);
			_validtagflag = false;
			if (Char.IsLetterOrDigit(_name[0]) &&
			Char.IsLetterOrDigit(_name[1]) &&
			Char.IsLetterOrDigit(_name[2]) &&
			Char.IsLetterOrDigit(_name[3]))
			{
				_validtagflag = true;
			}
			id3t = null;
		}
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				CheckTagFlag(_name);
			}
		}
		public byte[] NameBytes
		{
			get { return (byte[])_namebytes.Clone(); }
			set
			{
				_namebytes = (byte[])value.Clone();
				_name = System.Text.Encoding.GetEncoding(((ID3Class)_parent).EncodingName).GetString(_namebytes);
				CheckTagFlag(_name);
			}
		}

		public int Length
		{
			get { return _length; }
			set { _length = value; }
		}

		public string ContentString
		{
			get { return _strcontent; }
			set { _strcontent = value; }
		}
		public char[] ContentChars
		{
			get { return (char[])_charcontent.Clone(); }
			set { _charcontent = (char[])value.Clone(); }
		}
		public byte[] ContentBytes
		{
			get { return (byte[])_bytecontent.Clone(); }
			set { _bytecontent = (byte[])value.Clone(); }
		}
		public bool UnicodeFlag
		{
			get { return _unicodeflag; }
			set { _unicodeflag = value; }
		}
		public bool ValidTag
		{
			get { return _validtagflag; }
		}
		public bool StandardTag
		{
			get { return _standardtagflag; }
		}
		/*
		Frames that allow different types of text
		encoding have a text encoding description byte directly after the
		frame size. If ISO-8859-1 is used this byte should be $00, if Unicode
		is used it should be $01.
		*/
		public long GetLongValue()
		{
			return System.Convert.ToInt64(_strcontent);
		}
		public double GetDoubleValue()
		{
			return System.Convert.ToDouble(_strcontent);
		}
		public void CheckFrameFlags(byte[] theseflags)
		{
			_flaga = false;
			_flagb = false;
			_flagc = false;
			_flagi = false;
			_flagj = false;
			_flagk = false;
			_flags = (byte[])theseflags.Clone();

			if (_parent.IsBitSet(theseflags[0], 7)) { _flaga = true; }
			if (_parent.IsBitSet(theseflags[0], 6)) { _flagb = true; }
			if (_parent.IsBitSet(theseflags[0], 5)) { _flagc = true; }
			if (_parent.IsBitSet(theseflags[1], 7)) { _flagi = true; }
			if (_parent.IsBitSet(theseflags[1], 6)) { _flagj = true; }
			if (_parent.IsBitSet(theseflags[1], 5)) { _flagk = true; }
			// % abc00000 % ijk00000
			//  a - Tag alter preservation
			//This flag tells the software what to do with this frame if it is
			//unknown and the tag is altered in any way. This applies to all
			//kinds of alterations, including adding more padding and reordering
			//the frames.
			//0     Frame should be preserved.
			//1     Frame should be discarded.
			//  b - File alter preservation
			//This flag tells the software what to do with this frame if it is
			//unknown and the file, excluding the tag, is altered.This does not
			//   apply when the audio is completely replaced with other audio data.
			//0     Frame should be preserved.
			//1     Frame should be discarded.
			//  c - Read only
			// This flag, if set, tells the software that the contents of this
			// frame is intended to be read only.Changing the contents might
			// break something, e.g.a signature. If the contents are changed,
			//     without knowledge in why the frame was flagged read only and
			// without taking the proper means to compensate, e.g.recalculating
			// the signature, the bit should be cleared.
			//  i - Compression
			// This flag indicates whether or not the frame is compressed.
			// 0     Frame is not compressed.
			//     1     Frame is compressed using zlib[zlib] with 4 bytes for
			//	'decompressed size' appended to the frame header.
			// j - Encryption
			//This flag indicates wether or not the frame is enrypted.If set
			//one byte indicating with which method it was encrypted will be
			//appended to the frame header.See section 4.26. for more
			//   information about encryption method registration.
			//   0     Frame is not encrypted.
			//   1     Frame is encrypted.
			//k - Grouping identity
			//   This flag indicates whether or not this frame belongs in a group
			//   with other frames.If set a group identifier byte is added to the
			//   frame header.Every frame with the same group identifier belongs
			//   to the same group.
			//   0     Frame does not contain group information
			//   1     Frame contains group information
			return;
		}



	}
}
