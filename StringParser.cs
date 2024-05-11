using System.Diagnostics;

namespace Parser {

	public class StringParser {
		const string strStartNote = "/s";

		Dictionary<string, string[]> fileVars = new Dictionary<string, string[]> ();

		// constructor
		public StringParser (string s) {
			// every line that has a name value pair
			var vStrings = s.Split (';');
			
			for (int i = 0; i < vStrings.Length; i++) {
				// splits the the current name value pair into an array with the first element being the name, and the second being the value
				var nameAndVars = vStrings[i].Split ('=', 2);
				nameAndVars[0] = RemoveWhiteSpace(RemoveEnclosed(nameAndVars[0], COMMENT_START_SIGN, '\n'));
			
				if (nameAndVars.Length < 2) { // makes sure it split properly
					if (nameAndVars[0].Length > 0) { // it the substring is empty, then don't print the error message
						Debug.WriteLine ($"Error in statement {nameAndVars[0]}\nYou've ether forgotten an '='");
					}
			
					continue;
				}
			
				// gets the name
				string name = nameAndVars[0];
				string[] vars; // declares the variables
				int strStart = nameAndVars[1].IndexOf (LITERAL_START_SIGN); // if this is a string literal, then it will get the start of the string literal
			
				if (strStart != -1) { // if it is a string literal, it will cut everything before the start
					vars = new string[] { nameAndVars[1].Substring(strStart+LITERAL_START_SIGN.Length) };
				}
				else { // if not it will split it appart where ever a ',' appears and remove all of the white space
					vars = RemoveWhiteSpace(nameAndVars[1]).Split(',');
				}
				fileVars.Add (name, vars); // adds it to the dictionary
			}

		}
		
		// gets ints
		public int[] GetAsInts (string name) {
			if (!fileVars.ContainsKey (name)) {
				Debug.WriteLine ($"Could not fine value {name}");
				return new int[0];
			}

			var vals = fileVars[name];
			int[] res = new int[vals.Length];
			for (int i = 0; i < vals.Length; i++) {
				res[i] = ParseInt (vals[i]);
			}
			return res;
		}

		public int GetAsIntOrDef (string name, int def) {
			var res = GetAsInts (name);
			return FirstOrDefault (res, def);
		}

		// gets floats
		public float[] GetAsFloats (string name) {
			if (!fileVars.ContainsKey (name)) {
				Debug.WriteLine ($"Could not fine value {name}");
				return new float[0];
			}

			var vals = fileVars[name];
			float[] res = new float[vals.Length];
			for (int i = 0; i < vals.Length; i++) {
				res[i] = ParseFloat (vals[i]);
			}
			return res;
		}

		public float GetAsFloatOrDef (string name, float def) {
			var res = GetAsFloats (name);
			return FirstOrDefault (res, def);
		}

		// gets strings
		public string[] GetAsStrings (string name) {
			if (!fileVars.ContainsKey (name)) {
				Debug.WriteLine ($"Could not fine value {name}");
				return new string[0];
			}

			return fileVars[name];
		}

		public string GetAsStringOrDef (string name, string def) {
			var res = GetAsStrings (name);
			return FirstOrDefault (res, def);
		}

		// gets the first item in an array or if the array has a length of zero, it will return null
		public static T FirstOrDefault <T> (T[] v, T def) {
			if (v.Length >= 1) return v[0];
			return def;
		}

		// number parsing functions
		public static int ParseInt (string s) {
			int num = 0;

			for (int i = 0; i < s.Length; i++) {
				if ('0' <= s[i] && s[i] <= '9') {
					num = 10 * num + (s[i]-'0');
				} else if (s[i] == '.') {
					break;
				}
			}

			return num;
		}

		public static float ParseFloat (string s) {
			int i;
			float num = 0;
			for (i = 0; i < s.Length; i++) {
				if ('0' <= s[i] && s[i] <= '9') {
					num = 10 * num + (s[i]-'0');
				}
				else if (s[i] == '.') {
					break;
				}
			}

			if (i >= s.Length)
				return num;

			if (s[i] != '.')
				return num;

			float mult = 0.1f;
			for (i = i+1; i < s.Length; i++) {
				if ('0' <= s[i] && s[i] <= '9') {
					num += (s[i] - '0') * mult;
					mult *= 0.1f;
				}
			}

			return num;
		}

		// removes white space like spaces, new lines, and tabs
		public static string RemoveWhiteSpace (string s) {
			return s.Replace (" ", "").Replace("\n", "").Replace("\t", "");
		}

		// looks for two characters, and removes any character between them
		public static string RemoveEnclosed (string s, char opening, char closing) {
			string s2 = s;
			while (true) {
				// finds the opening character
				int i1 = s2.IndexOf (opening);
				if (i1 <= -1) break; 
				string before = s2.Substring (0, i1);
		
				// finds the ending character
				int i2 = s2.IndexOf (closing, i1+1);
				if (i2 <= -1) { // returns the before portion if it can't find an ending character
					return before;
				}
				string after = s2.Substring (i2+1);
		
				// stitches together the text before and after then enclosed characters
				s2 = before + after;
			}

			return s2;
		}
		
		public static string Serialize (string name, string val) {
			return $"{name} = {val};";
		}

		public static string SerializeAsStringLiteral (string name, string val) {
			return $"{name} = {strStartNote}{val};";
		}


		// converts an array to a string that follows the parsers syntax
		public static string ArrayToString<T> (T[] a) {
			string res = $"{a[0]}";

			for (int i = 1; i < a.Length; i++) {
				res += $", {a[i]}";
			}

			return res;
		}
	}

	
}
