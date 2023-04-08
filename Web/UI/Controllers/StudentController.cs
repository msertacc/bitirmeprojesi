using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Student;

namespace UI.Controllers
{
	public class StudentController:Controller
	{
		//private readonly IStudentService studentService;
		//private readonly IMapper mapper;
		//public StudentController(IStudentService studentService, IMapper mapper)
		//{
		//	this.studentService = studentService;
		//	this.mapper = mapper;
		//}

		//public ActionResult Index()
		//{
		//	var response = studentService.GetStudents();
		//	var mappingResult = this.mapper.Map<List<StudentDto>, List<StudentViewModel>>(response);
		//	return View(mappingResult);
		//}

		//public ActionResult _Create()
		//{
		//	var viewModel = new StudentViewModel();
		//	return PartialView(viewModel);
		//}

		//public ActionResult Create(StudentViewModel viewModel)
		//{
		//	var mappingResult = this.mapper.Map<StudentViewModel, StudentDto>(viewModel);
		//	studentService.Create(mappingResult);
		//	return this.Redirect(Url.Action("Index"));
		//}
	}
}
