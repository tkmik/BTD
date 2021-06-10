using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTDCore.Models
{
    public enum TypeOfDocumentEnum
    {
        Technical = 1,
        Design
    }
    public class TypeOfDocument
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
        public TypeOfDocument()
        {
            Cards = new List<Card>();
        }
    }
}
