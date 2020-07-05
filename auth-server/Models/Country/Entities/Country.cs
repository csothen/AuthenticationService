using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace auth_server.Models.CountryModels
{
    public class Country
    {
        [Key]
        public Guid _cid { get; private set; }
        private string _name;
        private List<State> _states;

        public Country(string name, List<State> states)
        {
            this._cid = new Guid();
            this._name = name;
            this._states = states;
        }

        public Country()
        {
            //Default
        }

    }
}