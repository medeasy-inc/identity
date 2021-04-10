﻿using MedEasy.Objects;

using NodaTime;

using System;

namespace Identity.Objects
{
    /// <summary>
    /// Associate a <see cref="Claim"/> to a <see cref="Account"/> for a period of time.
    /// </summary>
    /// <remarks>
    /// This association takes precedence over a <see cref="RoleClaim"/> association for a given <see cref="Claim"/>.
    /// </remarks>
    public class AccountClaim : Entity<Guid, AccountClaim>
    {
        public Guid AccountId { get;  }

        public Claim Claim { get; private set; }

        /// <summary>
        /// When the claim is active for the user
        /// </summary>
        public Instant Start { get; private set; }

        /// <summary>
        /// When will the claim ends
        /// </summary>
        public Instant? End { get; }

        private AccountClaim(Guid accountId, Guid id) : base(id)
        {
            AccountId = accountId;
        }

        public AccountClaim(Guid accountId, Guid id, string type, string value, Instant start, Instant? end) : this (accountId, id)
        {
            AccountId = accountId;
            Claim = new Claim(type, value);
            Start = start;
            End = end;
        }

        /// <summary>
        /// Changes the value of the claim  
        /// </summary>
        /// <param name="newValue"></param>
        public void ChangeValueTo(string newValue) => Claim.ChangeValueTo(newValue);
    }
}
