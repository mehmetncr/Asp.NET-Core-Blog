using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogImage { get; set; }
        public string BlogThumbnailImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public string BlogTags { get; set; }


        // kategori tablosuna bağlamak için gerekenler
        //bir blog sadece bir kategoriye ait olabilir
        public int CategoryID { get; set; }
        public Category Category { get; set; }



        //yorumlar tablosuna bağlanmak için gerekenler
        //bir blog birden fazla yoruma sahip olabilir
        public List<Comment> Comments { get; set; }
    }
}
