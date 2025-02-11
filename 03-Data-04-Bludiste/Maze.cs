using System;
using System.IO;
using System.Collections.Generic;

class Maze
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    private Coords _entrance;
    private TileType[,] _map = null;
    private MazeDisplay _display = null;

    public void LoadMaze(string filename)
    {
        using (StreamReader reader = new StreamReader(filename)) //načtu textový soubor
        {
            Width = int.Parse(reader.ReadLine()); //první řádek je šířka
            Height = int.Parse(reader.ReadLine()); //druhý řádek je výška
            
            _map = new TileType[Width, Height];

            string line;
            for (int y = 0; y < Height; y++) //projdu všechny řádky
            {
                line = reader.ReadLine();
                for (int x = 0; x < Width; x++) //projdu všechny sloupce
                {
                    _map[x, y] = line[x] switch //uložím do mapy
                    {
                        '#' => TileType.Wall,
                        ' ' => TileType.Corridor,
                        'S' => TileType.Entrance,
                        'E' => TileType.Exit,
                    };
                    if (line[x] == 'S') //poznamenám si, kde je start
                        _entrance = new Coords(x, y);
                }
            }                
        }
        _display = new MazeDisplay(1, 1, Width, Height); //připravím prostor pro kreslení, odsazený o 1 čtverec
        RenderMaze();
    }

    public void RenderMaze()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                _display.RenderTile(new Coords(x, y), _map[x, y]);
            }
        }
        _display.WrapUp();
    }

    public void Solve()
    {
        //připrav seznam míst k navštívení
        Stack<Coords> toBeVisited = [];

        //dej do něj start
        toBeVisited.Push(_entrance);

        //dokud na seznamu něco je
        while(toBeVisited.Count > 0)
        {

            //vyndej první položku
            Coords here = toBeVisited.Pop();

            //když je to cíl, skonči
            if (_map[here.X, here.Y] == TileType.Exit)
                return;
            //jinak ji označ jako navštívenou (kromě startu)
            else if (_map[here.X, here.Y] != TileType.Entrance)
                _map[here.X, here.Y] = TileType.Visited;

            //vezmi všechny sousedy
            Coords[] neighbors = FindNeighbors(here);

            foreach( Coords neighbor in neighbors) {
                //dej je na seznam k projití
                toBeVisited.Push(neighbor);
                //a označ je jako "už o nich vím" (kromě cíle)
                if (_map[neighbor.X, neighbor.Y] != TileType.Exit)
                    _map[neighbor.X, neighbor.Y] = TileType.Marked;
            }

            //vykresli
            RenderMaze();

            //chvilku počkej
            System.Threading.Thread.Sleep(150);
        }
    }

    private Coords[] FindNeighbors(Coords here)
    {
        (int dx, int dy)[] steps = { (0, 1), (1, 0), (0, -1), (-1, 0) };
        List<Coords> neigbors = [];

        foreach(var step in steps)
        {
            Coords candidate = new Coords(here.X + step.dx, here.Y + step.dy);
            if (
                candidate.X < 0
                || candidate.X >= Width
                || candidate.Y < 0
                || candidate.Y >= Height
            )
                continue;

            TileType neighborType = _map[candidate.X, candidate.Y];
            if (neighborType == TileType.Corridor || neighborType == TileType.Exit)
                neigbors.Add(candidate);
        }
        return neigbors.ToArray();
    }
}

