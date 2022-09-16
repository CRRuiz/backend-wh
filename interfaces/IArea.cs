using models.Database;

namespace interfaces;

public interface IArea
{
    Task<object> Create(Area area);
    Task<object> All();
}