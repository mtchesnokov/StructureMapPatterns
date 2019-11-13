namespace Mt.CodePatterns.Adapter.Interfaces
{
   /// <summary>
   ///    Interface that represents adapter that converts object to another
   /// </summary>
   public interface IAdapter<TSource, TDestination>
      where TDestination : IMapFrom<TSource>
   {
      TDestination Adapt(TSource source);
   }
}