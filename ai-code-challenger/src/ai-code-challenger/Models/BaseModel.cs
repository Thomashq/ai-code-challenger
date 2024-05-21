using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ai_code_challenger.Models
{
    public abstract class BaseModel
    {
        public long Id { get; set; }

        public static void Configure(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
                {
                    var entity = modelBuilder.Entity(entityType.ClrType);
                    entity.Property<long>("Id").HasColumnName($"{entityType.ClrType.Name}Id");
                }
            }
        }
        [Required(ErrorMessage = "É necessário informar a data de criação")]
        public DateTime? CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
    }
}
