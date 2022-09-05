﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.Models
{
    /// <summary>
    /// 代办实体
    /// </summary>
    public class TodoDto:BaseDto
    {
        private string title;
        private string content;
        private int status;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Content 
        {
            get { return content; }
            set { content = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
