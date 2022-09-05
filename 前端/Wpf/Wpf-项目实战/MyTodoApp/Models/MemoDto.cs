﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.Models
{
    public class MemoDto:BaseDto
    {
        private string title;
        private string content;
 
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

   
    }
}
