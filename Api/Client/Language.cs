using AmongUs.Api.Loader;
using AmongUs.Api.Loader.Internal;
using AmongUs.Api.Registry;

namespace AmongUs.Api
{
	[Side(ModSide.Client)]
	public static class Language
	{
		public static string Translate(string modId, string key)
		{
			const string englishLanguage = "English";
			var wrappedKey = new RegistryKey(modId, key);
			var language = ApiWrapper.Instance.Language;
			if (TryTranslate(wrappedKey, language, out var result)) return result;
			if (language == englishLanguage) return key;
			TryTranslate(wrappedKey, englishLanguage, out var englishResult);
			return englishResult ?? key;
		}

		private static bool TryTranslate(RegistryKey key, string language, out string result)
		{
			if (!ModLoader.Instance.Mods.ContainsKey(key.ModId))
			{
				result = null;
				return false;
			}

			var mod = ModLoader.Instance.Mods[key.ModId];

			if (!mod.LanguageKeys.ContainsKey(language))
			{
				result = null;
				return false;
			}

			var languageKeys = mod.LanguageKeys[language];
			if (languageKeys.ContainsKey(key.Name))
			{
				result = languageKeys[key.Name];
				return true;
			}

			result = null;
			return false;
		}
	}
}
