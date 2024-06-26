﻿using Microsoft.AspNetCore.Identity;

using CarRentalPlatform.Domain.Exceptions;
using CarRentalPlatform.Domain.Models.Dealers;


namespace CarRentalPlatform.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        internal User(string email) : base(email)
        {
            this.Email = email;
        }
            

        public Dealer? Dealer { get; private set; }

        public void BecomeDealer(Dealer dealer)
        {
            if (this.Dealer != null)
            {
                throw new InvalidDealerException($"User '{this.UserName}' is already a dealer.");
            }

            this.Dealer = dealer;
        }
    }
}
