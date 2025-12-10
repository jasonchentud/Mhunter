using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mhunter.Models;
using System.Collections.Generic;

namespace Mhunter.UnitTests
{
    public static class TestMonsterData
    {
        public static List<Monster> SampleMonsters => new()
        {
            new Monster { id = 1, name = "Rathalos", description = "Fire wyvern." },
            new Monster { id = 2, name = "Anjanath", description = "Fanged wyvern." },
            new Monster { id = 3, name = "Great Jagras", description = "Big lizard." }
        };
    }
}

