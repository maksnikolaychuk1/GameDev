using UnityEngine;

namespace Code
{
    public class InputService : MonoBehaviour
    {
        private const KeyCode InputAlpha1 = KeyCode.Alpha1;
        private const KeyCode InputAlpha2 = KeyCode.Alpha2;
        
        public delegate void InputAction();
        public static event InputAction OnRotateKeyPressed;
        public static event InputAction OnScaleKeyPressed;
        
        private void Update()
        {
            if (Input.GetKeyDown(InputAlpha1))
            {
                OnRotateKeyPressed?.Invoke();
                Debug.Log("Pressed button '<color=yellow>1</color>': <color=orange>Rotating the object</color>");
            }

            if (Input.GetKeyDown(InputAlpha2))
            {
                OnScaleKeyPressed?.Invoke();
                Debug.Log("Pressed button '<color=yellow>2</color>': <color=orange>Scaling the object</color>");
            }
        }
    }
}