using System.ComponentModel.DataAnnotations;

namespace ServerApp.Servers.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required] public string LanguageName { get; set; }
    }
}