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
    [RoutePrefix("api/users")]
    public class UserController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<User> _usersRepository;
        private readonly IEntityBaseRepository<Preference> _preferenceRepository;

        public UserController(IEntityBaseRepository<User> usersRepository, 
            IEntityBaseRepository<Preference> preferenceRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork) : base(_errorsRepository, _unitOfWork)
        {
            _usersRepository = usersRepository;
            _preferenceRepository = preferenceRepository;
        }
        
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var users = _usersRepository.GetAll().ToList();

                IEnumerable<UserViewModel> usersVM = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);

                response = request.CreateResponse<IEnumerable<UserViewModel>>(HttpStatusCode.OK, usersVM);

                return response;
            });
        }

        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var user = _usersRepository.GetSingle(id);

                UserViewModel userVM = Mapper.Map<User, UserViewModel>(user);

                response = request.CreateResponse<UserViewModel>(HttpStatusCode.OK, userVM);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Return(HttpRequestMessage request, PreferenceViewModel preference)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var user = _usersRepository.GetSingle(preference.UserId);

                var pref = user.Preferences.Where(w => w.ImageId == preference.ImageId);

                if (pref.Count() > 0)
                {
                    var editPref = pref.FirstOrDefault();
                    editPref.Like = preference.Like;
                    editPref.DateLike = DateTime.Now;

                    _preferenceRepository.Edit(editPref);
                    _unitOfWork.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    var newPref = new Preference
                    {
                        UserId = preference.UserId,
                        ImageId = preference.ImageId,
                        Like = preference.Like,
                        DateLike = DateTime.Now
                    };

                    _preferenceRepository.Add(newPref);
                    _unitOfWork.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
    }
}
