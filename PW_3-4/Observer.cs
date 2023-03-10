using System;
using System.Collections.Generic;
using System.Text;

namespace PW_3_4
{
    public interface IObserver
    {
        void Update(Entity observable);
    }

    public interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
        void Operations(string operation);
    }


}
