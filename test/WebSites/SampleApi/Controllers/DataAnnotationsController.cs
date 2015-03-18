﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc;

namespace SampleApi.Controllers
{
    public class DateAnnotationsController : Controller
    {
        [HttpPost("payments/authorize")]
        [Produces("application/json", Type = typeof(int))]
        public IActionResult Authorize([FromBody]PaymentRequest request)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState);

            throw new NotImplementedException();
        }
    }

    public class PaymentRequest
    {
        [Required]
        public Transaction Transaction { get; set; }

        [Required]
        public CreditCard CreditCard { get; set; }
    }

    public class Transaction
    {
        [Required]
        public decimal Amount { get; set; }

        public string Note { get; set; }
    }

    public class CreditCard
    {
        [Required, RegularExpression("^[3-6]?\\d{12,15}$")]
        public string CardNumber { get; set; }

        [Required, Range(1, 12)]
        public int ExpMonth { get; set; }

        [Required, Range(14, 99)]
        public int ExpYear { get; set; }
    }
}