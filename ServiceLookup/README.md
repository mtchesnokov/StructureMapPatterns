# Object Extender

## Problem
Imagine we have code that we have build upon an object type (say Person). Each person has unique `Id`attribute and we can get all persons or find one 
by its `Id`. Imagine now that we no have 'external' objects (say coming from external REST api) that do not have this attribute. But it would be very 
desirable to re-use the existing infra to provide the same level of services that we have for the own class. An posibble solution will be to 'extend' the 
third party class by 'attaching' the missing column. In this demo we will show how to do that. 

## Existing code

```csharp
public class OwnPerson : IHaveId<int>
{
   public int Id { get; set; }

   public string Name { get; set; }
}

public interface IDataObjectProviderExt<TObjectId, TObject>
{
   IEnumerable<TObject> GetAll();

   TObject GetById(TObjectId id);
}

IDataObjectProviderExt<int, OwnPerson> provider = container.GetInstance<IDataObjectProviderExt<int, OwnPerson>>();
int objectId = 1;
OwnPerson obj = provider.GetById(objectId);
```

## External class

```csharp
public class ThirdPartyPerson
{
   public int PersonNo { get; set; }

   public string Name { get; set; }
}
```

## Extending external class

We can extend externl class by creating own class that implements `IKnowObjectId` interface

```csharp
public class ThirdPartyPersonExtender : IKnowObjectId<ThirdPartyPerson, int>
{
   public int GetId(ThirdPartyPerson obj)
   {
      return obj.PersonNo;
   }
}
```

## Using external objects in own pipeline

Now external class can also be used in other services that assume that the clas has `Id' attibute.

```csharp
IDataObjectProviderExt<int, ThirdPartyPerson> provider = container.GetInstance<IDataObjectProviderExt<int, ThirdPartyPerson>>();
int objectId = 1;
ThirdPartyPerson obj = provider.GetById(objectId);
```
