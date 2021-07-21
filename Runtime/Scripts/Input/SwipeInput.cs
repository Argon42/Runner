using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public class SwipeInput : GameInput
    {
        [SerializeField] private Camera inputCamera;
        [SerializeField] private Vector3 cameraOffset;
        
        [SerializeField] private UnityEvent<Vector3> onSwipe;
        [SerializeField] private UnityEvent<Vector3> onDrag;
        [SerializeField] private UnityEvent<Vector3> onPointerDown;
        [SerializeField] private UnityEvent<Vector3> onPointerUp;

        private Vector3 _startTouchPosition;
        private Vector3 _touchPosition;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startTouchPosition = GetTouchPosition();
                onPointerDown?.Invoke(_startTouchPosition);
            }
            else if (Input.GetMouseButton(0))
            {
                _touchPosition = GetTouchPosition();
                onDrag?.Invoke(_touchPosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _touchPosition = GetTouchPosition();
                onPointerUp?.Invoke(_touchPosition);
                onSwipe?.Invoke(_touchPosition - _startTouchPosition);
            }
        }

        private Vector3 GetTouchPosition() =>
            inputCamera.ScreenToWorldPoint(Input.mousePosition) + cameraOffset;
    }
}