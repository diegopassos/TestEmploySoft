using AutoMapper;
using Like.Data.Infrastructure;
using Like.Data.Repositories;
using Like.Entities;
using Like.Web.Infrastructure.Core;
using Like.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Like.Web.Controllers
{
    [RoutePrefix("api/images")]
    public class ImageController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Image> _imagesRepository;
        public ImageController(IEntityBaseRepository<Image> imagesRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork) : base(_errorsRepository, _unitOfWork)
        {
            _imagesRepository = imagesRepository;
        }
        
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var images = _imagesRepository.GetAll().ToList();

                IEnumerable<ImageViewModel> imagesVM = Mapper.Map<IEnumerable<Image>, IEnumerable<ImageViewModel>>(images);

                response = request.CreateResponse<IEnumerable<ImageViewModel>>(HttpStatusCode.OK, imagesVM);

                return response;
            });
        }

        [Route("random/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var image = _imagesRepository.GetAll().OrderBy(o => Guid.NewGuid()).Take(1).FirstOrDefault();

                ImageViewModel imageVM = Mapper.Map<Image, ImageViewModel>(image);

                response = request.CreateResponse<ImageViewModel>(HttpStatusCode.OK, imageVM);

                return response;
            });
        }
    }
}
