using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace Circulars.Infrastructure.Helpers
{
    public class MetadataValueModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var values = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (values.Length == 0)
                return Task.CompletedTask;
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            var deserialized = System.Text.Json.JsonSerializer.Deserialize(values.FirstValue, bindingContext.ModelType, options);

            bindingContext.Result = ModelBindingResult.Success(deserialized);
            return Task.CompletedTask;
        }
    }
}
