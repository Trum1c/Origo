class Document {
    private string name;
    private string content;

    public Document(string name, string content){
        this.name = name;
        this.content = content;
    }
    
    public string GetContent(){
        return content;
    }

    public string GetName(){
        return name;
    }

    
}