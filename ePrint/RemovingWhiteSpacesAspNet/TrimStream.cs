using System;
using System.IO;
using System.Text;

namespace RemovingWhiteSpacesAspNet
{
	public class TrimStream : Stream
	{
		private Stream stream;

		private StreamWriter streamWriter;

		private Decoder dec;

		private bool bNewLine;

		private bool bLastCharGT;

		private char[] arBlanks;

		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public TrimStream(Stream stm)
		{
			this.stream = stm;
			this.streamWriter = new StreamWriter(this.stream, Encoding.UTF8);
			this.dec = Encoding.UTF8.GetDecoder();
		}

		public override void Flush()
		{
			this.stream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			int num;
			int num1;
			int charCount = this.dec.GetCharCount(buffer, offset, count);
			char[] chrArray = new char[charCount];
			int chars = this.dec.GetChars(buffer, offset, count, chrArray, 0);
			if (chars <= 0)
			{
				return;
			}
			int num2 = -1;
			int num3 = -1;
			int num4 = 0;
			bool flag = true;
			for (int i = 0; i <= chars; i++)
			{
				bool flag1 = i == chars;
				char chr = (i < chars ? chrArray[i] : '\n');
				if (chr == '\n')
				{
					if (flag && this.arBlanks != null && num2 >= 0)
					{
						if ((int)this.arBlanks.Length > 0)
						{
							this.streamWriter.Write(this.arBlanks, 0, (int)this.arBlanks.Length);
						}
						this.arBlanks = null;
						num2 = 0;
						this.bNewLine = false;
					}
					flag = false;
					if (num2 >= 0)
					{
						if (this.bNewLine && chrArray[num2] != '<')
						{
							this.streamWriter.WriteLine();
						}
						this.streamWriter.Write(chrArray, num2, num3 - num2 + 1);
						if (!flag1)
						{
							num2 = -1;
							num3 = -1;
							num4 = i + 1;
						}
						this.bNewLine = !this.bLastCharGT;
						this.bLastCharGT = false;
					}
					if (flag1)
					{
						if (this.arBlanks != null || num2 >= 0)
						{
							if (num3 >= chars - 1)
							{
								this.arBlanks = new char[0];
							}
							else
							{
								if (num3 >= 0)
								{
									num = chars - num3 - 1;
									num1 = num3 + 1;
								}
								else
								{
									num = chars - num4;
									num1 = num4;
								}
								if (this.arBlanks == null || (int)this.arBlanks.Length <= 0)
								{
									this.arBlanks = new char[num];
									Array.Copy(chrArray, num1, this.arBlanks, 0, num);
								}
								else
								{
									char[] chrArray1 = new char[(int)this.arBlanks.Length + num];
									this.arBlanks.CopyTo(chrArray1, 0);
									Array.Copy(chrArray, num1, chrArray1, (int)this.arBlanks.Length, num);
									this.arBlanks = chrArray1;
								}
							}
						}
						this.bNewLine = false;
					}
				}
				else if (!char.IsWhiteSpace(chr))
				{
					if (num2 < 0)
					{
						num2 = i;
					}
					num3 = i;
					this.bLastCharGT = chr == '>';
				}
			}
			this.streamWriter.Flush();
		}
	}
}