using System;
using Utils.Signals.Interfaces;

namespace Utils.Signals
{
    public class Signal : ISignal
    {
        public event Action OnInvoke = () => { };
        
        public void Invoke()
        {
            OnInvoke.Invoke();
        }
    }
    
    public class Signal<T> : ISignal<T>
    {
        public event Action<T> OnInvoke = _ => { };
        
        public void Invoke(T value)
        {
            OnInvoke.Invoke(value);
        }
    }
}