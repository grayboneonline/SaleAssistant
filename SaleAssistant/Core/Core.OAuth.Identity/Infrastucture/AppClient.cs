using System.ComponentModel.DataAnnotations;

namespace Core.OAuth.Identity.Infrastucture
{
    public class AppClient
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public AppType Type { get; set; }

        public bool Active { get; set; }

        public int RefreshTokenLifeTime { get; set; }

        [MaxLength(100)]
        public string AllowedOrigin { get; set; }
    }

    public enum AppType
    {
        JavaScript = 0,
        NativeConfidential = 1
    }
}
