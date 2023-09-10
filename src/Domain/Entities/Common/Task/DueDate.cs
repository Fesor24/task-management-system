namespace Domain.Entities.Common.Task;
public record DueDate
{
    private static DateTimeOffset _defaultDate = default;

    private DueDate(DateTimeOffset value) => Value = value;

    public DateTimeOffset Value { get; init; }

    public static DueDate Create(DateTimeOffset value)
    {
        if(value == _defaultDate)
        {
            return null;
        }
         
        if(value < DateTimeOffset.UtcNow)
        {
            return null;
        }

        return new DueDate(value);
    }
}
