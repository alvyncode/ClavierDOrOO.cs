using System.Text.Json;
using Data;
using Models;
using Data.Questions;

public class DatabaseSeederService
{
    private readonly ClavierDorDbContext _context;

    public DatabaseSeederService(ClavierDorDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        try 
        {
            string baseDir = AppContext.BaseDirectory;
            string path = Path.Combine(baseDir, "Question.json");
            if (!File.Exists(path)) return;

            var jsonContent = await File.ReadAllTextAsync(path);
            var dtos = JsonSerializer.Deserialize<List<QuestionImportDto>>(jsonContent);

            if (dtos == null) return;

            var questionsToInsert = new List<Question>();
            foreach (var dto in dtos)
            {
                var q = new Question 
                { 
                    Intitule = dto.Intitule,
                    Reponse = dto.Reponse,
                    Indice = dto.Indice,
                    Theme = dto.Theme,
                    TypeDeQuestion = dto.TypeDeQuestion
                };

                if (dto.Options != null)
                {

                    q.OptionsProposees = new Options 
                    {
                       
                        PremiereOption = dto.Options.Option1,
                        DeuxiemeOption = dto.Options.Option2,
                        TroisiemeOption = dto.Options.Option3,
                        QuatrièmeOption = dto.Options.Option4, // Si null dans le JSON, ce sera null en BDD, c'est parfait
                        
                        
                    };
                }

                    questionsToInsert.Add(q);
            }

           
            await _context.Questions.AddRangeAsync(questionsToInsert);
            
           
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            
            
            System.Diagnostics.Debug.WriteLine($"Erreur d'import : {ex.Message}");
            throw;
        }
    }

}