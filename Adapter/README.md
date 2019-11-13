# Adapter

## Problem
Imagine we have the following problem: we have to be able to convert object of one type to object of another type. Say, data object coming from database 
to object that is OK to shown on the screen (view model). We may want to use one of the mapping frameworks available on the market (e.g. AutoMapper) to minimize development 
effort. However we may encounter some situations where custom code is needed during convesion. 

So our requirements are as follows: 
- Using popular mapping framework (e.g., AutoMapper) for most cases
- It should be possible to provide custom mapping logic where neccessary
- Whether custom of default mapping is used should be transparent to the code 'above' the call stack
- We may also want to provide general collection adapter that will automatically use the 'right' adapter to convert collections

## Solution
We create interface that represents adapter and provide default implementation. We will use default lookup behavior of the DI container to decide which version of the 
adapter to use in a specific use case. The general rule of thumb here that concrete impelementation will take precedence over its open generic code counterpart. 

## Usage example

```csharp
public class SourceObject
{
}

public class DestinationObject
{
}

public interface IAdapter<TSource, TDestination>
{
   TDestination Adapt(TSource source);
}
   
private static void Main(string[] args)
{   
   ...
   var adapter = container.GetInstance<IAdapter<TSource, TDestination>>();
   var source = new SourceObject();
   var destination = adapter.Adapt(source);
   ...
}
   
```