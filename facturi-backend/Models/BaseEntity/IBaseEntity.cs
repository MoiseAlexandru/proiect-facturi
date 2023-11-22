using System.ComponentModel.DataAnnotations.Schema;

namespace facturi_backend.Models.BaseEntity
{
    public interface IBaseEntity
    {
        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}
