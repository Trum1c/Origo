/* Main class for launching the game
THE FRONT END THAT ALLOWS INPUTS THAT CONNECTS TO THE BACKEND
MEANING, USER WRITES SOMETHING AND CODE RUNS OFF OF IT.

 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static City     city     = new City(50,50,50);
  static void Main (string[] args) {
    Console.WriteLine("Velkommen til borgmesterens by!");
    
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line==null) continue;
      
      // parse line
      string[] elements = line.Split(" ");
      string command = elements[0];
      string[] parameters = GetParameters(elements);
      
      switch (command) {
        case "stop":
        case "udgang":
        case "farvel":
          context.MakeDone();
          break;
        case "status":
          Console.WriteLine(city.GetStatus());
          break;
        case "gå":
          if (parameters.Length!=1) {
            Console.WriteLine("Jeg ved ikke hvor det ligger for søren 🤔");
            continue;
          }
          context.Transition(parameters[0]);
          break;
        case "hjælp":
          Console.WriteLine(" - stop     Stop spillet");
          Console.WriteLine(" - udgang   Stop spillet");
          Console.WriteLine(" - farvel   Stop spillet");
          Console.WriteLine(" - gå       Gå til et område");
          Console.WriteLine(" - hjælp    Viser disse beskeder");
          Console.WriteLine(" - status   Viser byens status");
          break;
        default:
          Console.WriteLine("Hovsa! Jeg forstår ikke '"+command+"' 😕");
          break;
      }
    }
    Console.WriteLine("Øv bøv, game over 😥");
  }
  
  private static string[] GetParameters (string[] input) {
    string[] output = new string[input.Length-1];
    for (int i=0 ; i<output.Length ; i++) {
      output[i] = input[i+1];
    }
    return output;
  }
}
