﻿using System.Configuration;

namespace TwMS_Helper
{
    class ConfigAppSettings
    {
        public static void SetValue(string key, string value)
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = string.Format("{0}\\Config.xml", System.Environment.CurrentDirectory);
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                if (value != null)
                    config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                if (value == null)
                    config.AppSettings.Settings.Remove(key);
                else
                    config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetValue(string key)
        {
            return GetValue(key, string.Empty);
        }

        public static string GetValue(string key, string def)
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = string.Format("{0}\\Config.xml", System.Environment.CurrentDirectory);
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key] == null ? def : config.AppSettings.Settings[key].Value;
        }
    }
}
