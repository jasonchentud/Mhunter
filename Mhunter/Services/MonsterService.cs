using Mhunter.Models;
using System.Net.Http.Json;

namespace Mhunter.Services
{
    public class MonsterService
    {
        private readonly HttpClient _http;

        public MonsterService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Monster>> GetAllMonsters()
        {
            return await _http.GetFromJsonAsync<List<Monster>>("https://mhw-db.com/monsters");
        }

        public async Task<Monster?> GetMonsterById(int id)
        {
            return await _http.GetFromJsonAsync<Monster?>($"https://mhw-db.com/monsters/{id}");
        }

        public async Task<Monster?> GetMonsterByName(string name)
        {
            var monsters = await GetAllMonsters();
            return monsters.FirstOrDefault(m =>
                m.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Monster?> GetRandomMonster()
        {
            var monsters = await GetAllMonsters();
            var rnd = new Random();
            return monsters[rnd.Next(monsters.Count)];
        }
    }
}
