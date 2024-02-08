namespace RealState.WebAPI.Helpers
{
    using Microsoft.OpenApi.Models;
    using RealState.WebAPI.Requests;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Collections.Generic;

    public class CepOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name is "AddProperty" && context.ApiDescription.RelativePath == "/imovel")
            {

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "cep",
                    In = ParameterLocation.Query,
                    Required = true,
                    Description = "CEP (Postal Code)",
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "price",
                    In = ParameterLocation.Query,
                    Required = true,
                    Description = "Price of the property",
                    Schema = new OpenApiSchema
                    {
                        Type = "number",
                        Format = "decimal"
                    }
                });

                var schemaRepository = new SchemaRepository();

                operation.RequestBody = new OpenApiRequestBody
                {
                    Required = true,
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["multipart/form-data"] = new OpenApiMediaType
                        {
                            Schema = context.SchemaGenerator.GenerateSchema(typeof(RequiredPropertyRequest), schemaRepository)
                        }
                    }
                };
            }
        }
    }

}