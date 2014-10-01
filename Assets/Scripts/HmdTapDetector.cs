using UnityEngine;
using System.Collections;

public class HmdTapDetector : MonoBehaviour 
{
    public delegate void OnHmdTappedEventHandler();
    public static OnHmdTappedEventHandler OnHmdTapped = () => {};
    public float accelerometerThreshold = 200f;

    void Update()
    {
        // Ref: http://zabaglione.info/archives/462
        var hmd = OVR.Hmd.GetHmd();
        var state = hmd.GetTrackingState();
        if ( (state.StatusFlags & (uint)OVR.ovrStatusBits.ovrStatus_OrientationTracked) != 0 ) {
            var accel = OVRExtensions.ToVector3(state.RawSensorData.Accelerometer);
            if (accel.sqrMagnitude > accelerometerThreshold) {
                OnHmdTapped();
            }
        }
    }
}
