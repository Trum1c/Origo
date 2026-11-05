/* Context class to hold all context relevant to a session.
 */

class Context {
    private Space current;
    private City city;              // NEW: line added
    private World world;
    private bool done = false;
    
    public Context (Space node, City city, World world) {   // NEW: second parameter
    current = node;
    this.city = city;             // NEW: save it in the field
    this.world = world;
    }
  
  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
      Space next;
      
      try{
          next = current.FollowEdge(direction);
      } catch (KeyNotFoundException) {
          Console.WriteLine("Du er forvirret og går rundt i en cirkel hvor du leder for '"+direction+"'. Til sidst giver du op 😩");
          return;
      }
      current.Goodbye();
      current = next;
      current.Welcome();
    }
    public bool Choose (int number) {
      Decision? decision = current.GetDecision();
  
      if (decision == null) {
        Console.WriteLine("Her er ingen beslutning at træffe.");
        return false;
      }
  
      Option? option = decision.Choose(number);
  
      if (option == null) {
        Console.WriteLine("Det valg kan du ikke træffe. Måske er beslutningen allerede truffet, eller nummeret findes ikke.");
        return false;
      }
  
      city.ApplyOption(option);

      if (city.GetEconomy() < 0) {
        Console.WriteLine("Din by har ingen penge tilbage!");
        Console.WriteLine(city.GetSummary());
        Console.WriteLine(city.GetStatus());
        done = true;
      } else if (world.AllDecisionsMade()) {
        Console.WriteLine("Du har truffet alle beslutninger!");
        Console.WriteLine(city.GetSummary());
        Console.WriteLine(city.GetStatus());
        done = true;
      }
      
      return true;
    }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

