using Models.Enums;

namespace Data.Questions;
public class QuestionImportDto
{
    public int Id { get; set; }
    public string Intitule { get; set; } // Exemple
    public Theme Theme { get; set; }
    public TypeDeQuestion TypeDeQuestion { get; set; }
    public OptionsImportDto Options { get; set; }
    public string Reponse { get; set; }
    public string Indice { get; set; }
}

public class OptionsImportDto
{
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; }
    public string Option4 { get; set; }
}
