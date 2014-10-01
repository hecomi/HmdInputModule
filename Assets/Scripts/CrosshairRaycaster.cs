using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CrosshairRaycaster : BaseRaycaster
{
    // 照準となるオブジェクト
	public Transform crosshair;

    private Canvas canvas_;
    private Canvas canvas
    {
        get
        {
			if (canvas_ != null) return canvas_;
            canvas_ = GetComponent<Canvas>();
            return canvas_;
        }
    }

    public override Camera eventCamera
    {
        get
        {
            return canvas.worldCamera != null ? canvas.worldCamera : Camera.main;
        }
    }

    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
		var pos = eventCamera.WorldToScreenPoint(crosshair.position);

        // Canvas に描かれる要素（Button, Text 等）を１つずつ見ていく
		var hitGraphics= new List<Graphic>();
        var graphics = GraphicRegistry.GetGraphicsForCanvas(canvas);
        foreach (var graphic in graphics) {
            // 描かれないものを除外
            if (graphic.depth == -1) continue;
			if ( !RectTransformUtility.RectangleContainsScreenPoint(graphic.rectTransform, pos, eventCamera) ) {
                continue;
            }
			if ( graphic.Raycast(pos, eventCamera) ) {
				hitGraphics.Add(graphic);
			}
        }

		// 並び替えをして結果に格納
        hitGraphics.Sort( (g1, g2) => g2.depth.CompareTo(g1.depth) );
        foreach (var graphic in hitGraphics) {
            resultAppendList.Add(new RaycastResult {
                go       = graphic.gameObject,
                module   = this,
                distance = Vector3.Distance(eventCamera.transform.position, canvas.transform.position),
                index    = resultAppendList.Count
            });
        }
    }
}
