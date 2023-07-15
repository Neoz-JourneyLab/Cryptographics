using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace TCP_Crypto {
	public class User {
		public string id;
		public string nick;
		public string public_RSA;
		public byte[] vpn_aes;
		public byte[] vpn_iv;
	}

	public class Roam {
		public string route;
		public string payload;
	}

	public static class BouncyCastle {
		public static byte[] GenerateRandomBytes(int length) {
			byte[] randomBytes = new byte[length];
			SecureRandom secureRandom = new();
			secureRandom.NextBytes(randomBytes);
			return randomBytes;
		}

		public static byte[] ExportPrivateKey(AsymmetricKeyParameter privateKey) {
			StringWriter stringWriter = new StringWriter();
			PemWriter pemWriter = new PemWriter(stringWriter);
			pemWriter.WriteObject(privateKey);
			pemWriter.Writer.Flush();

			string privateKeyPem = stringWriter.ToString();
			byte[] privateKeyBytes = Encoding.ASCII.GetBytes(privateKeyPem);

			return privateKeyBytes;
		}

		public static AsymmetricKeyParameter ImportPrivateKey(byte[] privateKeyBytes) {
			string privateKeyPem = Encoding.ASCII.GetString(privateKeyBytes);
			TextReader reader = new StringReader(privateKeyPem);
			PemReader pemReader = new PemReader(reader);

			object privateKeyObject = pemReader.ReadObject();

			if (privateKeyObject is AsymmetricCipherKeyPair keyPair) {
				RsaPrivateCrtKeyParameters privateKey = (RsaPrivateCrtKeyParameters)keyPair.Private;
				return privateKey;
			} else if (privateKeyObject is AsymmetricKeyParameter privateKeyParam) {
				return privateKeyParam;
			} else {
				throw new ArgumentException("Invalid private key format.");
			}
		}

		public static byte[] RSA_Encrypt(byte[] buffer, byte[] publicKey) {
			RsaEngine rsaEngine = new RsaEngine();
			AsymmetricKeyParameter publicKeyRestored = PublicKeyFactory.CreateKey(publicKey);
			rsaEngine.Init(true, publicKeyRestored);

			byte[] ciphertextBytes = rsaEngine.ProcessBlock(buffer, 0, buffer.Length);

			return ciphertextBytes;
		}

		public static byte[] RSA_Decrypt(byte[] cipher, AsymmetricKeyParameter privateKey) {
			RsaEngine rsaEngine = new RsaEngine();
			rsaEngine.Init(false, privateKey);

			byte[] decryptedBytes = rsaEngine.ProcessBlock(cipher, 0, cipher.Length);

			return decryptedBytes;
		}

		public static byte[] AES_Encrypt(byte[] buffer, byte[] key, byte[] iv) {
			IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");
			cipher.Init(true, new ParametersWithIV(new KeyParameter(key), iv));

			byte[] ciphertextBytes = cipher.DoFinal(buffer);

			return ciphertextBytes;
		}

		public static byte[] AES_Decrypt(byte[] ciphertext, byte[] key, byte[] iv) {
			IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");
			cipher.Init(false, new ParametersWithIV(new KeyParameter(key), iv));

			byte[] decryptedBytes = cipher.DoFinal(ciphertext);

			return decryptedBytes;
		}
	}
}