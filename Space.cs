/* Space class for modeling spaces (rooms, caves, ...)
SPACE CLASS GIVES NAMES TO SPACES (WHICH ARE NODES)
AND ALSO DISPLAYS LOCATION AND CURRENT EXITS.
 */

class Space : Node {
  public Space (String name) : base(name)
  {
  }
  
  public void Welcome () {
    Console.WriteLine("Du er nu ved "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Tilgængelige områder:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }
}
