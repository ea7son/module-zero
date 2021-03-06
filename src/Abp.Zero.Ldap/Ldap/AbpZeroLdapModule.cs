﻿using System.Reflection;
using Abp.Localization.Sources;
using Abp.Localization.Sources.Xml;
using Abp.Modules;
using Abp.Zero.Ldap.Configuration;

namespace Abp.Zero.Ldap
{
    /// <summary>
    /// This module extends module zero to add LDAP authentication.
    /// </summary>
    [DependsOn(typeof (AbpZeroCoreModule))]
    public class AbpZeroLdapModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.Sources.Extensions.Add(
                new LocalizationSourceExtensionInfo(
                    AbpZeroConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Abp.Zero.Ldap.Localization.Source")
                    )
                );

            Configuration.Settings.Providers.Add<LdapSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
