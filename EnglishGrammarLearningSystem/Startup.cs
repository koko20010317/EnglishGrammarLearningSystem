using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnglishGrammarLearningSystem.Startup))]
namespace EnglishGrammarLearningSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
