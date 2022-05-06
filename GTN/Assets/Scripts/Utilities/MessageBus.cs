using UniRx;

namespace GuessTheNote
{
    public static class MessageBus
    {
        public static void Publish<T>(T gameEvent) where T : GameEventBase
        {
            MessageBroker.Default.Publish(gameEvent);
        }

        public static System.IObservable<T> Receive<T>() where T : GameEventBase
        {
            return MessageBroker.Default.Receive<T>();
        }
    }
}