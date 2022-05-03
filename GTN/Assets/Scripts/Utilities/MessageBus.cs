using UniRx;
using System;

namespace GuessTheNote
{
    public static class MessageBus
    {
        public static void Publish<T>(T gameEvent) where T : GameEventBase
        {
            MessageBroker.Default.Publish(gameEvent);
        }

        public static IObservable<T> Receive<T>() where T : GameEventBase
        {
            return MessageBroker.Default.Receive<T>();
        }
    }
}