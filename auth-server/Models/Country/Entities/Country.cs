using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace auth_server.Models.CountryModels
{
    public class Country
    {
        [Key]
        public string _name { get; private set; }
        public ICollection<State> states { get; private set; }

        public Country(string name, ICollection<State> p_states)
        {
            this._name = name;
            this.states = p_states;
        }

        public Country()
        {
            //Default
        }

    }
}