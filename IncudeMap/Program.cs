using System;
using System.Collections.Generic;
using System.Linq;

namespace IncudeMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = Map.Create<Model>()
                         .Include(m => m.SubModel)
                         .ThenInclude(m => m.LeafModel)
                         .ThenInclude(m => m.ChildModel)
                         .Include(m => m.SubModel)
                         .ThenInclude(m=>m.ChildModel)
                         .Include(m=>m.SubModel)
                         .ThenInclude(m => m.LeafModel);


            Console.Write(string.Join(", ", map.propMap.ToArray().Reverse()));
            Console.ReadLine();
        }
    }

    public class Model
    {
        public SubModel SubModel { get; set; }
    }
    public class SubModel
    {
        public IList<LeafModel> LeafModel { get; set; }
        public ChildModel ChildModel { get; set; }
    }
    public class LeafModel
    {
        public ChildModel ChildModel { get; set; }
    }
    public class ChildModel
    {
    }
}
