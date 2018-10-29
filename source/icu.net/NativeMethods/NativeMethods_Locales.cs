// Copyright (c) 2018 SIL International
// This software is licensed under the MIT License (http://opensource.org/licenses/MIT)

using System;
using System.Runtime.InteropServices;

namespace Icu
{
	internal static partial class NativeMethods
	{
		private class LocalesMethodsContainer
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
			internal delegate int uloc_getLCIDDelegate([MarshalAs(UnmanagedType.LPStr)]string localeID);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
			internal delegate int uloc_getLocaleForLCIDDelegate(int lcid, IntPtr locale, int localeCapacity, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate IntPtr uloc_getISO3CountryDelegate(
				[MarshalAs(UnmanagedType.LPStr)]string locale);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate IntPtr uloc_getISO3LanguageDelegate(
				[MarshalAs(UnmanagedType.LPStr)]string locale);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_countAvailableDelegate();

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate IntPtr uloc_getAvailableDelegate(int n);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getLanguageDelegate(string localeID, IntPtr language,
				int languageCapacity, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getScriptDelegate(string localeID, IntPtr script,
				int scriptCapacity, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getCountryDelegate(string localeID, IntPtr country,
				int countryCapacity, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getVariantDelegate(string localeID, IntPtr variant,
				int variantCapacity, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getDisplayNameDelegate(string localeID, string inLocaleID,
				IntPtr result, int maxResultSize, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getDisplayLanguageDelegate(string localeID, string displayLocaleID,
				IntPtr result, int maxResultSize, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getDisplayScriptDelegate(string localeID, string displayLocaleID,
				IntPtr result, int maxResultSize, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getDisplayCountryDelegate(string localeID, string displayLocaleID,
				IntPtr result, int maxResultSize, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getDisplayVariantDelegate(string localeID, string displayLocaleID,
				IntPtr result, int maxResultSize, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getNameDelegate(string localeID, IntPtr name,
				int nameCapacity, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_getBaseNameDelegate(string localeID, IntPtr name,
				int nameCapacity, out ErrorCode err);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
			internal delegate int uloc_canonicalizeDelegate(string localeID, IntPtr name,
				int nameCapacity, out ErrorCode err);

			internal uloc_countAvailableDelegate uloc_countAvailable;
			internal uloc_getLCIDDelegate uloc_getLCID;
			internal uloc_getLocaleForLCIDDelegate uloc_getLocaleForLCID;
			internal uloc_getISO3CountryDelegate uloc_getISO3Country;
			internal uloc_getISO3LanguageDelegate uloc_getISO3Language;
			internal uloc_getAvailableDelegate uloc_getAvailable;
			internal uloc_getLanguageDelegate uloc_getLanguage;
			internal uloc_getScriptDelegate uloc_getScript;
			internal uloc_getCountryDelegate uloc_getCountry;
			internal uloc_getVariantDelegate uloc_getVariant;
			internal uloc_getDisplayNameDelegate uloc_getDisplayName;
			internal uloc_getDisplayLanguageDelegate uloc_getDisplayLanguage;
			internal uloc_getDisplayScriptDelegate uloc_getDisplayScript;
			internal uloc_getDisplayCountryDelegate uloc_getDisplayCountry;
			internal uloc_getDisplayVariantDelegate uloc_getDisplayVariant;
			internal uloc_getNameDelegate uloc_getName;
			internal uloc_getBaseNameDelegate uloc_getBaseName;
			internal uloc_canonicalizeDelegate uloc_canonicalize;
		}

		private static LocalesMethodsContainer _LocalesMethods;

		private static LocalesMethodsContainer LocalesMethods =>
			_LocalesMethods ??
			(_LocalesMethods = new LocalesMethodsContainer());

		/// <summary>Get the ICU LCID for a locale</summary>
		public static int uloc_getLCID([MarshalAs(UnmanagedType.LPStr)]string localeID)
		{
			if (LocalesMethods.uloc_getLCID == null)
				LocalesMethods.uloc_getLCID = GetMethod<LocalesMethodsContainer.uloc_getLCIDDelegate>(IcuCommonLibHandle, "uloc_getLCID");
			return LocalesMethods.uloc_getLCID(localeID);
		}

		/// <summary>Gets the ICU locale ID for the specified Win32 LCID value. </summary>
		public static int uloc_getLocaleForLCID(int lcid, IntPtr locale, int localeCapacity, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getLocaleForLCID == null)
				LocalesMethods.uloc_getLocaleForLCID = GetMethod<LocalesMethodsContainer.uloc_getLocaleForLCIDDelegate>(IcuCommonLibHandle, "uloc_getLocaleForLCID");
			return LocalesMethods.uloc_getLocaleForLCID(lcid, locale, localeCapacity, out err);
		}

		/// <summary>Return the ISO 3 char value, if it exists</summary>
		public static IntPtr uloc_getISO3Country(
			[MarshalAs(UnmanagedType.LPStr)]string locale)
		{
			if (LocalesMethods.uloc_getISO3Country == null)
				LocalesMethods.uloc_getISO3Country = GetMethod<LocalesMethodsContainer.uloc_getISO3CountryDelegate>(IcuCommonLibHandle, "uloc_getISO3Country");
			return LocalesMethods.uloc_getISO3Country(locale);
		}

		/// <summary>Return the ISO 3 char value, if it exists</summary>
		public static IntPtr uloc_getISO3Language(
			[MarshalAs(UnmanagedType.LPStr)]string locale)
		{
			if (LocalesMethods.uloc_getISO3Language == null)
				LocalesMethods.uloc_getISO3Language = GetMethod<LocalesMethodsContainer.uloc_getISO3LanguageDelegate>(IcuCommonLibHandle, "uloc_getISO3Language");
			return LocalesMethods.uloc_getISO3Language(locale);
		}

		/// <summary>
		/// Gets the size of the all available locale list.
		/// </summary>
		/// <returns>the size of the locale list </returns>
		public static int uloc_countAvailable()
		{
			if (LocalesMethods.uloc_countAvailable == null)
				LocalesMethods.uloc_countAvailable = GetMethod<LocalesMethodsContainer.uloc_countAvailableDelegate>(IcuCommonLibHandle, "uloc_countAvailable");
			return LocalesMethods.uloc_countAvailable();
		}

		/// <summary>
		/// Gets the specified locale from a list of all available locales.
		/// The return value is a pointer to an item of a locale name array. Both this array
		/// and the pointers it contains are owned by ICU and should not be deleted or written
		/// through by the caller. The locale name is terminated by a null pointer.
		/// </summary>
		/// <param name="n">n  the specific locale name index of the available locale list</param>
		/// <returns>a specified locale name of all available locales</returns>
		public static IntPtr uloc_getAvailable(int n)
		{
			if (LocalesMethods.uloc_getAvailable == null)
				LocalesMethods.uloc_getAvailable = GetMethod<LocalesMethodsContainer.uloc_getAvailableDelegate>(IcuCommonLibHandle, "uloc_getAvailable");
			return LocalesMethods.uloc_getAvailable(n);
		}

		/// <summary>
		/// Gets the language code for the specified locale.
		/// </summary>
		/// <param name="localeID">the locale to get the language code with </param>
		/// <param name="language">the language code for localeID </param>
		/// <param name="languageCapacity">the size of the language buffer to store the language
		/// code with </param>
		/// <param name="err">error information if retrieving the language code failed</param>
		/// <returns>the actual buffer size needed for the language code. If it's greater
		/// than languageCapacity, the returned language code will be truncated</returns>
		public static int uloc_getLanguage(string localeID, IntPtr language,
			int languageCapacity, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getLanguage == null)
				LocalesMethods.uloc_getLanguage = GetMethod<LocalesMethodsContainer.uloc_getLanguageDelegate>(IcuCommonLibHandle, "uloc_getLanguage");
			return LocalesMethods.uloc_getLanguage(localeID, language, languageCapacity, out err);
		}

		/// <summary>
		/// Gets the script code for the specified locale.
		/// </summary>
		/// <param name="localeID">the locale to get the script code with </param>
		/// <param name="script">the script code for localeID </param>
		/// <param name="scriptCapacity">the size of the script buffer to store the script
		/// code with </param>
		/// <param name="err">error information if retrieving the script code failed</param>
		/// <returns>the actual buffer size needed for the script code. If it's greater
		/// than scriptCapacity, the returned script code will be truncated</returns>
		public static int uloc_getScript(string localeID, IntPtr script,
			int scriptCapacity, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getScript == null)
				LocalesMethods.uloc_getScript = GetMethod<LocalesMethodsContainer.uloc_getScriptDelegate>(IcuCommonLibHandle, "uloc_getScript");
			return LocalesMethods.uloc_getScript(localeID, script, scriptCapacity, out err);
		}

		/// <summary>
		/// Gets the country code for the specified locale.
		/// </summary>
		/// <param name="localeID">the locale to get the country code with </param>
		/// <param name="country">the country code for localeID </param>
		/// <param name="countryCapacity">the size of the country buffer to store the country
		/// code with </param>
		/// <param name="err">error information if retrieving the country code failed</param>
		/// <returns>the actual buffer size needed for the country code. If it's greater
		/// than countryCapacity, the returned country code will be truncated</returns>
		public static int uloc_getCountry(string localeID, IntPtr country,
			int countryCapacity, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getCountry == null)
				LocalesMethods.uloc_getCountry = GetMethod<LocalesMethodsContainer.uloc_getCountryDelegate>(IcuCommonLibHandle, "uloc_getCountry");
			return LocalesMethods.uloc_getCountry(localeID, country, countryCapacity, out err);
		}

		/// <summary>
		/// Gets the variant code for the specified locale.
		/// </summary>
		/// <param name="localeID">the locale to get the variant code with </param>
		/// <param name="variant">the variant code for localeID </param>
		/// <param name="variantCapacity">the size of the variant buffer to store the variant
		/// code with </param>
		/// <param name="err">error information if retrieving the variant code failed</param>
		/// <returns>the actual buffer size needed for the variant code. If it's greater
		/// than variantCapacity, the returned variant code will be truncated</returns>
		public static int uloc_getVariant(string localeID, IntPtr variant,
			int variantCapacity, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getVariant == null)
				LocalesMethods.uloc_getVariant = GetMethod<LocalesMethodsContainer.uloc_getVariantDelegate>(IcuCommonLibHandle, "uloc_getVariant");
			return LocalesMethods.uloc_getVariant(localeID, variant, variantCapacity, out err);
		}

		/// <summary>
		/// Gets the full name suitable for display for the specified locale.
		/// </summary>
		/// <param name="localeID">the locale to get the displayable name with</param>
		/// <param name="inLocaleID">Specifies the locale to be used to display the name. In
		/// other words, if the locale's language code is "en", passing Locale::getFrench()
		/// for inLocale would result in "Anglais", while passing Locale::getGerman() for
		/// inLocale would result in "Englisch".  </param>
		/// <param name="result">the displayable name for localeID</param>
		/// <param name="maxResultSize">the size of the name buffer to store the displayable
		/// full name with</param>
		/// <param name="err">error information if retrieving the displayable name failed</param>
		/// <returns>the actual buffer size needed for the displayable name. If it's greater
		/// than variantCapacity, the returned displayable name will be truncated.</returns>
		public static int uloc_getDisplayName(string localeID, string inLocaleID,
			IntPtr result, int maxResultSize, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getDisplayName == null)
				LocalesMethods.uloc_getDisplayName = GetMethod<LocalesMethodsContainer.uloc_getDisplayNameDelegate>(IcuCommonLibHandle, "uloc_getDisplayName");
			return LocalesMethods.uloc_getDisplayName(localeID, inLocaleID, result, maxResultSize, out err);
		}

		public static int uloc_getDisplayLanguage(string localeID, string displayLocaleID,
			IntPtr result, int maxResultSize, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getDisplayLanguage == null)
				LocalesMethods.uloc_getDisplayLanguage = GetMethod<LocalesMethodsContainer.uloc_getDisplayLanguageDelegate>(IcuCommonLibHandle, "uloc_getDisplayLanguage");
			return LocalesMethods.uloc_getDisplayLanguage(localeID, displayLocaleID, result, maxResultSize, out err);
		}

		public static int uloc_getDisplayScript(string localeID, string displayLocaleID,
			IntPtr result, int maxResultSize, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getDisplayScript == null)
				LocalesMethods.uloc_getDisplayScript = GetMethod<LocalesMethodsContainer.uloc_getDisplayScriptDelegate>(IcuCommonLibHandle, "uloc_getDisplayScript");
			return LocalesMethods.uloc_getDisplayScript(localeID, displayLocaleID, result, maxResultSize, out err);
		}

		public static int uloc_getDisplayCountry(string localeID, string displayLocaleID,
			IntPtr result, int maxResultSize, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getDisplayCountry == null)
				LocalesMethods.uloc_getDisplayCountry = GetMethod<LocalesMethodsContainer.uloc_getDisplayCountryDelegate>(IcuCommonLibHandle, "uloc_getDisplayCountry");
			return LocalesMethods.uloc_getDisplayCountry(localeID, displayLocaleID, result, maxResultSize, out err);
		}

		public static int uloc_getDisplayVariant(string localeID, string displayLocaleID,
			IntPtr result, int maxResultSize, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getDisplayVariant == null)
				LocalesMethods.uloc_getDisplayVariant = GetMethod<LocalesMethodsContainer.uloc_getDisplayVariantDelegate>(IcuCommonLibHandle, "uloc_getDisplayVariant");
			return LocalesMethods.uloc_getDisplayVariant(localeID, displayLocaleID, result, maxResultSize, out err);
		}

		public static int uloc_getName(string localeID, IntPtr name,
			int nameCapacity, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getName == null)
				LocalesMethods.uloc_getName = GetMethod<LocalesMethodsContainer.uloc_getNameDelegate>(IcuCommonLibHandle, "uloc_getName");
			return LocalesMethods.uloc_getName(localeID, name, nameCapacity, out err);
		}

		public static int uloc_getBaseName(string localeID, IntPtr name,
			int nameCapacity, out ErrorCode err)
		{
			if (LocalesMethods.uloc_getBaseName == null)
				LocalesMethods.uloc_getBaseName = GetMethod<LocalesMethodsContainer.uloc_getBaseNameDelegate>(IcuCommonLibHandle, "uloc_getBaseName");
			return LocalesMethods.uloc_getBaseName(localeID, name, nameCapacity, out err);
		}

		public static int uloc_canonicalize(string localeID, IntPtr name,
			int nameCapacity, out ErrorCode err)
		{
			if (LocalesMethods.uloc_canonicalize == null)
				LocalesMethods.uloc_canonicalize = GetMethod<LocalesMethodsContainer.uloc_canonicalizeDelegate>(IcuCommonLibHandle, "uloc_canonicalize");
			var res = LocalesMethods.uloc_canonicalize(localeID, name, nameCapacity, out err);
			return res;
		}
	}
}
