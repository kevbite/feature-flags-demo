using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.FeatureManagement;

namespace Demo1
{
  public class App
  {
    private readonly IFeatureManager _featureManager;

    public App(IFeatureManagerSnapshot featureManager)
    {
      _featureManager = featureManager;
    }

    public async Task Execute()
    {
      for (var up = true; ; up = !up)
      {
        Console.Clear();
        WriteLine("Welcome to this amazing feature manager demo");

        if (up)
        {
          WriteLine(CarUp);
        }
        else
        {
          WriteLine(CarDown);
        }

        await Task.Delay(500);
      }
    }

    private void WriteLine(string line = "")
    {
      if (_featureManager.IsEnabled("FunColours"))
      {
        using (var colors = GetNextColour().GetEnumerator())
        {
          foreach (var c in line)
          {
            colors.MoveNext();
            Console.ForegroundColor = colors.Current;

            Console.Write(c);
          }
          Console.WriteLine();
        }
      }
      else
      {
        Console.ForegroundColor = Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(line);
      }
    }

    public IEnumerable<ConsoleColor> GetNextColour()
    {
      while (true)
      {
        yield return ConsoleColor.Cyan;
        yield return ConsoleColor.Red;
        yield return ConsoleColor.Green;
        yield return ConsoleColor.Yellow;
        yield return ConsoleColor.Magenta;
      }
    }

    private readonly string CarDown = @"

                  _________________
              _.-'_____  _________ _`.
            .` ,'      ||         | `.`.
          .` ,'        ||         |   `.`.
        .`  /          ||         |  ,' ] `....___
      _`__.'''''''''''''''''''''''`''''''''|..___ `-.._
    .'                  [='                '     `'-.._`.
 ,:/.'''''''''''''''''''|''''''''''''''''''|'''''''''''\'\
  //||    _..._         |                  '    _..._  |)|
 /|//   ,',---.`.       |                  |  .',---.`.\>|
(':/   //' .-. `\\      \_________________/  '/' .-. `\\|_)
 `-...'||  '-'  ||________,,,,,,,,,,,,,,,__.'||  '-'  ||-'
       '.'.___.','                           '.'.___.','
         '-.m.-'                               '-.m.-'";
    private readonly string CarUp = @"
                  _________________
              _.-'_____  _________ _`.
            .` ,'      ||         | `.`.
          .` ,'        ||         |   `.`.
        .`  /          ||         |  ,' ] `....___
      _`__.'''''''''''''''''''''''`''''''''|..___ `-.._
    .'                  [='                '     `'-.._`.
 ,:/.'''''''''''''''''''|''''''''''''''''''|'''''''''''\'\
  //||    _..._         |                  '    _..._  |)|
 /|//   ,'     `.       |                  |  .'     `.\>|
(':/   /  ,---.  \      \_________________/  '  ,---.  \|_)
 `-...' /' .-. `\|________,,,,,,,,,,,,,,,__.' /' .-. `\-'
       ||  '-'  |                            ||  '-'  |
       '.'.___.','                           '.'.___.','
         '-.m.-'                               '-.m.-'         ";
  }


}

