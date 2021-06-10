using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTDCore.Models
{
    public class Card
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [ConcurrencyCheck]
        public string Designation { get; set; }
        [Required]
        [ConcurrencyCheck]
        public string Name { get; set; }
        [Required]
        [ConcurrencyCheck]
        public DateTime DateOfRegistration { get; set; }
        [Required]
        [ConcurrencyCheck]
        public int A0 { get; set; }
        [Required]
        [ConcurrencyCheck]
        public int A1 { get; set; }
        [Required]
        [ConcurrencyCheck]
        public int A2 { get; set; }
        [Required]
        [ConcurrencyCheck]
        public int A3 { get; set; }
        [Required]
        [ConcurrencyCheck]
        public int A4 { get; set; }
        [NotMapped]
        private int numberOfSheets;
        [Required]
        [ConcurrencyCheck]
        public int NumberOfSheets
        {
            get { return numberOfSheets; }
            private set { numberOfSheets = A0 + A1 + A2 + A3 + A4; }
        }
        [Required]
        [ConcurrencyCheck]
        [ForeignKey("TypeOfDocument")]
        public int TypeId { get; set; }
        public TypeOfDocument TypeOfDocument { get; set; }
        [Required]
        [ConcurrencyCheck]
        public DateTime DateOfChanges { get; set; }
        [Required]
        [ConcurrencyCheck]
        public bool IsCanceled { get; set; }
        [Required]
        [ConcurrencyCheck]
        public bool IsTemporary { get; set; }
        public string Note { get; set; }
    }
}
