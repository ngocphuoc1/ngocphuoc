namespace Web_BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "M� s�ch kh�ng ???c ?? tr?ng")]
        [Display(Name = "M� s�ch")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Ti�u ?? kh�ng ???c ?? tr?ng")]
        [StringLength(100, ErrorMessage = "Ti�u ?? s�ch kh�ng ???c v??t qu� 30 k� t?")]
        [Display(Name = "Ti�u ??")]
        public string Title { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Mi�u t? kh�ng ???c ?? tr?ng")]
        [Display(Name = "Mi�u t?")]
        public string Description { get; set; }



        [Required(ErrorMessage = "T�c gi? kh�ng ???c ?? tr?ng")]
        [StringLength(30, ErrorMessage = "T�c gi? s�ch kh�ng ???c v??t qu� 30 k� t?")]
        [Display(Name = "T�c gi?")]
        public string Author { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "H�nh ?nh kh�ng ???c ?? tr?ng")]
        [Display(Name = "H�nh ?nh")]
        public string Images { get; set; }

        [Required(ErrorMessage = "Gi� s�ch kh�ng ???c ?? tr?ng")]
        [Range(1000, 1000000, ErrorMessage = "Gi� s�ch t? 1000 - 1.000.000")]
        [Display(Name = "Gi� s�ch")]
        public int Price { get; set; }
    }
}
