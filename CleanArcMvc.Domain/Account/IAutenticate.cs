namespace CleanArchMvc.Domain.Account
{
    public interface IAutenticate
    {
        Task<bool> Authenticate(string email, string password); 

        Task<bool> RegisterUser(string email, string password);

        Task Logout();
    } 
}