﻿// Author : Gilles Macabies Solution : DataGridFilter Projet : DataGridFilter File : Loc.cs Created : 18/12/2019

using System;
using System.Collections.Generic;
using System.Globalization;
// ReSharper disable UnusedMember.Global

namespace FilterDataGrid
{
    public enum Local
    {
        Chinese,
        Dutch,
        English,
        EnglishGB,
        French,
        German,
        Italian,
        Polish,
        Russian
    }

    public class Loc
    {
        #region Private Fields

        private Local language;

        // culture name(used for dates)
        private static readonly Dictionary<Local, string> CultureNames = new Dictionary<Local, string>
        {
            { Local.Chinese, "zh-Hans" },
            { Local.Dutch,   "nl-NL" },
            { Local.English, "en-US" },
            { Local.EnglishGB, "en-GB" },
            { Local.French,  "fr-FR" },
            { Local.German,  "de-DE" },
            { Local.Italian, "it-IT" },
            { Local.Polish,  "pl-PL" },
            { Local.Russian, "ru-RU" },
        };

        /// <summary>
        /// Translation dictionary
        /// </summary>
        private static readonly Dictionary<string, Dictionary<Local, string>> Translation =
            new Dictionary<string, Dictionary<Local, string>>
            {
                {
                    "All", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "(全选)" },
                        { Local.Dutch,   "(Alles selecteren)" },
                        { Local.English, "(Select all)" },
                        { Local.EnglishGB, "(Select all)" },
                        { Local.French,  "(Sélectionner tout)" },
                        { Local.German,  "(Alle auswählen)" },
                        { Local.Italian, "(Seleziona tutto)" },
                        { Local.Polish, "(Zaznacz wszystkie)" },
                        { Local.Russian, "(Выбрать все)" }
                    }
                },
                {
                    "Empty", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "(空白)" },
                        { Local.Dutch,   "(Leeg)" },
                        { Local.English, "(Blank)" },
                        { Local.EnglishGB, "(Blank)" },
                        { Local.French,  "(Vides)" },
                        { Local.German,  "(Leer)" },
                        { Local.Italian, "(Vuoto)" },
                        { Local.Polish, "(Pusty)" },
                        { Local.Russian, "(Заготовки)" }
                    }
                },
                {
                    "Clear", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "清除过滤器 \"{0}\"" },
                        { Local.Dutch,   "Filter \"{0}\" verwijderen" },
                        { Local.English, "Clear filter \"{0}\"" },
                        { Local.EnglishGB, "Clear filter \"{0}\"" },
                        { Local.French,  "Effacer le filtre \"{0}\"" },
                        { Local.German,  "Filter löschen \"{0}\"" },
                        { Local.Italian, "Cancella filtro \"{0}\"" },
                        { Local.Polish, "Wyczyść filtr \"{0}\"" },
                        { Local.Russian, "Очистить фильтр \"{0}\"" }
                    }
                },

                {
                    "Contains", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "搜索(包含)" },
                        { Local.Dutch,   "Zoek (bevat)" },
                        { Local.English, "Search (contains)" },
                        { Local.EnglishGB, "Search (contains)" },
                        { Local.French,  "Rechercher (contient)" },
                        { Local.German,  "Suche (enthält)" },
                        { Local.Italian, "Cerca (contiene)" },
                        { Local.Polish, "Szukaj (zawiera)" },
                        { Local.Russian, "Искать (содержит)" }
                    }
                },

                {
                    "StartsWith", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "搜索 (来自)" },
                        { Local.Dutch,   "Zoek (beginnen met)" },
                        { Local.English, "Search (startswith)" },
                        { Local.EnglishGB, "Search (startswith)" },
                        { Local.French,  "Rechercher (commence par)" },
                        { Local.German,  "Suche (beginnen mit)" },
                        { Local.Italian, "Cerca (inizia con)" },
                        { Local.Polish, "Szukaj (zaczyna się od)" },
                        { Local.Russian, "Искать (hачни с)" }
                    }
                },

                {
                    "Toggle", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "切換包含/開始於" },
                        { Local.Dutch,   "Toggle bevat/begint met" },
                        { Local.English, "Toggle contains/startswith" },
                        { Local.EnglishGB, "Toggle contains/startswith" },
                        { Local.French,  "Basculer contient/commence par" },
                        { Local.German,  "Toggle enthält/beginnt mit" },
                        { Local.Italian, "Toggle contiene/inizia con" },
                        { Local.Polish,  "Przełącz zawiera/zaczyna się od" },
                        { Local.Russian, "Переключить содержит/начинается с" }
                    }
                },

                {
                    "Ok", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "确定" },
                        { Local.Dutch,   "Ok" },
                        { Local.English, "Ok" },
                        { Local.EnglishGB, "Ok" },
                        { Local.French,  "Ok" },
                        { Local.German,  "Ok" },
                        { Local.Italian, "Ok" },
                        { Local.Polish,  "Ok" },
                        { Local.Russian, "Ok" }
                    }
                },
                {
                    "Cancel", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "取消" },
                        { Local.Dutch,   "Annuleren" },
                        { Local.English, "Cancel" },
                        { Local.EnglishGB, "Cancel" },
                        { Local.French,  "Annuler" },
                        { Local.German,  "Abbrechen" },
                        { Local.Italian, "Annulla" },
                        { Local.Polish,  "Anuluj" },
                        { Local.Russian, "Отмена" }
                    }
                },
                {
                    "Status", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "{0:n0} 找到了 {1:n0} 条记录" },
                        { Local.Dutch,   "{0:n0} rij(en) gevonden op {1:n0}" },
                        { Local.English, "{0:n0} record(s) found on {1:n0}" },
                        { Local.EnglishGB, "Showing {0:n0} record(s) of {1:n0}" },
                        { Local.French,  "{0:n0} enregistrement(s) trouvé(s) sur {1:n0}" },
                        { Local.German,  "{0:n0} zeilen angezeigt von {1:n0}" },
                        { Local.Italian, "{0:n0} oggetti trovati su {1:n0}" },
                        { Local.Polish,  "{0:n0} rekord(y) znaleziony(e) w {1:n0}" },
                        { Local.Russian, "{0:n0} записей найдено на {1:n0}" }
                    }
                },
                {
                    "ElapsedTime", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "经过时间{0:mm}:{0:ss}.{0:ff}" },
                        { Local.Dutch,   "Verstreken tijd {0:mm}:{0:ss}.{0:ff}" },
                        { Local.English, "Elapsed time {0:mm}:{0:ss}.{0:ff}" },
                        { Local.EnglishGB, "Elapsed time {0:mm}:{0:ss}.{0:ff}" },
                        { Local.French,  "Temps écoulé {0:mm}:{0:ss}.{0:ff}" },
                        { Local.German,  "Verstrichene Zeit {0:mm}:{0:ss}.{0:ff}" },
                        { Local.Italian, "Tempo trascorso {0:mm}:{0:ss}.{0:ff}" },
                        { Local.Polish,  "Zajęło {0:mm}:{0:ss}.{0:ff}" },
                        { Local.Russian, "Пройденное время {0:mm}:{0:ss}.{0:ff}" }
                    }
                },
                {
                    "Neutral", new Dictionary<Local, string>
                    {
                        { Local.Chinese, "{0}" },
                        { Local.Dutch,   "{0}" },
                        { Local.English, "{0}" },
                        { Local.EnglishGB, "{0}" },
                        { Local.French,  "{0}" },
                        { Local.German,  "{0}" },
                        { Local.Italian, "{0}" },
                        { Local.Polish,  "{0}" },
                        { Local.Russian, "{0}" }
                    }
                }
            };

        #endregion Private Fields

        #region Constructors

        public Loc()
        {
            Language = Local.English;
        }

        #endregion Constructors

        #region Public Properties

        public Local Language
        {
            get => language;
            set
            {
                language = value;
                Culture = new CultureInfo(CultureNames[value]);
            }
        }

        public CultureInfo Culture { get; private set; }

        public string CultureName => CultureNames[Language];

        public string LanguageName => Enum.GetName(typeof(Local), Language);

        public string All => Translate("All");

        public string Cancel => Translate("Cancel");

        public string Clear => Translate("Clear");

        public string Contains => Translate("Contains");

        public string ElapsedTime => Translate("ElapsedTime");

        public string Empty => Translate("Empty");

        public string Ok => Translate("Ok");

        public string StartsWith => Translate("StartsWith");

        public string Status => Translate("Status");

        public string Toggle => Translate("Toggle");

        public string Neutral => Translate("Neutral");

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Translated into the language
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string Translate(string key)
        {
            return Translation.ContainsKey(key) && Translation[key].ContainsKey(Language)
                ? Translation[key][Language]
                : "unknow";
        }

        #endregion Private Methods
    }
}