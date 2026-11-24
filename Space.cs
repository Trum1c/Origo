/* Space class for modeling spaces (rooms, caves, ...)
SPACE CLASS GIVES NAMES TO SPACES (WHICH ARE NODES)
AND ALSO DISPLAYS LOCATION AND CURRENT EXITS.
 */

class Space : Node {
    private Decision? decision;
    private string description;
    private Document? document;
    private string art;
    
    public Space (String name, String description, string art) : base(name)
    {
      this.description = description;
      this.art = art;
    }

  public void SetDecision(Decision decision){
      this.decision = decision;
  }

  public Decision? GetDecision(){
      return decision;
  }

  public void SetDocument(Document? document){
      this.document = document;
  }

  public Document? GetDocument(){
      return document;
  }

  public void SetArt(string art){
      this.art = art;
  }
  
  public void Welcome () {
    Console.WriteLine("Du er nu ved "+name);
    Console.WriteLine(art);

    if(GetDocument() != null){
        Console.WriteLine("Der findes en dokument i denne lokation (psst skriv 'tag')");
    } else {
        Console.WriteLine("Der findes ingen dokumenter her....");
    }

    Console.WriteLine(description);
    
    if(decision != null){
        if(decision.IsMade()){
            Console.WriteLine("Beslutningen her er allerede truffet.");
        } else{
            Console.WriteLine(decision.Describe());
        }
    }
    
 PrintLocation();   

  }
public void PrintLocation(){
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
