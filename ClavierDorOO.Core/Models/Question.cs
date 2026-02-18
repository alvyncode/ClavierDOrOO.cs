using Models.Enums;

namespace Models;

public class Question
{
    // Champs et props
    public int Id { get; set; }
    public string Intitule { get; set; }
    public Theme Theme {get;set;}
    public TypeDeQuestion TypeDeQuestion {get;set;}
    public Options? OptionsProposees {get; set;}
    public string  Reponse { get; set; }
    public string ? Indice { get; set; }

}