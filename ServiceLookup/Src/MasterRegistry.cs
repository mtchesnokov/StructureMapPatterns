using Mt.CodePatterns.ServiceLookup.Interfaces;
using Mt.CodePatterns.ServiceLookup.Services;
using StructureMap;

namespace Mt.CodePatterns.ServiceLookup
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory();
            s.AddAllTypesOf(typeof(IMessage));
            s.AddAllTypesOf(typeof(ICanSendSpecificMessage<>));
         });

         For<ICanSendMessage>().Use<CanSendMessage>();
      }
   }
}