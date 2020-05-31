﻿using System;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
//using System.Threading.Tasks;
/* https://id3.org/Developer%20Information*/
namespace MusicLibraryMerge
{
	class ID3Class
	{

		//add a frame

		//name as string convert to bytes
		//length as int32 convert to bytes
		//flags as bool convert to bytes
		//if text and unicode set unicode flag
		//content as string convert to bytes
		//OR
		//content as bytes convert to string

		private List<ID3Frame> _lcllistframes;
		private ID3Header _id3h;
		private ID3ExtendedHeader _id3exh;
		private System.IO.FileInfo _lclfileinfo;
		private System.String _lclfilename;
		private System.IO.BinaryReader _lclbr;
		private System.IO.FileStream _lclfsr;
		private System.IO.FileStream _lclfsw;
		private System.IO.BinaryWriter _lclbw;
		private System.String _encodingname = "ISO-8859-1";
		//private System.String backupext = ".bkp";
		private System.String tempext = ".tmp";

		public ID3Class()
		{
			initvariables();
		}
		public ID3Class(string thisfile)
		{
			OpenFile(thisfile);
			initvariables();
		}
		private void initvariables()
		{
			_lcllistframes = new List<ID3Frame>();
		}
		public void OpenFile(string thisfile)
		{
			if (!String.IsNullOrEmpty(thisfile) && !String.IsNullOrWhiteSpace(thisfile))
			{
				_lclfilename = thisfile;
				_lclfileinfo = new System.IO.FileInfo(thisfile);
				if (_lclfileinfo != null)
				{
					_lclfsr = _lclfileinfo.Open(System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
					_lclbr = new System.IO.BinaryReader(_lclfsr);
				}
			}
			return;
		}

		public void CloseFile()
		{
			if (_lclbr != null)
			{
				_lclbr.Close();
				_lclbr.Dispose();
			}
			if (_lclbw != null)
			{
				_lclbw.Flush();
				_lclbw.Close();
				_lclbw.Dispose();
			}
			if (_lclfsr != null)
			{
				_lclfsr.Close();
				_lclfsr.Dispose();
			}
			_lclfileinfo = null;
			_lcllistframes = null;
			return;
		}
		public string EncodingName
		{
			get { return _encodingname; }
		}
		public List<ID3Frame> FrameList
		{
			get { return _lcllistframes; }
		}
		public ID3Frame FindFirstFrame(string lcltag)
		{
			ID3Frame newframe = null;
			foreach (ID3Frame thisframe in _lcllistframes)
			{
				if (thisframe.Name.Equals(lcltag))
				{
					newframe = thisframe;
					break;
				}
			}
			return newframe;
		}
		private Int32 BigEndByteArrayToInt(byte[] thesebytes)
		{
			return BigEndByteArrayToInt(thesebytes, 0, thesebytes.GetUpperBound(0));
		}
		private Int32 BigEndByteArrayToInt(byte[] thesebytes, int startbyte, int bounds)
		{
			Int32 thisint = 0;

			if (bounds > thesebytes.GetUpperBound(0))
			{
				bounds = thesebytes.GetUpperBound(0);
			}
			for (int ii = startbyte; ii <= bounds; ii++)
			{
				thisint = (thisint << 8);
				thisint += thesebytes[ii];
			}
			return thisint;
		}
		private byte[] BigEndIntToByteArray(int thisint)
		{
			return BigEndIntToByteArray(thisint, 0, 3);
		}
		private byte[] BigEndIntToByteArray(int thisint, int startbyte, int lastbyte)
		{
			byte[] retbytes = new byte[lastbyte + 1];
			for (int ii = lastbyte; ii >= startbyte; ii--)
			{
				retbytes[ii] = (byte)(thisint & 0xff);
				thisint >>= 8;
			}
			return retbytes;
		}
		public bool IsBitSet(int thisint, int whichbit)
		{
			bool isset = false;
			if ((thisint & (0x01 << whichbit)) != 0x0) { isset = true; }
			return isset;
		}
		public int SetBit(int thisint, int whichbit, int retsize = 1)
		{
			int retvalue = 0;
			switch (retsize)
			{
				case (4):
					{
						retvalue = ((int)thisint ^ (0x1 << whichbit) & 0xffff);
						break;
					}
				case (3):
					{
						retvalue = ((int)thisint ^ (0x1 << whichbit) & 0xfff);
						break;
					}
				case (2):
					{
						retvalue = ((int)thisint ^ (0x1 << whichbit) & 0xff);
						break;
					}
				case (1):
					{
						retvalue = ((int)thisint ^ (0x1 << whichbit) & 0xf);
						break;
					}
			}
			return retvalue;
		}

		public void ReadMetaData()
		{
			char[] lclchar;
			Int32 extheaderlength = 0;
			byte[] lclbyte;
			ID3Frame id3f;
			_id3h = new ID3Header(this);

			if (_lclfileinfo != null)
			{
				lclchar = new char[3];                   // 3 bytes of 'ID3'
				lclchar = _lclbr.ReadChars(3);
				_id3h.ID = lclchar;
				lclbyte = new byte[2];
				lclbyte = _lclbr.ReadBytes(2);
				_id3h.Version = lclbyte;         // 2 byte version - 1 revision 1 minor
				if (_id3h.Version[0] < 4)
				{
					lclbyte = new byte[1];
					lclbyte[0] = _lclbr.ReadByte();         // 1 byte flags
					_id3h.CheckHeaderFlags(lclbyte);
					lclbyte = new byte[4];
					lclbyte = _lclbr.ReadBytes(4);           // 4 byte size
					_id3h.Length = _id3h.Get4ByteLength(lclbyte); //headerlength + headersize of 10 bytes since start at 0 offset
					if (_id3h.ExtendedHeaderFlag)
					{
						//get extended header
						_id3exh = new ID3ExtendedHeader(this);
						lclbyte = new byte[2];
						lclbyte = _lclbr.ReadBytes(2);
						_id3exh.CheckExtendedHeaderFlags(lclbyte);
						lclbyte = new byte[4];
						lclbyte = _lclbr.ReadBytes(4);
						extheaderlength = _id3h.Get4ByteLength(lclbyte);
						if (_id3exh.FlagCRC)
						{
							lclbyte = new byte[4];
							lclbyte = _lclbr.ReadBytes(4);
							_id3exh.CRC = lclbyte;
						}
					}
					_lclbr.BaseStream.Seek(_id3h.HeaderSize, System.IO.SeekOrigin.Begin);
					while (_lclbr.BaseStream.Position < _id3h.StartOfAudio)  //stream position must be < offset of headerlength
					{
						lclbyte = new byte[4];         //4 byte (char) tagname
						lclbyte = _lclbr.ReadBytes(4);  //read 4 chars

						id3f = new ID3Frame(this);//set up new frames
						id3f.NameBytes = lclbyte;
						if (id3f.ValidTag)
						{
							lclbyte = _lclbr.ReadBytes(4); //read 4 bytes of size
							id3f.Length = BigEndByteArrayToInt(lclbyte);// file is big endian
							lclbyte = new byte[2];
							lclbyte = _lclbr.ReadBytes(2);     //2  bytes of flags
							id3f.CheckFrameFlags(lclbyte);

							if (id3f.IsText)
							{
								//if first char is 0x01 then it should be Unicode
								lclbyte = new byte[1];
								lclbyte[0] = _lclbr.ReadByte();//if the first byte read is $01 then it's unicode!
								id3f.UnicodeFlag = (lclbyte[0] == 1);
								if (id3f.UnicodeFlag)
								{
									lclbyte = new byte[2];
									lclbyte = _lclbr.ReadBytes(2);
									id3f.UnicodeBOM = lclbyte;
									lclbyte = new byte[id3f.Length - 3];
								}
								else
								{
									lclbyte = new byte[id3f.Length - 1];
								}
								lclbyte = _lclbr.ReadBytes(lclbyte.Length);// read the frame content
								id3f.ContentBytes = lclbyte;
							}
							else
							{
								//lclbyte = new byte[id3f.Length];//if the first byte read is $01 then it's unicode!
								lclbyte = _lclbr.ReadBytes(id3f.Length);// read the frame content
								id3f.ContentBytes = lclbyte;
							}
							if ((id3f.Length > 0) && (id3f.ValidTag))
							{
								_lcllistframes.Add(id3f);
							}
						}
						else
						{
							id3f = null;
						}
					}
				}
			}
			return;
		}
		public long TotalFramesLength()
		{
			int allframeslength = 0;
			foreach (ID3Frame lclframe in _lcllistframes)
			{
				allframeslength += lclframe.Length;
			}
			return allframeslength;
		}
		public byte[] Audio()
		{
			_lclbr.BaseStream.Seek(_id3h.StartOfAudio, System.IO.SeekOrigin.Begin);
			byte[] lclbytes = new byte[(_lclbr.BaseStream.Length - _id3h.StartOfAudio)];
			lclbytes = _lclbr.ReadBytes((int)(_lclbr.BaseStream.Length - _id3h.StartOfAudio));
			return lclbytes;
		}
		public void WriteMetaData(string newfile = "")
		{
			if (_lclfileinfo != null)
			{
				//open writefile
				//string destfilename = _lclfileinfo.FullName;
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				string writefilename  = System.String.Empty;
				if (!System.String.IsNullOrEmpty(newfile))
				{
					writefilename = newfile;
				}
				else
				{
					writefilename = _lclfilename + tempext;
				}
				if(!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(writefilename)))
				{
					System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(writefilename));
				}
				if (System.IO.File.Exists(writefilename))
				{
					System.IO.File.Delete(writefilename);
				}
				System.IO.FileInfo writefileinfo = new System.IO.FileInfo(writefilename);
				if (writefileinfo == null)
				{
					return;
				}
				_lclfsw = writefileinfo.Create();
				//_lclfsw = writefileinfo.Open(System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
				_lclbw = new System.IO.BinaryWriter(_lclfsw);

				//write header
				_lclbw.Write(_id3h.ID, 0, _id3h.ID.Length);
				_lclbw.Write(_id3h.Version, 0, _id3h.Version.Length);
				_lclbw.Write(_id3h.FlagBytes, 0, _id3h.FlagBytes.Length);
				_lclbw.Write(_id3h.Set4ByteLength(_id3h.Length), 0, 4);
				if (_id3h.ExtendedHeaderFlag)
				{
					//write extended header if present
				}
				//write each frame
				foreach (ID3Frame lclframe in _lcllistframes)
				{
					_lclbw.Write(lclframe.NameBytes, 0, lclframe.NameBytes.Length);
					_lclbw.Write(BigEndIntToByteArray(lclframe.Length), 0, 4);
					_lclbw.Write(lclframe.Flags, 0, lclframe.Flags.Length);
					if (lclframe.IsText)
					{
						_lclbw.Write(lclframe.UnicodeFlag);
						if (lclframe.UnicodeFlag)
						{
							_lclbw.Write(lclframe.UnicodeBOM);
						}
					}
					_lclbw.Write(lclframe.ContentBytes, 0, lclframe.ContentBytes.Length);
				}
				//write padding
				//write audio
				_lclbw.BaseStream.Seek(_id3h.StartOfAudio, System.IO.SeekOrigin.Begin);
				_lclbw.Write(Audio(), 0, Audio().Length);
				//close readfile
				//CloseFile();

				//_lclfileinfo = writefileinfo.Replace(_lclfilename, sb.ToString(), false);
				//close writefile
				_lclbw.Close();
				_lclbw.Dispose();
				_lclbw = null;
				_lclfsw.Close();
				_lclfsw.Dispose();
				_lclfsw = null;

				//rename readfile for backup then rename writefile to readfile
				//sb.Clear();
				//sb.Append(System.IO.Path.GetDirectoryName(_lclfilename) + System.IO.Path.DirectorySeparatorChar);
				//sb.Append(System.IO.Path.GetFileNameWithoutExtension(_lclfilename));
				//sb.Append(backupext);
				//sb.Append(System.IO.Path.GetExtension(_lclfilename));


				//leave open readfile
			}

			return;
		}
		~ID3Class()
		{
			CloseFile();
			//if(id3h!=null){ id3h = null; }
			//if(id3exh!=null){ id3exh = null; }
			_id3h = null;
			_id3exh = null;
			return;
		}

	}
}
