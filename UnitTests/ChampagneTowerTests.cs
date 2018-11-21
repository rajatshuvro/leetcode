using Problems;
using Xunit;

namespace UnitTests
{
    public class ChampagneTowerTests
    {
        [Fact]
        public void Pour_1()
        {
            var champTower = new TowerOfChampagne();
            var result = champTower.ChampagneTower(1, 1, 1);

            Assert.Equal(0.0, result);
        }

        [Fact]
        public void Pour_2()
        {
            var champTower = new TowerOfChampagne();
            var result = champTower.ChampagneTower(2, 1, 1);

            Assert.Equal(0.5, result);
        }

        [Fact]
        public void Pour_3()
        {
            var champTower = new TowerOfChampagne();
            var result = champTower.ChampagneTower(3, 1, 1);

            Assert.Equal(1.0, result);
        }

        [Fact]
        public void Pour_4_2_0()
        {
            var champTower = new TowerOfChampagne();
            var result = champTower.ChampagneTower(4, 2, 0);

            Assert.Equal(0.25, result);
            
        }

        [Fact]
        public void Pour_4_2_1()
        {
            var champTower = new TowerOfChampagne();
            var result = champTower.ChampagneTower(4, 2, 1);
            Assert.Equal(0.5, result);
            
        }

        [Fact]
        public void Pour_4_2_2()
        {
            var champTower = new TowerOfChampagne();
            var result = champTower.ChampagneTower(4, 2, 2);
            Assert.Equal(0.25, result);
        }
        [Fact]
        public void Pour_6()
        {
            var champTower = new TowerOfChampagne();
            var result = champTower.ChampagneTower(6, 2, 1);

            Assert.Equal(1.0, result);
        }

        [Fact]
        public void Pour_200()
        {
            var champTower = new TowerOfChampagne();
            var result = champTower.ChampagneTower(200, 15, 11);

            Assert.Equal(1.0, result);
        }
    }
}