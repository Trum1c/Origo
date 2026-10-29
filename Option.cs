public class Option {
    private string name;
    private int economyChange;
    private int satisfactionChange;
    private int co2Change;

    public Option (string name, int economyChange, int satisfactionChange, int co2Change) {
        this.name = name;
        this.economyChange = economyChange;
        this.satisfactionChange = satisfactionChange;
        this.co2Change = co2Change;
    }
        public string GetName(){
            return name;
        }
        public int EconomyChange(){
            return economyChange;
        }
        public int SatisfactionChange(){
            return satisfactionChange;
        }
        public int Co2Change(){
            return co2Change;
        }
}
