using System;
using Support.Test;

namespace Support.Test.Containers
{
    /// <summary>
    /// Spring implementation of IContainer
    /// On construction all Spring object configuration will be initialized
    /// </summary>
    public class SpringContainer : IContainer
    {
        private readonly IApplicationContext applicationContext = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpringContainer"/> class.
        /// Get the Spring config from the config file
        /// </summary>
        public SpringContainer(): this(ContextRegistry.GetContext())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpringContainer"/> class.
        /// The spring config is provided by a list of context strings
        /// </summary>
        /// <example>
        /// <![CDATA[
        /// var container = new SpringContainer("config://spring/objects",
        ///                                     "assembly://Artilium.Arta.Core.Data/Artilium.Arta.Core.Data/CoreDataAccess.xml");
        /// ]]>
        /// </example>
        /// <param name="configs">The configs.</param>
        public SpringContainer(string[] configs)
        {
            var xmlCtx = new XmlApplicationContext(configs);
            applicationContext = new StaticApplicationContext(xmlCtx);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpringContainer"/> class.
        /// The spring context is provided by a custom IApplicationContext
        /// </summary>
        /// <param name="context">The context.</param>
        public SpringContainer(IApplicationContext context)
        {
            applicationContext = context;
        }


        /// <summary>
        /// Registers the specified implementation for a type.
        /// </summary>
        /// <typeparam name="T">Type to register an implementation for.</typeparam>
        /// <param name="implementationToRegister">The implementation to register.</param>
        public void Register<T>(T implementationToRegister)
        {
            var ctx = applicationContext as AbstractApplicationContext;
            if (ctx == null)
            {
                throw new InvalidOperationException("Register is not supported with this application context");
            }
            ctx.ObjectFactory.RegisterSingleton(typeof(T).Name, implementationToRegister);
        }

        /// <summary>
        /// Registers the specified type and use autowiring for dependency injection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Register<T>()
        {
            var objectFactory = new DefaultObjectDefinitionFactory();
            var objDef = objectFactory.CreateObjectDefinition(typeof(T).FullName, null, AppDomain.CurrentDomain);
            objDef.AutowireMode = AutoWiringMode.AutoDetect;
            var ctx = applicationContext as GenericApplicationContext;
            if (ctx != null)
            {
                // register the object definition base on the type name
                ctx.RegisterObjectDefinition(typeof(T).Name, objDef);
            }
        }

        /// <summary>
        /// Gets the implementation of a type based on its name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public T GetImplementationOf<T>(string name) where T : class
        {
            return applicationContext.GetObject(name, typeof(T)) as T;
        }

        /// <summary>
        /// Gets the implementation of a type.
        /// </summary>
        /// <typeparam name="T">Type to retrieve</typeparam>
        /// <returns>Implementation of a type</returns>
        public T GetImplementationOf<T>() where T : class
        {
            // try to find it by type
            var registeredObjects = applicationContext.GetObjectsOfType(typeof(T));
            if (registeredObjects.Count == 0)
            {
                // try to get if from XMLApplicationContext
                registeredObjects = applicationContext.ParentContext.GetObjectsOfType(typeof(T));
            }
            //if (registeredObjects.Count == 0)
            //{
            //    // try to get the object base on the type name
            //    object obj = applicationContext.GetObject(typeof (T).Name, typeof (T));
            //    if (obj != null)
            //    {
            //        return obj as T;
            //    }
            //}

            // evaluate what we found
            if (registeredObjects.Count > 1)
            {
                throw new Spring.Objects.Factory.UnsatisfiedDependencyException(string.Format("More then one implementation of {0}", typeof(T).Name));
            }

            if (registeredObjects.Count == 0)
            {
                throw new Spring.Objects.Factory.UnsatisfiedDependencyException(string.Format("No implementation of {0}", typeof(T).Name));
            }

            // take first element
            T implementation = null;
            foreach(var entry in registeredObjects.Values)
            {
                implementation = entry as T;
                break;
            }
            return implementation;
        }
    }
}