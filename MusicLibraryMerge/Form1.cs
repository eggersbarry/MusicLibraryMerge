﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicLibraryMerge
{
	public partial class Form1 : Form
	{

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
			if (snder.Name == "button1")
			{
				sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask));
			}
			else
			{
				sb1.AddRange(md.GetAllFiles(thispath, findmask, ignoremask));
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
			rtb1.Lines = DoMerge().ToArray();
			Cursor = oldcursor;
		}
		private List<string> DoMerge()
		{
			//			return DoMerge(0);
			return DoMerge(1);
		}
		private List<string> DoMerge(int forwhich)
		{
			string thispath = tbfirstfolder.Text;
			string putpath = tbsecondfolder.Text;
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			string album;
			string artist;
			//string genre;
			//string year;
			//string track;
			string songname;
			string[] mdata;
			string newfile;
			string newdir;
			string ext;
			string filefullpath;
			string filepath;
			string fulldirname;
			string thisfilename;
			string didwhat = System.String.Empty;
			int copied = 0, skipped = 0, notcopied = 0;

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				ext = System.IO.Path.GetExtension(thisfile);
				filefullpath = System.IO.Path.GetFullPath(thisfile);
				filepath = System.IO.Path.GetPathRoot(thisfile);
				fulldirname = System.IO.Path.GetDirectoryName(thisfile);
				thisfilename = System.IO.Path.GetFileNameWithoutExtension(thisfile);
				rtb1.Text = string.Format("{0:d} of {1:d}  {2:s}", sb2.Count, sb1.Count, thisfile);
				rtb1.Refresh();
				Application.DoEvents();
				switch (forwhich)
				{
					case (1):
						{
							mdata = thisfile.Remove(0, thispath.Length).Split(new char[] { System.IO.Path.DirectorySeparatorChar }, System.StringSplitOptions.RemoveEmptyEntries);
							if (mdata.GetUpperBound(0) == 2)
							{
								artist = mdata[0];
								album = mdata[1];
								songname = mdata[2].Substring(0, mdata[2].Length - (ext.Length));
								newfile = putpath + System.IO.Path.DirectorySeparatorChar + album + System.IO.Path.DirectorySeparatorChar + mdata[2];

								ID3Class myid3 = new ID3Class(thisfile);
								myid3.ReadMetaData();
								myid3.WriteMetaData();
								myid3.CloseFile();
								sb2.Add("-> Copied " + newfile);
								copied++;
							}
							break;
						}
					default:
						{
							newfile = putpath + thisfile.Remove(0, thispath.Length);
							didwhat = "START";
							try
							{
								newdir = fulldirname.Replace(thispath, putpath);
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
									skipped++;
									didwhat = "++ Skipped ";
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
							break;
						}
				}


			}
			sb2.Add(string.Format("{0:d} of {1:d} ---- copied={2:d} skipped={3:d} errored={4:d}", sb2.Count, sb1.Count, copied, skipped, notcopied));
			return sb2;
		}
		private List<string> DoTrim()
		{
			string thispath = tbfirstfolder.Text;
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				sb2.Add(md.FixTrimFileName(thisfile, replacemask));
			}
			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> DoReplace()
		{
			string thispath = tbfirstfolder.Text;
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				sb2.Add(md.FixFileNameReplace(thisfile, replacemask, submask));
			}
			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> DoRemoveBraces()
		{
			string thispath = tbfirstfolder.Text;
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();
			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask));
			sb1.Sort();
			rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
				sb2.Add(md.FixFileNameRemoveBraces(thisfile, replacemask, submask));
			}
			sb1.AddRange(sb2);
			return sb1;
		}
		private List<string> DoEmptyFolders()
		{
			string thispath = tbfirstfolder.Text;
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			sb1.AddRange(md.GetAllFolders(thispath));
			sb1.Sort();
			//rtb1.Lines = sb1.ToArray();
			ShowFound(sb1.Count);
			foreach (string thisfile in sb1)
			{
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
			string thispath = tbfirstfolder.Text;
			MyDir1 md = new MyDir1();
			List<string> sb1 = new List<string>();
			List<string> sb2 = new List<string>();
			string replacemask = GetReplaceMask();
			string ignoremask = GetIgnoreMask();
			string findmask = GetFindMask();
			string submask = GetSubMask();

			sb1.AddRange(md.GetAllFilesRecursive(thispath, findmask, ignoremask));
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
				sb2.Add(md.FixDiscFileName(thisfile, mask1));
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

		private void btnbraces_Click(object sender, EventArgs e)
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
			ShowFound(rtb1.Lines.Count());
			Cursor = oldcursor;
		}
	}
}