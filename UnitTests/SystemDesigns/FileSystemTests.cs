using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class FileSystemTests
    {
        [Theory]
        [InlineData(new []{"FileSystem","createPath","get"}, new []{ null,"/a,1","/a"}, new [] {"null", "true", "1"})]
        [InlineData(new []{"FileSystem","createPath","createPath","get","createPath","get"}, 
            new []{ null,"/leet,1","/leet/code,2","/leet/code","/c/d,1","/c"}, new [] {"null","true","true","2","false","-1"})]
        public void FileTesting(string[] commands, string[] inputs, string[] outputs)
        {
            FileSystem fileSystem=null; 
            for (var i =0; i < commands.Length; i++)
            {
                var command = commands[i];
                switch (command)
                {
                    case "FileSystem":
                        fileSystem = new FileSystem();
                        break;
                    case "createPath":
                        var args = inputs[i].Split(',');
                        var path = args[0];
                        var value = int.Parse(args[1]);
                        var output = outputs[i];
                        
                        if(output == "true")
                            Assert.True(fileSystem.CreatePath(path, value));
                        else Assert.False(fileSystem.CreatePath(path, value));
                        break;
                    case "get":
                        value = int.Parse(outputs[i]);
                        Assert.Equal(value, fileSystem.Get(inputs[i]));
                        break;
                }
            }
        }
    }
}