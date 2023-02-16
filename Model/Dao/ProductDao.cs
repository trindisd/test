using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public  class ProductDao
    {
        OnlineShopDbContext db= null;
        public ProductDao() {
            db= new OnlineShopDbContext();
        }
        public IEnumerable<Product> ListAllProductPaging(int page = 1, int pageSize = 5)

        {
            IQueryable<Product> model = db.Products;
           
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Product Detail(string metatitle) 
        {
            return db.Products.Where(x=>x.MetaTitle == metatitle).FirstOrDefault();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Where(x=>x.ID== id).FirstOrDefault();
        }
        public List<Product> ListProductArrivels()
        {
            return db.Products.ToList();
        }
    }
}
