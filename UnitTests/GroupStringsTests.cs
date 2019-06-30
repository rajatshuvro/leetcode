using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class GroupStringsTests
    {
        [Fact]
        public void Test_0()
        {
            var input = new[] {"abc", "bcd", "acef", "xyz", "az", "ba", "a", "z"};
            var output = new List<List<string>>()
            {
                new List<string>(){ "abc", "bcd", "xyz" },
                new List<string>(){"acef"},
                new List<string>(){ "az", "ba" },
                new List<string>(){ "a", "z" }
            };

            var sol = new GroupShiftedStrings();

            var result = sol.GroupStrings(input);
            Assert.Equal(output.Count, result.Count);
            Assert.Equal(output[0], result[0]);
            Assert.Equal(output[1], result[1]);
            Assert.Equal(output[2], result[2]);
            Assert.Equal(output[3], result[3]);
        }

        [Fact]
        public void OneItem()
        {
            var input = new[] { "a"};
            var output = new List<List<string>>()
            {
                new List<string>(){ "a"}
            };

            var sol = new GroupShiftedStrings();

            var result = sol.GroupStrings(input);
            Assert.Equal(output.Count, result.Count);
            Assert.Equal(output[0], result[0]);
        }

        [Fact]
        public void Duplicates()
        {
            var input = new[] { "a", "a" };
            var output = new List<List<string>>()
            {
                new List<string>(){ "a", "a"}
            };

            var sol = new GroupShiftedStrings();

            var result = sol.GroupStrings(input);
            Assert.Equal(output.Count, result.Count);
            Assert.Equal(output[0], result[0]);
        }

        [Fact]
        public void Test_14()
        {
            var input = new[] { "az", "yx" };
            var output = new List<List<string>>()
            {
                new List<string>(){"az","yx"}
            };

            var sol = new GroupShiftedStrings();

            var result = sol.GroupStrings(input);
            Assert.Equal(output.Count, result.Count);
            Assert.Equal(output[0], result[0]);
        }

        //[Fact]
        //public void Test_15()
        //{
        //    var input = new[] { "fpbnsbrkbcyzdmmmoisaa", "cpjtwqcdwbldwwrryuclcngw", "a", "fnuqwejouqzrif", "js", "qcpr", "zghmdiaqmfelr", "iedda", "l", "dgwlvcyubde", "lpt", "qzq", "zkddvitlk", "xbogegswmad", "mkndeyrh", "llofdjckor", "lebzshcb", "firomjjlidqpsdeqyn", "dclpiqbypjpfafukqmjnjg", "lbpabjpcmkyivbtgdwhzlxa", "wmalmuanxvjtgmerohskwil", "yxgkdlwtkekavapflheieb", "oraxvssurmzybmnzhw", "ohecvkfe", "kknecibjnq", "wuxnoibr", "gkxpnpbfvjm", "lwpphufxw", "sbs", "txb", "ilbqahdzgij", "i", "zvuur", "yfglchzpledkq", "eqdf", "nw", "aiplrzejplumda", "d", "huoybvhibgqibbwwdzhqhslb", "rbnzendwnoklpyyyauemm" };
        //    var output = new List<List<string>>()
        //    {
        //        new List<string>(){ "a", "d", "i", "l" },
        //        new List<string>(){ "eqdf", "qcpr" },
        //        new List<string>(){ "lpt","txb" },
        //        new List<string>(){ "yfglchzpledkq","zghmdiaqmfelr"},
        //        new List<string>(){ "kknecibjnq","llofdjckor"},
        //        new List<string>(){ "cpjtwqcdwbldwwrryuclcngw","huoybvhibgqibbwwdzhqhslb"},
        //        new List<string>(){ "lbpabjpcmkyivbtgdwhzlxa","wmalmuanxvjtgmerohskwil"},
        //        new List<string>(){ "iedda","zvuur"},
        //        new List<string>(){ "js","nw"},
        //        new List<string>(){ "lebzshcb","ohecvkfe"},
        //        new List<string>(){ "dgwlvcyubde","ilbqahdzgij"},
        //        new List<string>(){ "lwpphufxw","zkddvitlk"},
        //        new List<string>(){ "qzq","sbs"},
        //        new List<string>(){ "dclpiqbypjpfafukqmjnjg","yxgkdlwtkekavapflheieb"},
        //        new List<string>(){ "mkndeyrh","wuxnoibr"},
        //        new List<string>(){ "firomjjlidqpsdeqyn","oraxvssurmzybmnzhw"},
        //        new List<string>(){ "gkxpnpbfvjm","xbogegswmad"},
        //        new List<string>(){ "fpbnsbrkbcyzdmmmoisaa","rbnzendwnoklpyyyauemm"},
        //        new List<string>(){ "aiplrzejplumda","fnuqwejouqzrif"},

        //    };

        //    var sol = new GroupShiftedStrings();

        //    var result = sol.GroupStrings(input);
        //    Assert.Equal(output.Count, result.Count);
        //    Assert.Equal(output[0], result[0]);
        //}

    }
}