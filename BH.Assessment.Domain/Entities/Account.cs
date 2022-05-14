﻿using BH.Assessment.Domain.Common;

namespace BH.Assessment.Domain.Entities;

public class Account : AuditableEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public AccountType AccountType { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}

public enum AccountType
{
    CurrentAccount
}