using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace EpiBubble.Helpers
{
    public enum DeviceType
    {
        XBOX, 
        Mobile, 
        SurfaceHub,
        IOT,
        Desktop,
        Tablet,
        Other
    }

    /// <summary>
    /// Detects device type
    /// </summary>
    public static class DeviceDetector
    {
        public static DeviceType DetectDeviceType()
        {
            switch(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily)
            {
                case "Windows.Xbox":
                    return DeviceType.XBOX;
                case "Windows.Desktop":
                    return UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse
                        ? DeviceType.Desktop
                        : DeviceType.Tablet;
                case "Windows.Mobile":
                    return DeviceType.Mobile;
                case "Windows.Universal":
                    return DeviceType.IOT;
                case "Windows.Team":
                    return DeviceType.SurfaceHub;
                default:
                    return DeviceType.Other;
            }
        }
    }
}
