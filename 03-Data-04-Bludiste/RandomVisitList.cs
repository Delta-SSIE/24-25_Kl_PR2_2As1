using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class RandomVisitList : IVisitList
{
    List<Coords> _list = [];
    Random _random = new();

    public int Count => _list.Count;

    public void Add(Coords place)
    {
        _list.Add(place);
    }

    public Coords NextPlace()
    {
        int index = _random.Next(_list.Count);
        Coords place = _list[index];
        _list.RemoveAt(index);
        return place;
    }
}
