﻿using Hub.API.Options;
using Hub.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.API.Installers
{
    public class DBInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ChannelsDatabaseSettings>(
                configuration.GetSection(nameof(ChannelsDatabaseSettings)));
            services.Configure<UsersDatabaseSettings>(
                configuration.GetSection(nameof(UsersDatabaseSettings)));

            services.Configure<NotificationsDatabaseSettings>(
                configuration.GetSection(nameof(NotificationsDatabaseSettings)));

            services.AddSingleton<INotificationsDatabaseSettings>(sp => 
                                sp.GetRequiredService<IOptions<NotificationsDatabaseSettings>>().Value);

            services.AddSingleton<IChannelsDatabaseSettings>(sp =>
                                sp.GetRequiredService<IOptions<ChannelsDatabaseSettings>>().Value);

            services.AddSingleton<IUsersDatabaseSettings>(sp =>
                    sp.GetRequiredService<IOptions<UsersDatabaseSettings>>().Value);

            services.AddSingleton<IChartsServices, ChartsServices>();
            services.AddSingleton<IChannelsService, ChannelsService>();
            services.AddSingleton<INotificationsService, NotificationsService>();
        }
    }
}
