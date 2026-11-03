/*
Decision class represents a question the player must answer.
Each object contains a question and a list of options the player must choose.
When the player answers the question. the chosen attribute is set to the answer.
*/

class Decision{
    private string question;
    private List<Option> options = new List<Option>();
    private Option? chosen;

    public Decision(string question){
        this.question = question;
    }

    public void AddOption(Option option){
        this.options.Add(option);
    }

    // Returns the question and options to choose from.
    public string Describe(){
        string allOptions = "";
        int optionNumber = 1;

        // build the string by looping through each option and adding them.
        foreach(Option option in options){
            allOptions += "\n"+optionNumber+". "+option.GetName()+"\n";
            allOptions += "Økonomi: "+option.GetEconomyChange()+"\n";
            allOptions += "Tilfredshed: "+option.GetSatisfactionChange()+"\n";
            allOptions += "CO2: "+option.GetCo2Change()+"\n";

            optionNumber++;
        }
        return this.question+"\n"+allOptions;
    }

    public Option? Choose(int number){
        // Remember to check in Game.cs if this returns null.
        // null = already answered question or invalid option.
        if(chosen != null){
            return null; // checks if the question has already been answered.
        }
        int index = number - 1;
        if(index < 0 || index >= options.Count){
            return null; // checks if the option chosen is actually an option.
        }
        
        this.chosen = options[index];
        return chosen;
    }

    public bool IsMade(){
        return chosen != null;
    }
}