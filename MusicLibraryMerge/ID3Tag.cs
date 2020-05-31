using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
/*https://id3.org/Developer%20Information*/
namespace MusicLibraryMerge
{
	public enum TEXTTAGS
	{
		TALB,
		TBPM,
		TCOM,
		TCON,
		TCOP,
		TDAT,
		TDLY,
		TENC,
		TEXT,
		TFLT,
		TIME,
		TIT1,
		TIT2,
		TIT3,
		TKEY,
		TLAN,
		TLEN,
		TMED,
		TOAL,
		TOFN,
		TOLY,
		TOPE,
		TORY,
		TOWN,
		TPE1,
		TPE2,
		TPE3,
		TPE4,
		TPOS,
		TPUB,
		TRCK,
		TRDA,
		TRSN,
		TRSO,
		TSIZ,
		TSRC,
		TSSE,
		TYER
	}

	public enum URLTAGS
	{
		WCOMWCOP = 0,
		WOAFWOAR,
		WOASWORS,
		WPAYWPUB
/*
With these frames dynamic data such as webpages with touring information, 
price information or plain ordinary news can be added to the tag. 
There may only be one URL link frame of its kind in an tag, 
except when stated otherwise in the frame description. 
If the textstring is followed by a termination ($00 (00)) 
all the following information should be ignored and not be displayed. 
All URL link frame identifiers begins with "W". Only URL link frame identifiers begins with "W". 
All URL link frames have the following format:
<Header for 'URL link frame', ID: "W000" - "WZZZ", excluding "WXXX" described in 4.3.2.>
URL <text string>
*/
	}
	public enum TAGNAMES3V23
	{
		AENC = 0,
		APIC,
		COMM,
		COMR,
		ENCR,
		EQUA,
		ETCO,
		GEOB,
		GRID,
		IPLS,
		LINK,
		MCDI,
		MLLT,
		OWNE,
		PCNT,
		POPM,
		POSS,
		PRIV,
		RBUF,
		RVAD,
		RVRB,
		SYLT,
		SYTC,
		TALB,
		TBPM,
		TCOM,
		TCON,
		TCOP,
		TDAT,
		TDLY,
		TENC,
		TEXT,
		TFLT,
		TIME,
		TIT1,
		TIT2,
		TIT3,
		TKEY,
		TLAN,
		TLEN,
		TMED,
		TOAL,
		TOFN,
		TOLY,
		TOPE,
		TORY,
		TOWN,
		TPE1,
		TPE2,
		TPE3,
		TPE4,
		TPOS,
		TPUB,
		TRCK,
		TRDA,
		TRSN,
		TRSO,
		TSIZ,
		TSRC,
		TSSE,
		TXXX,
		TYER,
		UFID,
		USER,
		USLT,
		WCOM,
		WCOP,
		WOAF,
		WOAR,
		WOAS,
		WORS,
		WPAY,
		WPUB,
		WXXX
	}
	public enum TAGNAMES3V24
	{
		ASPI = 0,
		SEEK,
		SIGN,
		TDEN,
		TDRC,
		TDRL,
		TDTG,
		TMCL,
		TMOO,
		TPRO,
		TSOA,
		TSOP,
		TSOT,
		TSST,
		AENC,
		APIC,
		COMM,
		COMR,
		ENCR,
		EQU2,
		ETCO,
		GEOB,
		GRID,
		TIPL,
		LINK,
		MCDI,
		MLLT,
		OWNE,
		PCNT,
		POPM,
		POSS,
		PRIV,
		RBUF,
		RVA2,
		RVRB,
		SYLT,
		SYTC,
		TALB,
		TBPM,
		TCOM,
		TCON,
		TCOP,
		//  TDRC
		TDLY,
		TENC,
		TEXT,
		TFLT,
		TIME,
		TIT1,
		TIT2,
		TIT3,
		TKEY,
		TLAN,
		TLEN,
		TMED,
		TOAL,
		TOFN,
		TOLY,
		TOPE,
		TDOR,
		TOWN,
		TPE1,
		TPE2,
		TPE3,
		TPE4,
		TPOS,
		TPUB,
		TRCK,
		//  TRDC
		TRSN,
		TRSO,
		TSRC,
		TSSE,
		TXXX,
		//  TYER
		UFID,
		USER,
		USLT,
		WCOM,
		WCOP,
		WOAF,
		WOAR,
		WOAS,
		WORS,
		WPAY,
		WPUB,
		WXXX
	}

	class ID3Tag
	{
		private ID3Class _parent;
		private string[] _texttags;
		private string[] _id3v23_tags;
		private string[] _id3v24_tags;
		private string[] _urltags;
		public ID3Tag()
		{
			inittagarrays();
			return;
		}
		public ID3Tag(ID3Class lclparent)
		{
			_parent = lclparent;
			inittagarrays();
			return;
		}
		~ID3Tag()
		{
			return;
		}
		public ID3Class Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}
		private void inittagarrays()
		{
			_texttags = Enum.GetNames(typeof(TEXTTAGS));
			_id3v23_tags = Enum.GetNames(typeof(TAGNAMES3V23));
			_id3v24_tags = Enum.GetNames(typeof(TAGNAMES3V24));
			_urltags = Enum.GetNames(typeof(URLTAGS));
			return;
		}
		public bool IsTextTag(string tagname)
		{
			bool retvalue = false;
			foreach (string lcltag in _texttags)
			{
				if (lcltag.Equals(tagname))
				{
					retvalue = true;
					break;
				}
			}
			return retvalue;
		}
		public bool IsV24Tag(string tagname)
		{
			bool retvalue = false;
			foreach (string lcltag in _id3v24_tags)
			{
				if (lcltag.Equals(tagname))
				{
					retvalue = true;
					break;
				}
			}
			return retvalue;
		}
		public bool IsV23Tag(string tagname)
		{
			bool retvalue = false;
			foreach (string lcltag in _id3v23_tags)
			{
				if (lcltag.Equals(tagname))
				{
					retvalue = true;
					break;
				}
			}
			return retvalue;
		}

	}
}
