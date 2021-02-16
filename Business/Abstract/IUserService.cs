using Core.Results.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();

        IDataResult<List<User>> GetUsersById(int id);
        IDataResult<List<UserDetailDto>> GetUserDetails();
    }
}
