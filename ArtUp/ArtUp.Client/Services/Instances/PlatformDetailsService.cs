using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.Client.Models;
using ArtUp.Client.Services.Interfaces;
using System.Configuration;
using System.Web.Configuration;

namespace ArtUp.Client.Services.Instances
{
    public class PlatformDetailsService : IPlatformDetailsService
    {
        public PlatformDetailsViewModel GetSettings()
        {
            var tax = byte.Parse(ConfigurationManager.AppSettings["Tax"]);
            var com = byte.Parse(ConfigurationManager.AppSettings["Comission"]);
            var sum = int.Parse(ConfigurationManager.AppSettings["Sum"]);

            return new PlatformDetailsViewModel { IncomeTax = tax, MaxFreeAmount = sum, PlatformComission = com };
        }

        public void SetSetting(PlatformDetailsViewModel model)
        {
            Configuration myConfiguration;
            myConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            myConfiguration.AppSettings.Settings.Remove("Tax");
            myConfiguration.AppSettings.Settings.Add("Tax", model.IncomeTax.ToString());
            myConfiguration.AppSettings.Settings.Remove("Comission");
            myConfiguration.AppSettings.Settings.Add("Comission", model.PlatformComission.ToString());
            myConfiguration.AppSettings.Settings.Remove("Sum");
            myConfiguration.AppSettings.Settings.Add("Sum", model.MaxFreeAmount.ToString());
            myConfiguration.Save();
        }
    }
}