using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proto_API_Yugi.Clients.Interface;
using Proto_API_Yugi.Models.Implementation;
using Proto_API_Yugi.Services;

namespace Proto_API_Yugi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YugiController  : ControllerBase
    {
        private readonly IYgoproDeckClient _iYgoproDeckClient;
        private readonly IServiceClient _serviceClient;
        private readonly YugiService _yugiService;
        public YugiController(IYgoproDeckClient iYgoproDeckClient, 
        YugiService yugiService,
        IServiceClient serviceClient)
        {
            _iYgoproDeckClient = iYgoproDeckClient;
            _yugiService = yugiService;
            _serviceClient = serviceClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string id ="71625222";
            var inStorage = _yugiService.Find(id);
            if(inStorage == null)
            {
                var responseCard =  await _iYgoproDeckClient.GetCardByIdAsync("").ConfigureAwait(false);
                if(responseCard != null)
                {
                    var card = responseCard.data.FirstOrDefault();
                    var image = await _serviceClient.GetImageCardByUrlAsync(
                        card.card_images.FirstOrDefault().image_url).ConfigureAwait(false);
                    
                    card.card_images.FirstOrDefault().image = image;

                    _yugiService.Create(responseCard.data.FirstOrDefault());

                    inStorage = _yugiService.Find(id);

                    return StatusCode((int)HttpStatusCode.OK, inStorage);
                }
                return StatusCode((int)HttpStatusCode.NotFound, "Not found");
            }
            return StatusCode((int)HttpStatusCode.OK, inStorage);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            string id ="71625222";
            _yugiService.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}