using EFCore;
using EFCore.DataAccess;

var ctx = new EfcoreContext();
var departmentService = new DepartmentService(ctx);
var studentService = new StudentService(ctx);
var courseService = new CourseService(ctx);

// var department = departmentService.RetrieveById(1, true);
// Utils.PrintDepartment(department, true);
//
// var student = studentService.RetrieveById(1, true);
// Utils.PrintStudent(student, true);

// var course = courseService.RetrieveById(1, true);
// Utils.PrintCourse(course, true);


// var Engineering = new Department()
// {
//     DepartmentName = "Engineering",
// };
//
// departmentService.Create(Engineering);
// studentService.RegisterCourse(1, 2);
//
// var student = courseService.RetrieveByStudentId(1);
// foreach (var course in student.Courses)
// {
//     Utils.PrintCourse(course);
// }

var course = courseService.RetrieveById(1, true);
Utils.PrintCourse(course, true);

// var engineering = new Course()
// {
//     CourseName = "Engineering"
// };
//
// courseService.Create(engineering);
//
// var courses = courseService.RetrieveList();
// foreach (var course in courses)
// {
//     Utils.PrintCourse(course, false);
// }

// studentService.UnRegisterCourse(1, 2);
// var student = courseService.RetrieveByStudentId(1);
// foreach (var course in student.Courses)
// {
//     Utils.PrintCourse(course);
// }

