using System;

class Program {
  static void Main(string[] args)
  {
      Maze maze = new Maze();
      maze.LoadMaze("maze.txt");
        //maze.Solve(new QueueVisitList());
        //maze.Solve(new StackVisitList());
        //maze.Solve(new RandomVisitList());
        maze.Solve(new PriorityVisitList(maze.Exit));
  }
}