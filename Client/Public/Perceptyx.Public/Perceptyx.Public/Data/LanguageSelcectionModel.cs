using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Public.Data
{
    class LanguageSelectionModel
    {
        public string Language { get; set; }
        public string CountryName { get; set; }
        public string ImageName { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public static List<LanguageSelectionModel> GetLanguages()
        {
            var languages = new List<LanguageSelectionModel>();

            languages.Add(new LanguageSelectionModel
            {
                Language = "普通话",
                CountryName = "China",
                ImageName = ""
            });

            languages.Add(new LanguageSelectionModel
            {
                Language = "English",
                CountryName = "England",
                ImageName = ""
            });

            languages.Add(new LanguageSelectionModel
            {
                Language = "日本語",
                CountryName = "Japan",
                ImageName = ""
            });

            languages.Add(new LanguageSelectionModel
            {
                Language = "русский",
                CountryName = "Russia",
                ImageName = ""
            });

            languages.Add(new LanguageSelectionModel
            {
                Language = "Español",
                CountryName = "Spain",
                ImageName = ""
            });

            languages.Add(new LanguageSelectionModel
            {
                Language = "ไทย",
                CountryName = "Thailand",
                ImageName = ""
            });

            return languages;
        }
    }
}
