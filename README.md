# Include-Map
It can be used with both entity framework's Include and automapper's ProjectTo statement with explicit expansion.

# Sample Usage

      var map = Map.Create<Model>()
                   .Include(m => m.SubModel)
                   .ThenInclude(m => m.LeafModel)
                   .ThenInclude(m => m.ChildModel)
                   .Include(m => m.SubModel)
                   .ThenInclude(m=>m.ChildModel)
                   .Include(m=>m.SubModel)
                   .ThenInclude(m => m.LeafModel);
                         
# Result 

SubModel,<br/>
 SubModel.LeafModel, <br/>
 SubModel.LeafModel.ChildModel, <br/><br/>
SubModel, <br/>
 SubModel.ChildModel, <br/><br/>
SubModel,<br/>
 SubModel.LeafModel<br/>
