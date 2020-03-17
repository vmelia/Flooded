using UnityEngine;

namespace Assets.Scripts
{
    public class UpdateUI : MonoBehaviour
    {
        public GameObject Display;

        private int _count;

        private void Start()
        {
            EventBroker.ObjectAdded += OnObjectAdded;
            EventBroker.ObjectsCleared += OnObjectsCleared;
        }

        private void OnDisable()
        {
            EventBroker.ObjectAdded -= OnObjectAdded;
            EventBroker.ObjectsCleared -= OnObjectsCleared;
        }

        public void Update()
        {
            var textMesh = Display.GetComponent<TextMesh>();
            textMesh.text = _count.ToString("0000");
        }

        private void OnObjectAdded()
        {
            _count++;
        }

        private void OnObjectsCleared()
        {
            _count = 0;
        }
    }
}