using UnityEngine;
using UnityEngine.UI;

namespace GuessTheNote
{
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField] float _speedX = 0.1f;
        [SerializeField] float _speedY = 0.1f;

        private RawImage _image;

        private void Awake()
        {
            _image = GetComponent<RawImage>();
        }

        private void Update()
        {
            _image.uvRect = new Rect(_image.uvRect.position +
                                        new Vector2(_speedX, _speedY) * Time.deltaTime,
                                     _image.uvRect.size);
        }
    }
}
