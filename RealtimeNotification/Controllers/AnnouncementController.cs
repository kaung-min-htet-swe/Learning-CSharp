using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealtimeNotification.Hubs;

namespace RealtimeNotification.Controllers;

public class AnnouncementController(IHubContext<NotificationHub> hub):Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Send(AnnouncementRequestModel req)
    {
        Console.WriteLine($"req {req.Title} {req.Content}");
        await hub.Clients.All.SendAsync("ReceiveAnnouncement", req.Title, req.Content);
        return RedirectToAction("Index");
    }
}

public class AnnouncementRequestModel
{
    public string Title { get; set; }
    public string Content { get; set; }
}