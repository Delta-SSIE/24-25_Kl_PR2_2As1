using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class StackVisitList : IVisitList
{
    Stack<Coords> _stack = [];

    public int Count => _stack.Count;

    public void Add(Coords place)
    {
        _stack.Push(place);
    }

    public Coords NextPlace()
    {
        return _stack.Pop();
    }
}
