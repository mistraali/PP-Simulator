using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Simulator
{
    internal class Creature
    {
        //fields
        private string _name = "Unknown";
        private int _level = 1;
        //properties
        public string Name { 
            get => _name; 
            init
            {
                int minLength = 3;
                int maxLength = 25;
                _name = value;
                //trimming
                _name = _name.Trim();
                //cutting long names
                if (_name.Length > maxLength)
                {
                    _name = _name.Substring(0, maxLength);
                    _name = _name.Trim();
                }
                //filling short names
                if (_name.Length < minLength)
                {
                    do
                    {
                        _name += '#';
                    } while (_name.Length < minLength);
                }
                //names should start with upper case
                _name = char.ToUpper(_name[0]) + _name.Substring(1);
            } 
        }
        public int Level 
        { 
            get => _level; 
            init
            {
                //fitting into brackets
                _level = value;
                _level = _level < 1 ? 1 : _level;
                _level = _level > 10 ? 10 : _level;
            } 
        }

        public string Info => $"{Name} [{Level}]";

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        public Creature() { }

        //write greeting to console
        public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

        //advance by 1 level
        public void Upgrade()
        {
            if (Level < 10) _level++;
        }
    }
}
