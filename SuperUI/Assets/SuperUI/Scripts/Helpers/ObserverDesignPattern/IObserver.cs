
namespace LB.SuperUI.Helpers.Observer
{
    using System;

    public interface IObserver<in T> where T : EventArgs
    {
        void Syncronize(Object sender, T e);
    }
}


