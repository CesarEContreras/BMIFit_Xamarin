using System;
namespace BMIFit.Helpers
{
    public class Settings
    {
        private static readonly Lazy<Settings> lazy = new Lazy<Settings>(() => new Settings());

        private Settings()
        {
        }

        public static Settings Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public string AppCenterTokenIOS
        {
            get => string.Empty;
        }

        public string AppCenterTokenAndroid
        {
            get => string.Empty;
        }
    }
}
