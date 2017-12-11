﻿using Crossroads.Web.Common.Configuration;

/*
 * This is an extension method so that we don't have to define the
 * configuration "App Code" in each file.
 * This could be moved to web-common so that you could instantiate you
 * app code in a single place
 */

namespace MinistryPlatform.Configuration
{
    public static class ConfigurationWrapperExtensions
    {
        public static int? GetAppMpConfigIntValue(this IConfigurationWrapper configWrapper, string key)
        {
          return configWrapper.GetMpConfigIntValue("CRDS-FINANCE", key);
        }

        public static string GetAppMpConfigValue(this IConfigurationWrapper configWrapper, string key)
        {
          return configWrapper.GetMpConfigValue("CRDS-FINANCE", key);
        }
    }
}
