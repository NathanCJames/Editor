using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace EDITOR
{
	public partial class Form1 : Form
	{
		string Path = "";



		public Form1()
		{
			InitializeComponent();
		}



		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (FontFamily font in FontFamily.Families)
			{
				comboBox1.Items.Add(font.Name.ToString());
			}
		}

/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
/// 


		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//this line of code will allow the user to exit the editor program

			Application.Exit();
		}
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
/// 

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// this section of code allows the user to open an existing or saved file 

			DialogResult openResult = openFileDialog1.ShowDialog();

			if (openResult == DialogResult.OK)
			{

				Path = openFileDialog1.FileName;

				try
				{
					StreamReader fileOpen = new StreamReader(Path);
					string contents = fileOpen.ReadToEnd();
					fileOpen.Close();

					richTextBox1.Text = contents;
				}
				catch (IOException ioe)
				{

					MessageBox.Show("error opening file" + ioe.Message);
				}
			}
		}
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
/// 


		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{

			// allows the user to create a new page 

			richTextBox1.Clear();

			Path = "";
		}
/// <summary>
/// ////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
/// 

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//this section of code allows the user to save a document as any choice of the user 
			
			DialogResult saveResult = saveFileDialog1.ShowDialog();

			if (saveResult == DialogResult.OK)
			{
				Path = saveFileDialog1.FileName;
			}
			try
			{
			    StreamWriter sw = new StreamWriter(Path);
				sw.Write(richTextBox1.Text);
				sw.Close();
			}
			catch(IOException ioe)
			{
				MessageBox.Show("error saving file :" + ioe.Message);
			}
		}
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
/// 

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/////this section of code allows the user to save a plain document/page 

			if (Path == string.Empty)
			{
				{
					DialogResult saveResult = saveFileDialog1.ShowDialog();

					if (saveResult == DialogResult.OK)
					{
						Path = saveFileDialog1.FileName;
					}
					try
					{
						StreamWriter sw = new StreamWriter(Path);
						sw.Write(richTextBox1.Text);
						sw.Close();
					}
					catch (IOException ioe)
					{
						MessageBox.Show("error saving file :" + ioe.Message);
					}

				}
			}	

			else
			{
				try
				{
					StreamWriter sw = new StreamWriter(Path);
					sw.Write(richTextBox1.Text);
					sw.Close();
				}
				catch (IOException ioe)
				{
					MessageBox.Show("error saving file :" + ioe.Message);
				}
			}
			//////////////////////////////////////////////////////////////////////////////////////////////////////////
			//
		}

		/// <summary>
		///				this line of code allows the user to underline their text
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void BTN_underline_Click(object sender, EventArgs e)
		{
			richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Underline);
		}

		/// <summary>
		///				these lines of code allows the user to change to different font types 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				richTextBox1.Font = new Font(comboBox1.Text, richTextBox1.Font.Size);
			}
			catch { }

		}
		
		/// <summary>
		/// /		This allows the user to change the colour of the text they have typed in
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void BTN_TextColour_Click(object sender, EventArgs e)
		{
			DialogResult colors = colorDialog1.ShowDialog();
			if (colors == DialogResult.OK)
			{
				richTextBox1.ForeColor = colorDialog1.Color;
			}
		}
		//the following liens of code allows the user to change the text either from regular to bold or bold to italics and etc 

		private void BTN_Regular_Click(object sender, EventArgs e)
		{
			richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Regular);
		}

		private void BTN_Bold_Click(object sender, EventArgs e)
		{
			richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Bold);
		}

		private void BTN_Italics_Click(object sender, EventArgs e)
		{
			richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Italic);
		}

		private void HighLight_text_Click(object sender, EventArgs e)
		{
	
		}
		//this will be the code to change the background colour 

		private void BTN_BackgroundColour_Click(object sender, EventArgs e)
		{
			DialogResult color = colorDialog1.ShowDialog();
				if (color == DialogResult.OK)
			{
				richTextBox1.BackColor = colorDialog1.Color;
			}
				///this will allow the user to change the background color of the page 
				/////////
				////
				///
		}
		// the following lines of code allows the user to change the size of the selected text 

		private void comboSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, float.Parse(comboSize.SelectedItem.ToString()));
			}

			catch { }
		}

		//the following lines of code refernces the UPPER CASE character casing 
        private void btnUpperCase_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = richTextBox1.Text.ToUpper();
		}

		//the following line of code references the LOWER CASE character casing 
		private void btnLowerCase_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = richTextBox1.Text.ToLower();
			
		}
	
		
		//THE FOLLOWING LINES OF CODE ARE FOR THE INSERTING OF THE EMOTICONS 
	
			//the following lines of code refernces the "ANGEL" Emoticon
		private void btn_Angel_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage =EDITOR.Properties.Resources.icoAngel;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}


		//the following lines of code refernces the "BARF" Emoticon
		private void btn_icoBarf_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoBarf;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();

		}


		//the following lines of code refernces the "BLUSH" Emoticon
		private void btn_Blush_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoBlush;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();

		}


		//the following lines of code refernces the "CURIOUS" Emoticon
		private void btn_Curious_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoCurious;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}


		//the following lines of code refernces the "HAPPY" Emoticon
		private void btn_Happy_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoHappy;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}


		//the following lines of code refernces the "HUNGRY" Emoticon
		private void btn_Hungry_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoHungry;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}


		//the following lines of code refernces the "NEVER-MIND" Emoticon
		private void btn_NeverMind_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoNeverMind;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}


		//the following lines of code refernces the "PLUS-EYES" Emoticon
		private void btn_PlusEyes_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoPlusEyes;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}


		//the following lines of code refernces the "SKULL" Emoticon
		private void btn_Skull_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoSkull;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}


		//the following lines of code refernces the "SLEEPY" Emoticon
		private void btn_Sleepy_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoSleepy;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}
		//the following lines of code references the "DEVIL" Emoticon

		private void btn_icoDevil_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoDevil;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}

		//the following lines of code references the "ANGRY" Emoticon

		private void btn_icoAngry_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoAngry;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}

		//the following lines of code references the "HEART EYES" Emoticon

		private void btn_icoHeartEyes_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoHeartEyes;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}

		//the following lines of code references the "HEART" Emoticon

		private void btn_icoHeart_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoHeart;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}

		//the following lines of code references the "BROKEN HEART" Emoticon

		private void btn_icoBrokenHeart_Click(object sender, EventArgs e)
		{
			System.Drawing.Image tempImage = EDITOR.Properties.Resources.icoBrokenHeart;
			Clipboard.SetImage(tempImage);
			richTextBox1.Paste();
		}
	}
	
}
