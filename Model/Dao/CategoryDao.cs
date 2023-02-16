using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao() {
            db= new OnlineShopDbContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x=>x.Status == true).ToList();
        }
        public bool Delete(long id)
        {
            try
            {
                var cate = db.Categories.SingleOrDefault(x => x.ID ==  id);
                db.Categories.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
