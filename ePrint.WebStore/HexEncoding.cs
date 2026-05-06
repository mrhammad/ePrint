using System;
using System.Globalization;

public class HexEncoding
{
    public HexEncoding()
    {
    }

    public static int GetByteCount(string hexString)
    {
        int num = 0;
        for (int i = 0; i < hexString.Length; i++)
        {
            if (HexEncoding.IsHexDigit(hexString[i]))
            {
                num++;
            }
        }
        if (num % 2 != 0)
        {
            num--;
        }
        return num / 2;
    }

    public static byte[] GetBytes(string hexString, out int discarded)
    {
        discarded = 0;
        string str = "";
        for (int i = 0; i < hexString.Length; i++)
        {
            char chr = hexString[i];
            if (!HexEncoding.IsHexDigit(chr))
            {
                discarded = discarded + 1;
            }
            else
            {
                str = string.Concat(str, chr);
            }
        }
        if (str.Length % 2 != 0)
        {
            discarded = discarded + 1;
            str = str.Substring(0, str.Length - 1);
        }
        byte[] num = new byte[str.Length / 2];
        int num1 = 0;
        for (int j = 0; j < (int)num.Length; j++)
        {
            char[] chrArray = new char[] { str[num1], str[num1 + 1] };
            num[j] = HexEncoding.HexToByte(new string(chrArray));
            num1 = num1 + 2;
        }
        return num;
    }

    private static byte HexToByte(string hex)
    {
        if (hex.Length > 2 || hex.Length <= 0)
        {
            throw new ArgumentException("hex must be 1 or 2 characters in length");
        }
        return byte.Parse(hex, NumberStyles.HexNumber);
    }

    public static bool InHexFormat(string hexString)
    {
        bool flag = true;
        string str = hexString;
        int num = 0;
        while (num < str.Length)
        {
            if (HexEncoding.IsHexDigit(str[num]))
            {
                num++;
            }
            else
            {
                flag = false;
                break;
            }
        }
        return flag;
    }

    public static bool IsHexDigit(char c)
    {
        int num = Convert.ToInt32('A');
        int num1 = Convert.ToInt32('0');
        c = char.ToUpper(c);
        int num2 = Convert.ToInt32(c);
        if (num2 >= num && num2 < num + 6)
        {
            return true;
        }
        if (num2 >= num1 && num2 < num1 + 10)
        {
            return true;
        }
        return false;
    }

    public static string ToString(byte[] bytes)
    {
        string str = "";
        for (int i = 0; i < (int)bytes.Length; i++)
        {
            str = string.Concat(str, bytes[i].ToString("X2"));
        }
        return str;
    }
}