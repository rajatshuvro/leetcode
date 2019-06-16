using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class AircraftUtilizationTest
    {
        [Fact]
        public void Case1()
        {
            var airUtilizer = new AircraftUtilization();

            var forward = new List<List<int>>()
            {
                new List<int>() { 1,8},
                new List<int>() { 2,7},
                new List<int>() { 3,14}
            };

            var ret = new List<List<int>>()
            {
                new List<int>() { 1,5},
                new List<int>() { 2,10},
                new List<int>() { 3,14}
            };

            Assert.Equal(new List<List<int>> () {new List<int>(){ 3,1}}, airUtilizer.optimalUtilization(20,forward, ret));
        }
    }
}