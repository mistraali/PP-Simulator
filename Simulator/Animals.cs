using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    internal class Animals
    {
        private string _description = "Unknown";
        private uint size = 3;

        public required string Description
        {
            get => _description;
            init
            {
                int minLength = 3;
                int maxLength = 15;
                _description = value;
                //trimming
                _description = _description.Trim();
                //cutting long descriptions
                if (_description.Length > maxLength)
                {
                    _description = _description.Substring(0, maxLength);
                    _description = _description.Trim();
                }
                //filling short descriptions
                if (_description.Length < minLength)
                {
                    do
                    {
                        _description += '#';
                    } while (_description.Length < minLength);
                }
                //descriptions should start with upper case
                _description = char.ToUpper(_description[0]) + _description.Substring(1);
            }
        }
        public uint Size { get => size; set => size = value; }
        public string Info => $"{Description} <{Size}>";
    }
}
