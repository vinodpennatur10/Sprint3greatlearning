using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    public class ProjectRepository : BaseRepository<ProjectModel>, IProjectRepository
    {
        List<ProjectModel> lstProjectModel = new List<ProjectModel>();

        private readonly Context _context;
        public ProjectRepository()
        { }
        public ProjectRepository(Context context) : base(context)
        {
            _context = context;


        }

        public void createproject(ProjectModel objProjectModel)
        {
            if (_context.Projects.Count() == 0)
            {
                _context.Projects.Add(new ProjectModel
                {
                   CreatedOn=objProjectModel.CreatedOn,
                   Detail=objProjectModel.Detail,
                   Id=objProjectModel.Id,
                   Name=objProjectModel.Name
                });
            }
            _context.SaveChanges();

            lstProjectModel.Add(objProjectModel);
        }

        public  List<ProjectModel> Getallproject()
        {

            
 

            return lstProjectModel;

        }

        public ProjectModel Getaproject(int id)
        {
            var result = lstProjectModel.Find(x => x.Id == id);


            return result;

        }

        public string Updateproject(ProjectModel ProjectModel)
        {
          

            var result = lstProjectModel.Find(x => x.Id == ProjectModel.Id);
            lstProjectModel.RemoveAll(x => x.Id == ProjectModel.Id);
            lstProjectModel.Add(ProjectModel);
            //   UserModels.Remove(x => x.id == UserModel.Id);
            string returnresult;
            if (result == null)
            {
                returnresult = "failed";
            }
            else
            {
                returnresult = "success";
            }
            return returnresult;
        }
    }
}