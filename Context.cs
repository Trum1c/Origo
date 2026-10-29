/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  bool done = false;
  
  public Context (Space node) {
    current = node;
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
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

