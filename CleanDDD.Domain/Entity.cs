﻿namespace CleanDDD.Domain;

public abstract class Entity
{
    private List<IDomainEvent> _domainEvents = null!;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;
    protected void AddDomainEvent(IDomainEvent domainEvent)
        => (_domainEvents ??= new List<IDomainEvent>()).Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
