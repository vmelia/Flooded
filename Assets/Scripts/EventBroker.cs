using System;

namespace Assets.Scripts
{
    public class EventBroker
    {
        public static event Action ObjectAdded;
        public static event Action ObjectsCleared;

        public static void CallObjectAdded()
        {
            ObjectAdded?.Invoke();
        }

        public static void CallObjectsCleared()
        {
            ObjectsCleared?.Invoke();
        }
    }
}