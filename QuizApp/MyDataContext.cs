using Microsoft.EntityFrameworkCore;

namespace QuizApp;

public class MyDataContext : DbContext
{
    public DbSet<TestEntity> Tests { get; set; } = null!;
    public DbSet<QuestionEntity> Questions { get; set; } = null!;
    public DbSet<AnswerEntity> Answers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=quiz.db");
    }
}
