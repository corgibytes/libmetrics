using System.IO;
using Xunit;

namespace LibMetrics.Test.Integration
{
  public class FileHistoryFinderTest
  {
    [Fact]
    public void Git()
    {
      var rubyFixturePath = Helpers.FixturePath("ruby", "nokotest");

      FileHistoryFinder.Register<GitFileHistoryFinder>();
      var finder = new FileHistoryFinder(rubyFixturePath);

      Assert.IsType<GitFileHistory>(finder.FileHistoryOf("Gemfile.lock"));
    }
  }
}