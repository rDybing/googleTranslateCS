using System;
using static System.Console;
using Google.Cloud.Translation.V2;

namespace googleTranslateCS {
    class gTrans {
		static string apiKey;
        static void Main(string[] args) {
            bool loop = true;
			apiKey = getInput("Enter API Server Key:");
			string tgtLang = getInput("Enter Language code to translate to (eg: nb for Norwegian Bokmål, en for English):");
			string origLang = getInput("Enter Language code to translate from (eg: nb for Norwegian Bokmål, en for English");
			string text;

			while (loop) {
				text = getInput("Text to translate (type quit to exit):");
				if (text == "quit") {
					loop = false;
				} else {
					try {
						WriteLine(translateText(tgtLang, origLang, text));
					} 
					catch {
						WriteLine("Wrong language code, exiting\n");
						loop = false;
					}
				}
			}
		}

		static string getInput(string s) {
			string res;
			WriteLine(s);
			res = ReadLine();
			return res;
		}

		static string translateText(string toLang, string fromLang, string s) {
            string res;
			TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);
            var response = client.TranslateText(s, toLang, fromLang);
			res = response.TranslatedText;
			return res;
		}
	}
}
