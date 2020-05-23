using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*https://id3.org/Developer%20Information*/
namespace MusicLibraryMerge
{
	public enum TEXTTAGS
	{
		TYER = 0,
		TSSE,
		TSRC,
		TSIZ,
		TRSO,
		TRSN,
		TPOS,
		TPE4,
		TPE3,
		TPE2,
		TPE1,
		TOWN,
		TORY,
		TOPE,
		TMED,
/*
DIG     Other digital media
/A  Analog transfer from media
ANA     Other analog media
/WAC Wax cylinder
/8CA 8-track tape cassette
CD      CD
/A Analog transfer from media
/DD DDD
/AD ADD
/AA AAD
LD      Laserdisc
/A Analog transfer from media
TT      Turntable records
/33 33.33 rpm
/45 45 rpm
/71 71.29 rpm
/76 76.59 rpm
/78 78.26 rpm
/80 80 rpm
MD      MiniDisc
/A Analog transfer from media
DAT     DAT
/A Analog transfer from media
/1 standard, 48 kHz/16 bits, linear
/2 mode 2, 32 kHz/16 bits, linear
/3 mode 3, 32 kHz/12 bits, nonlinear, low speed
/4 mode 4, 32 kHz/12 bits, 4 channels
/5 mode 5, 44.1 kHz/16 bits, linear
/6 mode 6, 44.1 kHz/16 bits, 'wide track' play
DCC     DCC
/A Analog transfer from media
DVD     DVD
/A Analog transfer from media
TV      Television
/PAL PAL
/NTSC NTSC
/SECAM SECAM
VID     Video
/PAL PAL
/NTSC NTSC
/SECAM SECAM
/VHS VHS
/SVHS S-VHS
/BETA BETAMAX
RAD     Radio
/FM FM
/AM AM
/LW LW
/MW MW
TEL     Telephone
/I ISDN
MC      MC (normal cassette)
/4 4.75 cm/s (normal speed for a two sided cassette)
/9 9.5 cm/s
/I Type I cassette (ferric/normal)
/II Type II cassette (chrome)
/III Type III cassette (ferric chrome)
/IV Type IV cassette (metal)
REE     Reel
/9 9.5 cm/s
/19 19 cm/s
/38 38 cm/s
/76 76 cm/s
/I Type I cassette (ferric/normal)
/II Type II cassette (chrome)
/III Type III cassette (ferric chrome)
/IV Type IV cassette (metal)*/
		TLEN,
		TLAN,
		TFLT,
/*
MPG       MPEG Audio
/1        MPEG 1/2 layer I
/2        MPEG 1/2 layer II
/3        MPEG 1/2 layer III
/2.5      MPEG 2.5
/AAC     Advanced audio compression
VQF       Transform-domain Weighted Interleave Vector Quantization
PCM       Pulse Code Modulated audio
*/
		TEXT,
		TENC,
		TCON,
/*
References to the ID3v1 genres can be made by, as first byte,
enter "(" followed by a number from the genres list (appendix A)
and ended with a ")" character. 
This is optionally followed by a refinement,
e.g. "(21)" or "(4)Eurodisco". Several references can be made in the same frame,
e.g. "(51)(39)". 
If the refinement should begin with a "(" character it should be 
replaced with "((", e.g. "((I can figure out any genre)" or "(55)((I think...)". 
The following new content types is defined in ID3v2 and is implemented in the same way
as the numerig content types, e.g. "(RX)".
RX    Remix
CR    Cover
*/
		TCOM,
		TBPM,
		TALB,
		TXXX
/*
<Header for 'User defined text information frame', ID: "TXXX">
Text encoding    $xx
Description    <text string according to encoding> $00 (00)
Value    <text string according to encoding>
*/
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
		ID3Class _parent;
		string[] _texttags;
		string[] _id3v23_tags;
		string[] _id3v24_tags;
		string[] _urltags;
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
