using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    [DataContract(Name = "types")]
    public class PokemonTipo
    {
        [DataMember]
        public int Slot { get; set; }

        [DataMember(Name = "type")]
        public Tipo Tipo { get; set; }
    }

    [DataContract(Name = "type", Namespace = "type")]
    public class Tipo
    {
        [DataMember(Name = "name")]
        private string nome;
        public string Nome
        {
            get { return Utils.Util.FirstCharToUpper(this.nome); }
            set { Nome = this.nome; }
        }
    }
}
