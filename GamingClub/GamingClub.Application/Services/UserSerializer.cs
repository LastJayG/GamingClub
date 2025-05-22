
using GamingClub.Application.DTOs.User;
using GamingClub.Application.Interfaces;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace GamingClub.Application.Services
{
    public class UserSerializer : IUserSerializer
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),   //для кириллицы тоже
            WriteIndented = true
        };

        private readonly string _storageDir;
        public UserSerializer()
        {
            // заданный путь: ./Data/Users
            _storageDir = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Users");
            Directory.CreateDirectory(_storageDir);
        }

        public async Task SerializeToFileAsync(UserDTO user)
        {
            var filePath = Path.Combine(_storageDir, $"user_{user.Id}.json");

            await using var stream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(stream, user, _options);
        }

        public async Task<UserDTO?> DeserializeFromFileAsync(int userId)
        {
            var filePath = Path.Combine(_storageDir, $"user_{userId}.json");

            if (!File.Exists(filePath))
                return null;

            await using var stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<UserDTO>(stream, _options);
        }
    }
}
