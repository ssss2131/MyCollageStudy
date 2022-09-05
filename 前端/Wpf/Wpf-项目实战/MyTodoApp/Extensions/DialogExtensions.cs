using MyTodoApp.Common.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.Extensions
{
    public static class DialogExtensions
    {
        public static void UpdateLoading(this IEventAggregator aggregator, UpdateModel model)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
        }
        public static void Register(this IEventAggregator aggregator, Action<UpdateModel> action)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(action);
        }
        public static void RegisterMessage(this IEventAggregator aggregator, Action<MessageModel> action,string filterName="Main")
        {
            aggregator.GetEvent<MessageEvent>().Subscribe(action, ThreadOption.PublisherThread, true, (m) => 
            {
                return m.Filter.Equals(filterName);
                });
        }
        public static void SendMessage(this IEventAggregator aggregator,  MessageModel model,string filterName="Main")
        {
            model.Filter = filterName;
            aggregator.GetEvent<MessageEvent>().Publish(model);
        }
    }
}
