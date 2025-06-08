using Microsoft.EntityFrameworkCore;

namespace Cashly.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder RegisterPostgresEnum<TEnum>(this ModelBuilder modelBuilder, string name) where TEnum : struct, Enum
        {
            modelBuilder.HasPostgresEnum<TEnum>(schema: "public", name: name);
            return modelBuilder;
        }
    }
}
