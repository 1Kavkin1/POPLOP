namespace QuizApp;

public class TestEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int TimeLimitMinutes { get; set; }

    public List<QuestionEntity> Questions { get; set; } = new();
}

public class QuestionEntity
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;

    public int TestId { get; set; }
    public TestEntity Test { get; set; } = null!;

    public List<AnswerEntity> Answers { get; set; } = new();
}

public class AnswerEntity
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
    public QuestionEntity Question { get; set; } = null!;
}
