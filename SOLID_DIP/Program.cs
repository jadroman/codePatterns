using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// SOLID - Dependency inversion principle:
/// States that high-level modules/classes should not depend on low-level modules/classes. 
/// Both should depend upon abstractions. Secondly, abstractions should not depend upon details. 
/// Details should depend upon abstractions.
/// </summary>
namespace SOLID_DIP
{   

    class Program
    {
        /// <summary>
        /// We create this interface so our high and low level classes are depend on abstractions and not on each others. 
        /// </summary>
        public interface IMessage
        {
            void SendMessage();
        }

        /// <summary>
        /// low level class
        /// </summary>
        public class Email : IMessage
        {
            public string ToAddress { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
            public void SendMessage()
            {
                //Send email
            }
        }

        /// <summary>
        /// low level class
        /// </summary>
        public class SMS : IMessage
        {
            public string PhoneNumber { get; set; }
            public string Message { get; set; }
            public void SendMessage()
            {
                //Send sms
            }
        }

        /// <summary>
        /// high level class
        /// </summary>
        public class Notification
        {
            private ICollection<IMessage> _messages;

            public Notification(ICollection<IMessage> messages)
            {
                this._messages = messages;
            }
            public void Send()
            {
                foreach (var message in _messages)
                {
                    message.SendMessage();
                }
            }
        }


        static void Main(string[] args)
        {

        }
    }
}
