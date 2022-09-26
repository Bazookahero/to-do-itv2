﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_itv2.Models
{
    public class ToDo
    {
        private readonly int id;
        private string description;
        private bool done;
        private Person? assignee;

        public bool Done { get { return done; } }
        public Person Assignee { get { return assignee; } }
        public string Description
        {
            get { return description; }
            set
            {
                if (description.Length < 2)
                {
                    Console.WriteLine("Description can't be shorter than 2 letters");
                }
             description = value;
            }
        }
        public int Id { get { return id; } }
        public ToDo(int id, string description)
        {
            this.id = id;
            this.description = description;   
        }
    }
}
