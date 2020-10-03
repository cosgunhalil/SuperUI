
namespace LB.SuperUI.Helpers.Observer
{
    using System;

    public interface ISubject<T> where T : EventArgs
    {
        void Register(IObserver<T> observer);
        void UnRegister(IObserver<T> observer);

        void AddEvent(T eventArgs);
    }
}

