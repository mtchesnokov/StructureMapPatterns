using System;
using System.Collections.Generic;
using Mt.CodePatterns.ObjectQueries.Domain.Helpers;

namespace Mt.CodePatterns.ObjectQueries.Interfaces.Helpers
{
   /// <summary>
   ///    This interface represent help service to looks for registered in container object query types
   /// </summary>
   internal interface IQueryDescriptorProvider
   {
      IEnumerable<QueryDescriptor> GetQueryDescriptors<TObject>(params Type[] queryTypes);
   }
}