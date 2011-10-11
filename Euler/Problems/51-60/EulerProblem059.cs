using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Problems {
	public class EulerProblem059 : Problem {
		public EulerProblem059()
			: base(null, null, null) {
			SolutionResponse = 107359;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			using (System.IO.StreamReader file = new System.IO.StreamReader("..\\..\\..\\InputFiles\\cipher1.txt")) {
				while (!file.EndOfStream) {

					var text = file.ReadLine();
					var cipherTextStringASCII = text.Split(new char[] { ',' });
					var cipherTextIntASCII = cipherTextStringASCII.Select(Int32.Parse).ToList();
					var cipherTextIsEnglish = cipherTextIntASCII.Select(Cipher.IsEnglish).ToList();
					if (Logging)
						Console.WriteLine(cipherTextIsEnglish.Aggregate("", (current, c) => current + ", " + c.ToString()));

					int count = cipherTextIntASCII.Count();
					foreach (var key in new KeyIterator()) {
						var plainText = "";
						var plainTextSum = 0;
						var allEnglish = true;
						for (int i = 0; i < count; i++) {
							if (Logging)
								Console.WriteLine(key);

							int keyByte = (i + 1) % 3 == 1 ? key.First
													: (i + 1) % 3 == 2 ? key.Second : key.Third;

							int plainTextASCII = cipherTextIntASCII[i] ^ keyByte;
							if (!Cipher.IsEnglish(plainTextASCII)) {
								allEnglish = false;
								break;
							}

							plainTextSum += plainTextASCII;
							plainText += (char)plainTextASCII;
						}
						if (allEnglish) {
							Console.WriteLine(plainText);
							return plainTextSum;
						}
					}

				}
			}
			return 0;
		}
	}

	public static class Cipher {
		public static Func<int, bool> IsEnglish = (c) => IsAlpha(c) || IsNumeric(c) || IsPunctuation(c);
		public static readonly Func<int, bool> IsAlpha = (c) => (c >= 65 && c <= 90) || (c >= 97 && c <= 122);
		static readonly Func<int, bool> IsNumeric = (c) => (c >= 48 && c <= 57);
		static readonly Func<int, bool> IsPunctuation = (c) => c == 13 || c == 63 || c == 96 || c == 123 || c == 125 || (c >= 32 && c <= 34) || (c >= 38 && c <= 41) || (c >= 44 && c <= 46) || (c >= 58 && c <= 59);
	}

	public class CipherKey {
		public int First { get; set; }
		public int Second { get; set; }
		public int Third { get; set; }

		public override string ToString() {
			return String.Format("^{0}.{1}.{2}^", (char)First, (char)Second, (char)Third);
		}
	}

	public class KeyIterator : IEnumerable<CipherKey> {
		private const int start = 97;
		public IEnumerator<CipherKey> GetEnumerator() {
			for (int i = start; i <= 122; i++) {
				if (!Cipher.IsAlpha(i)) continue;
				for (int j = start; j <= 122; j++) {
					if (!Cipher.IsAlpha(j)) continue;
					for (int k = start; k <= 122; k++) {
						if (!Cipher.IsAlpha(k)) continue;
						yield return new CipherKey { First = i, Second = j, Third = k };
					}
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
	}
}
