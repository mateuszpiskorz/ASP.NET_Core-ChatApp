﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class Conversations
    {
        public Conversations()
        {
            Status = messageStatus.Sent;
        }
        public enum messageStatus
        {
            Sent,
            Delivered
        }

        public int Id { get; set; }
        public User Receiver { get; set; }
        public User Sender { get; set; }
        public string Message { get; set; }
        public messageStatus Status { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
