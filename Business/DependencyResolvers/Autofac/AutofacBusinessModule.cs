using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.ElasticSearchOptions.Abstract;
using Business.ElasticSearchOptions.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RealEstateAdsManager>().As<IRealEstateAdsService>();
            builder.RegisterType<RealEstateAdsDal>().As<IRealEstateAdsDal>();

            builder.RegisterType<ElasticSearchManager>().As<IElasticSearchService>();
            builder.RegisterType<ElasticSearchConfigration>().As<IElasticSearchConfigration>();

            builder.RegisterType<RealEstateCompanyManager>().As<IRealEstateCompanyService>();
            builder.RegisterType<RealEstateCompanyDal>().As<IRealEstateCompanyDal>();
        }
    }
}