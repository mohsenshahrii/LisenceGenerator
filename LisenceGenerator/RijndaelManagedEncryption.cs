// Decompiled with JetBrains decompiler
// Type: LisenceGenerator.RijndaelManagedEncryption
// Assembly: LisenceGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9BEF78-E796-4830-BCFC-0A99DC7C5626
// Assembly location: D:\fADAKrEPOSITORYiNFORMATION_14000622\ACVM\LisenceGenerator.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace LisenceGenerator
{
  public class RijndaelManagedEncryption
  {
    internal const string Inputkey = "560A18CD-6346-4CF0-A2E8-671F9B6B9EA9";

    public static string EncryptRijndael(string text, string salt)
    {
      if (string.IsNullOrEmpty(text))
        throw new ArgumentNullException(nameof (text));
      RijndaelManaged rijndaelManaged = RijndaelManagedEncryption.NewRijndaelManaged(salt);
      ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
      MemoryStream memoryStream = new MemoryStream();
      using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
      {
        using (StreamWriter streamWriter = new StreamWriter((Stream) cryptoStream))
          streamWriter.Write(text);
      }
      return Convert.ToBase64String(memoryStream.ToArray());
    }

    public static bool IsBase64String(string base64String)
    {
      base64String = base64String.Trim();
      return base64String.Length % 4 == 0 && Regex.IsMatch(base64String, "^[a-zA-Z0-9\\+/]*={0,3}$", RegexOptions.None);
    }

    public static string DecryptRijndael(string cipherText, string salt)
    {
      if (string.IsNullOrEmpty(cipherText))
        throw new ArgumentNullException(nameof (cipherText));
      if (!RijndaelManagedEncryption.IsBase64String(cipherText))
        throw new Exception("cipherText encoding");
      RijndaelManaged rijndaelManaged = RijndaelManagedEncryption.NewRijndaelManaged(salt);
      ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
      string end;
      using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipherText)))
      {
        using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
        {
          using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
            end = streamReader.ReadToEnd();
        }
      }
      return end;
    }

    private static RijndaelManaged NewRijndaelManaged(string salt)
    {
      Rfc2898DeriveBytes rfc2898DeriveBytes = salt != null ? new Rfc2898DeriveBytes("560A18CD-6346-4CF0-A2E8-671F9B6B9EA9", Encoding.ASCII.GetBytes(salt)) : throw new ArgumentNullException(nameof (salt));
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
      rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
      return rijndaelManaged;
    }
  }
}
