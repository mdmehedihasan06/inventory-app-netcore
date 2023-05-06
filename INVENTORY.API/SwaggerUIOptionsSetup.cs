using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

public class SwaggerUIOptionsSetup : IConfigureOptions<SwaggerUIOptions>
{
	private readonly IApiVersionDescriptionProvider _provider;

	public SwaggerUIOptionsSetup(IApiVersionDescriptionProvider provider)
	{
		_provider = provider;
	}

	public void Configure(SwaggerUIOptions options)
	{
		foreach (var description in _provider.ApiVersionDescriptions)
		{
			options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
		}

		options.DefaultModelExpandDepth(0);
		options.DefaultModelsExpandDepth(-1);
		options.DefaultModelRendering(ModelRendering.Model);
		options.DocExpansion(DocExpansion.None);
	}
}
