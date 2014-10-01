using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour 
{
	public float filter = 0.1f;
    public float crosshairDistance = 10f;

	void Update() 
	{
        var inputModule = UnityEngine.EventSystems.EventSystemManager.currentSystem.currentInputModule as HmdInputModule;
        if (inputModule && inputModule.currentDevice == HmdInputModule.Device.Mouse) {
            var mousePosition = new Vector3(Input.mousePosition.x * 2, Input.mousePosition.y * 2, crosshairDistance);
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        } else {
            var centerPosition = new Vector3(0.5f, 0.5f, crosshairDistance);
            transform.position += (Camera.main.ViewportToWorldPoint(centerPosition) - transform.position) * filter;
        }
        transform.LookAt(Camera.main.transform);
        transform.Rotate(Camera.main.transform.up, 180);
    }
}
