using System.Runtime.Serialization;
using Pokedex.Utils;

namespace Pokedex.Models
{
    [DataContract]
    public class Pokemon
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        private string nome;
        public string Nome //Deixa a primeira leitra em maiuscula
        {    
            get { return Util.FirstCharToUpper(this.nome); }
            set { Nome = this.nome; }
        }

        [DataMember(Name = "height")]
        private double altura;
        public double Altura { get { return this.altura / 10; } set { this.Altura = altura; } }

        [DataMember(Name = "weight")]
        private double peso;
        public double Peso { get { return this.peso / 10; } set { this.Peso = peso; } }

        [DataMember(Name = "types")]
        public PokemonTipo[] Tipos { get; set; }
    }
}
