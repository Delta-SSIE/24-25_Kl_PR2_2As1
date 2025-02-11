using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class PriorityVisitList : IVisitList
{
    PriorityQueue<Coords, double> _queue = new();
    Coords _exit;

    public PriorityVisitList(Coords exit)
    {
        _exit = exit;
    }

    public int Count => _queue.Count;

    public void Add(Coords place)
    {
        double distance = Math.Sqrt(Math.Pow(place.X - _exit.X, 2) + Math.Pow(place.Y - _exit.Y, 2));
        _queue.Enqueue(place, distance);
    }

    public Coords NextPlace()
    {
        return _queue.Dequeue();
    }
}
