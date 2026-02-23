using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("Picture")]
    public class PictureEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureId { get; set; }
        public byte[] PicturePictureBinary { get; set; }
        public string PictureMimeType { get; set; }
        public string PictureSeoFilename { get; set; }
        public string PictureAltAttribute { get; set; }
        public string PictureTitleAttribute { get; set; }
        public bool PictureIsNew { get; set; }
        public string PictureFilename { get; set; }
    
    }
}
