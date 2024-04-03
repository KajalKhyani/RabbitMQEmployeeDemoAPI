namespace RabbitMQEmployeeDemoAPI.RabitMQ
{
    public interface IRabitMQProducer
    {
        public void SendEmployeeMessage<T>(T message);
    }
}
