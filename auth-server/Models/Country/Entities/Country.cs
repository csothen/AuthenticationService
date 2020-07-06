using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace auth_server.Models.CountryModels
{
    public class Country
    {
        [Key]
        public string _name { get; private set; }
        public ICollection<State> _states { get; private set; }

        public Country(string name, ICollection<State> states)
        {
            this._name = name;
            this._states = states;
        }

        public Country()
        {
            //Default
        }

    }
}