using System;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Translation
{
    public class Languages
    {
        private string _json;

        public Languages(string force_xx_xx = null)
        {
            // System locale
            string format_xx_xx = CultureInfo.CurrentUICulture.Name;

            // Base url
            string url_resources = "https://raw.githubusercontent.com/TW2/translations/main/LANG/";

            // Search for json
            string locale = force_xx_xx == null ? format_xx_xx.ToLower() : force_xx_xx.ToLower();
            string url = url_resources + locale + ".json";

            try{
                _json = DownloadFile(url);
            }catch(Exception){
                _json = null;
            }
        }

        private string DownloadFile(string url){

            // Get file content from url
            string content = null;
            using (HttpClient client = new HttpClient()){
                content = client.GetStringAsync(url).Result;
            }
            
            return content;
        }
        
        public string TryGet(string key){

            // If not null then try to get a value
            if(_json != null){
                JObject o = JObject.Parse(_json);
                string result = (string)o[key];
                return result;
            }
            return null;
        }
    }
}