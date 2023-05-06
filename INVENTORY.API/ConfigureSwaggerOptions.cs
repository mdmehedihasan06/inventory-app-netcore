using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace INVENTORY.API
{
	public class ConfigureSwaggerOptions
	: IConfigureNamedOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider _provider;

		public ConfigureSwaggerOptions(
			IApiVersionDescriptionProvider provider)
		{
			_provider = provider;
		}

		/// <summary>
		/// Configure each API discovered for Swagger Documentation
		/// </summary>
		/// <param name="options"></param>
		public void Configure(SwaggerGenOptions options)
		{
			// add swagger document for every API version discovered
			foreach (var description in _provider.ApiVersionDescriptions)
			{
				options.SwaggerDoc(
					description.GroupName,
					CreateVersionInfo(description));
			}
		}

		/// <summary>
		/// Configure Swagger Options. Inherited from the Interface
		/// </summary>
		/// <param name="name"></param>
		/// <param name="options"></param>
		public void Configure(string name, SwaggerGenOptions options)
		{
			Configure(options);
		}

		/// <summary>
		/// Create information about the version of the API
		/// </summary>
		/// <param name="description"></param>
		/// <returns>Information about the API</returns>
		private OpenApiInfo CreateVersionInfo(
				ApiVersionDescription desc)
		{
			var info = new OpenApiInfo()
			{
				Title = "INVENTORY Web API",
				Version = desc.ApiVersion.ToString()
			};

			if (desc.IsDeprecated)
			{
				info.Description += " Please enter token information. \r\n\r\n Enter access_token in the text input below.\r\n\r\nExample: \"12345abcdef\"";
			}

			return info;
		}
	}
}
