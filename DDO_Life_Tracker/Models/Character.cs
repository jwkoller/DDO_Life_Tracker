﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public class Character : IDDOCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Incarnation> IncarnationHistory 
        {
            get
            {
                return _incarnationHistory.OrderByDescending(x => x.Id).AsEnumerable();
            } 
        }
        public DateTime CreateDate { get; set; }

        private List<Incarnation> _incarnationHistory;

        public Character(string name, DateTime created, IEnumerable<Incarnation> incarnationHistory, int id) : this(name, created)
        {
            Id = id;
            AddIncarnations(incarnationHistory);
        }

        public Character(string name) : this(name, DateTime.Now) { }

        public Character(string name, DateTime created)
        {
            CreateDate = created;
            Name = name;
            _incarnationHistory = new List<Incarnation>();
        }
        public void AddIncarnation(Incarnation incarnation)
        {
            _incarnationHistory.Add(incarnation);
        }

        public void AddIncarnations(IEnumerable<Incarnation> incarnations)
        {
            foreach(Incarnation inc in  incarnations)
            {
                AddIncarnation(inc);
            }
        }
    }
}