﻿using BusinessLogic.Base;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("sellers")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private ISellerService _sellerService;
        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        [Route("GetAllSellers")]
        public IActionResult GetAllSellers()
        {
            try
            {
                var x = _sellerService.GetAllSellers();
                if (x == null)
                    return NotFound();

                return Ok(_sellerService.GetAllSellers());

            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("GetSellerById")]
        public IActionResult GetSellerById(int sellerId)
        {
            var x = _sellerService.GetSellerById(sellerId);

            try
            {
                if (x == null)
                    return NotFound();

                return Ok(x);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("GetSellersByRating")]
        public IActionResult GetSellersByRating(double rating)
        {
            var x = _sellerService.GetSellersByRating(rating);

            try
            {
                if (x == null)
                    return NotFound();

                return Ok(x);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("AddSeller")]
        public IActionResult AddSeller(Seller seller)
        {
            try
            {
                _sellerService.AddSeller(seller);
                return StatusCode(201);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete] // Bunun yerine HttpPost da kullanılabilir
        [Route("RemoveSellerById")]
        public IActionResult RemoveSellerById(int sellerId)
        {
            try
            {
                Seller s = _sellerService.RemoveSellerById(sellerId);
                return Ok(s);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut] //Bunun yerine HttpPost da kullanılabilir
        [Route("UpdateSeller")]
        public IActionResult UpdateSeller(Seller seller)
        {
            try
            {
                _sellerService.Update(seller);
                return Ok(seller);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
