using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreBank3169_0.Models.ContextClasses;
using NetCoreBank3169_0.Models.Entities;
using NetCoreBank3169_0.RequestModels;

namespace NetCoreBank3169_0.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        MyContext _db;

        public TransactionController(MyContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> StartTransaction(PaymentRequestModel item)
        {
            if(_db.CardInfoes.Any(x => x.CardNumber == item.CardNumber && x.CVC == item.CVC && x.CardUserName == item.CardUserName)) //kart bilgileri tutuyorsa ( Aslında burada daha ayrıntılı bir kontrol yapılır)
            {
                UserCardInfo uCInfo = await _db.CardInfoes.SingleOrDefaultAsync(x => x.CardNumber == item.CardNumber && x.CVC == item.CVC && x.CardUserName == item.CardUserName); // kartı bulup bir degişkene atıyoruz...

                if (uCInfo.Balance >= item.ShoppingPrice)
                {
                    uCInfo.Balance -= item.ShoppingPrice; //Fiyat, kartın balance'indan düsüyor
                    await _db.SaveChangesAsync();

                    return Ok("Odeme basarıyla alındı");
                }
                else return StatusCode(400, "Kart bakiyesi yetersiz bulundu");

            }

            return StatusCode(400, "Kart bulunamadı");
        }
    }
}
