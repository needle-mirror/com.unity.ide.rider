using System.Text;

namespace Packages.Rider.Editor.ProjectGeneration
{
  internal sealed class LegacyStyleProjectGeneration : ProjectGeneration
  {
    public LegacyStyleProjectGeneration() : base() {}
    
    public LegacyStyleProjectGeneration(string projectDirectory, IAssemblyNameProvider assemblyNameProvider, IFileIO fileIoProvider, IGUIDGenerator guidGenerator)
      : base(projectDirectory, assemblyNameProvider, fileIoProvider, guidGenerator) {}

    protected override void AppendProjectStartTag(StringBuilder stringBuilder)
    {
      stringBuilder
        .AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>")
        .AppendLine(
          "<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
    }

    protected override void AppendProjectFooter(StringBuilder stringBuilder)
    {
      stringBuilder.AppendLine("  <Import Project=\"$(MSBuildToolsPath)\\Microsoft.CSharp.targets\" />");
    }

    protected override void AppendProjectProperties(StringBuilder stringBuilder)
    {
      stringBuilder
        .AppendLine("    <TargetFrameworkVersion>v4.7.1</TargetFrameworkVersion>")
        .AppendLine("    <ResolveNuGetPackages>false</ResolveNuGetPackages>")
        .AppendLine("    <_TargetFrameworkDirectories>non_empty_path_generated_by_unity.rider.package</_TargetFrameworkDirectories>")
        .AppendLine("    <_FullFrameworkReferenceAssemblyPaths>non_empty_path_generated_by_unity.rider.package</_FullFrameworkReferenceAssemblyPaths>")
        ;      
    }
  }
}