namespace Films_PProject.Application.Services;

public class HashingService
{ 
    public async Task<string> HashPassword(string password)
    {
        return await Task.Run(() =>
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        });
    }
    
    public async Task<bool> VerifyPassword(string password, string hashedPassword)
    {
        return await Task.Run(() =>
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        });
    }
}