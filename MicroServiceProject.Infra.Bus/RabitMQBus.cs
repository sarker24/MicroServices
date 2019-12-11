using MediatR;
using MicroServiceProject.Domain.Core.Bus;
using MicroServiceProject.Domain.Core.Commands;
using MicroServiceProject.Domain.Core.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceProject.Infra.Bus
{
    public sealed class RabitMQBus : IEventBus
    {
        // create MeiatoR to send command
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers; //Hold our handler our all event
        private readonly List<Type> _eventTypes; // any types of event

        public RabitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public Task SendCommand<T>(T commnd) where T : Command
        {
            return _mediator.Send(commnd);
        }

        public void publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", eventName, null, body);
            }

        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            // If eventtyppe not contain then add in the list
            if(!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if(!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            // If same event name is there then throw exception
            if(_handlers[eventName].Any(s => s.GetType()== handlerType))
            {
                throw new Exception(
                    $"Handler type {handlerType.Name} already register");
            }

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory()
            { HostName = "localhost", DispatchConsumersAsync = true };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(eventName, true, consumer);

        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if(_handlers.ContainsKey(eventName))
            {
                var Subscriptions = _handlers[eventName];

                foreach(var subscription in Subscriptions)
                {
                    var handler = Activator.CreateInstance(subscription);

                    if (handler == null) continue;

                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var @event = JsonConvert.DeserializeObject(message, eventType);
                    var conrcteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    await (Task)conrcteType.GetMethod("Handle").Invoke(handler, new object[] { @event });

                }
            }
        }
    }
}
