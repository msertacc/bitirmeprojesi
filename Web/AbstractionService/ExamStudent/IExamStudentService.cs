﻿using Entity.Dto.ExamUser;

namespace Abstraction.Service.ExamUser
{
	public interface IExamUserService
	{
		List<ExamUserDto> GetExamByUser(string user);

        //ExamUserDto GetExamUserById(int id);

		//Task Create(ExamUserDto userDto);

		//Task Update(ExamUserDto userDto);

		//Task Delete(int id);
	}
}
