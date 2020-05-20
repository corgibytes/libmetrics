using System;

namespace LibMetrics
{
  public class LibYearPackageResult
  {
    public string Name { get; }
    public string Version { get; }
    public DateTime PublishedAt { get; }
    public double Value { get; }

    public LibYearPackageResult(string name, string version, DateTime publishedAt, double value)
    {
      Name = name;
      Version = version;
      PublishedAt = publishedAt;
      Value = value;
    }
  }
}