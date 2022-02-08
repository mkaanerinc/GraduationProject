using Autofac;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<InstallmentOptionManager>().As<IInstallmentOptionService>().SingleInstance();
            builder.RegisterType<EFInstallmentOptionDal>().As<IInstallmentOptionDal>().SingleInstance();

            builder.RegisterType<InsuredPersonManager>().As<IInsuredPersonService>().SingleInstance();
            builder.RegisterType<EFInsuredPersonDal>().As<IInsuredPersonDal>().SingleInstance();

            builder.RegisterType<InsuredPersonRelationshipManager>().As<IInsuredPersonRelationshipService>().SingleInstance();
            builder.RegisterType<EFInsuredPersonRelationshipDal>().As<IInsuredPersonRelationshipDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EFOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<PaymentMethodManager>().As<IPaymentMethodService>().SingleInstance();
            builder.RegisterType<EFPaymentMethodDal>().As<IPaymentMethodDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
