using DG.Tweening;
using UnityEngine;

namespace Code
{
    public class RotateCube : MonoBehaviour
    {
        private const float DefaultAnimationDuration = 0f;

        [SerializeField]
        private GameObject cube;

        [SerializeField]
        private float duration = 2f;

        [SerializeField]
        private Ease easingCurve = Ease.InOutBounce;

        private void OnEnable()
        {
            InputService.OnRotateKeyPressed += RotateCubeOnKeyPress;
        }

        private void OnDisable()
        {
            InputService.OnRotateKeyPressed -= RotateCubeOnKeyPress;
        }

        private void RotateCubeOnKeyPress()
        {
            cube.transform.DORotate(Vector3.zero, DefaultAnimationDuration);

            var vector = new Vector3(0, 360, 0);

            cube.transform
                .DORotate(vector, duration, RotateMode.FastBeyond360)
                .SetEase(easingCurve);
        }
    }
}