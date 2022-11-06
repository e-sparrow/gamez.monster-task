using System;

namespace Utils.Signals.Interfaces
{
    public interface ISignal
    {
        event Action OnInvoke;

        void Invoke();
    }

    public interface ISignal<T>
    {
        event Action<T> OnInvoke;

        void Invoke(T value);
    }
}