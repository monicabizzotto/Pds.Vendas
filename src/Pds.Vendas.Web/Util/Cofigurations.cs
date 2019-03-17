using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Util
{
	public class Configurations
	{
		private string ConfigurationDirectory { get; }
		private string ConfigurationFile { get; }
		private IConfigurationBuilder _builder { get; }

		public Configurations()
			: this(Directory.GetCurrentDirectory(), "appsettings.json")
		{ }
		public Configurations(string configurationFile)
			: this(Directory.GetCurrentDirectory(), configurationFile)
		{ }
		public Configurations(string configurationDirectory, string configurationFile)
		{
			ConfigurationFile = configurationFile;
			ConfigurationDirectory = configurationDirectory;

			_builder = new ConfigurationBuilder()
				.SetBasePath(ConfigurationDirectory)
				.AddJsonFile(ConfigurationFile);

			Configuration = _builder.Build();
		}

		public IConfiguration Configuration { get; private set; }

		public string GetConfiguration(string key)
		{
			return Configuration[key];
		}
	}
}
