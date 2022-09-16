using models.Database;

namespace interfaces;

public interface IEmpleado
{
    Task<object> All();
    Task<object> Create(Empleado empleado);
    Task<object> Find(string id);
    Task<object> Update(Empleado empleado);
    Task<object> Delete(string id);
}