﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicLibraryMerge
{
	public partial class Form1 : Form
	{
		private int _whichfolder = 2;
		private int max_path = 260;
		public Form1()
		{
			InitializeComponent();
			this.Text = String.Format("{0}, Version {1}", GetAssemblyName(), GetVersionInfoStr());
		}
		private string GetAssemblyName()
		{
			//System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly();
			//System.Reflection.AssemblyName assname = ass.GetName();
			//System.Version assvs = assname.Version;
			return System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
		}
		private string GetVersionInfoStr(string delimiter)
		{
			//String.Format("{0}, Version {1}", assname.Name, assvs.ToString());
			System.Version lclver = GetVersionInfo();
			string lclverstr = lclver.Major.ToString()
							+ delimiter
							+ lclver.Minor.ToString()
							+ delimiter
							+ lclver.MajorRevision
							+ delimiter
							+ lclver.MinorRevision.ToString();
			return lclverstr;
		}
		private string GetVersionInfoStr()
		{
			return GetVersionInfo().ToString();
		}
		private System.Version GetVersionInfo()
		{
			//System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly();
			//System.Reflection.AssemblyName assname = ass.GetName();
			//System.Version assvs = assname.Version;
			return System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			buttonClick(sender, e);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			buttonClick(sender, e);
		}
		private string GetSubMask()
		{
			string mask1 = string.Empty;
			if (!System.String.IsNullOrEmpty(tsub.Text))
			{
				mask1 = tsub.Text;
			}
			return mask1;
		}
		private string GetFindMask()
		{
			string mask1 = string.Empty;
			if (!System.String.IsNullOrEmpty(tfind.Text))
			{
				mask1 = tfind.Text;
			}
			return mask1;
		}
		private string GetReplaceMask()
		{
			string mask1 = string.Empty;
			if (!System.String.IsNullOrEmpty(tmatch.Text))
			{
				mask1 = tmatch.Text;
			}
			return mask1;
		}
		private string Get1BetweenMask()
		{
			string mask2 = string.Empty;
			if (!System.String.IsNullOrEmpty(tfirstbetween.Text))
			{
				mask2 = tfirstbetween.Text;
			}
			return mask2;
		}
		private string Get2BetweenMask()
		{
			string mask2 = string.Empty;
			if (!System.String.IsNullOrEmpty(tlastbetween.Text))
			{
				mask2 = tlastbetween.Text;
			}
			return mask2;
		}

		private string GetIgnoreMask()
		{
			string mask2 = string.Empty;
			if (!System.String.IsNullOrEmpty(tignore.Text))
			{
				mask2 = tignore.Text;
			}
			return mask2;
		}
		private List<string> buttonClick(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			string thispath = tbfirstfolder.Text;
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			System.Windows.Forms.Button snder = (System.Windows.Forms.Button)sender;
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			int usesubs = cb_subs.Checked == true ? 1 : 0;
			if (snder.Name == "button1")
			{
				sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			}
			else
			{
				sb1.AddRange(md.GetAllFiles(thispath, findmask, ignoremask, usesubs));
			}
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			Cursor = oldcursor;
			return sb1;
		}

		private void GetStartFolder()
		{
			System.Windows.Forms.FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				tbfirstfolder.Text = fbd.SelectedPath;
			}
		}

		private void GetDestinationFolder()
		{
			System.Windows.Forms.FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				tbsecondfolder.Text = fbd.SelectedPath;
			}
		}
		private void Form1_DragDrop(object sender, DragEventArgs ee)
		{
			StringBuilder sb = new StringBuilder();
			string fname;
			foreach (string ss in (String[])ee.Data.GetData(DataFormats.FileDrop)) // should be only one
			{
				if (ss.Length > 0)
				{
					sb.AppendLine(ss);
				}
			}
			fname = sb.ToString().Replace("\r\n", "");
			if (!string.IsNullOrEmpty(fname))
			{
				if ((System.IO.File.GetAttributes(fname) & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
				{
					tbfirstfolder.Text = fname;
				}
			}
			return;
		}

		private void Form1_DragEnter(object sender, DragEventArgs ee)
		{
			ee.Effect = DragDropEffects.None;
			if (ee.Data != null)
			{
				if (ee.Data.GetDataPresent(DataFormats.FileDrop))
				{
					// Display the copy cursor.
					ee.Effect = DragDropEffects.Copy;
				}
			}
			return;
		}

		private void tbfolder_DragDrop(object sender, DragEventArgs ee)
		{
			StringBuilder sb = new StringBuilder();
			string fname;
			foreach (string ss in (String[])ee.Data.GetData(DataFormats.FileDrop)) // should be only one
			{
				if (ss.Length > 0)
				{
					sb.AppendLine(ss);
				}
			}
			fname = sb.ToString().Replace("\r\n", "");
			if (!string.IsNullOrEmpty(fname))
			{
				if ((System.IO.File.GetAttributes(fname) & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
				{
					((System.Windows.Forms.TextBox)sender).Text = fname;
				}
			}
			return;
		}

		private void tbfolder_DragEnter(object sender, DragEventArgs ee)
		{
			ee.Effect = DragDropEffects.None;
			if (ee.Data != null)
			{
				if (ee.Data.GetDataPresent(DataFormats.FileDrop))
				{
					// Display the copy cursor.
					ee.Effect = DragDropEffects.Copy;
				}
			}
			return;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void startFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetStartFolder();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			lblfound.Text = "";
		}
		private void btnfirstfolder_Click(object sender, EventArgs e)
		{
			GetStartFolder();
		}
		private void btnsecondfolder_Click(object sender, EventArgs e)
		{
			GetDestinationFolder();
		}

		private void finalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDestinationFolder();
		}

		private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnMerge_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			rtb1.Clear();
			int copytosubs = cb_copytosubs.Checked == true ? 1 : 0;
			string thispath = tbfirstfolder.Text;
			string putpath = tbsecondfolder.Text;
			int usesubs = cb_subs.Checked == true ? 1 : 0;
			rtb1.Lines = DoFixMetaData(copytosubs, usesubs, thispath, putpath).ToArray();
			Cursor = oldcursor;
		}
		private List<string> DoFixMetaData(int copytosubs, int usesubs, string thispath, string putpath)
		{
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			string album;
			string artist;
			string songname;
			string[] mdata;
			string newfile = System.String.Empty;
			string ext;
			string filefullpath;
			string filepath;
			string fulldirname;
			string thisfilename;
			ID3Class.ID3Frame lclframe;
			string didwhat = System.String.Empty;
			int copied = 0, skipped = 0, notcopied = 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				ext = System.IO.Path.GetExtension(thisfile);
				filefullpath = System.IO.Path.GetFullPath(thisfile);
				filepath = System.IO.Path.GetPathRoot(thisfile);
				fulldirname = System.IO.Path.GetDirectoryName(thisfile);
				thisfilename = System.IO.Path.GetFileNameWithoutExtension(thisfile);
				rtb1.Text = string.Format("{0:d} of {1:d}  {2:s}", sb2.Count, sb1.Count, thisfile);
				rtb1.Refresh();
				Application.DoEvents();
				if (System.IO.Path.GetExtension(thisfile).ToUpper().Equals(md.MP3Extension))
				{
					if (copytosubs == 1)
					{
						newfile = thisfile.Replace(thispath, putpath);
					}
					if (copytosubs == 0)
					{
						newfile = putpath + System.IO.Path.DirectorySeparatorChar + thisfilename + ext;
					}
					if (newfile.Length < max_path)
					{
						mdata = thisfile.Remove(0, thispath.Length).Split(new char[] { System.IO.Path.DirectorySeparatorChar }, System.StringSplitOptions.RemoveEmptyEntries);
						if (mdata.GetUpperBound(0) == 2)
						{
							artist = mdata[0];
							album = mdata[1];
							songname = mdata[2].Substring(0, mdata[2].Length - (ext.Length));
							if (int.TryParse(songname.Substring(0, 2), out int tmpint))
							{
								songname = songname.Remove(0, 3);
							}

							ID3Class.ID3Data myid3 = new ID3Class.ID3Data(thisfile);
							if (myid3.ReadMetaData())
							{

								lclframe = myid3.FindFirstFrame("TALB");// album name
								if (lclframe == null)
								{
									lclframe = new ID3Class.ID3Frame(myid3);
									lclframe.Name = "TALB";
									myid3.FrameList.Add(lclframe);
								}
								lclframe.UnicodeFlag = true;
								lclframe.ContentString = album;
								//use the following if you don't want Unicode in the metadata
								//lclframe.UnicodeFlag = false;
								//lclframe.ContentBytes = System.Text.Encoding.GetEncoding(myid3.EncodingName).GetBytes("Barry's " + album);

								lclframe = myid3.FindFirstFrame("TIT2"); // Song title
								if (lclframe == null)
								{
									lclframe = new ID3Class.ID3Frame(myid3);
									lclframe.Name = "TIT2";
									myid3.FrameList.Add(lclframe);
								}
								lclframe.UnicodeFlag = true;
								lclframe.ContentString = songname;

								lclframe = myid3.FindFirstFrame("TPE2");// album artist
								if (lclframe == null)
								{
									lclframe = new ID3Class.ID3Frame(myid3);
									lclframe.Name = "TPE2";
									myid3.FrameList.Add(lclframe);
								}
								lclframe.UnicodeFlag = true;
								lclframe.ContentString = artist;
								newfile = md.MakeNextFileName(newfile);
								if (myid3.WriteMetaData(newfile))
								{
									myid3.CloseFile();
									sb2.Add("-> Copied " + newfile);
									copied++;
								}
								else
								{
									newfile = md.MakeNextFileName(newfile);
									System.IO.File.Copy(thisfile, newfile);
								}
							}
							else
							{
								newfile = md.MakeNextFileName(newfile);
								System.IO.File.Copy(thisfile, newfile);
							}
						}
						else
						{
							newfile = md.MakeNextFileName(newfile);
							System.IO.File.Copy(thisfile, newfile);
						}
					}
					else
					{
						System.Windows.Forms.MessageBox.Show("Manually handle - FilePath Too Long " + newfile);
						sb2.Add("Manually handle - FilePath Too Long " + newfile);
						skipped++;
					}
				}
			}
			sb2.Add(string.Format("{0:d} of {1:d} ---- copied={2:d} skipped={3:d} errored={4:d}", sb2.Count, sb1.Count, copied, skipped, notcopied));
			return sb2;
		}
		private List<string> CopyFiles(int copytosubs, int usesubs, string thispath, string putpath)
		{
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string newfile = System.String.Empty;
			string newdir = System.String.Empty;
			string ext = System.String.Empty;
			string filefullpath = System.String.Empty;
			string filepath = System.String.Empty;
			string fulldirname = System.String.Empty;
			string thisfilename = System.String.Empty;
			string didwhat = System.String.Empty;
			int copied = 0, skipped = 0, notcopied = 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				ext = System.IO.Path.GetExtension(thisfile);
				filefullpath = System.IO.Path.GetFullPath(thisfile);
				filepath = System.IO.Path.GetPathRoot(thisfile);
				fulldirname = System.IO.Path.GetDirectoryName(thisfile);
				thisfilename = System.IO.Path.GetFileNameWithoutExtension(thisfile);
				rtb1.Text = string.Format("{0:d} of {1:d}  {2:s}", sb2.Count, sb1.Count, thisfile);
				rtb1.Refresh();
				Application.DoEvents();
				if (copytosubs == 1)
				{
					newfile = putpath + thisfile.Remove(0, thispath.Length);
				}
				if (copytosubs == 0)
				{
					newfile = putpath + System.IO.Path.DirectorySeparatorChar + thisfilename + ext;
				}
				if (newfile.Length < max_path)
				{
					didwhat = "START";
					try
					{
						newdir = System.IO.Path.GetDirectoryName(newfile);
						if (!System.IO.Directory.Exists(newdir))
						{
							System.IO.Directory.CreateDirectory(newdir);
						}
						if (!System.IO.File.Exists(newfile))
						{
							System.IO.File.Copy(thisfile, newfile);
							didwhat = "=> Copied ";
							copied++;
						}
						else
						{
							MyDir1 myd = new MyDir1();
							newfile = myd.MakeNextFileName(newfile);
							System.IO.File.Copy(thisfile, newfile);
							copied++;
							didwhat = "++ Copied To ";
						}
					}
					catch (Exception ee)
					{
						didwhat = "**NOT COPIED " + ee.Message + " ";
						notcopied++;
					}
					finally
					{
						sb2.Add(didwhat + newfile);
					}
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("Manually handle - FilePath Too Long " + newfile);
					sb2.Add("Manually handle - FilePath Too Long " + newfile);
				}
			}
			sb2.Add(string.Format("{0:d} of {1:d} ---- copied={2:d} skipped={3:d} errored={4:d}", sb2.Count, sb1.Count, copied, skipped, notcopied));
			return sb2;
		}

		private List<string> DoTrim()
		{
			string thispath = System.String.Empty;
			if (_whichfolder == 2)
			{ thispath = tbsecondfolder.Text; }
			if (_whichfolder == 1)
			{ thispath = tbfirstfolder.Text; }
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			int usesubs = cb_subs.Checked == true ? 1 : 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				sb2.Add(md.FixTrimFileName(thisfile, replacemask));
			}
			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> DoReplace()
		{
			string thispath = System.String.Empty;
			if (_whichfolder == 2)
			{ thispath = tbsecondfolder.Text; }
			if (_whichfolder == 1)
			{ thispath = tbfirstfolder.Text; }
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			int usesubs = cb_subs.Checked == true ? 1 : 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				sb2.Add(md.FixFileNameReplace(thisfile, replacemask, submask));
			}
			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> DoRemoveBraces()
		{
			string thispath = System.String.Empty;
			if (_whichfolder == 2)
			{ thispath = tbsecondfolder.Text; }
			if (_whichfolder == 1)
			{ thispath = tbfirstfolder.Text; }
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string firstbetweenmask = Get1BetweenMask();
			string secondbetweenmask = Get2BetweenMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			//string submask = GetSubMask();
			int usesubs = cb_subs.Checked == true ? 1 : 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				sb2.Add(md.FixFileNameRemoveBraces(thisfile, firstbetweenmask, secondbetweenmask));
			}
			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> DoEmptyFolders()
		{
			string thispath = System.String.Empty;
			if (_whichfolder == 2)
			{ thispath = tbsecondfolder.Text; }
			if (_whichfolder == 1)
			{ thispath = tbfirstfolder.Text; }
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			sb1.AddRange(md.GetAllFolders(thispath));
			sb1.Sort();
			//rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				string thisstring = md.RemoveEmptyFolders(thisfile);
				if (!System.String.IsNullOrEmpty(thisstring))
				{
					sb2.Add(thisstring);
				}
			}
			sb1.AddRange(sb2);
			return sb2;
		}

		private List<string> DoFixDisc()
		{
			string thispath = System.String.Empty;
			if (_whichfolder == 2)
			{ thispath = tbsecondfolder.Text; }
			if (_whichfolder == 1)
			{ thispath = tbfirstfolder.Text; }
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			int usesubs = cb_subs.Checked == true ? 1 : 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			string mask1 = "disc_";
			if (!System.String.IsNullOrEmpty(GetReplaceMask()))
			{
				mask1 = GetReplaceMask();
			}
			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				sb2.Add(md.FixDiscFileName(thisfile, mask1));
			}
			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> RemoveLeadingNos(int maxnumber)
		{
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string thispath = System.String.Empty;
			if (_whichfolder == 2)
			{ thispath = tbsecondfolder.Text; }
			if (_whichfolder == 1)
			{ thispath = tbfirstfolder.Text; }
			MyDir1 md = new MyDir1();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			int usesubs = cb_subs.Checked == true ? 1 : 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();

			//rtb1.Lines = sb1.ToArray();
			//ShowFound(sb1.Count);

			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				sb2.Add(md.RemoveLeadingNo(thisfile, maxnumber));
			}

			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> RemoveTrailingNos()
		{
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string thispath = System.String.Empty;
			if (_whichfolder == 2)
			{ thispath = tbsecondfolder.Text; }
			if (_whichfolder == 1)
			{ thispath = tbfirstfolder.Text; }
			MyDir1 md = new MyDir1();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			int usesubs = cb_subs.Checked == true ? 1 : 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();

			//rtb1.Lines = sb1.ToArray();
			//ShowFound(sb1.Count);

			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				sb2.Add(md.RemoveTrailingNo(thisfile));
			}

			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> DoFixAttributes(string whichattributes)
		{
			string thispath = System.String.Empty;
			if (_whichfolder == 2)
			{ thispath = tbsecondfolder.Text; }
			if (_whichfolder == 1)
			{ thispath = tbfirstfolder.Text; }
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			//string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			//string submask = GetSubMask();
			string mask1 = System.String.Empty;
			int usesubs = cb_subs.Checked == true ? 1 : 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask, usesubs));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			if (!System.String.IsNullOrEmpty(GetReplaceMask()))
			{
				mask1 = GetReplaceMask();
			}
			else
			{
				mask1 = whichattributes;
			}
			foreach (string thisfile in sb1)
			{
				Application.DoEvents();
				sb2.Add(md.FixAttributes(thisfile, mask1));
			}
			sb1.AddRange(sb2);
			return sb1;
		}

		private Int32 ShowFound(Int32 howmany)
		{
			lblfound.Text = String.Format("{0} Found", howmany);
			return howmany;
		}

		private void btnTrim_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			rtb1.Lines = DoTrim().ToArray();
			Cursor = oldcursor;
		}

		private void btnfixdisc_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			rtb1.Lines = DoFixDisc().ToArray();
			Cursor = oldcursor;
		}

		private void btnReplace_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			rtb1.Lines = DoReplace().ToArray();
			Cursor = oldcursor;
		}

		private void btnRemoveBetween_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			rtb1.Lines = DoRemoveBraces().ToArray();
			Cursor = oldcursor;
		}

		private void btnemptyfolders_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			rtb1.Lines = DoEmptyFolders().ToArray();
			ShowFound(rtb1.Lines.Length);
			Cursor = oldcursor;
		}

		private void btnCopyFiles_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			int copytosubs = cb_copytosubs.Checked == true ? 1 : 0;
			string thispath = tbfirstfolder.Text;
			string putpath = tbsecondfolder.Text;
			int usesubs = cb_subs.Checked == true ? 1 : 0;
			rtb1.Lines = CopyFiles(copytosubs, usesubs, thispath, putpath).ToArray();
			ShowFound(rtb1.Lines.Length);
			Cursor = oldcursor;
		}

		private void btnAttrib_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			rtb1.Lines = DoFixAttributes("SystemHidden").ToArray();
			ShowFound(rtb1.Lines.Length);
			Cursor = oldcursor;
		}

		private void btnwhich_Click(object sender, EventArgs e)
		{
			if (btnwhich.Text.IndexOf("Start") > 0)
			{
				btnwhich.Text = "Use Dest Folder";
				_whichfolder = 2;
			}
			else
			{
				btnwhich.Text = "Use Start Folder";
				_whichfolder = 1;
			}
		}

		private void btn_FillData_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			//rtb1.Lines = DoFixAttributes("SystemHidden").ToArray();
			//ShowFound(rtb1.Lines.Length);
			Cursor = oldcursor;
		}

		private void btnLeadingNo_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			int.TryParse(tmaxnumber.Text, out int maxnumber);
			rtb1.Lines = RemoveLeadingNos(maxnumber).ToArray();
			ShowFound(rtb1.Lines.Length);
			Cursor = oldcursor;
		}

		private void btnRemoveTrailingNos_Click(object sender, EventArgs e)
		{
			Cursor oldcursor = Cursor;
			Cursor = Cursors.WaitCursor;
			rtb1.Lines = RemoveTrailingNos().ToArray();
			ShowFound(rtb1.Lines.Length);
			Cursor = oldcursor;
		}

		private void rtb1_DoubleClick(object sender, EventArgs e)
		{
			rtb1.Text = System.String.Empty;
		}
	}
}
