namespace DesignPatternsApp
{
    public abstract class Project
    {
        // Factory method
        public abstract IProjectManager CreateProject();
    }

    public interface IProjectManager
    {
        void HandleProject();
    }

    // Concrete class for Web projects
    public class WebProject : Project
    {
        public override IProjectManager CreateProject()
        {
            return new WebProjectManager();
            ;
        }
    }

    public class WebProjectManager : IProjectManager
    {
        public void HandleProject()
        {
            WriteLine("Handling a Web project");
        }
    }

    // Concrete class for Mobile projects
    public class MobileProject : Project
    {
        public override IProjectManager CreateProject()
        {
            return new MobileProjectManager();
        }
    }

    public class MobileProjectManager : IProjectManager
    {
        public void HandleProject()
        {
            WriteLine("Handling a Mobile project");
        }
    }
}
