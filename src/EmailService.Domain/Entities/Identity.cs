namespace EmailService.Domain;

public abstract class Identity
{
    /// <summary>
    /// Уникальный идентификтор
    /// </summary>
    public Guid Id { get; set; }
}
