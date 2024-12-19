namespace Film_PProject.Infrastructure.Settings;

public class JwtSetting
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public int ExpireInMinutes { get; set; }
    public string Audience { get; set; }
}