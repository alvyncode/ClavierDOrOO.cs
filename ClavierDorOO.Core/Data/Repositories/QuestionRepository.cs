using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
namespace Data.Repositories;
public class QuestionRepository
{
    private ClavierDorDbContext _context;
    public QuestionRepository()
    {
        var ConnexionString = "server=localhost;user=root;password=;database=clavier_dor_oo_db";
        var optionsBuilder = new DbContextOptionsBuilder<ClavierDorDbContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
        optionsBuilder.UseMySql(ConnexionString, serverVersion);

        _context = new ClavierDorDbContext(optionsBuilder.Options);
    }
    public List<Question> RecupererQuestionTheme(Theme theme)
    {
        return _context.Questions.Where( q => q.Theme == theme).Include(q=>q.OptionsProposees).ToList();
    }
}
