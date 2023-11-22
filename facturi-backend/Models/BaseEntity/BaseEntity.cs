
using System.ComponentModel.DataAnnotations.Schema;

namespace facturi_backend.Models.BaseEntity
{
    public class BaseEntity : IBaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateModified { get; set; }
    }
}
