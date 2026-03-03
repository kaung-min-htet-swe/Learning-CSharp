using EFCoreDemo.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace EFCoreDemo.StudentModule;

public class StudentModule
{
    public static async Task Run(CompanyContext ctx)
    {
        try
        {
            var addressService = new AddressService(ctx);
            var studentService = new StudentService(ctx, addressService);

            var home1 = new Address()
            {
                AddreLine = "Address Line 1",
                State = "State 1",
                Township = "Township 1",
            };

            var student = await studentService.UpdateAddress(3, home1);
            Ulits.PrintStudent(student!);
        }
        catch (Exception e)
        {
            Console.Write("In exception.");
            Console.WriteLine(e.StackTrace);
        }
    }
}