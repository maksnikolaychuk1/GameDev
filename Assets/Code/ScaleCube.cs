using DG.Tweening;
using UnityEngine;

namespace Code
{
    public class ScaleCube : MonoBehaviour
    {
        private const int Vibrato = 1;
        private const float Elasticity = 0f;

        private Vector3 _originalScale;

        [SerializeField]
        private GameObject cube;

        [SerializeField]
        private float duration = 0.5f;

        [SerializeField]
        private Vector3 punchScale = new(0.4f, 0.4f, 0.4f);

        [SerializeField]
        private Ease easingStartCurve = Ease.InOutSine;
        
        [SerializeField]
        private Ease easingEndCurve = Ease.OutBounce;
        
        private void OnEnable()
        {
            _originalScale = cube.transform.localScale;
            InputService.OnScaleKeyPressed += ScaleCubeOnKeyPress;
        }

        private void OnDisable()
        {
            InputService.OnScaleKeyPressed -= ScaleCubeOnKeyPress;
        }

        private void ScaleCubeOnKeyPress()
        {
            cube.transform
                .DOPunchScale(punchScale, duration, Vibrato, Elasticity)
                .SetEase(easingStartCurve)
                .OnComplete(() =>
                {
                    transform.DOScale(_originalScale, duration);
                });
        }
    }
}