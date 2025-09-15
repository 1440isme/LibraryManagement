using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.UI
{
    public static class EventBus
    {
        private static readonly Dictionary<string, List<Action>> _subscribers = new Dictionary<string, List<Action>>();

        public static void Subscribe(string eventName, Action handler)
        {
            if (!_subscribers.ContainsKey(eventName))
                _subscribers[eventName] = new List<Action>();

            _subscribers[eventName].Add(handler);
        }

        public static void Unsubscribe(string eventName, Action handler)
        {
            if (_subscribers.ContainsKey(eventName))
                _subscribers[eventName].Remove(handler);
        }

        public static void Publish(string eventName)
        {
            if (_subscribers.ContainsKey(eventName))
            {
                foreach (var handler in _subscribers[eventName].ToList())
                {
                    handler.Invoke();
                }
            }
        }
    }
}
