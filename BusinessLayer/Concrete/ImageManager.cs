using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void Add(Image t)
        {
            _imageDal.Add(t);
        }

        public void Delete(Image t)
        {
            _imageDal.Delete(t);
        }

        public List<Image> GetAll()
        {
            return _imageDal.GetAll();
        }

        public Image GetById(int id)
        {
            return _imageDal.GetById(id);
        }

        public void Update(Image t)
        {
            _imageDal.Update(t);
        }
    }
}
