using EFCore;
using EFCore.DataAccess;

var ctx = new EfcoreContext();
var departmentService = new DepartmentService(ctx);
var studentService = new StudentService(ctx);

var department = departmentService.RetrieveById(1, true);
Utils.PrintDepartment(department, true);

var student = studentService.RetrieveById(1, true);
Utils.PrintStudent(student, true);