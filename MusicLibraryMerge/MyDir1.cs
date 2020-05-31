using System;
using System.Collections.Generic;
using System.IO;
//using System.Diagnostics.SymbolStore;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Threading.Tasks;

namespace MusicLibraryMerge
{
	class MyDir1
	{
		private string _mp3extension = ".MP3";
				   public string  MP3Extension
				   {
				   get { return _mp3extension; }
				   }
		public MyDir1()
		{
			return;
		}

		public string TrimFileName(string fname, string mask1)
		{
			string ext = System.IO.Path.GetExtension(fname);
			string filefullpath = System.IO.Path.GetFullPath(fname);
			string filepath = System.IO.Path.GetPathRoot(fname);
			string fulldirname = System.IO.Path.GetDirectoryName(fname);
			string retval = System.String.Empty;
			string newfile0 = string.Empty;
			string thisfile = System.IO.Path.GetFileNameWithoutExtension(fname);
			if (string.IsNullOrEmpty(mask1))
			{
				newfile0 = thisfile.Trim();
			}
			else
			{
				newfile0 = thisfile.Trim(mask1.ToCharArray());
			}
			string thisnewfile = fulldirname + System.IO.Path.DirectorySeparatorChar + newfile0 + ext;

			if (!System.IO.File.Exists(thisnewfile))
			{
				System.IO.File.Move(fname, thisnewfile);
				retval = "Fixed " + thisnewfile;
			}
			else
			{
				System.IO.FileInfo fisource = new System.IO.FileInfo(fname);
				System.IO.FileInfo fidestination = new System.IO.FileInfo(thisnewfile);
				if (fisource.Length == fidestination.Length)
				{
					fisource.Delete();
					retval = "Deleted " + fname;
				}
				else
				{
					retval = "Not Fixed or Deleted " + fname;
				}
				fisource = null;
				fidestination = null;
			}
			return retval;
		}
		public List<string> GetAllFilesRecursive(string dirpath, string mask, string nomask)
		{
			List<string> sbb = new List<string>();
			int foundmatch = 0;
			string[] nochars = nomask.Split("\\".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
			if (!dirpath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
			{
				dirpath = dirpath + System.IO.Path.DirectorySeparatorChar.ToString();
			}
			string[] files = System.IO.Directory.GetFiles(dirpath, mask);
			foreach (string fname in files)
			{
				if (String.IsNullOrEmpty(nomask))
				{
					sbb.Add(fname);
				}
				else
				{
					foundmatch = 0;
					foreach (string thischar in nochars)
					{
						if (fname.IndexOf(thischar, StringComparison.OrdinalIgnoreCase) >= 0)
						{
							foundmatch += 1;
						}
					}
					if (foundmatch == 0)
					{
						sbb.Add(fname);
					}
				}
			}
			string[] dirs = System.IO.Directory.GetDirectories(dirpath);
			foreach (string dir in dirs)
			{
				sbb.AddRange(GetAllFilesRecursive(dir, mask, nomask));
			}
			return sbb;
		}
		public List<string> GetAllFolders(string thispath)
		{
			List<string> alldirs = new List<string>(System.IO.Directory.EnumerateDirectories(thispath, "*", System.IO.SearchOption.AllDirectories));
			return alldirs;
		}
		public string RemoveEmptyFolders(string thisfile)
		{
			string sbb = System.String.Empty;
			List<string> alldirs = new List<string>(System.IO.Directory.EnumerateDirectories(thisfile, "*", System.IO.SearchOption.TopDirectoryOnly));
			List<string> allfiles = null;
			if (alldirs.Count == 0)
			{
				allfiles = new List<string>(System.IO.Directory.GetFiles(thisfile, "*", System.IO.SearchOption.TopDirectoryOnly));
				if (allfiles.Count == 0)
				{
					System.IO.Directory.Delete(thisfile);
					sbb = "Deleted " + thisfile;
				}
			}
			return sbb;
		}
		public List<string> GetAllFiles(string thispath, string whichfiles, string nomask)
		{
			List<string> sbb = new List<string>();
			List<string> alldirs = new List<string>(System.IO.Directory.EnumerateDirectories(thispath, "*", System.IO.SearchOption.AllDirectories));
			string[] nochars = nomask.Split("\\".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
			int foundmatch = 0;
			alldirs.Add(thispath);
			foreach (string onedir in alldirs)
			{
				string[] files = System.IO.Directory.GetFiles(onedir, whichfiles);
				foreach (string fname in files)
				{
					if (String.IsNullOrEmpty(nomask))
					{
						sbb.Add(fname);
					}
					else
					{
						foundmatch = 0;
						foreach (string thischar in nochars)
						{
							if (fname.IndexOf(thischar, StringComparison.OrdinalIgnoreCase) >= 0)
							{
								foundmatch += 1;
							}
						}
						if (foundmatch == 0)
						{
							sbb.Add(fname);
						}
					}
				}
			}
			return sbb;
		}

		public string FixFileNameReplace(string fname, string mask1, string mask2)
		{
			string ext = System.IO.Path.GetExtension(fname);
			string filefullpath = System.IO.Path.GetFullPath(fname);
			string filepath = System.IO.Path.GetPathRoot(fname);
			string fulldirname = System.IO.Path.GetDirectoryName(fname);
			string retval = System.String.Empty;
			string thisfile = System.IO.Path.GetFileNameWithoutExtension(fname);
			//either this block
			//string lclmask = mask1.Replace("*", "");
			//Deleted
			//or these two lines
			string newfile0 = thisfile.Replace(mask1, mask2);
			string thisnewfile = fulldirname + System.IO.Path.DirectorySeparatorChar + newfile0.Trim() + ext;
			if (!thisnewfile.Equals(fname))
			{
				if (!System.IO.File.Exists(thisnewfile))
				{
					System.IO.File.Move(fname, thisnewfile);
					retval = "Fixed " + thisnewfile;
				}
				else
				{
					System.IO.FileInfo fisource = new System.IO.FileInfo(fname);
					System.IO.FileInfo fidestination = new System.IO.FileInfo(thisnewfile);
					if (fisource.Extension.ToUpper().Equals(".MP3"))
					{
						if (fisource.Length == fidestination.Length)
						{
							fisource.Delete();
							retval = "Deleted " + fname;
						}
						else
						{
							if (fisource.Length < fidestination.Length)
							{
								fisource.Delete();
								retval = "Deleted " + fname;
							}
							else
							{
								fidestination.Delete();
								System.IO.File.Move(fname, thisnewfile);
								retval = "Deleted " + thisnewfile;
							}
						}
					}
					else
					{
						if (fisource.Length == fidestination.Length)
						{
							fisource.Delete();
							retval = "Deleted " + fname;
						}
						else
						{
							if (fisource.Length > fidestination.Length)
							{
								fisource.Delete();
								retval = "Deleted " + fname;
							}
							else
							{
								fidestination.Delete();
								System.IO.File.Move(fname, thisnewfile);
								retval = "Deleted " + thisnewfile;
							}
						}
					}
					fisource = null;
					fidestination = null;
				}
			}
			else
			{
				retval = "Skipped " + fname;
			}
			return retval;
		}
		public string FixDiscFileName(string fname, string mask1)
		{
			string ext = System.IO.Path.GetExtension(fname);
			string filefullpath = System.IO.Path.GetFullPath(fname);
			string filepath = System.IO.Path.GetPathRoot(fname);
			string fulldirname = System.IO.Path.GetDirectoryName(fname);
			string retval = System.String.Empty;
			string thisfile = System.IO.Path.GetFileNameWithoutExtension(fname);
			// this block
			string lclmask = mask1.Replace("*", "");
			string newfile1 = thisfile.Substring(thisfile.ToLower().IndexOf(lclmask.ToLower()));
			string newfile2 = newfile1.Substring(newfile1.IndexOf(")") + 1);
			string newfile3 = newfile2.Replace("_", " ");
			string newfile4 = newfile3.Substring(0, newfile3.IndexOf("-")) + newfile3.Substring(newfile3.IndexOf("- ") + 1);
			string newfile6 = fulldirname + System.IO.Path.DirectorySeparatorChar + newfile4.Trim() + ext;
			string newfile0 = newfile6;
			string thisnewfile = newfile0;
			//or these two lines
			//Deleted 
			if (!thisnewfile.Equals(fname))
			{
				if (!System.IO.File.Exists(thisnewfile))
				{
					System.IO.File.Move(fname, thisnewfile);
					retval = "Fixed " + thisnewfile;
				}
				else
				{
					System.IO.FileInfo fisource = new System.IO.FileInfo(fname);
					System.IO.FileInfo fidestination = new System.IO.FileInfo(thisnewfile);
					if (fisource.Length == fidestination.Length)
					{
						fisource.Delete();
						retval = "Deleted " + fname;
					}
					else
					{
						retval = "Not Fixed or Deleted " + fname;
					}
					fisource = null;
					fidestination = null;
				}
			}
			else
			{
				retval = "Skipped " + fname;
			}
			return retval;
		}
		public string FixFileNameRemoveBraces(string fname, string mask1, string mask2)
		{
			string ext = System.IO.Path.GetExtension(fname);
			string filefullpath = System.IO.Path.GetFullPath(fname);
			string filepath = System.IO.Path.GetPathRoot(fname);
			string fulldirname = System.IO.Path.GetDirectoryName(fname);
			string retval = System.String.Empty;
			string thisfile = System.IO.Path.GetFileNameWithoutExtension(fname);
			// this block
			string lclmask1 = mask1.Replace("*", "").Trim();
			string lclmask2 = mask2.Replace("*", "").Trim();
			if ((thisfile.ToLower().IndexOf(lclmask1.ToLower()) > 0) && (thisfile.ToLower().IndexOf(lclmask2.ToLower()) > 0))
			{
				string newfile1 = thisfile.Substring(0, thisfile.ToLower().IndexOf(lclmask1.ToLower()) - 1);
				string newfile2 = thisfile.Substring(thisfile.ToLower().IndexOf(lclmask2.ToLower()) + 1);
				string newfile3 = (newfile1 + newfile2).Replace("_", " ");
				//string newfile4 = newfile3.Substring(0, newfile3.IndexOf("-")) + newfile3.Substring(newfile3.IndexOf("- ") + 1);
				//string newfile6 = fulldirname + System.IO.Path.DirectorySeparatorChar + newfile4.Trim() + ext;
				string newfile0 = fulldirname + System.IO.Path.DirectorySeparatorChar + newfile3.Trim() + ext;
				string thisnewfile = newfile0;
				//or these two lines
				//Deleted 
				if (!System.IO.File.Exists(thisnewfile))
				{
					System.IO.File.Move(fname, thisnewfile);
					retval = "Fixed " + thisnewfile;
				}
				else
				{
					System.IO.FileInfo fisource = new System.IO.FileInfo(fname);
					System.IO.FileInfo fidestination = new System.IO.FileInfo(thisnewfile);
					if (fisource.Extension.ToUpper().Equals(".MP3"))
					{
						if (fisource.Length <= fidestination.Length)
						{
							fisource.Delete();
							retval = "Deleted " + fisource.FullName;
						}
						else
						{
							fidestination.Delete();
							retval = "Deleted " + fidestination.FullName;
						}
					}
					else
					{
						if (fisource.Length >= fidestination.Length)
						{
							fisource.Delete();
							retval = "Deleted " + fisource.FullName;
						}
						else
						{
							fidestination.Delete();
							retval = "Deleted " + fidestination.FullName;
						}
					}
					fisource = null;
					fidestination = null;
				}
			}
			else
			{
				retval = "Skipped " + fname;
			}
			return retval;
		}
		public string FixTrimFileName(string fname, string mask1)
		{
			string ext = System.IO.Path.GetExtension(fname);
			string filefullpath = System.IO.Path.GetFullPath(fname);
			string filepath = System.IO.Path.GetPathRoot(fname);
			string fulldirname = System.IO.Path.GetDirectoryName(fname);
			string retval = System.String.Empty;
			string thisfile = System.IO.Path.GetFileNameWithoutExtension(fname);
			// this block
			//deleted
			//or these two lines
			string newfile0 = thisfile;             //.Replace(mask1, mask2);
			string thisnewfile = fulldirname + System.IO.Path.DirectorySeparatorChar + newfile0.Trim() + ext;
			if (!thisnewfile.Equals(fname))
			{
				if (!System.IO.File.Exists(thisnewfile))
				{
					System.IO.File.Move(fname, thisnewfile);
					retval = "Fixed " + thisnewfile;
				}
				else
				{
					retval = "Skipped1 " + fname;
				}
			}
			else
			{
				retval = "Skipped2 " + fname;
			}
			return retval;
		}
		public string[] FindDuplicateFolders(string thispath1, string thispath2)
		{
			string[] retval = null;
			List<string> allthis = new List<string>();
			string[] dirs1 = System.IO.Directory.GetDirectories(thispath1);
			string[] dirs2 = System.IO.Directory.GetDirectories(thispath2);

			List<string> alldirs1 = new List<string>(System.IO.Directory.EnumerateDirectories(thispath1, "*", System.IO.SearchOption.AllDirectories));
			List<string> alldirs2 = new List<string>(System.IO.Directory.EnumerateDirectories(thispath2, "*", System.IO.SearchOption.AllDirectories));

			retval = dirs1;
			return retval;
		}
		public string FixAttributes(string fname, string mask1)
		{
			string retval;
			string ext = System.IO.Path.GetExtension(fname);
			string filefullpath = System.IO.Path.GetFullPath(fname);
			string filepath = System.IO.Path.GetPathRoot(fname);
			string fulldirname = System.IO.Path.GetDirectoryName(fname);
			string thisfile = System.IO.Path.GetFileNameWithoutExtension(fname);

			try
			{
				System.IO.FileAttributes lclfas = System.IO.File.GetAttributes(fname);

				string[] attribname = Enum.GetNames(typeof(System.IO.FileAttributes));
				int[] attribvalues = (int[])Enum.GetValues(typeof(System.IO.FileAttributes));
				for (int ii =0; ii<attribname.Length;ii++)
				{
					if(mask1.IndexOf(attribname[ii],System.StringComparison.OrdinalIgnoreCase)>=0)			
					{
						lclfas &= ~(System.IO.FileAttributes)attribvalues[ii];
					}
				}
				System.IO.File.SetAttributes(fname, lclfas);
				retval = "Fixed " + fname;
			}
			catch (Exception ee)
			{
				retval = "Error " + fname + ee.Message;
			}
			finally
			{
				// do nothing yet			
			}
			return retval;
		}
		~MyDir1()
		{
			return;
		}
	}
}
