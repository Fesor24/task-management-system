namespace Domain.Entities.Common.Task;
public record DueDate
{
    private static DateTime _defaultDate = default;

    private DueDate(DateTime value) => Value = value;

    public DateTime Value { get; init; }

    public static DueDate Create(DateTime value)
    {
        if(value == _defaultDate)
        {
            return null;
        }
         
        if(value < DateTime.UtcNow)
        {
            return null;
        }

        return new DueDate(value);
    }
}
