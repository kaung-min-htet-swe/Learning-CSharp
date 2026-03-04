using EFCoreDemo.Shared;

namespace EFCoreDemo.StudentModule;

public class AddressTestDemo
{
    public static async Task<Address?> UpdateAddressTest(AddressService _adderssService)
    {
        var address = await _adderssService.GetById(1);
        address.State = "updated State";
        await _adderssService.Update(address);
        return address;
    }
}