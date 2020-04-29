using PerformanceCounterHelper;

namespace MvcMusicStore.Infrastructure
{
    [PerformanceCounterCategory("MvcMusicStore", System.Diagnostics.PerformanceCounterCategoryType.MultiInstance, "MvcMusic Store Info")]
    public enum Counters
    {
        [PerformanceCounter("Go to home count", "Go to home Info", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        GoToHome,
        [PerformanceCounter("Successful login count", "Successful login info", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        SuccessLogIn,
        [PerformanceCounter("Successful log Off count", "Successful log out info", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        SuccessLogOff
    }
}