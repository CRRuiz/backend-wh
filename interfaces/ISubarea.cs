using models.Database;

namespace interfaces;

public interface ISubarea
{
    Task<object> All();
    Task<object> Create(Subarea subarea);
    Task<object> FindArea(string id);
}