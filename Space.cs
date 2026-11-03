/* Space class for modeling spaces (rooms, caves, ...)
SPACE CLASS GIVES NAMES TO SPACES (WHICH ARE NODES)
AND ALSO DISPLAYS LOCATION AND CURRENT EXITS.
 */

class Space : Node {
    private Decision? decision;
    
  public Space (String name) : base(name)
  {
  }

  public void SetDecision(Decision decision){
      this.decision = decision;
  }

  public Decision? GetDecision(){
      return decision;
  }
  
  public void Welcome () {
    Console.WriteLine("Du er nu ved "+name);

    if(decision != null){
        if(decision.IsMade()){
            Console.WriteLine("Beslutningen her er allerede truffet.");
        } else{
            Console.WriteLine(decision.Describe());
        }
    }
    
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
