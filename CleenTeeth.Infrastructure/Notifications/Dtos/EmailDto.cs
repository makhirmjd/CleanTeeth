namespace CleenTeeth.Infrastructure.Notifications.Dtos
{
    public class EmailDto
    {
        public required string Sender { get; set; }
        public required string Receipient { get; set; }
        public required string Subject { get; set; }
        public required string Body { get; set; }

    }
}
