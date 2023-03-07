using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> TGetList()
        {
           return _productDal.GetList();
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void TInsert(Product t)
        {
            _productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);

        }

        void IGenericService<Product>.TInsert(Product t)
        {
            throw new NotImplementedException();
        }

        void IGenericService<Product>.TDelete(Product t)
        {
            throw new NotImplementedException();
        }

        void IGenericService<Product>.TUpdate(Product t)
        {
            throw new NotImplementedException();
        }

        List<Product> IGenericService<Product>.GetList()
        {
            throw new NotImplementedException();
        }

        Product IGenericService<Product>.TGetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
