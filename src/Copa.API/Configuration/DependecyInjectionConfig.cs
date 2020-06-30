using API.Copa.Business.Interfaces;
using API.Copa.Business.Notificacoes;
using API.Copa.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copa.API.Configuration
{
	public static  class DependecyInjectionConfig
	{
		public static IServiceCollection ResolveDependecies(this IServiceCollection services)
		{
			services.AddScoped<INotificador, Notificador>();
			services.AddScoped<ICopaService, CopaService>();
			services.AddScoped<IPrimeiraFaseService, PrimeiraFaseService>();
			services.AddScoped<IFaseFinalService, FaseFinalService>();
			services.AddScoped<IJogoService, JogoService>();

			return services;
		}
	}
}
