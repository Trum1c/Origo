/* Context class to hold all context relevant to a session.
 */

class Context {
    private Space current;
    private City city;              // NEW: line added
    private bool done = false;
    
    public Context (Space node, City city) {   // NEW: second parameter
    current = node;
    this.city = city;             // NEW: save it in the field
    }
  
  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
      Space next;
      
      try{
          next = current.FollowEdge(direction);
      } catch (KeyNotFoundException) {
          Console.WriteLine("Du er forvirret og går rundt i en cirkel hvor du ledder for '"+direction+"'. Til sidst giver du op 😩");
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
      return true;
    }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

