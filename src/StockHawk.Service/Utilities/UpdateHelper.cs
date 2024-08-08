namespace StockHawk.Service.Utilities;

public static class UpdateHelper
{
    public static void ApplyUpdates<TSource, TDestination>(TSource source, TDestination destination)
    {
        var sourceProperties = typeof(TSource).GetProperties();
        var destinationProperties = typeof(TDestination).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            var sourceValue = sourceProperty.GetValue(source);
            
            if (sourceValue == null) continue;
            
            var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);
            if (destinationProperty != null && destinationProperty.CanWrite)
            {
                destinationProperty.SetValue(destination, sourceValue);
            }
        }
    }
}