namespace interfaces;

public interface IAuth
{
    Task<object> Login(models.Request.Auth auth);
}