using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace SymmetricAlgorithms
{
	public partial class Form1 : Form
	{
		Modes mode = Modes.Empty;
		Algorithms algorithm = Algorithms.Empty;
		Paddings padding = Paddings.Empty;
		byte[] key;
		byte[] IV;
		byte[] te;
		byte[] cipherbytes;
		string EncodedText;
		SymmetricAlgorithm sa;
		public Form1()
		{
			InitializeComponent();
		}

		//public bool Check()
		//{
		//	bool Checked = false;
		//	bool AllChecked = false;
		//	for (int i =0; i<= groupBox1.Controls.OfType<RadioButton>().Count();i++)
		//	{

		//	}
		//	foreach(RadioButton i in groupBox1.Controls.OfType<RadioButton>())
		//	{
		//		if (i.Checked)
		//		{
		//			Checked = true;

		//			break;
		//		}
		//	}
		//	if (Checked)
		//	{
		//		Checked = false;
		//		foreach (RadioButton i in groupBox2.Controls.OfType<RadioButton>())
		//		{
		//			if (i.Checked)
		//			{
		//				Checked = true;
		//				break;
		//			}
		//		}
		//	}
		//	if (Checked)
		//	{
		//		Checked = false;
		//		foreach (RadioButton i in groupBox3.Controls.OfType<RadioButton>())
		//		{
		//			if (i.Checked)
		//			{
		//				AllChecked = true;
		//				Checked = true;
		//				break;
		//			}
		//		}
		//	}
		//	if (AllChecked) return true; else return false;
		//}

		enum Modes
		{
			Empty,
			ECB,
			CBC,
			CFB,
			OFB,
			CTS
		}
		enum Algorithms
		{
			Empty,
			DES,
			TripleDES,
			Rijndael,
			RC2
		}
		enum Paddings
		{
			Empty,
			PKCS7,
			Zeros,

			None
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				algorithm = Algorithms.DES;
				sa = DES.Create();
				sa.GenerateKey();
				sa.GenerateIV();
				key = sa.Key;
				IV = sa.IV;
				textBox1.Text = BitConverter.ToString(sa.Key).Replace('-', ' ');
				textBox2.Text = BitConverter.ToString(sa.IV).Replace('-', ' ');
			}
			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
			{
				algorithm = Algorithms.TripleDES;
				sa = TripleDES.Create();
				sa.GenerateKey();
				sa.GenerateIV();
				key = sa.Key;
				IV = sa.IV;
				textBox1.Text = BitConverter.ToString(sa.Key).Replace('-', ' ');
				textBox2.Text = BitConverter.ToString(sa.IV).Replace('-', ' ');
			}
			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked)
			{
				algorithm = Algorithms.Rijndael;
				sa = Rijndael.Create();
				sa.GenerateKey();
				sa.GenerateIV();
				key = sa.Key;
				IV = sa.IV;
				textBox1.Text = BitConverter.ToString(sa.Key).Replace('-', ' ');
				textBox2.Text = BitConverter.ToString(sa.IV).Replace('-', ' ');
			}

			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton4.Checked)
			{
				algorithm = Algorithms.RC2;
				sa = RC2.Create();
				sa.GenerateKey();
				sa.GenerateIV();
				key = sa.Key;
				IV = sa.IV;
				textBox1.Text = BitConverter.ToString(sa.Key).Replace('-', ' ');
				textBox2.Text = BitConverter.ToString(sa.IV).Replace('-', ' ');
			}


			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton5.Checked)
			{
				mode = Modes.ECB;
				sa.Mode = CipherMode.ECB;
			}

			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton6_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton6.Checked)
			{
				mode = Modes.CBC;
				sa.Mode = CipherMode.CBC;
			}

			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton7_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton7.Checked)
			{
				mode = Modes.CFB;
				sa.Mode = CipherMode.CFB;
			}

			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton8_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton8.Checked)
			{
				mode = Modes.OFB;
				sa.Mode = CipherMode.OFB;
			}

			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton9_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton9.Checked)
			{
				mode = Modes.CTS;
				sa.Mode = CipherMode.CTS;
			}

			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton14_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton14.Checked)
			{
				padding = Paddings.PKCS7;
				sa.Padding = PaddingMode.PKCS7;
			}

			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton13_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton13.Checked)
			{
				padding = Paddings.Zeros;
				sa.Padding = PaddingMode.Zeros;
			}
			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void radioButton12_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton12.Checked)
			{
				padding = Paddings.None;
				sa.Padding = PaddingMode.None;
			}

			if (algorithm != 0 && mode != 0 && padding != 0)
			{
				textBox3.ReadOnly = false;
				button1.Enabled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);
			byte[] plainbytes = Encoding.Default.GetBytes(textBox3.Text);
			cs.Write(plainbytes, 0, plainbytes.Length);
			cs.Close();
			cipherbytes = ms.ToArray();
			ms.Close();
			EncodedText = Encoding.Default.GetString(cipherbytes);
			textBox6.Text = EncodedText;
			textBox7.Text = BitConverter.ToString(cipherbytes).Replace('-', ' ');
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			radioButton2.Checked = true;
			radioButton5.Checked = true;
			radioButton14.Checked = true;

		}

		private void button2_Click(object sender, EventArgs e)
		{
			//te = new byte[EncodedText.Length];
			//te = Encoding.Default.GetBytes(EncodedText);
			SymmetricAlgorithm sa2 = TripleDES.Create();
			if (algorithm == Algorithms.DES) sa2 = DES.Create();
			else if (algorithm == Algorithms.TripleDES) sa2 = TripleDES.Create();
			else if (algorithm == Algorithms.Rijndael) sa2 = Rijndael.Create();
			else if (algorithm == Algorithms.RC2) sa2 = RC2.Create();
			sa2.Key = key;
			sa2.IV = IV;
			sa2.Mode = sa.Mode;
			sa2.Padding = sa.Padding;
			//MemoryStream ms2 = new MemoryStream(te);
			//CryptoStream cs2 = new CryptoStream(ms2, sa2.CreateDecryptor(), CryptoStreamMode.Read);
			//byte[] plainbytes2 = new Byte[te.Length];
			//cs2.Read(plainbytes2, 0, te.Length);
			//cs2.Close();
			//ms2.Close();
			//textBox8.Text = Encoding.Default.GetString(plainbytes2);
			MemoryStream ms = new MemoryStream(cipherbytes);
			CryptoStream cs = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Read);
			byte[] plainbytes = new Byte[cipherbytes.Length];
			cs.Read(plainbytes, 0, cipherbytes.Length);
			cs.Close();
			ms.Close();
			textBox8.Text = Encoding.Default.GetString(plainbytes);
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(textBox3.Text))
			{
				button2.Enabled = true;
			}
			else button2.Enabled = false;
		}
	}
}
