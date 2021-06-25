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
        [Required(ErrorMessage = "Mã sách không ???c ?? tr?ng")]
        [Display(Name = "Mã sách")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tiêu ?? không ???c ?? tr?ng")]
        [StringLength(100, ErrorMessage = "Tiêu ?? sách không ???c v??t quá 30 ký t?")]
        [Display(Name = "Tiêu ??")]
        public string Title { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Miêu t? không ???c ?? tr?ng")]
        [Display(Name = "Miêu t?")]
        public string Description { get; set; }



        [Required(ErrorMessage = "Tác gi? không ???c ?? tr?ng")]
        [StringLength(30, ErrorMessage = "Tác gi? sách không ???c v??t quá 30 ký t?")]
        [Display(Name = "Tác gi?")]
        public string Author { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Hình ?nh không ???c ?? tr?ng")]
        [Display(Name = "Hình ?nh")]
        public string Images { get; set; }

        [Required(ErrorMessage = "Giá sách không ???c ?? tr?ng")]
        [Range(1000, 1000000, ErrorMessage = "Giá sách t? 1000 - 1.000.000")]
        [Display(Name = "Giá sách")]
        public int Price { get; set; }
    }
}
