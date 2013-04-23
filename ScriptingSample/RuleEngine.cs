namespace ScriptingSample
{
    using Roslyn.Scripting;
    using Roslyn.Scripting.CSharp;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class RuleEngine<TContext> where TContext : class
    {
        private ScriptEngine engine;
        private Session session;

        public RuleEngine(TContext context)
        {
            engine = new ScriptEngine();
            DefaultAssemblies.ToList().ForEach(x => engine.AddReference(x));
            DefaultNamespaces.ToList().ForEach(x => engine.ImportNamespace(x));
            engine.AddReference(typeof(TContext).Assembly);
            engine.ImportNamespace(typeof(TContext).Namespace);
            session = engine.CreateSession<TContext>(context);
        }

        public object Execute(string script)
        {
            return session.Execute(script);
        }

        public void ExecuteFile(string path)
        {
            session.ExecuteFile(path);
        }

        private IEnumerable<Assembly> DefaultAssemblies
        {
            get
            {
                yield return typeof(object).Assembly;      // mscorlib.dll
                yield return typeof(System.Uri).Assembly;  // System.dll
                yield return typeof(IQueryable).Assembly;  // System.Core.dll
            }
        }

        private IEnumerable<string> DefaultNamespaces
        {
            get
            {
                yield return "System";
                yield return "System.Linq";
                yield return "System.Collections";
                yield return "System.Collections.Generic";
            }
        }
    }
}