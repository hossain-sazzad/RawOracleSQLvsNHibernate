using System;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace NhibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadNHibernateCfg();
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            //log4net.Config.XmlConfigurator.Configure();
            
            Queries query = new Queries();
            query.Query();

        }

        public static void LoadNHibernateCfg()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Program).Assembly);
            SchemaExport schemaExport = new SchemaExport(cfg);
            schemaExport.SetDelimiter(";");
            schemaExport.Execute(true, false,false);
      
        }

    }
}
