using System.Collections.Generic;

namespace WebApplication1
{ 
    public interface IProjectRepository
    {
    List<ProjectModel> Getallproject();
        void createproject(ProjectModel ProjectModel);
        string Updateproject(ProjectModel ProjectModel);
        ProjectModel Getaproject(int id);

}
}