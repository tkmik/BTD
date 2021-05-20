using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual ICollection<Card> Karts { get; set; }
        public TypeOfDocument()
        {
            Karts = new List<Card>();
        }
    }
}
