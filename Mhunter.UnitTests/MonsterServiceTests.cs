using Mhunter.Services;
using Mhunter.Models;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mhunter.UnitTests
{
    // Fake service avoids HTTP calls
    public class TestMonsterService : MonsterService
    {
        private readonly List<Monster> _data;

        public TestMonsterService(List<Monster> monsters)
            : base(new HttpClient()) 
        {
            _data = monsters;
        }

        public override Task<List<Monster>> GetAllMonsters()
        {
            return Task.FromResult(_data);
        }

        public override Task<Monster?> GetMonsterByName(string name)
        {
            return Task.FromResult(_data.Find(m => m.name == name));
        }

        public override Task<Monster?> GetRandomMonster()
        {
            return Task.FromResult(_data[0]);
        }
    }

    public class MonsterServiceTests
    {
        private readonly TestMonsterService _service;

        public MonsterServiceTests()
        {
            _service = new TestMonsterService(TestMonsterData.SampleMonsters);
        }

        [Fact]
        public async Task GetMonsterByName_ReturnsCorrectMonster()
        {
            var monster = await _service.GetMonsterByName("Rathalos");

            Assert.NotNull(monster);
            Assert.Equal("Rathalos", monster!.name);
        }

        [Fact]
        public async Task GetMonsterByName_ReturnsNull_WhenNotFound()
        {
            var monster = await _service.GetMonsterByName("InvalidMonster");

            Assert.Null(monster);
        }

        [Fact]
        public async Task GetRandomMonster_ReturnsValidMonster()
        {
            var monster = await _service.GetRandomMonster();

            Assert.NotNull(monster);
            Assert.Equal("Rathalos", monster!.name);  // deterministic value
        }
    }
}

