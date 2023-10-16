using System;
using System.Collections.Generic;
using Stately;

public class Solver
{
    public Maze Maze { get; set; }
    public bool Profundidade(Space space)
    {
        if (space.Exit)
        {
            space.IsSolution = true;
            return true;
        }

        space.Visited = true;

        if (space.Bottom != null && space.Bottom.Visited != true)
        {
            space.IsSolution = Profundidade(space.Bottom);
            if (space.IsSolution)
                return true;
        }
        if (space.Left != null && space.Left.Visited != true)
        {
            space.IsSolution = Profundidade(space.Left);
            if (space.IsSolution)
                return true;
        }
        if (space.Right != null && space.Right.Visited != true)
        {
            space.IsSolution = Profundidade(space.Right);
            if (space.IsSolution)
                return true;
        }
        if (space.Top != null && space.Top.Visited != true)
        {
            space.IsSolution = Profundidade(space.Top);
            if (space.IsSolution)
                return true;
        }

        return false;
    }

    public Space Largura(List<Space> spaces)
    {
        foreach (var space in spaces)
        {
            if (space.Exit)
            {
                space.IsSolution = true;
                return space;
            }

            space.Visited = true;
        }

        List<Space> newSpaces = new List<Space> { };

        foreach (var space in spaces)
        {
            if (space.Bottom != null && space.Bottom.Visited != true)
            {
                newSpaces.Add(space.Bottom);
            }
            if (space.Left != null && space.Left.Visited != true)
            {
                newSpaces.Add(space.Left);
            }
            if (space.Right != null && space.Right.Visited != true)
            {
                newSpaces.Add(space.Right);
            }
            if (space.Top != null && space.Top.Visited != true)
            {
                newSpaces.Add(space.Top);
            }
        }

        if (newSpaces.Count > 0)
        {
            Space newSpace = Largura(newSpaces);

            foreach (var space in spaces)
            {
                if (space.Visited && space != null)
                {
                    if (newSpace.X == space.X - 1 && newSpace.Y == space.Y)
                    {
                        space.IsSolution = true;
                        return space;
                    }
                    if (newSpace.X == space.X + 1 && newSpace.Y == space.Y)
                    {
                        space.IsSolution = true;
                        return space;
                    }
                    if (newSpace.X == space.X && newSpace.Y == space.Y - 1)
                    {
                        space.IsSolution = true;
                        return space;
                    }
                    if (newSpace.X == space.X && newSpace.Y == space.Y + 1)
                    {
                        space.IsSolution = true;
                        return space;
                    }
                }
            }
        }

        return null;
    }
    public void Solve()
    {
        List<Space> spaces = new List<Space> { };
        spaces.Add(Maze.Spaces[0]);

        Largura(spaces);
    }
}