using System.Threading;

namespace Packages.Rider.Editor
{
  /// <summary>
  /// Tracks the lifetime of the currently loaded editor code. Exposes a
  /// <see cref="System.Threading.CancellationToken"/> that is cancelled when
  /// Unity is about to unload the current code (assembly reload or domain
  /// teardown), so background work started from this package can shut down
  /// cleanly.
  /// </summary>
  // ReSharper disable once PartialTypeWithSinglePart
  public static partial class UnityCodeLifetime
  {
    internal static CancellationToken Token => cts.Token;

    private static CancellationTokenSource cts;
    
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.OnCodeLoaded]
#endif
    private static void Initialize()
    {
      cts = new CancellationTokenSource();
    }

#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.OnCodeUnloading]
#endif
    private static void Terminate()
    {
      cts.Cancel();
      cts = null;
    }

#if !UNITY_6000_5_OR_NEWER
    static UnityCodeLifetime()
    {
      Initialize();
      UnityEditor.AssemblyReloadEvents.beforeAssemblyReload += Terminate;
    }
#endif
  }
}
