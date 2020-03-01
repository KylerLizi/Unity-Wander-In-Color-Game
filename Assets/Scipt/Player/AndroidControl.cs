//using UnityEngine;
//using System.Collections;

//public class AndroidControl : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//        Input.multiTouchEnabled = true;//允许多指触屏
//    }
	
//	// Update is called once per frame
//	void Update () {
//        if (Input.touchCount > 0)
//        {
//            for (int i = 0; i < Input.touchCount; i++)
//            {
//                Touch touch = Input.GetTouch(i);
//                if (touch.phase == TouchPhase.Began)
//                {
//                    Press(touch.position, i);
//                }
//                if (touch.phase == TouchPhase.Ended)
//                {
//                    Release(touch.position, i);
//                }
//                if (touch.phase == TouchPhase.Moved)
//                {
//                    RaycastDragPosition(touch.position, i);
//                }
//            }
//            return;
//        }
//        //鼠标点击屏幕时，触发相应事件
//        if (Input.GetMouseButtonDown(0))
//        {
//            Press(Input.mousePosition, 0);
//        }
//        else if (Input.GetMouseButtonUp(0))
//        {
//            Release(Input.mousePosition, 0);
//        }
//        else if (Input.GetMouseButton(0))
//        {
//            RaycastDragPosition(Input.mousePosition, 0);
//        }
//    }

//    private void Press(Vector2 screenPos, int TouchNumber)
//    {
//        lastGo = RaycastObject(screenPos, TouchNumber);
//        if (lastGo != null)
//        {
//            lastGo.SendMessage("OnPress_IE", TouchNumber, SendMessageOptions.DontRequireReceiver);
//        }
//    }

//    private void Release(Vector2 screenPos, int TouchNumber)
//    {
//        lastGo = RaycastObject(screenPos, TouchNumber);

//        if (lastGo != null)
//        {
//            GameObject currentGo = RaycastObject(screenPos, TouchNumber);
//            if (currentGo == lastGo) lastGo.SendMessage("OnClick_IE", SendMessageOptions.DontRequireReceiver);
//            lastGo.SendMessage("OnRelease_IE", TouchNumber, SendMessageOptions.DontRequireReceiver);
//            lastGo = null;
//        }
//    }
//}
